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

            InternalPanel,
            InvInternalPanel,
            ExternalPanel,
            InvExternalPanel,
            CommsPanel,
            InvCommsPanel,
            RolePanel,
            InvRolePanel,

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
            InvHardpoints,

            BeingInterdicted,
            InvBeingInterdicted,
            InMainShip,
            InvInMainShip,

            Landed,
            InvLanded,
            Supercruise,
            InvSupercruise,

            Docked,
            InvDocked,

            LandingGearDown,
            InvLandingGearDown,
            ShieldsUp,
            InvShieldsUp,
            FlightAssistOff,
            InvFlightAssistOff,

            InWing,
            InvInWing,
            LightsOn,
            InvLightsOn,
            SilentRunning,
            InvSilentRunning,
            ScoopingFuel,
            InvScoopingFuel,
            SrvHandbrake,
            InvSrvHandbrake,
            SrvUnderShip,
            InvSrvUnderShip,
            SrvDriveAssist,
            InvSrvDriveAssist,
            FsdMassLocked,
            InvFsdMassLocked,
            FsdCharging,
            InvFsdCharging,
            FsdCooldown,
            InvFsdCooldown,
            LowFuel,
            InvLowFuel,
            Overheating,
            InvOverheating,
            HasLatLong,
            InvHasLatLong,
            IsInDanger,
            InvIsInDanger,
            NightVision,
            InvNightVision,
            FsdJump,
            InvFsdJump,

            SrvHighBeam,
            InvSrvHighBeam,

            InTaxi,
            InvInTaxi,
            InMulticrew,
            InvInMulticrew,
            GlideMode,
            InvGlideMode,
            TelepresenceMulticrew,
            InvTelepresenceMulticrew,
            PhysicalMulticrew,
            InvPhysicalMulticrew,
            Fsdhyperdrivecharging,
            InvFsdhyperdrivecharging

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

            if (name.Contains("main") && !name.Contains("inmainship"))
            {
                profiles.Add(ProfileType.Main);
                return profiles;
            }

            if (name.Contains("invinternalpanel"))
            {
                profiles.Add(ProfileType.InvInternalPanel);
            }
            else if (name.Contains("internalpanel"))
            {
                profiles.Add(ProfileType.InternalPanel);
            }

            if (name.Contains("invexternalpanel"))
            {
                profiles.Add(ProfileType.InvExternalPanel);
            }
            else if (name.Contains("externalpanel"))
            {
                profiles.Add(ProfileType.ExternalPanel);
            }

            if (name.Contains("invcommspanel"))
            {
                profiles.Add(ProfileType.InvCommsPanel);
            }
            else if (name.Contains("commspanel"))
            {
                profiles.Add(ProfileType.CommsPanel);
            }

            if (name.Contains("invrolepanel"))
            {
                profiles.Add(ProfileType.InvRolePanel);
            }
            else if (name.Contains("rolepanel"))
            {
                profiles.Add(ProfileType.RolePanel);
            }

            if (name.Contains("invgalaxymap"))
            {
                profiles.Add(ProfileType.InvGalaxyMap);
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

            if (name.Contains("invbeinginterdicted"))
            {
                profiles.Add(ProfileType.InvBeingInterdicted);
            }
            else if (name.Contains("beinginterdicted"))
            {
                profiles.Add(ProfileType.BeingInterdicted);
            }

            if (name.Contains("invinmainship"))
            {
                profiles.Add(ProfileType.InvInMainShip);
            }
            else if (name.Contains("inmainship"))
            {
                profiles.Add(ProfileType.InMainShip);
            }

            if (name.Contains("invlanded"))
            {
                profiles.Add(ProfileType.InvLanded);
            }
            else if (name.Contains("landed"))
            {
                profiles.Add(ProfileType.Landed);
            }

            if (name.Contains("invsupercruise"))
            {
                profiles.Add(ProfileType.InvSupercruise);
            }
            else if (name.Contains("supercruise"))
            {
                profiles.Add(ProfileType.Supercruise);
            }

            if (name.Contains("invdocked"))
            {
                profiles.Add(ProfileType.InvDocked);
            }
            else if (name.Contains("docked"))
            {
                profiles.Add(ProfileType.Docked);
            }

            if (name.Contains("invlandinggeardown"))
            {
                profiles.Add(ProfileType.InvLandingGearDown);
            }
            else if (name.Contains("landinggeardown"))
            {
                profiles.Add(ProfileType.LandingGearDown);
            }

            if (name.Contains("invshieldsup"))
            {
                profiles.Add(ProfileType.InvShieldsUp);
            }
            else if (name.Contains("shieldsup"))
            {
                profiles.Add(ProfileType.ShieldsUp);
            }

            if (name.Contains("invflightassistoff"))
            {
                profiles.Add(ProfileType.InvFlightAssistOff);
            }
            else if (name.Contains("flightassistoff"))
            {
                profiles.Add(ProfileType.FlightAssistOff);
            }

            if (name.Contains("invinwing"))
            {
                profiles.Add(ProfileType.InvInWing);
            }
            else if (name.Contains("inwing"))
            {
                profiles.Add(ProfileType.InWing);
            }

            if (name.Contains("invlightson"))
            {
                profiles.Add(ProfileType.InvLightsOn);
            }
            else if (name.Contains("lightson"))
            {
                profiles.Add(ProfileType.LightsOn);
            }

            if (name.Contains("invsilentrunning"))
            {
                profiles.Add(ProfileType.InvSilentRunning);
            }
            else if (name.Contains("silentrunning"))
            {
                profiles.Add(ProfileType.SilentRunning);
            }

            if (name.Contains("invscoopingfuel"))
            {
                profiles.Add(ProfileType.InvScoopingFuel);
            }
            else if (name.Contains("scoopingfuel"))
            {
                profiles.Add(ProfileType.ScoopingFuel);
            }

            if (name.Contains("invsrvhandbrake"))
            {
                profiles.Add(ProfileType.InvSrvHandbrake);
            }
            else if (name.Contains("srvhandbrake"))
            {
                profiles.Add(ProfileType.SrvHandbrake);
            }

            if (name.Contains("invsrvundership"))
            {
                profiles.Add(ProfileType.InvSrvUnderShip);
            }
            else if (name.Contains("srvundership"))
            {
                profiles.Add(ProfileType.SrvUnderShip);
            }

            if (name.Contains("invsrvdriveassist"))
            {
                profiles.Add(ProfileType.InvSrvDriveAssist);
            }
            else if (name.Contains("srvdriveassist"))
            {
                profiles.Add(ProfileType.SrvDriveAssist);
            }

            if (name.Contains("invfsdmasslocked"))
            {
                profiles.Add(ProfileType.InvFsdMassLocked);
            }
            else if (name.Contains("fsdmasslocked"))
            {
                profiles.Add(ProfileType.FsdMassLocked);
            }

            if (name.Contains("invfsdcharging"))
            {
                profiles.Add(ProfileType.InvFsdCharging);
            }
            else if (name.Contains("fsdcharging"))
            {
                profiles.Add(ProfileType.FsdCharging);
            }

            if (name.Contains("invfsdcooldown"))
            {
                profiles.Add(ProfileType.InvFsdCooldown);
            }
            else if (name.Contains("fsdcooldown"))
            {
                profiles.Add(ProfileType.FsdCooldown);
            }

            if (name.Contains("invlowfuel"))
            {
                profiles.Add(ProfileType.InvLowFuel);
            }
            else if (name.Contains("lowfuel"))
            {
                profiles.Add(ProfileType.LowFuel);
            }

            if (name.Contains("invoverheating"))
            {
                profiles.Add(ProfileType.InvOverheating);
            }
            else if (name.Contains("overheating"))
            {
                profiles.Add(ProfileType.Overheating);
            }

            if (name.Contains("invhaslatlong"))
            {
                profiles.Add(ProfileType.InvHasLatLong);
            }
            else if (name.Contains("haslatlong"))
            {
                profiles.Add(ProfileType.HasLatLong);
            }

            if (name.Contains("invisindanger"))
            {
                profiles.Add(ProfileType.InvIsInDanger);
            }
            else if (name.Contains("isindanger"))
            {
                profiles.Add(ProfileType.IsInDanger);
            }

            if (name.Contains("invnightvision"))
            {
                profiles.Add(ProfileType.InvNightVision);
            }
            else if (name.Contains("nightvision"))
            {
                profiles.Add(ProfileType.NightVision);
            }

            if (name.Contains("invfsdjump"))
            {
                profiles.Add(ProfileType.InvFsdJump);
            }
            else if (name.Contains("fsdjump"))
            {
                profiles.Add(ProfileType.FsdJump);
            }

            if (name.Contains("invsrvhighbeam"))
            {
                profiles.Add(ProfileType.InvSrvHighBeam);
            }
            else if (name.Contains("srvhighbeam"))
            {
                profiles.Add(ProfileType.SrvHighBeam);
            }

            if (name.Contains("invintaxi"))
            {
                profiles.Add(ProfileType.InvInTaxi);
            }
            else if (name.Contains("intaxi"))
            {
                profiles.Add(ProfileType.InTaxi);
            }

            if (name.Contains("invinmulticrew"))
            {
                profiles.Add(ProfileType.InvInMulticrew);
            }
            else if (name.Contains("inmulticrew"))
            {
                profiles.Add(ProfileType.InMulticrew);
            }

            if (name.Contains("invglidemode"))
            {
                profiles.Add(ProfileType.InvGlideMode);
            }
            else if (name.Contains("glidemode"))
            {
                profiles.Add(ProfileType.GlideMode);
            }

            if (name.Contains("invtelepresencemulticrew"))
            {
                profiles.Add(ProfileType.InvTelepresenceMulticrew);
            }
            else if (name.Contains("telepresencemulticrew"))
            {
                profiles.Add(ProfileType.TelepresenceMulticrew);
            }

            if (name.Contains("invphysicalmulticrew"))
            {
                profiles.Add(ProfileType.InvPhysicalMulticrew);
            }
            else if (name.Contains("physicalmulticrew"))
            {
                profiles.Add(ProfileType.PhysicalMulticrew);
            }

            if (name.Contains("invfsdhyperdrivecharging"))
            {
                profiles.Add(ProfileType.InvFsdhyperdrivecharging);
            }
            else if (name.Contains("fsdhyperdrivecharging"))
            {
                profiles.Add(ProfileType.Fsdhyperdrivecharging);
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

            FindProfiles(DeviceType.StreamDeckMobile, manifest);

            FindProfiles(DeviceType.StreamDeckPlus, manifest);
        }

    }
}
