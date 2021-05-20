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

    [PluginActionId("com.mhwlng.elite.limpet")]
    public class Limpet : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    Firegroup = string.Empty,
                    Fire = string.Empty,
                    PrimaryImageFilename = string.Empty,
                    SecondaryImageFilename = string.Empty,
                    PrimaryColor = "#ffffff",
                    SecondaryColor = "#ffffff",
                    ClickSoundFilename = string.Empty,
                    ErrorSoundFilename = string.Empty
                };

                return instance;
            }

            [JsonProperty(PropertyName = "firegroup")]
            public string Firegroup { get; set; }

            [JsonProperty(PropertyName = "fire")]
            public string Fire { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "primaryImage")]
            public string PrimaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "secondaryImage")]
            public string SecondaryImageFilename { get; set; }

            [JsonProperty(PropertyName = "primaryColor")]
            public string PrimaryColor { get; set; }

            [JsonProperty(PropertyName = "secondaryColor")]
            public string SecondaryColor { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "clickSound")]
            public string ClickSoundFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "errorSound")]
            public string ErrorSoundFilename { get; set; }

        }

        private PluginSettings settings;
        private Bitmap _primaryImage = null;
        private Bitmap _secondaryImage = null;

        private bool _primaryImageIsGif = false;
        private bool _secondaryImageIsGif = false;

        private string _primaryFile;
        private string _secondaryFile;
        private CachedSound _clickSound = null;
        private CachedSound _errorSound = null;

        private SolidBrush _primaryBrush = new SolidBrush(Color.White);
        private SolidBrush _secondaryBrush = new SolidBrush(Color.White);

        private readonly Font drawFont = new Font("Arial", 60);


        private async Task HandleDisplay()
        {
            var isDisabled = (EliteData.StatusData.OnFoot ||
                              EliteData.StatusData.InSRV ||
                              EliteData.StatusData.Docked ||
                              EliteData.StatusData.Landed ||
                              EliteData.StatusData.LandingGearDown ||
                              EliteData.StatusData.Supercruise ||
                              EliteData.StatusData.FsdJump //||

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


            var myBitmap = EliteData.LimpetCount > 0 && !isDisabled  ? _primaryImage : _secondaryImage;
            var imgBase64 = EliteData.LimpetCount > 0 && !isDisabled ? _primaryFile : _secondaryFile;
            var bitmapImageIsGif = EliteData.LimpetCount > 0 && !isDisabled ? _primaryImageIsGif : _secondaryImageIsGif;
            var textBrush = EliteData.LimpetCount > 0 && !isDisabled ? _primaryBrush : _secondaryBrush;
            var textHtmlColor = EliteData.LimpetCount > 0 && !isDisabled ? settings.PrimaryColor : settings.SecondaryColor;

            if (_primaryImage != null)
            {
                if (!bitmapImageIsGif && EliteData.LimpetCount > 0 && textHtmlColor != "#ff00ff")
                {
                    try
                    {
                        using (var bitmap = new Bitmap(myBitmap))
                        {
                            using (var graphics = Graphics.FromImage(bitmap))
                            {
                                var width = bitmap.Width; // assumes rectangular bitmap

                                var fontContainerHeight = 100 * (width / 256.0);

                                for (int adjustedSize = 60; adjustedSize >= 10; adjustedSize -= 5)
                                {
                                    var testFont = new Font(drawFont.Name, adjustedSize, drawFont.Style);

                                    var adjustedSizeNew =
                                        graphics.MeasureString(EliteData.LimpetCount.ToString(), testFont);

                                    if (fontContainerHeight >= adjustedSizeNew.Height)
                                    {
                                        var stringSize = graphics.MeasureString(EliteData.LimpetCount.ToString(),
                                            testFont);

                                        var x = (width - stringSize.Width) / 2.0;
                                        var y = 28.0 * (width / 256.0);

                                        graphics.DrawString(EliteData.LimpetCount.ToString(), testFont, textBrush,
                                            (float) x, (float) y);

                                        testFont.Dispose();

                                        break;
                                    }
                                }
                            }

                            imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.LogMessage(TracingLevel.FATAL, "Limpet HandleDisplay " + ex);
                    }
                }
                await Connection.SetImageAsync(imgBase64);
            }
        }

        public Limpet(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Limpet Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Limpet Constructor #2");

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
                              EliteData.StatusData.Supercruise ||
                              EliteData.StatusData.FsdJump //||

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



            if (!isDisabled && EliteData.LimpetCount > 0 && !string.IsNullOrEmpty(settings.Firegroup) && !string.IsNullOrEmpty(settings.Fire))
            {
                var cycle = Convert.ToInt32(settings.Firegroup) - EliteData.StatusData.Firegroup;

                if (cycle < 0)
                {
                    for (var f = 0; f < -cycle; f++)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                        Thread.Sleep(30);
                    }
                }
                else if (cycle > 0)
                {
                    for (var f = 0 ; f < cycle; f++)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                        Thread.Sleep(30);
                    }
                }

                Thread.Sleep(100);

                SendKeypress(settings.Fire == "PRIMARY"
                    ? Program.Binding[BindingType.Ship].PrimaryFire
                    : Program.Binding[BindingType.Ship].SecondaryFire);

                Thread.Sleep(100);

                if (cycle < 0)
                {
                    for (var f = 0; f < -cycle; f++)
                    {
                        Thread.Sleep(30);
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                    }

                }
                else if (cycle > 0)
                {
                    for (var f = 0; f < cycle; f++)
                    {
                        Thread.Sleep(30);
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
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

            if (string.IsNullOrEmpty(settings.PrimaryColor))
            {
                settings.PrimaryColor = "#ffffff";
            }

            if (string.IsNullOrEmpty(settings.SecondaryColor))
            {
                settings.SecondaryColor = "#ffffff";
            }


            try
            {
                var converter = new ColorConverter();

                _primaryBrush = new SolidBrush((Color) converter.ConvertFromString(settings.PrimaryColor));
                _secondaryBrush = new SolidBrush((Color) converter.ConvertFromString(settings.SecondaryColor));

                if (_primaryImage != null)
                {
                    _primaryImage.Dispose();
                    _primaryImage = null;
                    _primaryFile = null;
                    _primaryImageIsGif = false;
                }

                if (_secondaryImage != null)
                {
                    _secondaryImage.Dispose();
                    _secondaryImage = null;
                    _secondaryFile = null;
                    _secondaryImageIsGif = false;
                }

                if (File.Exists(settings.PrimaryImageFilename))
                {
                    _primaryImage = (Bitmap) Image.FromFile(settings.PrimaryImageFilename);

                    _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);

                    _primaryImageIsGif = CheckForGif(settings.PrimaryImageFilename);
                }

                if (File.Exists(settings.SecondaryImageFilename))
                {
                    _secondaryImage = (Bitmap) Image.FromFile(settings.SecondaryImageFilename);

                    _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);

                    _secondaryImageIsGif = CheckForGif(settings.SecondaryImageFilename);
                }
                else
                {
                    _secondaryImage = _primaryImage;

                    _secondaryFile = _primaryFile;

                    _secondaryImageIsGif = CheckForGif(settings.PrimaryImageFilename);
                }

                if (_primaryImage == null)
                {
                    _primaryImage = _secondaryImage;

                    _primaryFile = _secondaryFile;

                    _primaryImageIsGif = CheckForGif(settings.SecondaryImageFilename);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, "Limpet InitializeSettings " + ex);

            }

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
