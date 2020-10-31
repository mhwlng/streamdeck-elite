using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BarRaider.SdTools;
using EliteJournalReader;
using EliteJournalReader.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite.Buttons
{

    [PluginActionId("com.mhwlng.elite.fss")]
    public class FSS : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    PrimaryImageFilename = string.Empty,
                    SecondaryImageFilename = string.Empty,
                    TertiaryImageFilename = string.Empty,
                    ClickSoundFilename = string.Empty,
                    ErrorSoundFilename = string.Empty,
                    DontSwitchToCombatMode = false
                };

                return instance;
            }

            [FilenameProperty]
            [JsonProperty(PropertyName = "primaryImage")]
            public string PrimaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "secondaryImage")]
            public string SecondaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "tertiaryImage")]
            public string TertiaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "clickSound")]
            public string ClickSoundFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "errorSound")]
            public string ErrorSoundFilename { get; set; }

            [JsonProperty(PropertyName = "dontSwitchToCombatMode")]
            public bool DontSwitchToCombatMode { get; set; }

        }

        private PluginSettings settings;

        private string _primaryFile;
        private string _secondaryFile;
        private string _tertiaryFile;
        private CachedSound _clickSound = null;
        private CachedSound _errorSound = null;


        private async Task HandleDisplay()
        {
            var imgBase64 = _primaryFile; // Engaged Image

            if (!EliteData.StatusData.Supercruise)
            {
                imgBase64 = _tertiaryFile; // Disabled Image
            }
            else
            {
                if (EliteData.StatusData.GuiFocus != StatusGuiFocus.FSSMode)
                {
                    imgBase64 = _secondaryFile;
                }
            }

            if (!string.IsNullOrWhiteSpace(imgBase64))
            {
                await Connection.SetImageAsync(imgBase64);
            }
        }

        public FSS(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "FSS Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "FSS Constructor #2");

                settings = payload.Settings.ToObject<PluginSettings>();
                HandleFileNames();

                AsyncHelper.RunSync(HandleDisplay);
            }

            Program.JournalWatcher.AllEventHandler += HandleEliteEvents;

        }

        public void HandleEliteEvents(object sender, JournalEventArgs e)
        {
            AsyncHelper.RunSync(HandleDisplay);
        }

        public override void KeyPressed(KeyPayload payload)
        {
            if (InputRunning || Program.Bindings == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;
            
            if (EliteData.StatusData.Supercruise)
            {
                if (EliteData.StatusData.GuiFocus == StatusGuiFocus.FSSMode)
                {
                    SendKeypress(Program.Bindings.ExplorationFSSQuit);

                    if (!settings.DontSwitchToCombatMode && EliteData.StatusData.HudInAnalysisMode)
                    {
                        Thread.Sleep(300);

                        SendKeypress(Program.Bindings.PlayerHUDModeToggle); // back to combat mode
                    }
                }
                else
                {
                    if (!EliteData.StatusData.HudInAnalysisMode)
                    {
                        SendKeypress(Program.Bindings.PlayerHUDModeToggle); // to analysis mode
                        Thread.Sleep(100);
                    }

                    SendKeypress(Program.Bindings.ExplorationFSSEnter);
                }

                if (_clickSound != null)
                {
                    try
                    {
                        AudioPlaybackEngine.Instance.PlaySound(_clickSound);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.LogMessage(TracingLevel.FATAL, $"PlaySound: {ex}");
                    }
                }

            }
            else
            {
                if (_errorSound != null)
                {
                    try
                    {
                        AudioPlaybackEngine.Instance.PlaySound(_errorSound);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.LogMessage(TracingLevel.FATAL, $"PlaySound: {ex}");
                    }
                }
            }

            AsyncHelper.RunSync(HandleDisplay);


        }


        public override void KeyReleased(KeyPayload payload)
        {

        }

        public override void Dispose()
        {
            base.Dispose();

            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called #1");

            Program.JournalWatcher.AllEventHandler -= HandleEliteEvents;
        }

        public override async void OnTick()
        {
            base.OnTick();

            await HandleDisplay();
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "ReceivedSettings");

            // New in StreamDeck-Tools v2.0:
            BarRaider.SdTools.Tools.AutoPopulateSettings(settings, payload.Settings);
            HandleFileNames();

            AsyncHelper.RunSync(HandleDisplay);
        }

        private void HandleFileNames()
        {
            _clickSound = null;
            if (File.Exists(settings.ClickSoundFilename))
            {
                try
                {
                    _clickSound = new CachedSound(settings.ClickSoundFilename);
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"CachedSound: {settings.ClickSoundFilename} {ex}");

                    _clickSound = null;
                    settings.ClickSoundFilename = null;
                }
            }

            _errorSound = null;
            if (File.Exists(settings.ErrorSoundFilename))
            {
                try
                {
                    _errorSound = new CachedSound(settings.ErrorSoundFilename);
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"CachedSound: {settings.ErrorSoundFilename} {ex}");

                    _errorSound = null;
                    settings.ErrorSoundFilename = null;
                }
            }

            _primaryFile = null;
            _secondaryFile = null;
            _tertiaryFile = null;

            if (File.Exists(settings.PrimaryImageFilename))
            {
                _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);
            }

            if (File.Exists(settings.SecondaryImageFilename))
            {
                _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);
            }
            else
            {
                _secondaryFile = _primaryFile;
            }

            if (File.Exists(settings.TertiaryImageFilename))
            {
                _tertiaryFile = Tools.FileToBase64(settings.TertiaryImageFilename, true);
            }
            else
            {
                _tertiaryFile = _primaryFile;
            }

            if (_primaryFile == null)
            {
                _primaryFile = _secondaryFile;
            }

            if (_primaryFile == null)
            {
                _primaryFile = _tertiaryFile;
            }

            

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
