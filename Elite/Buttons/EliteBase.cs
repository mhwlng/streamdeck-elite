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
    public abstract class EliteBase : PluginBase
    {

        private static Dictionary<string,string> _lastStatus = new Dictionary<string, string>();

        protected bool InputRunning;
        protected bool ForceStop = false;
        protected EliteBase(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
        }

        public override void Dispose()
        {
        }

        public override void KeyReleased(KeyPayload payload) { }

        private bool CheckProfileState(Profile.ProfileType profileType)
        {
            var state = false;

            switch (profileType)
            {
                case Profile.ProfileType.GalaxyMap:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.GalaxyMap;
                    break;
                case Profile.ProfileType.SystemMap:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.SystemMap;
                    break;
                case Profile.ProfileType.Orrery:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.Orrery;
                    break;
                case Profile.ProfileType.FSSMode:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.FSSMode;
                    break;
                case Profile.ProfileType.SAAMode:
                    state = EliteData.StatusData.GuiFocus == StatusGuiFocus.SAAMode;
                    break;
                case Profile.ProfileType.InFighter:
                    state = EliteData.StatusData.InFighter;
                    break;
                case Profile.ProfileType.SrvTurret:
                    state = EliteData.StatusData.SrvTurret;
                    break;
                case Profile.ProfileType.InSRV:
                    state = EliteData.StatusData.InSRV;
                    break;
                case Profile.ProfileType.OnFoot:
                    state = EliteData.StatusData.OnFoot;
                    break;
                case Profile.ProfileType.AnalysisMode:
                    state = EliteData.StatusData.HudInAnalysisMode;
                    break;
                case Profile.ProfileType.CargoScoop:
                    state = EliteData.StatusData.CargoScoopDeployed;
                    break;
                case Profile.ProfileType.Hardpoints:
                    state = EliteData.StatusData.HardpointsDeployed;
                    break;
            }

            return state;

        }

        public override void OnTick()
        {
            var deviceInfo = Connection.DeviceInfo();

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
                var state = CheckProfileState(profile.Key);

                if (state)
                {
                    if (_lastStatus[deviceInfo.Id] != profile.Key.ToString())
                    {
                        var p = profiles[profile.Key];

                        Logger.Instance.LogMessage(TracingLevel.DEBUG,
                            "switch profile " + profile.Key + " to " + p.Name + " for " + p.DeviceType);

                        Connection.SwitchProfileAsync(p.Name);

                        _lastStatus[deviceInfo.Id] = profile.Key.ToString();
                    }

                    return;
                }
            }
            
            if  (_lastStatus[deviceInfo.Id] != Profile.ProfileType.Main.ToString())
            {
                var p = profiles[Profile.ProfileType.Main];

                Logger.Instance.LogMessage(TracingLevel.DEBUG, "switch profile " + Profile.ProfileType.Main + " to " + p.Name + " for " + p.DeviceType);
                Connection.SwitchProfileAsync(p.Name);

                _lastStatus[deviceInfo.Id] = Profile.ProfileType.Main.ToString();
            }

        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }


        private async void SendInput(string inputText)
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


        private void SendInputDown(string inputText)
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

        private void SendInputUp(string inputText)
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


        protected void SendKeypress(StandardBindingInfo keyInfo, int repeatCount = 1)
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

        protected void SendKeypressDown(StandardBindingInfo keyInfo)
        {
            var inputText = CommandTools.BuildInputText(keyInfo);

            if (!string.IsNullOrEmpty(inputText))
            {
                SendInputDown("{" + inputText + "}");
            }
        }


        protected void SendKeypressUp(StandardBindingInfo keyInfo)
        {
            var inputText = CommandTools.BuildInputText(keyInfo);

            if (!string.IsNullOrEmpty(inputText))
            {
                SendInputUp("{" + inputText + "}");
            }
        }

        protected static bool CheckForGif(string imageFilename)
        {
            return imageFilename?.ToLower().EndsWith(".gif") == true;
        }

    }
}
