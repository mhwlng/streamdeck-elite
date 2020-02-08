using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using StandardBindingInfo = Elite.EliteApi.StandardBindingInfo;

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
                    isPrimary = Program.EliteApi.Status.CargoScoop;
                    break;
                case "LandingGearToggle":
                    isPrimary = Program.EliteApi.Status.Gear;
                    break;

                case "ToggleFlightAssist":
                    isPrimary = Program.EliteApi.Status.FlightAssist;
                    break;

                case "ShipSpotLightToggle":
                    isPrimary = Program.EliteApi.Status.Lights;
                    break;

                case "NightVisionToggle":
                    isPrimary = Program.EliteApi.Status.NightVision;
                    break;

                case "PlayerHUDModeToggle":
                    isPrimary = Program.EliteApi.Status.AnalysisMode;
                    break;

                case "DeployHardpointToggle":
                    isPrimary = Program.EliteApi.Status.Hardpoints;
                    break;

                case "Supercruise":
                    isPrimary = Program.EliteApi.Status.Supercruise;
                    break;

                case "ToggleButtonUpInput":
                    isPrimary = Program.EliteApi.Status.SilentRunning;
                    break;

                case "ToggleBuggyTurretButton":
                    isPrimary = Program.EliteApi.Status.SrvTurrent;
                    break;

                case "ToggleDriveAssist":
                    isPrimary = Program.EliteApi.Status.SrvDriveAssist;
                    break;

                case "AutoBreakBuggyButton":
                    isPrimary = Program.EliteApi.Status.SrvHandbreak;
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

                AsyncHelper.RunSync(() => HandleDisplay());

            }

            Program.EliteApi.Events.AllEvent += async (sender, e) => await HandleDisplay();



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
