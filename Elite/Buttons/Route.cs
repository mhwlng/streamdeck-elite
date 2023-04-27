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

    [PluginActionId("com.mhwlng.elite.route")]
    public class Route : EliteKeypadBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    PrimaryImageFilename = string.Empty,
                    TertiaryImageFilename = string.Empty,
                    PrimaryColor = "#ffffff",
                    TertiaryColor = "#ffffff",
                    ClickSoundFilename = string.Empty,
                    ErrorSoundFilename = string.Empty
                };

                return instance;
            }

            [FilenameProperty]
            [JsonProperty(PropertyName = "primaryImage")]
            public string PrimaryImageFilename { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "tertiaryImage")]
            public string TertiaryImageFilename { get; set; }

            [JsonProperty(PropertyName = "primaryColor")]
            public string PrimaryColor { get; set; }

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
        private Bitmap _tertiaryImage = null;

        private bool _primaryImageIsGif = false;
        private bool _tertiaryImageIsGif = false;

        private string _primaryFile;
        private string _tertiaryFile;
        private CachedSound _clickSound = null;
        private CachedSound _errorSound = null;

        private SolidBrush _primaryBrush = new SolidBrush(Color.White);
        private SolidBrush _tertiaryBrush = new SolidBrush(Color.White);

        private readonly Font drawFont = new Font("Arial", 60);

        private async Task HandleDisplay()
        {
            var myBitmap = _primaryImage; // Engaged Image
            var imgBase64 = _primaryFile;
            var bitmapImageIsGif = _primaryImageIsGif;
            var textBrush = _primaryBrush;
            var textHtmlColor = settings.PrimaryColor;

            var isDisabled = EliteData.RemainingJumpsInRoute == 0;

            if (isDisabled)
            {
                myBitmap = _tertiaryImage; // Disabled Image
                imgBase64 = _tertiaryFile;
                bitmapImageIsGif = _tertiaryImageIsGif;
                textBrush = _tertiaryBrush;
                textHtmlColor = settings.TertiaryColor;
            }
         

            if (_primaryImage != null)
            {
                if (!bitmapImageIsGif && EliteData.StarSystem != EliteData.FsdTargetName && EliteData.RemainingJumpsInRoute > 0  && textHtmlColor != "#ff00ff")
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
                    catch (Exception ex)
                    {
                        Logger.Instance.LogMessage(TracingLevel.FATAL, "Route HandleDisplay " + ex);
                    }
                }
                await Connection.SetImageAsync(imgBase64);
            }
        }

        public Route(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Route Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Route Constructor #2");

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
            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            var isDisabled = EliteData.RemainingJumpsInRoute == 0;


            if (!isDisabled)
            {
                 StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
                
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

            if (string.IsNullOrEmpty(settings.TertiaryColor))
            {
                settings.TertiaryColor = "#ffffff";
            }

            try
            {
                var converter = new ColorConverter();

                _primaryBrush = new SolidBrush((Color) converter.ConvertFromString(settings.PrimaryColor));
                _tertiaryBrush = new SolidBrush((Color) converter.ConvertFromString(settings.TertiaryColor));

                if (_primaryImage != null)
                {
                    _primaryImage.Dispose();
                    _primaryImage = null;
                    _primaryFile = null;
                    _primaryImageIsGif = false;
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
                    _primaryImage = (Bitmap) Image.FromFile(settings.PrimaryImageFilename);

                    _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);

                    _primaryImageIsGif = StreamDeckCommon.CheckForGif(settings.PrimaryImageFilename);
                }


                if (File.Exists(settings.TertiaryImageFilename))
                {
                    _tertiaryImage = (Bitmap) Image.FromFile(settings.TertiaryImageFilename);

                    _tertiaryFile = Tools.FileToBase64(settings.TertiaryImageFilename, true);

                    _tertiaryImageIsGif = StreamDeckCommon.CheckForGif(settings.TertiaryImageFilename);
                }
                else
                {
                    _tertiaryImage = _primaryImage;

                    _tertiaryFile = _primaryFile;

                    _tertiaryImageIsGif = StreamDeckCommon.CheckForGif(settings.PrimaryImageFilename);
                }

                if (_primaryImage == null)
                {
                    _primaryImage = _tertiaryImage;

                    _primaryFile = _tertiaryFile;

                    _primaryImageIsGif = StreamDeckCommon.CheckForGif(settings.TertiaryImageFilename);
                }

            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, "Route InitializeSettings " + ex);
            }

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
