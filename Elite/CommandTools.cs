using BarRaider.SdTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Elite
{
    internal static class CommandTools
    {
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handleWindow, out int lpdwProcessID);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetKeyboardLayout(int WindowsThreadProcessID);

        internal const char MACRO_START_CHAR = '{';
        internal const string MACRO_END = "}}";
        internal const string REGEX_MACRO = @"^\{(\{[^\{\}]+\})+\}$";
        internal const string REGEX_SUB_COMMAND = @"(\{[^\{\}]+\})";

        internal static string ExtractMacro(string text, int position)
        {
            try
            {
                var endPosition = text.IndexOf(MACRO_END, position);

                // Found an end, let's verify it's actually a macro
                if (endPosition > position)
                {
                    // Use Regex to verify it's really a macro
                    var match = Regex.Match(text.Substring(position, endPosition - position + MACRO_END.Length), REGEX_MACRO);
                    if (match.Length > 0)
                    {
                        return match.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, $"ExtractMacro Exception: {ex}");
            }

            return null;
        }

        internal static List<DirectInputKeyCode> ExtractKeyStrokes(string macroText)
        {
            var keyStrokes = new List<DirectInputKeyCode>();


            try
            {
                var matches = Regex.Matches(macroText, REGEX_SUB_COMMAND);
                foreach (var match in matches)
                {
                    var matchText = match.ToString().ToUpperInvariant().Replace("{", "").Replace("}", "");

                    if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "en-US")
                    {
                        // http://kbdlayout.info/kbdusx/shiftstates+scancodes/base

                        // FIRST ROW  DIKGRAVE          DIKMINUS        DIKEQUALS
                        // SECOND ROW DIKLEFTBRACKET    DIKRIGHTBRACKET DIKBACKSLASH
                        // THIRD ROW  DIKSEMICOLON      DIKAPOSTROPHE
                        // FOURTH ROW DIKCOMMA          DIKPERIOD       DIKSLASH
                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "es-ES")
                    {
                        // http://kbdlayout.info/kbdsp/shiftstates+scancodes/base

                        // FIRST ROW
                        // SECOND ROW 
                        // THIRD ROW
                        // FOURTH ROW

                        // all the keys are the same as en-US in binding file , for some reason ????
                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "en-GB")
                    {
                        // http://kbdlayout.info/kbduk/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // second row
                            case "DIKHASH":
                                matchText = "DIKBACKSLASH";
                                break;
                        }
                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "fr-FR")
                    {
                        // http://kbdlayout.info/kbdfr/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // FIRST ROW
                            case "DIKSUPERSCRIPTTWO":
                                matchText = "DIKGRAVE";
                                break;
                            case "DIKAMPERSAND":
                                matchText = "DIK1";
                                break;
                            case "DIKÉ":
                                matchText = "DIK2";
                                break;
                            case "DIKDOUBLEQUOTE":
                                matchText = "DIK3";
                                break;
                            case "DIKAPOSTROPHE":
                                matchText = "DIK4";
                                break;
                            case "DIKLEFTPARENTHESIS":
                                matchText = "DIK5";
                                break;
                            case "DIKMINUS":
                                matchText = "DIK6";
                                break;
                            case "DIKÈ":
                                matchText = "DIK7";
                                break;
                            case "DIKUNDERLINE":
                                matchText = "DIK8";
                                break;
                            case "DIKÇ":
                                matchText = "DIK9";
                                break;
                            case "DIKÀ":
                                matchText = "DIK0";
                                break;
                            case "DIKRIGHTPARENTHESIS":
                                matchText = "DIKMINUS";
                                break;

                            // SECOND ROW
                            case "DIKA":
                                matchText = "DIKQ";
                                break;
                            case "DIKZ":
                                matchText = "DIKW";
                                break;
                            case "DIKCIRCUMFLEX":
                                matchText = "DIKLEFTBRACKET";
                                break;
                            case "DIKDOLLAR":
                                matchText = "DIKRIGHTBRACKET";
                                break;
                            case "DIKASTERISK":
                                matchText = "DIKBACKSLASH";
                                break;

                            // THIRD ROW

                            case "DIKQ":
                                matchText = "DIKA";
                                break;

                            case "DIKM":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKÙ":
                                matchText = "DIKAPOSTROPHE";
                                break;

                            // FOURTH ROW
                            case "DIKW":
                                matchText = "DIKZ";
                                break;
                            case "DIKCOMMA":
                                matchText = "DIKM";
                                break;
                            case "DIKSEMICOLON":
                                matchText = "DIKCOMMA";
                                break;
                            case "DIKCOLON":
                                matchText = "DIKPERIOD";
                                break;
                            case "DIKEXCLAMATIONPOINT":
                                matchText = "DIKSLASH";
                                break;
                        }

                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "de-DE")
                    {
                        // http://kbdlayout.info/kbdgr/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // FIRST ROW
                            case "DIKCIRCUMFLEX":
                                matchText = "DIKGRAVE";
                                break;
                            case "DIKß":
                                matchText = "DIKMINUS";
                                break;
                            case "DIKACUTE":
                                matchText = "DIKEQUALS";
                                break;

                            // SECOND ROW 
                            case "DIKZ":
                                matchText = "DIKY";
                                break;
                            case "DIKÜ":
                                matchText = "DIKLEFTBRACKET";
                                break;
                            case "DIKPLUS":
                                matchText = "DIKRIGHTBRACKET";
                                break;
                            case "DIKHASH":
                                matchText = "DIKBACKSLASH";
                                break;

                            // THIRD ROW
                            case "DIKÖ":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKÄ":
                                matchText = "DIKAPOSTROPHE";
                                break;

                            // FOURTH ROW
                            case "DIKY":
                                matchText = "DIKZ";
                                break;
                            case "DIKMINUS":
                                matchText = "DIKSLASH";
                                break;
                        }

                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "de-CH")
                    {
                        // http://kbdlayout.info/kbdsg/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // FIRST ROW
                            case "DIK§":
                                matchText = "DIKGRAVE";
                                break;
                            case "DIKAPOSTROPHE":
                                matchText = "DIKMINUS";
                                break;
                            case "DIKCIRCUMFLEX":
                                matchText = "DIKEQUALS";
                                break;

                            // SECOND ROW 
                            case "DIKZ":
                                matchText = "DIKY";
                                break;
                            case "DIKÜ":
                                matchText = "DIKLEFTBRACKET";
                                break;
                            case "DIKUMLAUT":
                                matchText = "DIKRIGHTBRACKET";
                                break;
                            case "DIKDOLLAR":
                                matchText = "DIKBACKSLASH";
                                break;

                            // THIRD ROW
                            case "DIKÖ":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKÄ":
                                matchText = "DIKAPOSTROPHE";
                                break;

                            // FOURTH ROW
                            case "DIKY":
                                matchText = "DIKZ";
                                break;
                            case "DIKMINUS":
                                matchText = "DIKSLASH";
                                break;

                        }

                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "da-DK")
                    {
                        // http://kbdlayout.info/kbdda/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // FIRST ROW
                            case "DIKHALF":
                                matchText = "DIKGRAVE";
                                break;
                            case "DIKPLUS":
                                matchText = "DIKMINUS";
                                break;
                            case "DIKACUTE":
                                matchText = "DIKEQUALS";
                                break;

                            // SECOND ROW 
                            case "DIKÅ":
                                matchText = "DIKLEFTBRACKET";
                                break;
                            case "DIKUMLAUT":
                                matchText = "DIKRIGHTBRACKET";
                                break;
                            case "DIKAPOSTROPHE":
                                matchText = "DIKBACKSLASH";
                                break;

                            // THIRD ROW
                            case "DIKÆ":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKØ":
                                matchText = "DIKAPOSTROPHE";
                                break;

                            // FOURTH ROW
                            case "DIKMINUS":
                                matchText = "DIKSLASH";
                                break;
                        }

                    }
                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "it-IT")
                    {
                        // http://kbdlayout.info/kbdit/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // FIRST ROW
                            case "DIKBACKSLASH":
                                matchText = "DIKGRAVE";
                                break;
                            case "DIKAPOSTROPHE":
                                matchText = "DIKMINUS";
                                break;
                            case "DIKÌ":
                                matchText = "DIKEQUALS";
                                break;

                            // SECOND ROW 
                            case "DIKÈ":
                                matchText = "DIKLEFTBRACKET";
                                break;
                            case "DIKPLUS":
                                matchText = "DIKRIGHTBRACKET";
                                break;
                            case "DIKÙ":
                                matchText = "DIKBACKSLASH";
                                break;

                            // THIRD ROW
                            case "DIKÒ":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKÀ":
                                matchText = "DIKAPOSTROPHE";
                                break;

                            // FOURTH ROW
                            case "DIKMINUS":
                                matchText = "DIKSLASH";
                                break;
                        }

                    }

                    else if (Program.Binding[BindingType.OnFoot].KeyboardLayout == "pt-PT")
                    {
                        // http://kbdlayout.info/kbdpo/shiftstates+scancodes/base

                        switch (matchText)
                        {
                            // FIRST ROW
                            case "DIKBACKSLASH":
                                matchText = "DIKGRAVE";
                                break;
                            case "DIKAPOSTROPHE":
                                matchText = "DIKMINUS";
                                break;
                            case "DIK«":
                                matchText = "DIKEQUALS";
                                break;

                            // SECOND ROW 
                            case "DIKPLUS":
                                matchText = "DIKLEFTBRACKET";
                                break;
                            case "DIKACUTE":
                                matchText = "DIKRIGHTBRACKET";
                                break;
                            case "DIKTILDE":
                                matchText = "DIKBACKSLASH";
                                break;

                            // THIRD ROW
                            case "DIKÇ":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKº":
                                matchText = "DIKAPOSTROPHE";
                                break;

                            // FOURTH ROW
                            case "DIKMINUS":
                                matchText = "DIKSLASH";
                                break;
                        }

                    }


                    var stroke = (DirectInputKeyCode)Enum.Parse(typeof(DirectInputKeyCode), matchText, true);

                    keyStrokes.Add(stroke);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, $"ExtractKeyStrokes Exception: {ex}");
            }

            return keyStrokes;
        }



        public static DirectInputKeyCode ConvertLocaleScanCode(DirectInputKeyCode scanCode)
        {
            //german

            // http://kbdlayout.info/KBDGR/shiftstates+scancodes/base

            // french
            // http://kbdlayout.info/kbdfr/shiftstates+scancodes/base

            // usa
            // http://kbdlayout.info/kbdusx/shiftstates+scancodes/base

            if (Program.Binding[BindingType.OnFoot].KeyboardLayout != "en-US")
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

                    hkl = (IntPtr)67699721; // en-US 4090409

                    var virtualScanCode = MapVirtualKeyEx((ushort)virtualKeyCode, 4, hkl);

                    if (virtualScanCode > 0)
                    {
                        Logger.Instance.LogMessage(TracingLevel.INFO,
                            "keycode " + virtualKeyCode.ToString("X") + " scancode " + virtualScanCode.ToString("X") +
                            " keyboard code " + hkl.ToString("X"));

                        return (DirectInputKeyCode)(virtualScanCode & 0xff); // only use low byte
                    }
                }
            }

            return scanCode;
        }


        public static void HandleMacro(string macro)
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

        public static void HandleMacroDown(string macro)
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


        public static void HandleMacroUp(string macro)
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

        public static string BuildInputText(StandardBindingInfo keyInfo)
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
                    .Replace("DIKEnter", "DIKRETURN")  // don't affect DIKNumpadEnter
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



    }
}
