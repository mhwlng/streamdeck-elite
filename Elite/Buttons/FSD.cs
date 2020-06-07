using System.Drawing;
using System.IO;
using System.Reflection;
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

    [PluginActionId("com.mhwlng.elite.fsd")]
    public class FSD : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    PrimaryImageFilename = string.Empty,
                    SecondaryImageFilename = string.Empty,
                    TertiaryImageFilename = string.Empty
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

            if (!EliteData.StatusData.Supercruise)
            {
                myBitmap = _tertiaryImage; // Disabled Image
            }
            else
            {
                if (EliteData.StatusData.GuiFocus != StatusGuiFocus.FSSMode)
                {
                    myBitmap = _secondaryImage;
                }
            }

            if (_primaryImage != null)
            {
                using (var bitmap = new Bitmap(myBitmap))
                {
                    var imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);

                    await Connection.SetImageAsync(imgBase64);
                }
            }
        }

        public FSD(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "FSD Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "FSD Constructor #2");

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

            if (EliteData.StatusData.Supercruise)
            {
                if (EliteData.StatusData.GuiFocus == StatusGuiFocus.FSSMode)
                {
                    SendKeypress(Program.Bindings.ExplorationFSSQuit);

                    if (EliteData.StatusData.HudInAnalysisMode)
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
