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

                            // THIRD ROW
                            case "DIKM":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKÙ":
                                matchText = "DIKAPOSTROPHE";
                                break;
                            case "DIKASTERISK":
                                matchText = "DIKBACKSLASH";
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

                            // THIRD ROW
                            case "DIKÖ":
                                matchText = "DIKSEMICOLON";
                                break;
                            case "DIKÄ":
                                matchText = "DIKAPOSTROPHE";
                                break;
                            case "DIKHASH":
                                matchText = "DIKBACKSLASH";
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
