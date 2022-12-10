using System;
using System.IO;
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
    public class Toggle : EliteKeypadBase
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
                    ClickSoundFilename = string.Empty
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
            [JsonProperty(PropertyName = "clickSound")]
            public string ClickSoundFilename { get; set; }
        }


        PluginSettings settings;
        private string _primaryFile;
        private string _secondaryFile;
        private CachedSound _clickSound = null;

        private async Task HandleDisplay()
        {
            string imgBase64;

            var isPrimary = false;

            switch (settings.Function)
            {
                case "FocusCommsPanel":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.CommsPanel;
                    break;
                case "FocusRadarPanel":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.RolePanel;
                    break;
                case "FocusRightPanel":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.InternalPanel;
                    break;
                case "FocusLeftPanel":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.ExternalPanel;
                    break;

                case "GalaxyMap":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.GalaxyMap;
                    break;
                case "SystemMap":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.SystemMap || EliteData.StatusData.GuiFocus == StatusGuiFocus.Orrery;
                    break;

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
                    isPrimary = EliteData.StatusData.LightsOn || EliteData.StatusData.SrvHighBeam;
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
                HandleFileNames();

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
            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            // TODO ???

            //SAAMode = 10,  // Surface Area Analysis scanner (same as Detailed Surface Scanner ???)
                             // Can only be used in supercruise and only functions in analysis mode.
                             // no keybind, needs fire group+trigger

            //<ExplorationSAAExitThirdPerson>
            //	<Primary Device="231D0127" Key="Joy_3" />
            //	<Secondary Device="Keyboard" Key="Key_W">
            //		<Modifier Device="Keyboard" Key="Key_LeftAlt" />
            //		<Modifier Device="Keyboard" Key="Key_RightShift" />
            //	</Secondary>
            //</ExplorationSAAExitThirdPerson>


            switch (settings.Function)
            {
                case "FocusCommsPanel":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    else if (EliteData.StatusData.OnFoot)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    break;
                case "FocusRadarPanel":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusRightPanel);
                    break;

                case "GalaxyMap":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    else
                    if (EliteData.StatusData.OnFoot)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    break;
                case "SystemMap":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    else
                    if (EliteData.StatusData.OnFoot)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SystemMapOpen);
                    break;

                case "ToggleCargoScoop":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    break;
                case "LandingGearToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].LandingGearToggle);
                    break;

                case "ToggleFlightAssist":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    break;

                case "ShipSpotLightToggle":
                    if (EliteData.StatusData.InSRV)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    else
                    if (EliteData.StatusData.OnFoot)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton );
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    break;

                case "NightVisionToggle":
                    if (EliteData.StatusData.OnFoot)
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    else
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].NightVisionToggle);
                    break;

                case "PlayerHUDModeToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    break;

                case "DeployHardpointToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    break;

                case "Supercruise":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].Supercruise);
                    break;

                case "ToggleButtonUpInput":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    break;

                case "ToggleBuggyTurretButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;

                case "ToggleDriveAssist":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;

                case "AutoBreakBuggyButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;

            }

            if (_clickSound != null)
            {
                try
                {
                    AudioPlaybackEngine.Instance.PlaySound(_clickSound);
                }
                catch(Exception ex)
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"PlaySound: {ex}");
                }
            }

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
            _clickSound = null;
            if (File.Exists(settings.ClickSoundFilename))
            {
                try
                {
                    _clickSound = new CachedSound(settings.ClickSoundFilename);
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"CachedSound: {settings.ClickSoundFilename} {ex}");

                    _clickSound = null;
                    settings.ClickSoundFilename = null;
                }
            }

            _primaryFile = Tools.FileToBase64(settings.PrimaryImageFilename, true);
            _secondaryFile = Tools.FileToBase64(settings.SecondaryImageFilename, true);

            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
