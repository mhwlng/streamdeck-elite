using System;
using System.Drawing;
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

    [PluginActionId("com.mhwlng.elite.firegroupdial")]
    public class FireGroupDial : EliteDialBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    FunctionPress = string.Empty,
                    FunctionTouchLongPress = string.Empty,
                    FunctionTouchPress = string.Empty
                };

                return instance;
            }

  
            [JsonProperty(PropertyName = "functionpress")]
            public string FunctionPress { get; set; }

            [JsonProperty(PropertyName = "functiontouchpress")]
            public string FunctionTouchPress { get; set; }

            [JsonProperty(PropertyName = "functiontouchlongpress")]
            public string FunctionTouchLongPress { get; set; }

        }


        PluginSettings settings;
   
        private int ccwPending;
        private int cwPending;
      
        //private Thread dialWatcherThread = null;
        //private CancellationTokenSource cancellationTokenSource;


        public FireGroupDial(SDConnection connection, InitialPayload payload) : base(connection, payload)
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
            /*
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
            dialWatcherThread.Start();*/
        }

        public override void Dispose()
        {
           /*
             if (cancellationTokenSource != null)
            
                cancellationTokenSource.Cancel();

            if (dialWatcherThread != null)
                dialWatcherThread.Join();*/

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

        public override void DialDown(DialPayload payload)
        {
            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            EliteKeys.SendKeypressDown(settings.FunctionPress);
        }

        public override void DialUp(DialPayload payload)
        {

            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            EliteKeys.SendKeypressUp(settings.FunctionPress);
        }

        public override void DialRotate(DialRotatePayload payload)
        {

            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            if (payload.Ticks > 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.INFO, $"DialRotate CW: {payload.Ticks}");

                cwPending += payload.Ticks;

                for (var ticks = 0; ticks < cwPending; ticks++)
                {
                    EliteKeys.SendKeypress("CycleFireGroupNext");

                }

                cwPending = 0;
            }

            else if (payload.Ticks < 0)
            {
 
                //Logger.Instance.LogMessage(TracingLevel.INFO, $"DialRotate CCW: {payload.Ticks}");

                ccwPending += -payload.Ticks;
                
                for (var ticks = 0; ticks < ccwPending; ticks++)
                {
                    EliteKeys.SendKeypress("CycleFireGroupPrevious");
                }

                ccwPending = 0;
            }

        
        }


        public override async void OnTick()
        {
            base.OnTick();
            
            await Connection.SetFeedbackAsync("value", "FG : " + Convert.ToChar(65+EliteData.StatusData.Firegroup));
           
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
            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
		}

	}
}
