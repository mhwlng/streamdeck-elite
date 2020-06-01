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
                    SecondaryImageFilename = string.Empty
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

        }

        private PluginSettings settings;
        private Bitmap _primaryImage = null;
        private Bitmap _secondaryImage = null;

        private readonly Font drawFont = new Font("Arial", 60);

        private readonly SolidBrush whiteBrush = new SolidBrush(Color.White);
        private readonly SolidBrush blackBrush = new SolidBrush(Color.FromArgb(0x30, 030, 0x30));
        private readonly SolidBrush greyBrush = new SolidBrush(Color.FromArgb(0x90, 0x90, 0x90));


        private async Task HandleDisplay()
        {
            var isDisabled = (EliteData.StatusData.Docked ||
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

            if (_primaryImage != null)
            {
                using (var bitmap = new Bitmap(myBitmap))
                {
                    if (EliteData.LimpetCount > 0)
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
                                    var stringSize = graphics.MeasureString(EliteData.LimpetCount.ToString(), testFont);

                                    var x = (width - stringSize.Width) / 2.0;
                                    var y = 28.0 * (width / 256.0);

                                    graphics.DrawString(EliteData.LimpetCount.ToString(), testFont, whiteBrush,
                                        (float) x, (float) y);

                                    testFont.Dispose();

                                    break;
                                }
                            }
                        }
                    }

                    var imgBase64 = BarRaider.SdTools.Tools.ImageToBase64(bitmap, true);

                    await Connection.SetImageAsync(imgBase64);
                }
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

            if (EliteData.LimpetCount > 0 && !string.IsNullOrEmpty(settings.Firegroup) && !string.IsNullOrEmpty(settings.Fire))
            {
                var cycle = Convert.ToInt32(settings.Firegroup) - EliteData.StatusData.Firegroup;

                if (cycle < 0)
                {
                    for (var f = 0; f < -cycle; f++)
                    {
                        SendKeypress(Program.Bindings.CycleFireGroupPrevious);
                        Thread.Sleep(30);
                    }
                }
                else if (cycle > 0)
                {
                    for (var f = 0 ; f < cycle; f++)
                    {
                        SendKeypress(Program.Bindings.CycleFireGroupNext);
                        Thread.Sleep(30);
                    }
                }

                Thread.Sleep(100);

                SendKeypress(settings.Fire == "PRIMARY"
                    ? Program.Bindings.PrimaryFire
                    : Program.Bindings.SecondaryFire);

                Thread.Sleep(100);

                if (cycle < 0)
                {
                    for (var f = 0; f < -cycle; f++)
                    {
                        Thread.Sleep(30);
                        SendKeypress(Program.Bindings.CycleFireGroupNext);
                    }

                }
                else if (cycle > 0)
                {
                    for (var f = 0; f < cycle; f++)
                    {
                        Thread.Sleep(30);
                        SendKeypress(Program.Bindings.CycleFireGroupPrevious);
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
