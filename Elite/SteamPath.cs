using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Microsoft.Win32;
using NLog.LayoutRenderers;

namespace Elite
{
    public static class SteamPath
    {
        // FROM https://stackoverflow.com/questions/54767662/finding-game-launcher-executables-in-directory-c-sharp
        public static string FindSteamEliteDirectory()
        {
            var steamGameDirs = new List<string>();

            const string steam32 = "SOFTWARE\\VALVE\\";
            const string steam64 = "SOFTWARE\\Wow6432Node\\Valve\\";
            var key32 = Registry.LocalMachine.OpenSubKey(steam32);
            var key64 = Registry.LocalMachine.OpenSubKey(steam64);
            if (key32 != null && (key64?.ToString() == null || key64.ToString() == ""))
            {
                foreach (var k32SubKey in key32.GetSubKeyNames())
                {
                    using (var subKey = key32.OpenSubKey(k32SubKey))
                    {
                        var steam32Path = subKey.GetValue("InstallPath")?.ToString();
                        if (steam32Path != null)
                        {
                            var config32Path = steam32Path + "/steamapps/libraryfolders.vdf";
                            string driveRegex = @"[A-Z]:\\";
                            if (File.Exists(config32Path))
                            {
                                string[] configLines = File.ReadAllLines(config32Path);
                                foreach (var item in configLines)
                                {
                                    //Console.WriteLine("32:  " + item);
                                    Match match = Regex.Match(item, driveRegex);
                                    if (item != string.Empty && match.Success)
                                    {
                                        string matched = match.ToString();
                                        string item2 = item.Substring(item.IndexOf(matched));
                                        item2 = item2.Replace("\\\\", "\\");
                                        item2 = item2.Replace("\"", "\\steamapps\\common\\");
                                        steamGameDirs.Add(item2);
                                    }
                                }
                                steamGameDirs.Add(steam32Path + "\\steamapps\\common\\");
                            }
                        }
                    }
                }
            }

            if (key64 != null)
            {
                foreach (var k64SubKey in key64.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key64.OpenSubKey(k64SubKey))
                    {
                        var steam64path = subKey.GetValue("InstallPath")?.ToString();
                        if (steam64path != null)
                        {
                            var config64path = steam64path + "/steamapps/libraryfolders.vdf";
                            var driveRegex = @"[A-Z]:\\";
                            if (File.Exists(config64path))
                            {
                                var configLines = File.ReadAllLines(config64path);
                                foreach (var item in configLines)
                                {
                                    //Console.WriteLine("64:  " + item);
                                    Match match = Regex.Match(item, driveRegex);
                                    if (item != string.Empty && match.Success)
                                    {
                                        var matched = match.ToString();
                                        var item2 = item.Substring(item.IndexOf(matched));
                                        item2 = item2.Replace("\\\\", "\\");
                                        item2 = item2.Replace("\"", "\\steamapps\\common\\");
                                        steamGameDirs.Add(item2);
                                    }
                                }
                                steamGameDirs.Add(steam64path + "\\steamapps\\common\\");
                            }
                        }
                    }
                }
            }

            foreach (var path in steamGameDirs)
            {
                var controlSchemePath64 = @"Elite Dangerous\Products\elite-dangerous-64\ControlSchemes\";

                if (Directory.Exists(path + controlSchemePath64))
                {
                    return path + controlSchemePath64;
                }
            }

            return null;

        }

    }
}
