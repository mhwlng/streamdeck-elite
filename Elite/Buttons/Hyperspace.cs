using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using BarRaider.SdTools;
using EliteJournalReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite.Buttons
{

    [PluginActionId("com.mhwlng.elite.hyperspace")]
    public class Hyperspace : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    Function = string.Empty,
                    PrimaryImageFilename = string.Empty,
                    SecondaryImageFilename = string.Empty,
                    TertiaryImageFilename = string.Empty,
                    PrimaryColor = "#ffffff",
                    SecondaryColor = "#ffffff",
                    TertiaryColor = "#ffffff",
                    ClickSoundFilename = string.Empty,
                    ErrorSoundFilename = string.Empty
                };

                return instance;
            }

            [JsonProperty(PropertyName = "function")]
            public string Function { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "primaryImage")]
            public string PrimaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "secondaryImage")]
            public string SecondaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "tertiaryImage")]
            public string TertiaryImageFilename { get; set; }

            [JsonProperty(PropertyName = "primaryColor")]
            public string PrimaryColor { get; set; }

            [JsonProperty(PropertyName = "secondaryColor")]
            public string SecondaryColor { get; set; }

            [JsonProperty(PropertyName = "tertiaryColor")]
            public string TertiaryColor { get; set; }

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
        private Bitmap _tertiaryImage = null;

        private bool _primaryImageIsGif = false;
        private bool _secondaryImageIsGif = false;
        private bool _tertiaryImageIsGif = false;

        private string _primaryFile;
        private string _secondaryFile;
        private string _tertiaryFile;
        private CachedSound _clickSound = null;
        private CachedSound _errorSound = null;

        private SolidBrush _primaryBrush = new SolidBrush(Color.White);
        private SolidBrush _secondaryBrush = new SolidBrush(Color.White);
        private SolidBrush _tertiaryBrush = new SolidBrush(Color.White);

        private readonly Font drawFont = new Font("Arial", 60);

        private async Task HandleDisplay()
        {
            var myBitmap = _primaryImage; // Engaged Image
            var imgBase64 = _primaryFile;
            var bitmapImageIsGif = _primaryImageIsGif;
            var textBrush = _primaryBrush;
            var textHtmlColor = settings.PrimaryColor;

            var isDisabled = (EliteData.StatusData.Docked ||
                                EliteData.StatusData.Landed ||
                                EliteData.StatusData.LandingGearDown ||
                                EliteData.StatusData.CargoScoopDeployed ||

                                //EliteData.StatusData.SilentRunning ||
                                //EliteData.StatusData.ScoopingFuel ||
                                //EliteData.StatusData.IsInDanger ||
                                //EliteData.StatusData.BeingInterdicted ||
                                //EliteData.StatusData.HudInAnalysisMode ||

                                EliteData.StatusData.FsdMassLocked ||
                                //EliteData.StatusData.FsdCharging ||
                                EliteData.StatusData.FsdCooldown ||

                                //EliteData.StatusData.Supercruise ||
                                //EliteData.StatusData.FsdJump ||
                                EliteData.StatusData.HardpointsDeployed);

            if (isDisabled)
            {
                myBitmap = _tertiaryImage; // Disabled Image
                imgBase64 = _tertiaryFile;
                bitmapImageIsGif = _tertiaryImageIsGif;
                textBrush = _tertiaryBrush;
                textHtmlColor = settings.TertiaryColor;
            }
            else
            {
                switch (settings.Function)
                {
                    case "HYPERSUPERCOMBINATION":
                        if (!EliteData.StatusData.FsdJump)
                        {
                            myBitmap = _secondaryImage;
                            imgBase64 = _secondaryFile;
                            bitmapImageIsGif = _secondaryImageIsGif;
                            textBrush = _secondaryBrush;
                            textHtmlColor = settings.SecondaryColor;
                        }

                        break;
                    case "HYPERSPACE":
                        if (!EliteData.StatusData.FsdJump)
                        {
                            myBitmap = _secondaryImage;
                            imgBase64 = _secondaryFile;
                            bitmapImageIsGif = _secondaryImageIsGif;
                            textBrush = _secondaryBrush;
                            textHtmlColor = settings.SecondaryColor;
                        }

                        break;
                    case "SUPERCRUISE":
                        if (!EliteData.StatusData.Supercruise)
                        {
                            myBitmap = _secondaryImage;
                            imgBase64 = _secondaryFile;
                            bitmapImageIsGif = _secondaryImageIsGif;
                            textBrush = _secondaryBrush;
                            textHtmlColor = settings.SecondaryColor;
                        }

                        break;
                }
            }

            if (_primaryImage != null)
            {
                if (!bitmapImageIsGif && settings.Function != "SUPERCRUISE" && EliteData.StarSystem != EliteData.FsdTargetName && EliteData.RemainingJumpsInRoute > 0  && textHtmlColor != "#ff00ff")
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
                                    graphics.MeasureString(EliteData.RemainingJumpsInRoute.ToString(),
                                        testFont);

                                if (fontContainerHeight >= adjustedSizeNew.Height)
                                {
                                    var stringSize =
                                        graphics.MeasureString(EliteData.RemainingJumpsInRoute.ToString(),
                                            testFont);

                                    var x = (width - stringSize.Width) / 2.0;
                                    var y = 28.0 * (width / 256.0);

                                    graphics.DrawString(EliteData.RemainingJumpsInRoute.ToString(), testFont,
                                        textBrush, (float) x, (float) y);

                                    testFont.Dispose();

                                    break;
                                }
                            }
                        }

                        imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);
                    }
                }
                await Connection.SetImageAsync(imgBase64);
            }
        }

        public Hyperspace(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Hyperspace Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Hyperspace Constructor #2");

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
            if (InputRunning || Program.Bindings == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;

            var isDisabled = (EliteData.StatusData.Docked ||
                              EliteData.StatusData.Landed ||
                              EliteData.StatusData.LandingGearDown ||
                              EliteData.StatusData.CargoScoopDeployed ||

                              //EliteData.StatusData.SilentRunning ||
                              //EliteData.StatusData.ScoopingFuel ||
                              //EliteData.StatusData.IsInDanger ||
                              //EliteData.StatusData.BeingInterdicted ||
                              //EliteData.StatusData.HudInAnalysisMode ||

                              EliteData.StatusData.FsdMassLocked ||
                              //EliteData.StatusData.FsdCharging ||
                              EliteData.StatusData.FsdCooldown ||

                              //EliteData.StatusData.Supercruise ||
                              //EliteData.StatusData.FsdJump ||
                              EliteData.StatusData.HardpointsDeployed);

            if (!isDisabled)
            {
                switch (settings.Function)
                {
                    case "HYPERSUPERCOMBINATION"
                        : // context dependent, i.e. jump if another system is targeted, supercruise if not.
                        SendKeypress(Program.Bindings.HyperSuperCombination);
                        break;
                    case "SUPERCRUISE": // supercruise even if another system targeted
                        SendKeypress(Program.Bindings.Supercruise);
                        break;
                    case "HYPERSPACE": // jump
                        SendKeypress(Program.Bindings.Hyperspace);
                        break;
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
            InitializeSettings();

            AsyncHelper.RunSync(HandleDisplay);
        }

        private void InitializeSettings()
        {
            _clickSound = null;
            if (File.Exists(settings.ClickSoundFilename))
            {
                _clickSound = new CachedSound(settings.ClickSoundFilename);
            }

            _errorSound = null;
            if (File.Exists(settings.ErrorSoundFilename))
            {
                _errorSound = new CachedSound(settings.ErrorSoundFilename);
            }

            if (string.IsNullOrEmpty(settings.PrimaryColor))
            {
                settings.PrimaryColor = "#ffffff";
            }

            if (string.IsNullOrEmpty(settings.SecondaryColor))
            {
                settings.SecondaryColor = "#ffffff";
            }

            if (string.IsNullOrEmpty(settings.TertiaryColor))
            {
                settings.TertiaryColor = "#ffffff";
            }

            var converter = new ColorConverter();

            _primaryBrush = new SolidBrush((Color)converter.ConvertFromString(settings.PrimaryColor));
            _secondaryBrush = new SolidBrush((Color)converter.ConvertFromString(settings.SecondaryColor));
            _tertiaryBrush = new SolidBrush((Color)converter.ConvertFromString(settings.TertiaryColor));

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

            if (_tertiaryImage != null)
            {
                _tertiaryImage.Dispose();
                _tertiaryImage = null;
                _tertiaryFile = null;
                _tertiaryImageIsGif = false;
            }

            if (File.Exists(settings.PrimaryImageFilename))
            {
                _primaryImage = (Bitmap)Image.FromFile(settings.PrimaryImageFilename);

                _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);

                _primaryImageIsGif = CheckForGif(settings.PrimaryImageFilename);
            }

            if (File.Exists(settings.SecondaryImageFilename))
            {
                _secondaryImage = (Bitmap)Image.FromFile(settings.SecondaryImageFilename);

                _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);

                _secondaryImageIsGif = CheckForGif(settings.SecondaryImageFilename);
            }
            else
            {
                _secondaryImage = _primaryImage;

                _secondaryFile = _primaryFile;

                _secondaryImageIsGif = CheckForGif(settings.PrimaryImageFilename);
            }

            if (File.Exists(settings.TertiaryImageFilename))
            {
                _tertiaryImage = (Bitmap)Image.FromFile(settings.TertiaryImageFilename);

                _tertiaryFile = Tools.FileToBase64(settings.TertiaryImageFilename, true);

                _tertiaryImageIsGif = CheckForGif(settings.TertiaryImageFilename);
            }
            else
            {
                _tertiaryImage = _primaryImage;

                _tertiaryFile = _primaryFile;

                _tertiaryImageIsGif = CheckForGif(settings.PrimaryImageFilename);
            }

            if (_primaryImage == null)
            {
                _primaryImage = _secondaryImage;

                _primaryFile = _secondaryFile;

                _primaryImageIsGif = CheckForGif(settings.SecondaryImageFilename);
            }

            if (_primaryImage == null)
            {
                _primaryImage = _tertiaryImage;

                _primaryFile = _tertiaryFile;

                _primaryImageIsGif = CheckForGif(settings.TertiaryImageFilename);
            }

            

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
