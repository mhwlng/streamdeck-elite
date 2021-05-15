using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Newtonsoft.Json;

namespace Elite
{
    static class Profile
    {
        public enum ProfileType
        {
            Main,

            GalaxyMap,
            SystemMap,
            Orrery,
            FSSMode,
            SAAMode,

            InFighter,
            SrvTurret,
            InSRV,

            OnFoot,

            AnalysisMode,
            CargoScoop,
            Hardpoints
        }

        public class ProfileData
        {
            public string Name { get; set; }
            public bool ReadOnly { get; set; }
            public StreamDeckDeviceType DeviceType { get; set; }
            public bool DontAutoSwitchWhenInstalled { get; set; }
        }

        public class ManifestData
        {
            public List<ProfileData> Profiles { get; set; } = new List<ProfileData>();
        }

        private static ProfileType? GetProfileType(string name)
        {
            name = name.ToLower();

            if (name.Contains("galaxymap")) return ProfileType.GalaxyMap;
            if (name.Contains("systemmap")) return ProfileType.SystemMap;
            if (name.Contains("orrery")) return ProfileType.Orrery;
            if (name.Contains("fssmode")) return ProfileType.FSSMode;
            if (name.Contains("saamode")) return ProfileType.SAAMode;

            if (name.Contains("infighter")) return ProfileType.InFighter;
            if (name.Contains("srvturret")) return ProfileType.SrvTurret;
            if (name.Contains("insrv")) return ProfileType.InSRV;

            if (name.Contains("onfoot")) return ProfileType.OnFoot;

            if (name.Contains("analysismode")) return ProfileType.AnalysisMode;
            if (name.Contains("cargoscoop")) return ProfileType.CargoScoop;
            if (name.Contains("hardpoints")) return ProfileType.Hardpoints;

            if (name.Contains("main")) return ProfileType.Main;

            return null;
        }

        public static Dictionary <StreamDeckDeviceType, Dictionary<ProfileType, ProfileData>> Profiles = new Dictionary<StreamDeckDeviceType, Dictionary<ProfileType, ProfileData>>();

        private static void FindProfiles(StreamDeckDeviceType streamDeckDeviceType, ManifestData manifest)
        {
            var profileDictionary = new Dictionary<ProfileType, ProfileData>();

            foreach (var profile in manifest.Profiles.Where(x => x.DeviceType == streamDeckDeviceType))
            {
                var profileType = GetProfileType(profile.Name);

                if (profileType != null)
                {
                    profileDictionary.Add((ProfileType)profileType, profile);

                    Logger.Instance.LogMessage(TracingLevel.INFO,
                        "Profile Found : " + profile.Name + " for " + profile.DeviceType);
                }
            }

            if (profileDictionary.Count > 1)
            {
                Profiles.Add(streamDeckDeviceType, profileDictionary);
            }
        }

        public static void ReadProfiles()
        {
            if (!File.Exists("manifest.json")) return;

            var manifestString = File.ReadAllText("manifest.json");

            if (string.IsNullOrEmpty(manifestString)) return;

            var manifest = JsonConvert.DeserializeObject<ManifestData>(manifestString);

            if (manifest?.Profiles?.Any() != true) return;

            FindProfiles(StreamDeckDeviceType.StreamDeckClassic, manifest);
            FindProfiles(StreamDeckDeviceType.StreamDeckMini, manifest);
            FindProfiles(StreamDeckDeviceType.StreamDeckXL, manifest);
        }

    }
}
