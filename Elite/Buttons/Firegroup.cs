using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BarRaider.SdTools;
using EliteJournalReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite.Buttons
{

    [PluginActionId("com.mhwlng.elite.firegroup")]
    public class FireGroup : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    Firegroup = string.Empty,
                    PrimaryImageFilename = string.Empty,
                    SecondaryImageFilename = string.Empty,
                    TertiaryImageFilename = string.Empty,
                    ClickSoundFilename = string.Empty,
                    ErrorSoundFilename = string.Empty,

                };

                return instance;
            }

            [JsonProperty(PropertyName = "firegroup")]
            public string Firegroup { get; set; }


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


        }

        private PluginSettings settings;
        private string _primaryFile;
        private string _secondaryFile;
        private string _tertiaryFile;
        private CachedSound _clickSound = null;
        private CachedSound _errorSound = null;

        private async Task HandleDisplay()
        {
            var isDisabled = (EliteData.StatusData.OnFoot ||
                              EliteData.StatusData.InSRV ||
                              EliteData.StatusData.Docked ||
                              EliteData.StatusData.Landed ||
                              EliteData.StatusData.LandingGearDown ||
                              EliteData.StatusData.FsdJump //||
                //EliteData.StatusData.Supercruise ||
                //EliteData.StatusData.CargoScoopDeployed ||
                //EliteData.StatusData.SilentRunning ||
                //EliteData.StatusData.ScoopingFuel ||
                //EliteData.StatusData.IsInDanger ||
                //EliteData.StatusData.BeingInterdicted ||
                //EliteData.StatusData.HudInAnalysisMode ||
                //EliteData.StatusData.FsdMassLocked ||
                //EliteData.StatusData.FsdCharging ||
                //EliteData.StatusData.FsdCooldown ||

                //EliteData.StatusData.HardpointsDeployed
                );

            string imgBase64;

            if (!isDisabled)
            {
                var isPrimary = false;

                if (!string.IsNullOrEmpty(settings.Firegroup))
                {
                    isPrimary = Convert.ToInt32(settings.Firegroup) == EliteData.StatusData.Firegroup;
                }

                if (isPrimary)
                {
                    if (!string.IsNullOrWhiteSpace(_primaryFile))
                    {
                        imgBase64 = _primaryFile;
                        await Connection.SetImageAsync(imgBase64);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(_secondaryFile))
                    {
                        imgBase64 = _secondaryFile;
                        await Connection.SetImageAsync(imgBase64);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(_tertiaryFile))
                {
                    imgBase64 = _tertiaryFile;
                    await Connection.SetImageAsync(imgBase64);
                }
            }

        }

        public FireGroup(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "FireGroup Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "FireGroup Constructor #2");

                settings = payload.Settings.ToObject<PluginSettings>();
                InitializeSettings();

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
            if (InputRunning || Program.Binding == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;

            var isDisabled = (EliteData.StatusData.OnFoot ||
                              EliteData.StatusData.InSRV ||
                              EliteData.StatusData.Docked ||
                              EliteData.StatusData.Landed ||
                              EliteData.StatusData.LandingGearDown ||
                              EliteData.StatusData.FsdJump //||

                //EliteData.StatusData.Supercruise ||
                //EliteData.StatusData.CargoScoopDeployed ||
                //EliteData.StatusData.SilentRunning ||
                //EliteData.StatusData.ScoopingFuel ||
                //EliteData.StatusData.IsInDanger ||
                //EliteData.StatusData.BeingInterdicted ||
                //EliteData.StatusData.HudInAnalysisMode ||
                //EliteData.StatusData.FsdMassLocked ||
                //EliteData.StatusData.FsdCharging ||
                //EliteData.StatusData.FsdCooldown ||

                //EliteData.StatusData.HardpointsDeployed
                );

            if (!isDisabled &&  !string.IsNullOrEmpty(settings.Firegroup))
            {
                var cycle = Convert.ToInt32(settings.Firegroup) - EliteData.StatusData.Firegroup;

                if (cycle < 0)
                {
                    for (var f = 0; f < -cycle; f++)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                        Thread.Sleep(70);
                    }
                }
                else if (cycle > 0)
                {
                    for (var f = 0; f < cycle; f++)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                        Thread.Sleep(70);
                    }
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
            AsyncHelper.RunSync(HandleDisplay);
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
            InitializeSettings();

            AsyncHelper.RunSync(HandleDisplay);
        }

        private void InitializeSettings()
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
