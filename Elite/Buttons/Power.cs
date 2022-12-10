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

    [PluginActionId("com.mhwlng.elite.power")]
    public class Power : EliteKeypadBase
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

            [JsonProperty(PropertyName = "primaryPipColor")]
            public string PrimaryPipColor { get; set; }

            [JsonProperty(PropertyName = "secondaryPipColor")]
            public string SecondaryPipColor { get; set; }

            [JsonProperty(PropertyName = "secondaryHalfPipColor")]
            public string SecondaryHalfPipColor { get; set; }

            [JsonProperty(PropertyName = "secondaryNoPipColor")]
            public string SecondaryNoPipColor { get; set; }

            [JsonProperty(PropertyName = "tertiaryPipColor")]
            public string TertiaryPipColor { get; set; }

            [JsonProperty(PropertyName = "tertiaryHalfPipColor")]
            public string TertiaryHalfPipColor { get; set; }

            [JsonProperty(PropertyName = "tertiaryNoPipColor")]
            public string TertiaryNoPipColor { get; set; }


        }

        private DateTime? lastPressedTime = null;
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

        private SolidBrush _primaryPipBrush = new SolidBrush(Color.White);

        private SolidBrush _secondaryPipBrush = new SolidBrush(Color.White);
        private SolidBrush _secondaryHalfPipBrush = new SolidBrush(Color.FromArgb(0x90, 0x90, 0x90));
        private SolidBrush _secondaryNoPipBrush = new SolidBrush(Color.FromArgb(0x30, 030, 0x30));

        private SolidBrush _tertiaryPipBrush = new SolidBrush(Color.White);
        private SolidBrush _tertiaryHalfPipBrush = new SolidBrush(Color.FromArgb(0x90, 0x90, 0x90));
        private SolidBrush _tertiaryNoPipBrush = new SolidBrush(Color.FromArgb(0x30, 030, 0x30));

        private async Task HandleDisplay()
        {
            var timeDiff = DateTime.Now - (lastPressedTime ?? DateTime.Now);

            if (EliteData.UnderAttack && (DateTime.Now - EliteData.LastUnderAttackEvent).Seconds > 20)
            {
                EliteData.UnderAttack = false;
            }

            if (timeDiff.TotalMilliseconds > 500)
            {
                var repeatCount = 3;

                switch (settings.Function)
                {
                    case "SYS":
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy, repeatCount);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseSystemsPower, repeatCount);
                        EliteData.StatusData.Pips[0] = 8;
                        break;
                    case "ENG":
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy, repeatCount);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseEnginesPower, repeatCount);
                        EliteData.StatusData.Pips[1] = 8;
                        break;
                    case "WEP":
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy, repeatCount);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseWeaponsPower, repeatCount);
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
                var bitmapImage = pips == 8 ? _primaryImage : _secondaryImage;
                var imgBase64 = pips == 8 ? _primaryFile : _secondaryFile;
                var bitmapImageIsGif = pips == 8 ? _primaryImageIsGif : _secondaryImageIsGif;

                var pipBrush = pips == 8 ? _primaryPipBrush : _secondaryPipBrush;
                var pipHtmlColor = pips == 8 ? settings.PrimaryPipColor : settings.SecondaryPipColor;

                var halfPipBrush = _secondaryHalfPipBrush;

                var noPipBrush = _secondaryNoPipBrush;
                var noPipHtmlColor = settings.SecondaryNoPipColor;

                if (settings.Function == "SYS" && pips < 8 && EliteData.UnderAttack)
                {
                    bitmapImage = _tertiaryImage;
                    imgBase64 = _tertiaryFile;
                    bitmapImageIsGif = _tertiaryImageIsGif;

                    pipBrush = _tertiaryPipBrush;
                    pipHtmlColor = settings.TertiaryPipColor;

                    halfPipBrush = _tertiaryHalfPipBrush;

                    noPipBrush = _tertiaryNoPipBrush;
                    noPipHtmlColor = settings.TertiaryNoPipColor;
                }

                if (!bitmapImageIsGif && settings.Function != "RST")
                {
                    try
                    {
                        using (var bitmap = new Bitmap(bitmapImage))
                        {
                            using (var graphics = Graphics.FromImage(bitmap))
                            {
                                var width = bitmap.Width; // assumes rectangular bitmap

                                for (var i = 2; i <= 8; i += 2)
                                {
                                    var x = (12.0 + (i / 2) * 40) * (width / 256.0);
                                    var y = 58.0 * (width / 256.0);
                                    var w = 30.0 * (width / 256.0);
                                    var h = 30.0 * (width / 256.0);

                                    if (pips > 0 && i <= pips + 1)
                                    {
                                        if (pipHtmlColor != "#ff00ff")
                                        {
                                            var brush = (pips == i - 1) ? halfPipBrush : pipBrush;

                                            graphics.FillRectangle(brush, (float) x, (float) y, (float) w, (float) h);
                                        }
                                    }
                                    else if (noPipHtmlColor != "#ff00ff")
                                    {
                                        graphics.FillRectangle(noPipBrush, (float) x, (float) y, (float) w, (float) h);
                                    }
                                }
                            }

                            imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.LogMessage(TracingLevel.FATAL, "Power HandleDisplay " + ex);
                    }
                }

                await Connection.SetImageAsync(imgBase64);
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
                HandleFileNames();

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
            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            lastPressedTime = DateTime.Now;

            switch (settings.Function)
            {
                case "SYS":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
                    AdjustPips(0);
                    break;
                case "ENG":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
                    AdjustPips(1);
                    break;
                case "WEP":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
                    AdjustPips(2);
                    break;
                case "RST":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ResetPowerDistribution);

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
            if (string.IsNullOrEmpty(settings.PrimaryPipColor))
            {
                settings.PrimaryPipColor = "#ffffff";
            }

            if (string.IsNullOrEmpty(settings.SecondaryPipColor))
            {
                settings.SecondaryPipColor = "#ffffff";
            }

            if (string.IsNullOrEmpty(settings.TertiaryPipColor))
            {
                settings.TertiaryPipColor = "#ffffff";
            }

            if (string.IsNullOrEmpty(settings.SecondaryHalfPipColor))
            {
                settings.SecondaryHalfPipColor = "#909090";
            }

            if (string.IsNullOrEmpty(settings.TertiaryHalfPipColor))
            {
                settings.TertiaryHalfPipColor = "#909090";
            }


            if (string.IsNullOrEmpty(settings.SecondaryNoPipColor))
            {
                settings.SecondaryNoPipColor = "#303030";
            }

            if (string.IsNullOrEmpty(settings.TertiaryNoPipColor))
            {
                settings.TertiaryNoPipColor = "#303030";
            }

            try
            {
                var converter = new ColorConverter();

                _primaryPipBrush = new SolidBrush((Color) converter.ConvertFromString(settings.PrimaryPipColor));

                _secondaryPipBrush = new SolidBrush((Color) converter.ConvertFromString(settings.SecondaryPipColor));
                _secondaryHalfPipBrush =
                    new SolidBrush((Color) converter.ConvertFromString(settings.SecondaryHalfPipColor));
                _secondaryNoPipBrush =
                    new SolidBrush((Color) converter.ConvertFromString(settings.SecondaryNoPipColor));

                _tertiaryPipBrush = new SolidBrush((Color) converter.ConvertFromString(settings.TertiaryPipColor));
                _tertiaryHalfPipBrush =
                    new SolidBrush((Color) converter.ConvertFromString(settings.TertiaryHalfPipColor));
                _tertiaryNoPipBrush = new SolidBrush((Color) converter.ConvertFromString(settings.TertiaryNoPipColor));

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
                    _primaryImage = (Bitmap) Image.FromFile(settings.PrimaryImageFilename);

                    _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);

                    _primaryImageIsGif = StreamDeckCommon.CheckForGif(settings.PrimaryImageFilename);
                }

                if (File.Exists(settings.SecondaryImageFilename))
                {
                    _secondaryImage = (Bitmap) Image.FromFile(settings.SecondaryImageFilename);

                    _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);

                    _secondaryImageIsGif = StreamDeckCommon.CheckForGif(settings.SecondaryImageFilename);
                }
                else
                {
                    _secondaryImage = _primaryImage;

                    _secondaryFile = _primaryFile;

                    _secondaryImageIsGif = StreamDeckCommon.CheckForGif(settings.PrimaryImageFilename);
                }

                if (_primaryImage == null)
                {
                    _primaryImage = _secondaryImage;

                    _primaryFile = _secondaryFile;

                    _primaryImageIsGif = StreamDeckCommon.CheckForGif(settings.SecondaryImageFilename);
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
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, "Power HandleFileNames " + ex);
            }

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
