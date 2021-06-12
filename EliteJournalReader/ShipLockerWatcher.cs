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

    public class ShipLockerWatcher : FileSystemWatcher
    {
        public event EventHandler<ShipLockerMaterialsEvent.ShipLockerMaterialsEventArgs> ShipLockerUpdated;

        /// <summary>
        ///     The default filter
        /// </summary>
        private const string DefaultFilter = @"ShipLocker.json";

        /// <summary>
        /// Token to signal that we are no longer watching
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        public ShipLockerWatcher(string path)
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

        private static FileInfo FileInfo(string shipLockerPath)
        {
            try
            {
                var info = new FileInfo(shipLockerPath);
                if (info.Exists)
                {
                    // This info can be cached so force a refresh
                    info.Refresh();
                }
                return info;
            }
            catch { return null; }
        }

        public ShipLockerMaterialsEvent.ShipLockerMaterialsEventArgs ReadShipLockerJson()
        {
            try
            {
                Thread.Sleep(100);

                var shipLockerPath = System.IO.Path.Combine(Path, "ShipLocker.json");

                FileInfo fileInfo = null;
                try
                {
                    fileInfo = FileInfo(shipLockerPath);
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
                        var shipLocker = obj.ToObject<ShipLockerMaterialsEvent.ShipLockerMaterialsEventArgs>();
                        return shipLocker;

                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning($"Error reading ShipLocker.json journal file: {e.Message}");
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

            Changed -= UpdateShipLocker;
            Changed += UpdateShipLocker;

            // start with reading any existing status
            var statusJsonPath = System.IO.Path.Combine(Path, "ShipLocker.json");
            if (File.Exists(statusJsonPath))
                UpdateShipLocker(statusJsonPath);

            EnableRaisingEvents = true;
        }

        public virtual void StopWatching()
        {
            try
            {
                if (!EnableRaisingEvents) return;

                Changed -= UpdateShipLocker;

                _cancellationTokenSource?.Cancel();

                EnableRaisingEvents = false;

            }
            catch (Exception e)
            {
                Trace.TraceError($"Error while stopping Journal watcher: {e.Message}");
                Trace.TraceInformation(e.StackTrace);
            }
        }

        private void UpdateShipLocker(object sender, FileSystemEventArgs e)
        {
            UpdateShipLocker(e.FullPath);
        }

        private DateTime _lastTimestamp = DateTime.MinValue;

        private void UpdateShipLocker(string fullPath)
        {
            try
            {
                var shipLocker = ReadShipLockerJson();

                if (shipLocker != null)
                {
                    // only fire the event if it's new data
                    if (shipLocker.Timestamp > _lastTimestamp)
                    {
                        _lastTimestamp = shipLocker.Timestamp;
                        FireShipLockerUpdatedEvent(shipLocker);
                    }
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                Trace.TraceInformation($"Error while reading from ShipLocker.json: {ex.Message}\n{ex.StackTrace}");
#else
            catch (Exception)
            {
#endif
            }
        }

        private void FireShipLockerUpdatedEvent(ShipLockerMaterialsEvent.ShipLockerMaterialsEventArgs evt) => ShipLockerUpdated?.Invoke(this, evt);

    }
    
}
