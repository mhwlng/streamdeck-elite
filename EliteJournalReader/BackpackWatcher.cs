using EliteJournalReader.Events;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EliteJournalReader
{

    // copied from https://github.com/MagicMau/EliteJournalReader

    public class BackPackWatcher : FileSystemWatcher
    {
        public event EventHandler<BackPackEvent.BackPackEventArgs> BackPackUpdated;

        /// <summary>
        ///     The default filter
        /// </summary>
        private const string DefaultFilter = @"Backpack.json";

        /// <summary>
        /// Token to signal that we are no longer watching
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        public BackPackWatcher(string path)
        {
            Initialize(path);
        }

        private void Initialize(string path)
        {
            Filter = DefaultFilter;
            NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;

            try
            {
                Path = System.IO.Path.GetFullPath(path);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception in setting path: " + ex.Message);
            }
        }

        // copied from https://github.com/EDCD/EDDI

        private static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                stream?.Close();
            }

            //file is not locked
            return false;
        }

        private static FileInfo FileInfo(string backPackPath)
        {
            try
            {
                var info = new FileInfo(backPackPath);
                if (info.Exists)
                {
                    // This info can be cached so force a refresh
                    info.Refresh();
                }
                return info;
            }
            catch { return null; }
        }

        public BackPackEvent.BackPackEventArgs ReadBackPackJson()
        {
            try
            {
                Thread.Sleep(100);

                var backPackPath = System.IO.Path.Combine(Path, "Backpack.json");

                FileInfo fileInfo = null;
                try
                {
                    fileInfo = FileInfo(backPackPath);
                }
                catch (NotSupportedException)
                {
                    // do nothing
                }

                if (fileInfo != null)
                {
                    var maxTries = 6;
                    while (IsFileLocked(fileInfo))
                    {
                        Thread.Sleep(100);
                        maxTries--;
                        if (maxTries == 0)
                        {
                            return null;
                        }
                    }

                    using (var fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(fs, Encoding.UTF8))
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        var json = reader.ReadToEnd();

                        if (string.IsNullOrEmpty(json))
                        {
                            return null;
                        }
                        var obj = JObject.Parse(json);
                        var backPack = obj.ToObject<BackPackEvent.BackPackEventArgs>();
                        return backPack;

                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning($"Error reading Backpack.json journal file: {e.Message}");
                Trace.TraceInformation(e.ToString());
            }

            return null;
        }

        public virtual void StartWatching()
        {
            if (EnableRaisingEvents)
            {
                // Already watching
                return;
            }

            if (!Directory.Exists(Path))
            {
                Trace.TraceError($"Cannot watch non-existing folder {Path}.");
                return;
            }

            _cancellationTokenSource?.Cancel(); // should not happen, but let's be safe, okay?

            _cancellationTokenSource = new CancellationTokenSource();

            Changed -= UpdateBackPack;
            Changed += UpdateBackPack;

            // start with reading any existing status
            var statusJsonPath = System.IO.Path.Combine(Path, "Backpack.json");
            if (File.Exists(statusJsonPath))
                UpdateBackPack(statusJsonPath);

            EnableRaisingEvents = true;
        }

        public virtual void StopWatching()
        {
            try
            {
                if (!EnableRaisingEvents) return;

                Changed -= UpdateBackPack;

                _cancellationTokenSource?.Cancel();

                EnableRaisingEvents = false;

            }
            catch (Exception e)
            {
                Trace.TraceError($"Error while stopping Journal watcher: {e.Message}");
                Trace.TraceInformation(e.StackTrace);
            }
        }

        private void UpdateBackPack(object sender, FileSystemEventArgs e)
        {
            UpdateBackPack(e.FullPath);
        }

        private DateTime _lastTimestamp = DateTime.MinValue;

        private void UpdateBackPack(string fullPath)
        {
            try
            {
                var backPack = ReadBackPackJson();

                if (backPack != null)
                {
                    // only fire the event if it's new data
                    if (backPack.Timestamp > _lastTimestamp)
                    {
                        _lastTimestamp = backPack.Timestamp;
                        FireBackPackUpdatedEvent(backPack);
                    }
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                Trace.TraceInformation($"Error while reading from Backpack.json: {ex.Message}\n{ex.StackTrace}");
#else
            catch (Exception)
            {
#endif
            }
        }

        private void FireBackPackUpdatedEvent(BackPackEvent.BackPackEventArgs evt) => BackPackUpdated?.Invoke(this, evt);

    }
    
}
