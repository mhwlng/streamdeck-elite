using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.Events;
using StandardBindingInfo = Elite.EliteApi.StandardBindingInfo;

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

        private bool _underAttack = false;
        private DateTime _lastUnderAttackEvent = DateTime.Now;

        protected EventHandler<UnderAttackInfo> HandleUnderAttackEventsDelegate;


        private async Task HandleDisplay()
        {
            string imgBase64;

            var isPrimary = false;

            if (_underAttack && (DateTime.Now - _lastUnderAttackEvent).Seconds > 20)
            {
                _underAttack = false;
            }

            switch (settings.Function)
            {
                case "SelectHighestThreat":
                    isPrimary = !_underAttack;
                    break;
                case "DeployChaff":
                    isPrimary = !_underAttack;
                    break;

                case "DeployHeatsink":
                    isPrimary = !Program.EliteApi.Status.Overheating;
                    break;

                case "DeployShieldCell":
                    isPrimary = Program.EliteApi.Status.Shields;
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
                Logger.Instance.LogMessage(TracingLevel.DEBUG, "Alarm Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                Logger.Instance.LogMessage(TracingLevel.DEBUG, "Alarm Constructor #2");

                settings = payload.Settings.ToObject<PluginSettings>();
                HandleFilenames();

                AsyncHelper.RunSync(() => HandleDisplay());

            }

            Program.EliteApi.Events.AllEvent += async (sender, e) => await HandleDisplay();

            HandleUnderAttackEventsDelegate = UnderAttackEvent;

            Program.EliteApi.Events.UnderAttackEvent += HandleUnderAttackEventsDelegate;
        }

        private void UnderAttackEvent(object sender, UnderAttackInfo e)
        {
            if (e.Target == "You")
            {
                _underAttack = true;
                _lastUnderAttackEvent = DateTime.Now;
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
                    _underAttack = false;
                    break;
                case "DeployChaff":
                    SendKeypress(Program.Bindings.FireChaffLauncher);
                    _underAttack = false;
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
            Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called #1");
        }

        public override async void OnTick()
        {
            await HandleDisplay();
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.DEBUG, "ReceivedSettings");

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
