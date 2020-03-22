using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using StandardBindingInfo = Elite.StandardBindingInfo;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite
{

    [PluginActionId("com.mhwlng.elite.alarm")]
    public class Alarm : EliteBase
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


        PluginSettings settings;
        private string _primaryFile;
        private string _secondaryFile;


        private async Task HandleDisplay()
        {
            string imgBase64;

            var isPrimary = false;

            if (EliteData.UnderAttack && (DateTime.Now - EliteData.LastUnderAttackEvent).Seconds > 20)
            {
                EliteData.UnderAttack = false;
            }

            switch (settings.Function)
            {
                case "SelectHighestThreat":
                    isPrimary = !EliteData.UnderAttack;
                    break;
                case "DeployChaff":
                    isPrimary = !EliteData.UnderAttack;
                    break;

                case "DeployHeatsink":
                    isPrimary = !EliteData.StatusData.Overheating;
                    break;

                case "DeployShieldCell":
                    isPrimary = EliteData.StatusData.ShieldsUp;
                    break;
            }

            if (isPrimary)
            {
                if (!string.IsNullOrWhiteSpace(_primaryFile))
                {
                    imgBase64 = _primaryFile;
                    await Connection.SetImageAsync(imgBase64);
                }
                
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(_secondaryFile))
                {
                    imgBase64 = _secondaryFile;
                    await Connection.SetImageAsync(imgBase64);
                }
            }

        }

        public Alarm(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Alarm Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Alarm Constructor #2");

                settings = payload.Settings.ToObject<PluginSettings>();
                HandleFilenames();

                AsyncHelper.RunSync(() => HandleDisplay());

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

            switch (settings.Function)
            {
                case "SelectHighestThreat":
                    SendKeypress(Program.Bindings.SelectHighestThreat);
                    EliteData.UnderAttack = false;
                    break;
                case "DeployChaff":
                    SendKeypress(Program.Bindings.FireChaffLauncher);
                    EliteData.UnderAttack = false;
                    break;

                case "DeployHeatsink":
                    SendKeypress(Program.Bindings.DeployHeatSink);
                    break;
                case "DeployShieldCell":
                    SendKeypress(Program.Bindings.UseShieldCell);
                    break;
            }


        }

        public override void Dispose()
        {
            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called #1");
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
            _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);
            _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
