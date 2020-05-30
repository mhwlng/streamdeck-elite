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

    [PluginActionId("com.mhwlng.elite.power")]
    public class Power : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    Function = string.Empty,
                    PrimaryImageFilename = string.Empty,
                    SecondaryImageFilename = string.Empty
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
        }

        private DateTime? lastPressedTime = null;
        private PluginSettings settings;
        private Bitmap _primaryImage = null;
        private Bitmap _secondaryImage = null;
				
        private readonly SolidBrush whiteBrush = new SolidBrush(Color.White);
        private readonly SolidBrush blackBrush = new SolidBrush(Color.FromArgb(0x30, 030, 0x30));
        private readonly SolidBrush greyBrush = new SolidBrush(Color.FromArgb(0x90, 0x90, 0x90));


        private async Task HandleDisplay()
        {
            var timeDiff = DateTime.Now - (lastPressedTime ?? DateTime.Now);

            // ??????????? handle SRV buttons ????????

            if (timeDiff.TotalMilliseconds > 500)
            {
                var repeatCount = 3;

                switch (settings.Function)
                {
                    case "SYS":
                        SendKeypress(Program.Bindings.IncreaseSystemsPower, repeatCount);
                        EliteData.StatusData.Pips[0] = 8;
                        break;
                    case "ENG":
                        SendKeypress(Program.Bindings.IncreaseEnginesPower, repeatCount);
                        EliteData.StatusData.Pips[1] = 8;
                        break;
                    case "WEP":
                        SendKeypress(Program.Bindings.IncreaseWeaponsPower, repeatCount);
                        EliteData.StatusData.Pips[2] = 8;
                        break;
                }

                lastPressedTime = null;
            }

            long pips = 0;
            switch (settings.Function)
            {
                case "SYS":
                    pips = EliteData.StatusData.Pips[0];
                    break;
                case "ENG":
                    pips = EliteData.StatusData.Pips[1];
                    break;
                case "WEP":
                    pips = EliteData.StatusData.Pips[2];
                    break;
            }

            if (_primaryImage != null)
            {
                using (var bitmap = new Bitmap(pips == 8 ? _primaryImage : _secondaryImage))
                {
                    if (settings.Function != "RST")
                    {
                        using (var graphics = Graphics.FromImage(bitmap))
                        {
                            var width = bitmap.Width; // assumes rectangular bitmap

                            var outline = new Pen(whiteBrush, 1);

                            for (var i = 2; i <= 8; i += 2)
                            {
                                var x = (12.0 + (i / 2) * 40) * (width/256.0);
                                var y = 58.0 * (width / 256.0);
                                var w = 30.0 * (width / 256.0);
                                var h = 30.0 * (width / 256.0);

                                if (pips > 0 && i <= pips + 1)
                                {
                                    var brush = (pips == i - 1) ? greyBrush : whiteBrush;

                                    graphics.FillRectangle(brush, (float)x, (float)y, (float)w, (float)h);
                                }
                                else
                                {
                                    graphics.FillRectangle(blackBrush, (float)x, (float)y, (float)w, (float)h);
                                }
                            }
                        }
                    }

                    var imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);

                    await Connection.SetImageAsync(imgBase64);
                }
            }
        }

        public Power(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Power Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Power Constructor #2");

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

        private void AdjustPips(int index)
        {
            if (EliteData.StatusData.Pips[index] < 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i != index)
                    {
                        EliteData.StatusData.Pips[i]--;
                    }
                    else
                    {
                        EliteData.StatusData.Pips[i] += 2;
                    }

                    if (EliteData.StatusData.Pips[i] < 0)
                    {
                        EliteData.StatusData.Pips[i] = 0;
                    }
                    else if (EliteData.StatusData.Pips[i] > 8)
                    {
                        EliteData.StatusData.Pips[i] = 8;
                    }
                }
            }
        }

        public override void KeyPressed(KeyPayload payload)
        {
            if (InputRunning || Program.Bindings == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;

            lastPressedTime = DateTime.Now;

            // ??????????? handle SRV buttons ????????

            switch (settings.Function)
            {
                case "SYS":
                    SendKeypress(Program.Bindings.IncreaseSystemsPower);
                    AdjustPips(0);
                    break;
                case "ENG":
                    SendKeypress(Program.Bindings.IncreaseEnginesPower);
                    AdjustPips(1);
                    break;
                case "WEP":
                    SendKeypress(Program.Bindings.IncreaseWeaponsPower);
                    AdjustPips(2);
                    break;
                case "RST":
                    SendKeypress(Program.Bindings.ResetPowerDistribution);

                    EliteData.StatusData.Pips[0] = 4;
                    EliteData.StatusData.Pips[1] = 4;
                    EliteData.StatusData.Pips[2] = 4;

                    break;
            }

            AsyncHelper.RunSync(HandleDisplay);
        }


        public override void KeyReleased(KeyPayload payload)
        {
            lastPressedTime = null;
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

            if (_primaryImage == null)
            {
                _primaryImage = _secondaryImage;
            }

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
