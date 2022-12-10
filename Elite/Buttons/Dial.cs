using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BarRaider.SdTools;
using BarRaider.SdTools.Payloads;
using EliteJournalReader.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite.Buttons
{

    [PluginActionId("com.mhwlng.elite.dial")]
    public class Dial : EliteDialBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    FunctionCw = string.Empty,
                    FunctionCcw = string.Empty,
                    FunctionPress = string.Empty,
                    FunctionTouchLongPress = string.Empty,
                    FunctionTouchPress = string.Empty
                };

                return instance;
            }

            [JsonProperty(PropertyName = "functioncw")]
            public string FunctionCw { get; set; }

            [JsonProperty(PropertyName = "functionccw")]
            public string FunctionCcw { get; set; }

            [JsonProperty(PropertyName = "delay")]
            public string Delay { get; set; }

            [JsonProperty(PropertyName = "functionpress")]
            public string FunctionPress { get; set; }

            [JsonProperty(PropertyName = "functiontouchpress")]
            public string FunctionTouchPress { get; set; }

            [JsonProperty(PropertyName = "functiontouchlongpress")]
            public string FunctionTouchLongPress { get; set; }

        }


        PluginSettings settings;
        private int? _delay = null;

        private bool ccwIsDown;
        private bool cwIsDown;

        private int ccwPending;
        private int cwPending;

        private DateTime? lastDialTime = null;

        private Thread dialWatcherThread = null;
        private CancellationTokenSource cancellationTokenSource;


        public Dial(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Static Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Static Constructor #2");

                settings = payload.Settings.ToObject<PluginSettings>();
                HandleFileNames();
            }

            cancellationTokenSource = new CancellationTokenSource();

            dialWatcherThread = new Thread(state =>
            {
                while (true)
                {
                    if (Program.Binding == null)
                    {
                        StreamDeckCommon.ForceStop = true;

                        return;
                    }
                    else if (Program.Binding == null || cancellationTokenSource.IsCancellationRequested)
                    {
                        return;
                    }

                    var timeDiff = DateTime.Now - (lastDialTime ?? DateTime.Now);

                    if ((ccwIsDown || cwIsDown) && timeDiff.TotalMilliseconds >= 100)
                    {
                        //Logger.Instance.LogMessage(TracingLevel.INFO, $"DialRotate Released");

                        ReleaseCcw();

                        ReleaseCw();

                        lastDialTime = DateTime.Now;

                    }

                    Thread.Sleep(100);

                }

            })
            {
                Name = "Dial Watcher",
                IsBackground = true
            };
            dialWatcherThread.Start();
        }

        public override void Dispose()
        {
            if (cancellationTokenSource != null)
                cancellationTokenSource.Cancel();

            if (dialWatcherThread != null)
                dialWatcherThread.Join();

            base.Dispose();

            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called #1");

        }
        public override void TouchPress(TouchpadPressPayload payload)
        {
            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            if (payload.IsLongPress)
            {

                //Logger.Instance.LogMessage(TracingLevel.INFO, $"TouchPress: LongPress");

                EliteKeys.SendKeypress(settings.FunctionTouchLongPress);

            }
            else
            {

                //Logger.Instance.LogMessage(TracingLevel.INFO, $"TouchPress: Press");

                EliteKeys.SendKeypress(settings.FunctionTouchPress);
            }
        }

        public override void DialPress(DialPressPayload payload)
        {

            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            if (payload.IsDialPressed)
            {
                EliteKeys.SendKeypressDown(settings.FunctionPress);
            }
            else
            {
                EliteKeys.SendKeypressUp(settings.FunctionPress);
            }
        }

        private void ReleaseCw()
        {
            if (cwIsDown)
            {
                EliteKeys.SendKeypressUp(settings.FunctionCw);

                Thread.Sleep(100);
                cwIsDown = false;
                cwPending = 0;
            }
        }

        private void ReleaseCcw()
        {
            if (ccwIsDown)
            {
                EliteKeys.SendKeypressUp(settings.FunctionCcw);

                Thread.Sleep(100);
                ccwIsDown = false;
                ccwPending = 0;
            }
        }
        public override void DialRotate(DialRotatePayload payload)
        {

            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            lastDialTime = DateTime.Now;

            if (payload.Ticks > 0)
            {
                ReleaseCcw();

                //Logger.Instance.LogMessage(TracingLevel.INFO, $"DialRotate CW: {payload.Ticks}");

                if (!cwIsDown)
                {
                    EliteKeys.SendKeypressDown(settings.FunctionCw);

                    cwIsDown = true;
                    cwPending += payload.Ticks;
                }
            }
            else if (payload.Ticks < 0)
            {
                ReleaseCw();

                //Logger.Instance.LogMessage(TracingLevel.INFO, $"DialRotate CCW: {payload.Ticks}");

                if (!ccwIsDown)
                {
                    EliteKeys.SendKeypressDown(settings.FunctionCcw);

                    ccwIsDown = true;
                    ccwPending += -payload.Ticks;
                }
            }
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "ReceivedSettings");

            // New in StreamDeck-Tools v2.0:
            BarRaider.SdTools.Tools.AutoPopulateSettings(settings, payload.Settings);
            HandleFileNames();
        }

        private void HandleFileNames()
        {
            _delay = null;

            if (!string.IsNullOrEmpty(settings.Delay))
            {
                var ok = int.TryParse(settings.Delay, out var delay);
                if (ok && (delay > 0))
                {
                    _delay = delay;
                }
            }

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
		}

	}
}
