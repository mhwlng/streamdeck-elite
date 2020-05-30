using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EliteJournalReader;
using StandardBindingInfo = Elite.StandardBindingInfo;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite
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
                    TertiaryImageFilename = string.Empty
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

        }

        private PluginSettings settings;
        private Bitmap _primaryImage = null;
        private Bitmap _secondaryImage = null;
        private Bitmap _tertiaryImage = null;

        private readonly Font drawFont = new Font("Arial", 60);

        private readonly SolidBrush whiteBrush = new SolidBrush(Color.White);
        private readonly SolidBrush blackBrush = new SolidBrush(Color.FromArgb(0x30, 030, 0x30));
        private readonly SolidBrush greyBrush = new SolidBrush(Color.FromArgb(0x90, 0x90, 0x90));


        private async Task HandleDisplay()
        {
            var myBitmap = _primaryImage; // Engaged Image

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
            }
            else
            {
                switch (settings.Function)
                {
                    case "HYPERSUPERCOMBINATION":
                        if (!EliteData.StatusData.FsdJump)
                        {
                            myBitmap = _secondaryImage;
                        }

                        break;
                    case "HYPERSPACE":
                        if (!EliteData.StatusData.FsdJump)
                        {
                            myBitmap = _secondaryImage;
                        }

                        break;
                    case "SUPERCRUISE":
                        if (!EliteData.StatusData.Supercruise)
                        {
                            myBitmap = _secondaryImage;
                        }

                        break;
                }
            }

            if (_primaryImage != null)
            {
                using (var bitmap = new Bitmap(myBitmap))
                {
                    if (settings.Function != "SUPERCRUISE")
                    {
                        if (EliteData.StarSystem != EliteData.FsdTargetName && EliteData.RemainingJumpsInRoute > 0)
                        {
                            using (var graphics = Graphics.FromImage(bitmap))
                            {
                                var width = bitmap.Width; // assumes rectangular bitmap

                                var fontContainerHeight = 100 * (width / 256.0);

                                for (int adjustedSize = 60; adjustedSize >= 10; adjustedSize-=5)
                                {
                                    var testFont = new Font(drawFont.Name, adjustedSize, drawFont.Style);

                                    var adjustedSizeNew = graphics.MeasureString(EliteData.RemainingJumpsInRoute.ToString(), testFont);

                                    if (fontContainerHeight >= adjustedSizeNew.Height)
                                    {
                                        var stringSize = graphics.MeasureString(EliteData.RemainingJumpsInRoute.ToString(), testFont);

                                        var x = (width - stringSize.Width) / 2.0;
                                        var y = 28.0 * (width / 256.0);

                                        graphics.DrawString(EliteData.RemainingJumpsInRoute.ToString(), testFont, whiteBrush, (float)x, (float)y);

                                        testFont.Dispose();

                                        break;
                                    }
                                }

                            }
                        }
                    }

                    var imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);

                    await Connection.SetImageAsync(imgBase64);
                }
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
                HandleFilenames();

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

            switch (settings.Function)
            {
                case "HYPERSUPERCOMBINATION": // context dependent, i.e. jump if another system is targeted, supercruise if not.
                    SendKeypress(Program.Bindings.HyperSuperCombination);
                    break;
                case "SUPERCRUISE": // supercruise even if another system targeted
                    SendKeypress(Program.Bindings.Supercruise);
                    break;
                case "HYPERSPACE": // jump
                    SendKeypress(Program.Bindings.Hyperspace);
                    break;
            }


            AsyncHelper.RunSync(HandleDisplay);
        }


        public override void KeyReleased(KeyPayload payload)
        {

        }

        public override void Dispose()
        {
            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called #1");

            Program.JournalWatcher.AllEventHandler -= HandleEliteEvents;
        }

        public override async void OnTick()
        {
            await HandleDisplay();
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "ReceivedSettings");

            // New in StreamDeck-Tools v2.0:
            BarRaider.SdTools.Tools.AutoPopulateSettings(settings, payload.Settings);
            HandleFilenames();

            AsyncHelper.RunSync(HandleDisplay);
        }

        private void HandleFilenames()
        {
            if (_primaryImage != null)
            {
                _primaryImage.Dispose();
                _primaryImage = null;
            }

            if (_secondaryImage != null)
            {
                _secondaryImage.Dispose();
                _secondaryImage = null;
            }

            if (_tertiaryImage != null)
            {
                _tertiaryImage.Dispose();
                _tertiaryImage = null;
            }

            if (File.Exists(settings.PrimaryImageFilename))
            {
                _primaryImage = (Bitmap)Image.FromFile(settings.PrimaryImageFilename);
            }

            if (File.Exists(settings.SecondaryImageFilename))
            {
                _secondaryImage = (Bitmap)Image.FromFile(settings.SecondaryImageFilename);
            }
            else
            {
                _secondaryImage = _primaryImage;
            }

            if (File.Exists(settings.TertiaryImageFilename))
            {
                _tertiaryImage = (Bitmap)Image.FromFile(settings.TertiaryImageFilename);
            }
            else
            {
                _tertiaryImage = _primaryImage;
            }

            if (_primaryImage == null)
            {
                _primaryImage = _secondaryImage;
            }

            if (_primaryImage == null)
            {
                _primaryImage = _tertiaryImage;
            }

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
