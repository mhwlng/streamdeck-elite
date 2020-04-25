using BarRaider.SdTools;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using EliteJournalReader;


namespace Elite
{
    class Program
    {
        public static StatusWatcher statusWatcher;
        public static JournalWatcher watcher;


        public static UserBindings Bindings;

        private class UnsafeNativeMethods
        {
            [DllImport("Shell32.dll")]
            public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);
        }

        /// <summary>
        /// The standard Directory of the Player Journal files (C:\Users\%username%\Saved Games\Frontier Developments\Elite Dangerous).
        /// </summary>
        public static DirectoryInfo StandardDirectory
        {
            get
            {
                int result = UnsafeNativeMethods.SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out IntPtr path);
                if (result >= 0)
                {
                    try { return new DirectoryInfo(Marshal.PtrToStringUni(path) + @"\Frontier Developments\Elite Dangerous"); }
                    catch { return new DirectoryInfo(Directory.GetCurrentDirectory()); }
                }
                else
                {
                    return new DirectoryInfo(Directory.GetCurrentDirectory());
                }
            }
        }
       

        static void Main(string[] args)
        {
            // Uncomment this line of code to allow for debugging
            //while (!System.Diagnostics.Debugger.IsAttached) { System.Threading.Thread.Sleep(100); }

            Logger.Instance.LogMessage(TracingLevel.INFO, "Init Elite Api");

            try
            {
                var journalPath = StandardDirectory.FullName;

                Logger.Instance.LogMessage(TracingLevel.INFO, "journal path " + journalPath);

                if (!Directory.Exists(journalPath))
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"Directory doesn't exist {journalPath}");
                }

                statusWatcher = new StatusWatcher(journalPath);

                statusWatcher.StatusUpdated += EliteData.HandleStatusEvents;

                statusWatcher.StartWatching();

                watcher = new JournalWatcher(journalPath);

                watcher.AllEventHandler += EliteData.HandleEliteEvents;

                watcher.StartWatching().Wait();

                var bindingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) , @"Frontier Developments\Elite Dangerous\Options\Bindings");
                
                Logger.Instance.LogMessage(TracingLevel.INFO, "bindings path " + bindingsPath);

                if (!Directory.Exists(bindingsPath))
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"Directory doesn't exist {bindingsPath}");

                }

                var bindsName = File.ReadAllText(Path.Combine(bindingsPath,"StartPreset.start"));

                var fileName = Path.Combine(bindingsPath, bindsName + ".3.0.binds");

                if (!File.Exists(fileName))
                {
                    //Logger.Instance.LogMessage(TracingLevel.ERROR, "file not found " + fileName);

                    fileName = fileName.Replace(".3.0.binds",".binds");

                    if (!File.Exists(fileName))
                    {
                        bindingsPath = SteamPath.FindSteamEliteDirectory();

                        if (!string.IsNullOrEmpty(bindingsPath))
                        {
                            fileName = Path.Combine(bindingsPath, bindsName + ".3.0.binds");

                            if (!File.Exists(fileName))
                            {
                                //Logger.Instance.LogMessage(TracingLevel.ERROR, "file not found " + fileName);

                                fileName = fileName.Replace(".3.0.binds", ".binds");
                            }
                        }
                    }
                }

                var serializer = new XmlSerializer(typeof(UserBindings));

                Logger.Instance.LogMessage(TracingLevel.INFO, "using " + fileName);

                var reader = new StreamReader(fileName);
                Bindings = (UserBindings) serializer.Deserialize(reader);
                reader.Close();

            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, $"Elite Api: {ex}");
            }


            //EliteAPI.Events.AllEvent += (sender, e) => Console.Beep();


            SDWrapper.Run(args);
        }


    }
}
