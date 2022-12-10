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
    public static class Profile
    {
        public enum ProfileType
        {
            Main,

            GalaxyMap,
            InvGalaxyMap,
            SystemMap,
            InvSystemMap,
            Orrery,
            InvOrrery,
            FSSMode,
            InvFSSMode,
            SAAMode,
            InvSAAMode,

            InFighter,
            InvInFighter,
            SrvTurret,
            InvSrvTurret,
            InSRV,
            InvInSRV,

            OnFoot,
            InvOnFoot,

            AnalysisMode,
            InvAnalysisMode,
            CargoScoop,
            InvCargoScoop,
            Hardpoints,
            InvHardpoints
        }

        public class ProfileData
        {
            public List<ProfileType> ProfileTypes { get; set; }
            public string Name { get; set; }
            public bool ReadOnly { get; set; }
            public DeviceType DeviceType { get; set; }
            public bool DontAutoSwitchWhenInstalled { get; set; }
        }

        public class ManifestData
        {
            public List<ProfileData> Profiles { get; set; } = new List<ProfileData>();
        }

        private static List<ProfileType> GetProfileTypes(string name)
        {
            var profiles = new List<ProfileType>();

            name = name.ToLower();

            if (name.Contains("main"))
            {
                profiles.Add(ProfileType.Main);
                return profiles;
            }

            if (name.Contains("invgalaxymap"))
            {
                profiles.Add( ProfileType.InvGalaxyMap);
            }
            else if (name.Contains("galaxymap"))
            {
                profiles.Add(ProfileType.GalaxyMap);
            }

            if (name.Contains("invsystemmap"))
            {
                profiles.Add(ProfileType.InvSystemMap);
            }
            else if (name.Contains("systemmap"))
            {
                profiles.Add(ProfileType.SystemMap);
            }

            if (name.Contains("invorrery"))
            {
                profiles.Add(ProfileType.InvOrrery);
            }
            else if (name.Contains("orrery"))
            {
                profiles.Add(ProfileType.Orrery);
            }

            if (name.Contains("invfssmode"))
            {
                profiles.Add(ProfileType.InvFSSMode);
            }
            else if (name.Contains("fssmode"))
            {
                profiles.Add(ProfileType.FSSMode);
            }

            if (name.Contains("invsaamode"))
            {
                profiles.Add(ProfileType.InvSAAMode);
            }
            else if (name.Contains("saamode"))
            {
                profiles.Add(ProfileType.SAAMode);
            }

            if (name.Contains("invinfighter"))
            {
                profiles.Add(ProfileType.InvInFighter);
            }
            else if (name.Contains("infighter"))
            {
                profiles.Add(ProfileType.InFighter);
            }

            if (name.Contains("invsrvturret"))
            {
                profiles.Add(ProfileType.InvSrvTurret);
            }
            else if (name.Contains("srvturret"))
            {
                profiles.Add(ProfileType.SrvTurret);
            }

            if (name.Contains("invinsrv"))
            {
                profiles.Add(ProfileType.InvInSRV);
            }
            else if (name.Contains("insrv"))
            {
                profiles.Add(ProfileType.InSRV);
            }

            if (name.Contains("invonfoot"))
            {
                profiles.Add(ProfileType.InvOnFoot);
            }
            else if (name.Contains("onfoot"))
            {
                profiles.Add(ProfileType.OnFoot);
            }

            if (name.Contains("invanalysismode"))
            {
                profiles.Add(ProfileType.InvAnalysisMode);
            }
            else if (name.Contains("analysismode"))
            {
                profiles.Add(ProfileType.AnalysisMode);
            }

            if (name.Contains("invcargoscoop"))
            {
                profiles.Add(ProfileType.InvCargoScoop);
            }
            else if (name.Contains("cargoscoop"))
            {
                profiles.Add(ProfileType.CargoScoop);
            }

            if (name.Contains("invhardpoints"))
            {
                profiles.Add(ProfileType.InvHardpoints);
            }
            else if (name.Contains("hardpoints"))
            {
                profiles.Add(ProfileType.Hardpoints);
            }

            return profiles;
        }

        public static Dictionary <DeviceType, List<ProfileData>> Profiles = new Dictionary<DeviceType, List<ProfileData>>();

        private static void FindProfiles(DeviceType streamDeckDeviceType, ManifestData manifest)
        {
            var profileList = new List<ProfileData>();

            foreach (var profile in manifest.Profiles.Where(x => x.DeviceType == streamDeckDeviceType))
            {
                profile.ProfileTypes = GetProfileTypes(profile.Name);

                if (profile.ProfileTypes.Any())
                {
                    profileList.Add(profile);

                    Logger.Instance.LogMessage(TracingLevel.INFO,
                        "Profile Found : " + profile.Name + " for " + profile.DeviceType);
                }
            }

            if (profileList.Any())
            {
                Profiles.Add(streamDeckDeviceType, profileList);
            }
        }

        public static void ReadProfiles()
        {
            if (!File.Exists("manifest.json")) return;

            var manifestString = File.ReadAllText("manifest.json");

            if (string.IsNullOrEmpty(manifestString)) return;

            var manifest = JsonConvert.DeserializeObject<ManifestData>(manifestString);

            if (manifest?.Profiles?.Any() != true) return;

            FindProfiles(DeviceType.StreamDeckClassic, manifest);
            FindProfiles(DeviceType.StreamDeckMini, manifest);
            FindProfiles(DeviceType.StreamDeckXL, manifest);

            FindProfiles(DeviceType.StreamDeckPlus, manifest);
        }

    }
}
