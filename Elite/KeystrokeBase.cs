using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Elite
{
    public abstract class KeystrokeBase : PluginBase
    {
        public abstract class PluginSettingsBase
        {
            [JsonProperty(PropertyName = "command")]
            public string Command { get; set; }

            [JsonProperty(PropertyName = "forcedKeydown")]
            public bool ForcedKeydown { get; set; }
        }

        private InputSimulator iis = new InputSimulator();

        private bool _keyPressed;
        private PluginSettingsBase settings;


        protected KeystrokeBase(SDConnection connection, InitialPayload payload, PluginSettingsBase settings) : base(connection, payload)
        {
            this.settings = settings;
        }

        protected virtual Task SaveSettings()
        {
            return Connection.SetSettingsAsync(JObject.FromObject(settings));
        }

        protected void RunCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(settings.Command))
                {
                    Logger.Instance.LogMessage(TracingLevel.WARN, "Command not configured");
                    return;
                }

                if (settings.Command.Length == 1)
                {
                    Task.Run(() => SimulateTextEntry(settings.Command[0]));
                }
                else // KeyStroke
                {
                    var keyStrokes = CommandTools.ExtractKeyStrokes(settings.Command);

                    // Actually initiate the keystrokes
                    if (keyStrokes.Count > 0)
                    {
                        var keyCode = keyStrokes.Last();
                        keyStrokes.Remove(keyCode);

                        if (keyStrokes.Count > 0)
                        {
                            Task.Run(() => SimulateKeyStroke(keyStrokes.Select(ks => ks).ToArray(), keyCode));
                        }
                        else
                        {
                            Task.Run(() => SimulateKeyDown(keyCode));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, $"RunCommand Exception: {ex}");
            }
        }

        protected void HandleKeystroke()
        {
            if (string.IsNullOrEmpty(settings.Command))
            {
                return;
            }

            if (settings.Command.Length == 1) // 1 Character is fine
            {
                return;
            }

            var macro = CommandTools.ExtractMacro(settings.Command, 0);
            if (string.IsNullOrEmpty(macro)) // Not a macro, save only first character
            {
                settings.Command = settings.Command[0].ToString();
                SaveSettings();
            }
            else
            {
                if (settings.Command != macro) // Save only one keystroke
                {
                    settings.Command = macro;
                    SaveSettings();
                }
            }
        }

        public override void Dispose()
        {
            _keyPressed = false;
            Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called");
        }


        private void SimulateKeyDown(DirectInputKeyCode keyCode)
        {
            while (_keyPressed)
            {
                iis.Keyboard.KeyDown(keyCode);
                Thread.Sleep(30);
            }
            iis.Keyboard.KeyUp(keyCode); // Release key at the end
        }

        private void SimulateKeyStroke(DirectInputKeyCode[] keyStrokes, DirectInputKeyCode keyCode)
        {
            while (_keyPressed)
            {
                if (settings.ForcedKeydown)
                {
                    foreach(var keystroke in keyStrokes)
                    {
                        iis.Keyboard.KeyDown(keystroke);
                    }
                    iis.Keyboard.KeyDown(keyCode);
                }
                else
                {
                    iis.Keyboard.ModifiedKeyStroke(keyStrokes, keyCode);
                }
                Thread.Sleep(30);
            }

            if (settings.ForcedKeydown)
            {
                iis.Keyboard.KeyUp(keyCode);
                foreach (var keystroke in keyStrokes)
                {
                    iis.Keyboard.KeyUp(keystroke);
                }
            }
        }

        private void SimulateTextEntry(char character)
        {
            while (_keyPressed)
            {
                iis.Keyboard.TextEntry(character);
                Thread.Sleep(30);
            }
        }

    }
}
