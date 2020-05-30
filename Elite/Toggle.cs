using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using EliteJournalReader;
using StandardBindingInfo = Elite.StandardBindingInfo;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite
{
    public static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory = new
            TaskFactory(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => TaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => TaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }

    [PluginActionId("com.mhwlng.elite")]
    public class Toggle : EliteBase
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

            switch (settings.Function)
            {
                case "ToggleCargoScoop":
                    isPrimary = EliteData.StatusData.CargoScoopDeployed;
                    break;
                case "LandingGearToggle":
                    isPrimary = EliteData.StatusData.LandingGearDown;
                    break;

                case "ToggleFlightAssist":
                    isPrimary = !EliteData.StatusData.FlightAssistOff;
                    break;

                case "ShipSpotLightToggle":
                    isPrimary = EliteData.StatusData.LightsOn;
                    break;

                case "NightVisionToggle":
                    isPrimary = EliteData.StatusData.NightVision;
                    break;

                case "PlayerHUDModeToggle":
                    isPrimary = EliteData.StatusData.HudInAnalysisMode;
                    break;

                case "DeployHardpointToggle":
                    isPrimary = EliteData.StatusData.HardpointsDeployed;
                    break;

                case "Supercruise":
                    isPrimary = EliteData.StatusData.Supercruise;
                    break;

                case "ToggleButtonUpInput":
                    isPrimary = EliteData.StatusData.SilentRunning;
                    break;

                case "ToggleBuggyTurretButton":
                    isPrimary = EliteData.StatusData.SrvTurret;
                    break;

                case "ToggleDriveAssist":
                    isPrimary = EliteData.StatusData.SrvDriveAssist;
                    break;

                case "AutoBreakBuggyButton":
                    isPrimary = EliteData.StatusData.SrvHandbrake;
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

        public Toggle(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Toggle Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Toggle Constructor #2");

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
                case "ToggleCargoScoop":
                    SendKeypress(Program.Bindings.ToggleCargoScoop);
                    break;
                case "LandingGearToggle":
                    SendKeypress(Program.Bindings.LandingGearToggle);
                    break;

                case "ToggleFlightAssist":
                    SendKeypress(Program.Bindings.ToggleFlightAssist);
                    break;

                case "ShipSpotLightToggle":
                    SendKeypress(Program.Bindings.ShipSpotLightToggle);
                    break;

                case "NightVisionToggle":
                    SendKeypress(Program.Bindings.NightVisionToggle);
                    break;

                case "PlayerHUDModeToggle":
                    SendKeypress(Program.Bindings.PlayerHUDModeToggle);
                    break;

                case "DeployHardpointToggle":
                    SendKeypress(Program.Bindings.DeployHardpointToggle);
                    break;

                case "Supercruise":
                    SendKeypress(Program.Bindings.Supercruise);
                    break;

                case "ToggleButtonUpInput":
                    SendKeypress(Program.Bindings.ToggleButtonUpInput);
                    break;

                case "ToggleBuggyTurretButton":
                    SendKeypress(Program.Bindings.ToggleBuggyTurretButton);
                    break;

                case "ToggleDriveAssist":
                    SendKeypress(Program.Bindings.ToggleDriveAssist);
                    break;

                case "AutoBreakBuggyButton":
                    SendKeypress(Program.Bindings.AutoBreakBuggyButton);
                    break;

            }


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
            _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);
            _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
