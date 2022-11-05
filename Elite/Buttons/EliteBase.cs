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

        private bool HandleProfile(StreamDeckDeviceInfo deviceInfo, Dictionary<Profile.ProfileType, Profile.ProfileData> profiles, Profile.ProfileType stateType, bool state)
        {
            if (!profiles.ContainsKey(stateType)) return false;

            if (!_lastStatus.ContainsKey(deviceInfo.Id))
            {
                _lastStatus.Add(deviceInfo.Id, null);
            }

            if (state && _lastStatus[deviceInfo.Id] !=  stateType.ToString())
            {
                var p = profiles[stateType];

                Logger.Instance.LogMessage(TracingLevel.DEBUG, "switch profile " + stateType + " to " + p.Name + " for " + p.DeviceType);

                Connection.SwitchProfileAsync(p.Name);

                _lastStatus[deviceInfo.Id] = stateType.ToString();

            }

            return state;
        }

        public override void OnTick()
        {
            var deviceInfo = Connection.DeviceInfo();

            if (!Profile.Profiles.ContainsKey(deviceInfo.Type)) return;

            var profiles = Profile.Profiles[deviceInfo.Type];

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
            */

            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.GalaxyMap, EliteData.StatusData.GuiFocus == StatusGuiFocus.GalaxyMap)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.SystemMap, EliteData.StatusData.GuiFocus == StatusGuiFocus.SystemMap)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.Orrery, EliteData.StatusData.GuiFocus == StatusGuiFocus.Orrery)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.FSSMode, EliteData.StatusData.GuiFocus == StatusGuiFocus.FSSMode)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.SAAMode, EliteData.StatusData.GuiFocus == StatusGuiFocus.SAAMode)) return;

            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.InFighter, EliteData.StatusData.InFighter)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.SrvTurret, EliteData.StatusData.SrvTurret)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.InSRV, EliteData.StatusData.InSRV)) return;

            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.OnFoot, EliteData.StatusData.OnFoot)) return;

            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.AnalysisMode, EliteData.StatusData.HudInAnalysisMode)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.CargoScoop, EliteData.StatusData.CargoScoopDeployed)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.Hardpoints, EliteData.StatusData.HardpointsDeployed)) return;

            HandleProfile(deviceInfo, profiles, Profile.ProfileType.Main, true);
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
