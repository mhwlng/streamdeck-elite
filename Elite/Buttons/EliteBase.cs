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
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handleWindow, out int lpdwProcessID);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetKeyboardLayout(int WindowsThreadProcessID);

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

            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.AnalysisMode, EliteData.StatusData.HudInAnalysisMode)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.CargoScoop, EliteData.StatusData.CargoScoopDeployed)) return;
            if (HandleProfile(deviceInfo, profiles, Profile.ProfileType.Hardpoints, EliteData.StatusData.HardpointsDeployed)) return;

            HandleProfile(deviceInfo, profiles, Profile.ProfileType.Main, true);
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }

        public DirectInputKeyCode ConvertLocaleScanCode(DirectInputKeyCode scanCode)
        {
            //german

            // http://kbdlayout.info/KBDGR/shiftstates+scancodes/base

            // french
            // http://kbdlayout.info/kbdfr/shiftstates+scancodes/base

            // usa
            // http://kbdlayout.info/kbdusx/shiftstates+scancodes/base

            if (Program.Bindings.KeyboardLayout != "en-US")
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, scanCode.ToString() + " " + ((ushort)scanCode).ToString("X"));
                
                int lpdwProcessId;
                IntPtr hWnd = GetForegroundWindow();
                int WinThreadProcId = GetWindowThreadProcessId(hWnd, out lpdwProcessId);
                var hkl = GetKeyboardLayout(WinThreadProcId);

                Logger.Instance.LogMessage(TracingLevel.INFO, ((long)hkl).ToString("X"));

                //hkl = (IntPtr)67568647; // de-DE 4070407

                // Maps the virtual scanCode to key code for the current locale
                var virtualKeyCode = MapVirtualKeyEx((ushort)scanCode, 3, hkl);

                if (virtualKeyCode > 0)
                {
                    // map key code back to en-US scan code :

                    hkl = (IntPtr) 67699721; // en-US 4090409

                    var virtualScanCode = MapVirtualKeyEx((ushort) virtualKeyCode, 4, hkl) ; 

                    if (virtualScanCode > 0)
                    {
                        Logger.Instance.LogMessage(TracingLevel.INFO,
                            "keycode " + virtualKeyCode.ToString("X") + " scancode " + virtualScanCode.ToString("X") +
                            " keyboard code " + hkl.ToString("X"));

                        return (DirectInputKeyCode) (virtualScanCode & 0xff); // only use low byte
                    }
                }
            }

            return scanCode;
        }

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

                    HandleMacro(macro);
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

                HandleMacroDown(macro);
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

                HandleMacroUp(macro);
            }
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

                    iis.Keyboard.DelayedModifiedKeyStroke(keyStrokes.Select(ks => ks), keyCode, 40);

                }
                else // Single Keycode
                {
                    //iis.Keyboard.KeyPress(keyCode);

                    iis.Keyboard.DelayedKeyPress(keyCode, 40);
                }
            }
        }

        private void HandleMacroDown(string macro)
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
                    iis.Keyboard.DelayedModifiedKeyStrokeDown(keyStrokes.Select(ks => ks), keyCode, 40);

                }
                else // Single Keycode
                {
                    iis.Keyboard.DelayedKeyPressDown(keyCode, 40);
                }
            }
        }


        private void HandleMacroUp(string macro)
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
                    iis.Keyboard.DelayedModifiedKeyStrokeUp(keyStrokes.Select(ks => ks), keyCode, 40);

                }
                else // Single Keycode
                {
                    iis.Keyboard.DelayedKeyPressUp(keyCode, 40);
                }
            }
        }

        private string BuildInputText(StandardBindingInfo keyInfo)
        {
            var inputText = "";

            if (keyInfo.Primary.Device == "Keyboard")
            {
                inputText =
                    "{" + keyInfo.Primary.Key.Replace("Key_", "DIK") + "}";
                foreach (var m in keyInfo.Primary.Modifier)
                {
                    if (m.Device == "Keyboard")
                    {
                        inputText =
                            "{" + m.Key.Replace("Key_", "DIK") +
                            "}" + inputText;
                    }
                }

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

                    .Replace("Subtract", "MINUS") //DIKNumpadSubtract   -> DikNumpadMinus
                    .Replace("Add", "PLUS") //DIKNumpadAdd        -> DikNumpadPlus
                    .Replace("Divide", "SLASH") //DIKNumpadDivide     -> DikNumpadSlash
                    .Replace("Decimal", "PERIOD") //DIKNumpadDecimal    -> DikNumpadPeriod
                    .Replace("Multiply", "STAR") //DIKNumpadMultiply   -> DikNumpadStar
                    .Replace("Enter", "RETURN")
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

                //Logger.Instance.LogMessage(TracingLevel.DEBUG, $"{inputText}");

            }

            return inputText;
        }

        protected void SendKeypress(StandardBindingInfo keyInfo, int repeatCount = 1)
        {
            var inputText = BuildInputText(keyInfo);

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
            var inputText = BuildInputText(keyInfo);

            if (!string.IsNullOrEmpty(inputText))
            {
                SendInputDown("{" + inputText + "}");
            }
        }


        protected void SendKeypressUp(StandardBindingInfo keyInfo)
        {
            var inputText = BuildInputText(keyInfo);

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
