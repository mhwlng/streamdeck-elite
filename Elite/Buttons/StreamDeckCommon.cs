using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using BarRaider.SdTools;
using EliteJournalReader.Events;

namespace Elite.Buttons
{
    static class StreamDeckCommon
    {

        private static Dictionary<string,string> _lastStatus = new Dictionary<string, string>();

        public static bool InputRunning;
        public static bool ForceStop = false;
        
        
        private static bool CheckProfileState(Profile.ProfileType profileType)
        {
            var state = false;

            switch (profileType)
            {
                case Profile.ProfileType.GalaxyMap:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.GalaxyMap;
                    break;
                case Profile.ProfileType.InvGalaxyMap:
                    state = EliteData.StatusData.GuiFocus != StatusGuiFocus.GalaxyMap;
                    break;
                case Profile.ProfileType.SystemMap:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.SystemMap;
                    break;
                case Profile.ProfileType.InvSystemMap:
                    state = EliteData.StatusData.GuiFocus != StatusGuiFocus.SystemMap;
                    break;
                case Profile.ProfileType.Orrery:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.Orrery;
                    break;
                case Profile.ProfileType.InvOrrery:
                    state = EliteData.StatusData.GuiFocus != StatusGuiFocus.Orrery;
                    break;
                case Profile.ProfileType.FSSMode:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.FSSMode;
                    break;
                case Profile.ProfileType.InvFSSMode:
                    state = EliteData.StatusData.GuiFocus != StatusGuiFocus.FSSMode;
                    break;
                case Profile.ProfileType.SAAMode:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.SAAMode;
                    break;
                case Profile.ProfileType.InvSAAMode:
                    state = EliteData.StatusData.GuiFocus != StatusGuiFocus.SAAMode;
                    break;
                case Profile.ProfileType.InFighter:
                    state = EliteData.StatusData.InFighter;
                    break;
                case Profile.ProfileType.InvInFighter:
                    state = !EliteData.StatusData.InFighter;
                    break;
                case Profile.ProfileType.SrvTurret:
                    state = EliteData.StatusData.SrvTurret;
                    break;
                case Profile.ProfileType.InvSrvTurret:
                    state = !EliteData.StatusData.SrvTurret;
                    break;
                case Profile.ProfileType.InSRV:
                    state = EliteData.StatusData.InSRV;
                    break;
                case Profile.ProfileType.InvInSRV:
                    state = !EliteData.StatusData.InSRV;
                    break;
                case Profile.ProfileType.OnFoot:
                    state = EliteData.StatusData.OnFoot;
                    break;
                case Profile.ProfileType.InvOnFoot:
                    state = !EliteData.StatusData.OnFoot;
                    break;
                case Profile.ProfileType.AnalysisMode:
                    state = EliteData.StatusData.HudInAnalysisMode;
                    break;
                case Profile.ProfileType.InvAnalysisMode:
                    state = !EliteData.StatusData.HudInAnalysisMode;
                    break;
                case Profile.ProfileType.CargoScoop:
                    state = EliteData.StatusData.CargoScoopDeployed;
                    break;
                case Profile.ProfileType.InvCargoScoop:
                    state = !EliteData.StatusData.CargoScoopDeployed;
                    break;
                case Profile.ProfileType.Hardpoints:
                    state = EliteData.StatusData.HardpointsDeployed;
                    break;
                case Profile.ProfileType.InvHardpoints:
                    state = !EliteData.StatusData.HardpointsDeployed;
                    break;
            }

            return state;
        }

        private static bool CheckProfileStates(List<Profile.ProfileType> profileTypes)
        {
            foreach (var profileType in profileTypes)
            {
                var state = CheckProfileState(profileType);
                if (!state) return false;
            }

            return true;

        }

        public static void HandleOnTick(ISDConnection connection)
        {
            var deviceInfo = connection.DeviceInfo();

            if (!Profile.Profiles.ContainsKey(deviceInfo.Type)) return;

            var profiles = Profile.Profiles[deviceInfo.Type];

            if (!_lastStatus.ContainsKey(deviceInfo.Id))
            {
                _lastStatus.Add(deviceInfo.Id, null);
            }

            /*
            EliteData.StatusData.GuiFocus == StatusGuiFocus.InternalPanel
            EliteData.StatusData.GuiFocus == StatusGuiFocus.ExternalPanel
            EliteData.StatusData.GuiFocus == StatusGuiFocus.CommsPanel
            EliteData.StatusData.GuiFocus == StatusGuiFocus.RolePanel
            EliteData.StatusData.GuiFocus == StatusGuiFocus.StationServices
            EliteData.StatusData.GuiFocus == StatusGuiFocus.Codex
            
            EliteData.StatusData.BeingInterdicted
            EliteData.StatusData.InMainShip
            EliteData.StatusData.Landed
            EliteData.StatusData.Supercruise
            EliteData.StatusData.Docked

            EliteData.StatusData.LandingGearDown
            EliteData.StatusData.ShieldsUp
            EliteData.StatusData.FlightAssistOff

            EliteData.StatusData.InWing
            EliteData.StatusData.LightsOn
            EliteData.StatusData.SilentRunning
            EliteData.StatusData.ScoopingFuel
            EliteData.StatusData.SrvHandbrake
            EliteData.StatusData.SrvUnderShip
            EliteData.StatusData.SrvDriveAssist
            EliteData.StatusData.FsdMassLocked
            EliteData.StatusData.FsdCharging
            EliteData.StatusData.FsdCooldown
            EliteData.StatusData.LowFuel
            EliteData.StatusData.Overheating
            EliteData.StatusData.HasLatLong
            EliteData.StatusData.IsInDanger
            EliteData.StatusData.NightVision
            EliteData.StatusData.AltitudeFromAverageRadius
            EliteData.StatusData.FsdJump
            EliteData.StatusData.SrvHighBeam
            
            EliteData.StatusData.InTaxi
            EliteData.StatusData.InMulticrew
            EliteData.StatusData.OnFootInStation
            EliteData.StatusData.OnFootOnPlanet
            EliteData.StatusData.AimDownSight
            EliteData.StatusData.LowOxygen
            EliteData.StatusData.LowHealth
            EliteData.StatusData.Cold
            EliteData.StatusData.Hot
            EliteData.StatusData.VeryCold
            EliteData.StatusData.VeryHot
            EliteData.StatusData.GlideMode
            EliteData.StatusData.OnFootInHangar
            EliteData.StatusData.OnFootSocialSpace
            EliteData.StatusData.OnFootExterior
            EliteData.StatusData.BreathableAtmosphere
            EliteData.StatusData.TelepresenceMulticrew
            EliteData.StatusData.PhysicalMulticrew
            EliteData.StatusData.Fsdhyperdrivecharging
            */

            foreach (var profile in profiles)
            {
                var key = string.Join(",", profile.ProfileTypes.Select(x => x.ToString()).ToArray());

                var state = CheckProfileStates(profile.ProfileTypes);

                if (state)
                {
                    if (_lastStatus[deviceInfo.Id] != key)
                    {
                        Logger.Instance.LogMessage(TracingLevel.DEBUG,
                            "switch profile " + key + " to " + profile.Name + " for " + profile.DeviceType);

                        connection.SwitchProfileAsync(profile.Name);

                        _lastStatus[deviceInfo.Id] = key;
                    }

                    return;
                }
            }
            
            if  (_lastStatus[deviceInfo.Id] != Profile.ProfileType.Main.ToString())
            {
                var p = profiles.FirstOrDefault(x => x.ProfileTypes.Contains(Profile.ProfileType.Main));

                if (p != null)
                {
                    Logger.Instance.LogMessage(TracingLevel.DEBUG,
                        "switch profile " + Profile.ProfileType.Main + " to " + p.Name + " for " + p.DeviceType);
                    connection.SwitchProfileAsync(p.Name);
                }

                _lastStatus[deviceInfo.Id] = Profile.ProfileType.Main.ToString();
            }

        }

        private static async void SendInput(string inputText)
        {
            InputRunning = true;
            await Task.Run(() =>
            {
                var text = inputText;

                for (var idx = 0; idx < text.Length && !ForceStop; idx++)
                {
                    var macro = CommandTools.ExtractMacro(text, idx);
                    idx += macro.Length - 1;
                    macro = macro.Substring(1, macro.Length - 2);

                    CommandTools.HandleMacro(macro);
                }
            });
            InputRunning = false;
        }


        private static void SendInputDown(string inputText)
        {
            var text = inputText;

            for (var idx = 0; idx < text.Length && !ForceStop; idx++)
            {
                var macro = CommandTools.ExtractMacro(text, idx);
                idx += macro.Length - 1;
                macro = macro.Substring(1, macro.Length - 2);

                CommandTools.HandleMacroDown(macro);
            }
        }

        private static void SendInputUp(string inputText)
        {
            var text = inputText;

            for (var idx = 0; idx < text.Length && !ForceStop; idx++)
            {
                var macro = CommandTools.ExtractMacro(text, idx);
                idx += macro.Length - 1;
                macro = macro.Substring(1, macro.Length - 2);

                CommandTools.HandleMacroUp(macro);
            }
        }


        public static void SendKeypress(StandardBindingInfo keyInfo, int repeatCount = 1)
        {
            var inputText = CommandTools.BuildInputText(keyInfo);

            if (!string.IsNullOrEmpty(inputText))
            {

                //Logger.Instance.LogMessage(TracingLevel.DEBUG, $"{inputText}");

                for (var i = 0; i < repeatCount; i++)
                {
                    if (repeatCount > 1 && i > 0)
                    {
                        Thread.Sleep(20);
                    } 
                    SendInput("{" + inputText + "}");

                }

                // keyboard test page : https://w3c.github.io/uievents/tools/key-event-viewer.html
            }

        }

        public static void SendKeypressDown(StandardBindingInfo keyInfo)
        {
            var inputText = CommandTools.BuildInputText(keyInfo);

            if (!string.IsNullOrEmpty(inputText))
            {
                SendInputDown("{" + inputText + "}");
            }
        }


        public static void SendKeypressUp(StandardBindingInfo keyInfo)
        {
            var inputText = CommandTools.BuildInputText(keyInfo);

            if (!string.IsNullOrEmpty(inputText))
            {
                SendInputUp("{" + inputText + "}");
            }
        }

        public static bool CheckForGif(string imageFilename)
        {
            return imageFilename?.ToLower().EndsWith(".gif") == true;
        }

    }
}
