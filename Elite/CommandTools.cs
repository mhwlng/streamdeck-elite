using BarRaider.SdTools;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WindowsInput.Native;

namespace Elite
{
    internal static class CommandTools
    {
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

                    if (Program.Bindings.KeyboardLayout == "en-US")
                    {
                        // http://kbdlayout.info/kbdusx/shiftstates+scancodes/base

                        // FIRST ROW  DIKGRAVE          DIKMINUS        DIKEQUALS
                        // SECOND ROW DIKLEFTBRACKET    DIKRIGHTBRACKET DIKBACKSLASH
                        // THIRD ROW  DIKSEMICOLON      DIKAPOSTROPHE
                        // FOURTH ROW DIKCOMMA          DIKPERIOD       DIKSLASH
                    }
                    else if (Program.Bindings.KeyboardLayout == "es-ES")
                    {
                        // http://kbdlayout.info/kbdsp/shiftstates+scancodes/base

                        // FIRST ROW
                        // SECOND ROW 
                        // THIRD ROW
                        // FOURTH ROW

                        // all the keys are the same as en-US in binding file , for some reason ????
                    }
                    else if (Program.Bindings.KeyboardLayout == "en-GB")
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
                    else if (Program.Bindings.KeyboardLayout == "fr-FR")
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
                    else if (Program.Bindings.KeyboardLayout == "de-DE")
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
                    else if (Program.Bindings.KeyboardLayout == "de-CH")
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
                    else if (Program.Bindings.KeyboardLayout == "da-DK")
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
                    else if (Program.Bindings.KeyboardLayout == "it-IT")
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

                    else if (Program.Bindings.KeyboardLayout == "pt-PT")
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


    }
}
