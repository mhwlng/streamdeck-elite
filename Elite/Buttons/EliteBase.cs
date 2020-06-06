using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using BarRaider.SdTools;
using EliteJournalReader.Events;

namespace Elite.Buttons
{
    public abstract class EliteBase : PluginBase
    {
        private static Dictionary<string,bool?> _lastStatus = new Dictionary<string, bool?>();

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
            var key = stateType + deviceInfo.Id;

            if (!_lastStatus.ContainsKey(key))
            {
                _lastStatus.Add(key, null);
            }

            if (state && _lastStatus[key] != true)
            {
                foreach (var p in profiles.Where(x => x.Key == stateType))
                {
                    Logger.Instance.LogMessage(TracingLevel.DEBUG, "switch profile " + stateType + " to " + p.Value.Name + " for " + p.Value.DeviceType);

                    Connection.SwitchProfileAsync(p.Value.Name);
                }
            }

            _lastStatus[key] = state;

            if (state && stateType != Profile.ProfileType.Main)
            {
                _lastStatus[Profile.ProfileType.Main + deviceInfo.Id] = false;
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

            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.AnalysisMode, EliteData.StatusData.HudInAnalysisMode)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.CargoScoop, EliteData.StatusData.CargoScoopDeployed)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.Hardpoints, EliteData.StatusData.HardpointsDeployed)) return;

            HandleProfile(deviceInfo, profiles, Profile.ProfileType.Main, true);
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }

        protected async void SendInput(string inputText)
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

                    HandleMacro(macro);
                }
            });
            InputRunning = false;
        }

        private void HandleMacro(string macro)
        {
            var keyStrokes = CommandTools.ExtractKeyStrokes(macro);

            // Actually initiate the keystrokes
            if (keyStrokes.Count > 0)
            {
                var iis = new InputSimulator();
                var keyCode = keyStrokes.Last();
                keyStrokes.Remove(keyCode);

                if (keyStrokes.Count > 0)
                {
                    //iis.Keyboard.ModifiedKeyStroke(keyStrokes.Select(ks => ks).ToArray(), keyCode);

                    iis.Keyboard.DelayedModifiedKeyStroke(keyStrokes.Select(ks => ks), keyCode, 50);

                }
                else // Single Keycode
                {
                    iis.Keyboard.KeyPress(keyCode);
                }
            }
        }

        protected void SendKeypress(StandardBindingInfo keyInfo, int repeatCount = 1)
        {
            var inputText = "";

            if (keyInfo.Primary.Device == "Keyboard")
            {
                inputText =
                    "{" + keyInfo.Primary.Key.Replace("Key_", "DIK") + "}";
            }
            else if (keyInfo.Secondary.Device == "Keyboard")
            {
                inputText =
                    "{" + keyInfo.Secondary.Key.Replace("Key_", "DIK") + "}";
                foreach (var m in keyInfo.Secondary.Modifier)
                {
                    if (m.Device == "Keyboard")
                    {
                        inputText =
                            "{" + m.Key.Replace("Key_", "DIK") +
                            "}" + inputText;
                    }
                }
            }

            if (!string.IsNullOrEmpty(inputText))
            {

                inputText = inputText.Replace("_", "")
                    .Replace("Backspace", "BACK")
                    .Replace("UpArrow", "UP")
                    .Replace("DownArrow", "DOWN")
                    .Replace("LeftArrow", "LEFT")
                    .Replace("RightArrow", "RIGHT")
                    .Replace("LeftAlt", "LMENU")
                    .Replace("RightAlt", "RMENU")
                    .Replace("RightControl", "RCONTROL")
                    .Replace("LeftControl", "LCONTROL")
                    .Replace("RightShift", "RSHIFT")
                    .Replace("LeftShift", "LSHIFT");

                Logger.Instance.LogMessage(TracingLevel.DEBUG, $"{inputText}");

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

    }
}
