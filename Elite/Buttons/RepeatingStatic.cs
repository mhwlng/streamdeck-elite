using System;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite.Buttons
{

    [PluginActionId("com.mhwlng.elite.repeatingstatic")]
    public class RepeatingStatic : EliteBase
    {
        protected class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                var instance = new PluginSettings
                {
                    Function = string.Empty,
                };

                return instance;
            }

            [JsonProperty(PropertyName = "function")]
            public string Function { get; set; }

        }


        PluginSettings settings;


        public RepeatingStatic(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Repeating Static Constructor #1");

                settings = PluginSettings.CreateDefaultSettings();
                Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();

            }
            else
            {
                //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Repeating Static Constructor #2");

                settings = payload.Settings.ToObject<PluginSettings>();
                HandleFileNames();
            }

        }

        public override void KeyPressed(KeyPayload payload)
        {
            if (Program.Binding == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;

            switch (settings.Function)
            {
                case "OrderFocusTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderFocusTarget);
                    break;
                case "OrderAggressiveBehaviour":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderAggressiveBehaviour);
                    break;
                case "OrderDefensiveBehaviour":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderDefensiveBehaviour);
                    break;
                case "OpenOrders":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OpenOrders);
                    break;
                case "OrderRequestDock":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderRequestDock);
                    break;
                case "OrderFollow":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderFollow);
                    break;
                case "OrderHoldFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderHoldFire);
                    break;
                case "OrderHoldPosition":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrderHoldPosition);
                    break;

                case "HeadLookPitchDown":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookPitchDown);
                    break;
                case "HeadLookYawLeft":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookYawLeft);
                    break;
                case "HeadLookYawRight":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookYawRight);
                    break;
                case "HeadLookPitchUp":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookPitchUp);
                    break;
                case "HeadLookReset":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookReset);
                    break;
                case "OpenCodexGoToDiscovery":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OpenCodexGoToDiscovery);
                    break;
                case "FriendsMenu":
                    SendKeypressDown(Program.Binding[BindingType.Ship].FriendsMenu);
                    break;
                case "Pause":
                    SendKeypressDown(Program.Binding[BindingType.Ship].Pause);
                    break;
                case "MicrophoneMute":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MicrophoneMute);
                    break;

                case "NightVisionToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].NightVisionToggle);
                    break;

                case "HMDReset":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HMDReset);
                    break;
                case "OculusReset":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OculusReset);
                    break;
                case "RadarDecreaseRange":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RadarDecreaseRange);
                    break;
                case "RadarIncreaseRange":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RadarIncreaseRange);
                    break;
                case "MultiCrewThirdPersonFovInButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovInButton);
                    break;
                case "MultiCrewThirdPersonFovOutButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovOutButton);
                    break;
                case "MultiCrewPrimaryFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewPrimaryFire);
                    break;
                case "MultiCrewSecondaryFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewSecondaryFire);
                    break;
                case "MultiCrewToggleMode":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewToggleMode);
                    break;
                case "MultiCrewThirdPersonPitchDownButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchDownButton);
                    break;
                case "MultiCrewThirdPersonPitchUpButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchUpButton);
                    break;
                case "MultiCrewPrimaryUtilityFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewPrimaryUtilityFire);
                    break;
                case "MultiCrewSecondaryUtilityFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewSecondaryUtilityFire);
                    break;
                case "MultiCrewCockpitUICycleBackward":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleBackward);
                    break;
                case "MultiCrewCockpitUICycleForward":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleForward);
                    break;
                case "MultiCrewThirdPersonYawLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawLeftButton);
                    break;
                case "MultiCrewThirdPersonYawRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawRightButton);
                    break;
                case "SAAThirdPersonFovInButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonFovInButton);
                    break;
                case "SAAThirdPersonFovOutButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonFovOutButton);
                    break;
                case "ExplorationFSSEnter":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSEnter);
                    break;
                case "ExplorationSAAExitThirdPerson":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAExitThirdPerson);
                    break;
                case "ExplorationFSSQuit":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSQuit);
                    break;
                case "ExplorationFSSShowHelp":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSShowHelp);
                    break;
                case "ExplorationSAANextGenus":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAANextGenus);
                    break;
                case "ExplorationSAAPreviousGenus":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAPreviousGenus);
                    break;
                case "ExplorationSAAShowHelp":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSDiscoveryScan);
                    break;
                case "ExplorationFSSCameraPitchDecreaseButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchDecreaseButton);
                    break;
                case "ExplorationFSSCameraPitchIncreaseButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchIncreaseButton);
                    break;
                case "ExplorationFSSRadioTuningX_Decrease":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Decrease);
                    break;
                case "ExplorationFSSRadioTuningX_Increase":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Increase);
                    break;
                case "ExplorationFSSCameraYawDecreaseButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawDecreaseButton);
                    break;
                case "ExplorationFSSCameraYawIncreaseButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawIncreaseButton);
                    break;
                case "SAAThirdPersonPitchDownButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonPitchDownButton);
                    break;
                case "SAAThirdPersonPitchUpButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonPitchUpButton);
                    break;
                case "ExplorationFSSMiniZoomIn":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomIn);
                    break;
                case "ExplorationFSSMiniZoomOut":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomOut);
                    break;
                case "ExplorationFSSTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSTarget);
                    break;
                case "ExplorationSAAChangeScannedAreaViewToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAChangeScannedAreaViewToggle);
                    break;
                case "SAAThirdPersonYawLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonYawLeftButton);
                    break;
                case "SAAThirdPersonYawRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonYawRightButton);
                    break;
                case "ExplorationFSSZoomIn":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSZoomIn);
                    break;
                case "ExplorationFSSZoomOut":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSZoomOut);
                    break;
                case "FocusCommsPanel":
                    SendKeypressDown(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    SendKeypressDown(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    break;
                case "QuickCommsPanel":
                    SendKeypressDown(Program.Binding[BindingType.Ship].QuickCommsPanel);
                    break;
                case "FocusRadarPanel":
                    SendKeypressDown(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    SendKeypressDown(Program.Binding[BindingType.Ship].FocusRightPanel);
                    break;
                case "UIFocus":
                    SendKeypressDown(Program.Binding[BindingType.Ship].UIFocus);
                    break;
                case "TargetWingman0":
                    SendKeypressDown(Program.Binding[BindingType.Ship].TargetWingman0);
                    break;
                case "TargetWingman1":
                    SendKeypressDown(Program.Binding[BindingType.Ship].TargetWingman1);
                    break;
                case "TargetWingman2":
                    SendKeypressDown(Program.Binding[BindingType.Ship].TargetWingman2);
                    break;
                case "WingNavLock":
                    SendKeypressDown(Program.Binding[BindingType.Ship].WingNavLock);
                    break;
                case "SelectTargetsTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SelectTargetsTarget);
                    break;
                case "FireChaffLauncher":
                    SendKeypressDown(Program.Binding[BindingType.Ship].FireChaffLauncher);
                    break;
                case "ChargeECM":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ChargeECM);
                    break;
                case "IncreaseEnginesPower":
                    SendKeypressDown(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
                    break;
                case "PrimaryFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].PrimaryFire);
                    break;
                case "SecondaryFire":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SecondaryFire);
                    break;
                case "DeployHardpointToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    break;
                case "DeployHeatSink":
                    SendKeypressDown(Program.Binding[BindingType.Ship].DeployHeatSink);
                    break;
                case "SelectHighestThreat":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SelectHighestThreat);
                    break;
                case "CycleNextTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CycleNextTarget);
                    break;
                case "CycleFireGroupNext":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                    break;
                case "CycleNextHostileTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CycleNextHostileTarget);
                    break;
                case "CycleNextSubsystem":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CycleNextSubsystem);
                    break;
                case "CyclePreviousTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CyclePreviousTarget);
                    break;
                case "CycleFireGroupPrevious":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                    break;
                case "CyclePreviousHostileTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CyclePreviousHostileTarget);
                    break;
                case "CyclePreviousSubsystem":
                    SendKeypressDown(Program.Binding[BindingType.Ship].CyclePreviousSubsystem);
                    break;
                case "ResetPowerDistribution":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ResetPowerDistribution);
                    break;
                case "UseShieldCell":
                    SendKeypressDown(Program.Binding[BindingType.Ship].UseShieldCell);
                    break;
                case "TriggerFieldNeutraliser":
                    SendKeypressDown(Program.Binding[BindingType.Ship].TriggerFieldNeutraliser);
                    break;
                case "IncreaseSystemsPower":
                    SendKeypressDown(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
                    break;
                case "SelectTarget":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SelectTarget);
                    break;
                case "IncreaseWeaponsPower":
                    SendKeypressDown(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
                    break;
                case "ShowPGScoreSummaryInput":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ShowPGScoreSummaryInput);
                    break;
                case "EjectAllCargo":
                    SendKeypressDown(Program.Binding[BindingType.Ship].EjectAllCargo);
                    break;
                case "EngineColourToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].EngineColourToggle);
                    break;
                case "PlayerHUDModeToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    break;
                case "OrbitLinesToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].OrbitLinesToggle);
                    break;
                case "MouseReset":
                    SendKeypressDown(Program.Binding[BindingType.Ship].MouseReset);
                    break;
                case "HeadLookToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookToggle);
                    break;
                case "WeaponColourToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].WeaponColourToggle);
                    break;
                case "SetSpeedMinus100":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus100);
                    break;
                case "SetSpeed100":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed100);
                    break;
                case "SetSpeedMinus25":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus25);
                    break;
                case "SetSpeed25":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed25);
                    break;
                case "SetSpeedMinus50":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus50);
                    break;
                case "SetSpeed50":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed50);
                    break;
                case "SetSpeedMinus75":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus75);
                    break;
                case "SetSpeed75":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed75);
                    break;
                case "SetSpeedZero":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedZero);
                    break;
                case "UseAlternateFlightValuesToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].UseAlternateFlightValuesToggle);
                    break;
                case "UseBoostJuice":
                    SendKeypressDown(Program.Binding[BindingType.Ship].UseBoostJuice);
                    break;
                case "ToggleCargoScoop":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    break;
                case "ToggleFlightAssist":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    break;
                case "ForwardKey":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ForwardKey);
                    break;
                case "ForwardThrustButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ForwardThrustButton);
                    break;
                case "ForwardThrustButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ForwardThrustButton_Landing);
                    break;
                case "GalaxyMapOpen":
                    SendKeypressDown(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    break;
                case "Hyperspace":
                    SendKeypressDown(Program.Binding[BindingType.Ship].Hyperspace);
                    break;
                case "HyperSuperCombination":
                    SendKeypressDown(Program.Binding[BindingType.Ship].HyperSuperCombination);
                    break;
                case "LandingGearToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].LandingGearToggle);
                    break;
                case "ShipSpotLightToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    break;
                case "TargetNextRouteSystem":
                    SendKeypressDown(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
                    break;
                case "PitchDownButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].PitchDownButton);
                    break;
                case "PitchDownButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].PitchDownButton_Landing);
                    break;
                case "PitchUpButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].PitchUpButton);
                    break;
                case "PitchUpButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].PitchUpButton_Landing);
                    break;
                case "ToggleReverseThrottleInput":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ToggleReverseThrottleInput);
                    break;
                case "BackwardKey":
                    SendKeypressDown(Program.Binding[BindingType.Ship].BackwardKey);
                    break;
                case "BackwardThrustButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].BackwardThrustButton);
                    break;
                case "BackwardThrustButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].BackwardThrustButton_Landing);
                    break;
                case "RollLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RollLeftButton);
                    break;
                case "RollLeftButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RollLeftButton_Landing);
                    break;
                case "RollRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RollRightButton);
                    break;
                case "RollRightButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RollRightButton_Landing);
                    break;
                case "DisableRotationCorrectToggle":
                    SendKeypressDown(Program.Binding[BindingType.Ship].DisableRotationCorrectToggle);
                    break;
                case "ToggleButtonUpInput":
                    SendKeypressDown(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    break;
                case "Supercruise":
                    SendKeypressDown(Program.Binding[BindingType.Ship].Supercruise);
                    break;
                case "SystemMapOpen":
                    SendKeypressDown(Program.Binding[BindingType.Ship].SystemMapOpen);
                    break;
                case "DownThrustButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].DownThrustButton);
                    break;
                case "DownThrustButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].DownThrustButton_Landing);
                    break;
                case "LeftThrustButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].LeftThrustButton);
                    break;
                case "LeftThrustButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].LeftThrustButton_Landing);
                    break;
                case "RightThrustButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RightThrustButton);
                    break;
                case "RightThrustButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].RightThrustButton_Landing);
                    break;
                case "UpThrustButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].UpThrustButton);
                    break;
                case "UpThrustButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].UpThrustButton_Landing);
                    break;
                case "YawLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].YawLeftButton);
                    break;
                case "YawLeftButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].YawLeftButton_Landing);
                    break;
                case "YawRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].YawRightButton);
                    break;
                case "YawRightButton_Landing":
                    SendKeypressDown(Program.Binding[BindingType.Ship].YawRightButton_Landing);
                    break;
                case "YawToRollButton":
                    SendKeypressDown(Program.Binding[BindingType.Ship].YawToRollButton);
                    break;

                // general

                case "UI_Back":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Back);
                    break;
                case "UI_Down":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Down);
                    break;
                case "UI_Left":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Left);
                    break;
                case "UI_Right":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Right);
                    break;
                case "UI_Select":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Select);
                    break;
                case "UI_Toggle":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Toggle);
                    break;
                case "UI_Up":
                    SendKeypressDown(Program.Binding[BindingType.General].UI_Up);
                    break;

                case "CycleNextPage":
                    SendKeypressDown(Program.Binding[BindingType.General].CycleNextPage);
                    break;
                case "CycleNextPanel":
                    SendKeypressDown(Program.Binding[BindingType.General].CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    SendKeypressDown(Program.Binding[BindingType.General].CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    SendKeypressDown(Program.Binding[BindingType.General].CyclePreviousPanel);
                    break;

                case "CamTranslateBackward":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    SendKeypressDown(Program.Binding[BindingType.General].CamPitchDown);
                    break;
                case "CamPitchUp":
                    SendKeypressDown(Program.Binding[BindingType.General].CamPitchUp);
                    break;
                case "CamTranslateRight":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateUp);
                    break;
                case "CamYawLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].CamYawLeft);
                    break;
                case "CamYawRight":
                    SendKeypressDown(Program.Binding[BindingType.General].CamYawRight);
                    break;
                case "CamTranslateZHold":
                    SendKeypressDown(Program.Binding[BindingType.General].CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    SendKeypressDown(Program.Binding[BindingType.General].CamZoomIn);
                    break;
                case "CamZoomOut":
                    SendKeypressDown(Program.Binding[BindingType.General].CamZoomOut);
                    break;

                case "MoveFreeCamBackwards":
                    SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamLeft);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    SendKeypressDown(Program.Binding[BindingType.General].ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamRight);
                    break;
                case "MoveFreeCamUp":
                    SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamUp);
                    break;
                case "FreeCamSpeedDec":
                    SendKeypressDown(Program.Binding[BindingType.General].FreeCamSpeedDec);
                    break;
                case "ToggleFreeCam":
                    SendKeypressDown(Program.Binding[BindingType.General].ToggleFreeCam);
                    break;
                case "FreeCamSpeedInc":
                    SendKeypressDown(Program.Binding[BindingType.General].FreeCamSpeedInc);
                    break;
                case "FreeCamToggleHUD":
                    SendKeypressDown(Program.Binding[BindingType.General].FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    SendKeypressDown(Program.Binding[BindingType.General].FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    SendKeypressDown(Program.Binding[BindingType.General].FreeCamZoomOut);
                    break;

                case "PhotoCameraToggle":
                    SendKeypressDown(Program.Binding[BindingType.General].PhotoCameraToggle);
                    break;
                case "StorePitchCameraDown":
                    SendKeypressDown(Program.Binding[BindingType.General].StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    SendKeypressDown(Program.Binding[BindingType.General].StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    SendKeypressDown(Program.Binding[BindingType.General].StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    SendKeypressDown(Program.Binding[BindingType.General].StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    SendKeypressDown(Program.Binding[BindingType.General].StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    SendKeypressDown(Program.Binding[BindingType.General].StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    SendKeypressDown(Program.Binding[BindingType.General].StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    SendKeypressDown(Program.Binding[BindingType.General].ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraNine);
                    break;
                case "VanityCameraTen":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraTen);
                    break;
                case "PitchCameraDown":
                    SendKeypressDown(Program.Binding[BindingType.General].PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    SendKeypressDown(Program.Binding[BindingType.General].PitchCameraUp);
                    break;
                case "RollCameraLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].RollCameraLeft);
                    break;
                case "RollCameraRight":
                    SendKeypressDown(Program.Binding[BindingType.General].RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    SendKeypressDown(Program.Binding[BindingType.General].ToggleRotationLock);
                    break;
                case "YawCameraLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].YawCameraLeft);
                    break;
                case "YawCameraRight":
                    SendKeypressDown(Program.Binding[BindingType.General].YawCameraRight);
                    break;
                case "FStopDec":
                    SendKeypressDown(Program.Binding[BindingType.General].FStopDec);
                    break;
                case "QuitCamera":
                    SendKeypressDown(Program.Binding[BindingType.General].QuitCamera);
                    break;
                case "FocusDistanceInc":
                    SendKeypressDown(Program.Binding[BindingType.General].FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    SendKeypressDown(Program.Binding[BindingType.General].FocusDistanceDec);
                    break;
                case "FStopInc":
                    SendKeypressDown(Program.Binding[BindingType.General].FStopInc);
                    break;
                case "FixCameraRelativeToggle":
                    SendKeypressDown(Program.Binding[BindingType.General].FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    SendKeypressDown(Program.Binding[BindingType.General].FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    SendKeypressDown(Program.Binding[BindingType.General].VanityCameraScrollLeft);
                    break;

                case "CommanderCreator_Redo":
                    SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Undo);
                    break;

                case "GalnetAudio_ClearQueue":
                    SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_ClearQueue);
                    break;
                case "GalnetAudio_SkipForward":
                    SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_SkipForward);
                    break;
                case "GalnetAudio_Play_Pause":
                    SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_SkipBackward);
                    break;

                // in srv

                case "ToggleDriveAssist":
                    SendKeypressDown(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;
                case "SteerLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].SteerLeftButton);
                    break;
                case "SteerRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].SteerRightButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonMax":
                    SendKeypressDown(Program.Binding[BindingType.Srv].DecreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonPartial":
                    SendKeypressDown(Program.Binding[BindingType.Srv].DecreaseSpeedButtonPartial);
                    break;
                case "IncreaseSpeedButtonPartial":
                    SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseSpeedButtonPartial);
                    break;
                case "RecallDismissShip":
                    SendKeypressDown(Program.Binding[BindingType.Srv].RecallDismissShip);
                    break;
                case "VerticalThrustersButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].VerticalThrustersButton);
                    break;

                case "PhotoCameraToggle_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].PhotoCameraToggle_Buggy);
                    break;

                case "FocusCommsPanel_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    break;
                case "GalaxyMapOpen_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;
                case "HeadlightsBuggyButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    break;
                case "BuggyPitchDownButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyPitchUpButton);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    SendKeypressDown(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    break;

                // on foot

                case "HumanoidClearAuthorityLevel":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidClearAuthorityLevel);
                    break;
                case "HumanoidHealthPack":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidHealthPack);
                    break;
                case "HumanoidBattery":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidBattery);
                    break;
                case "HumanoidSelectFragGrenade":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectFragGrenade);
                    break;
                case "HumanoidSelectEMPGrenade":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectEMPGrenade);
                    break;
                case "HumanoidSelectShieldGrenade":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectShieldGrenade);
                    break;

                case "PhotoCameraToggle_Humanoid":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].PhotoCameraToggle_Humanoid);
                    break;
                case "HumanoidForwardButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidForwardButton);
                    break;
                case "HumanoidBackwardButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidBackwardButton);
                    break;
                case "HumanoidStrafeLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidStrafeLeftButton);
                    break;
                case "HumanoidStrafeRightButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidStrafeRightButton);
                    break;
                case "HumanoidSprintButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSprintButton);
                    break;
                case "HumanoidCrouchButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidCrouchButton);
                    break;
                case "HumanoidJumpButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidJumpButton);
                    break;
                case "HumanoidPrimaryInteractButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPrimaryInteractButton);
                    break;
                case "HumanoidItemWheelButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidItemWheelButton);
                    break;
                case "HumanoidEmoteWheelButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteWheelButton);
                    break;
                case "HumanoidUtilityWheelCycleMode":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidUtilityWheelCycleMode);
                    break;

                case "HumanoidPrimaryFireButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPrimaryFireButton);
                    break;
                case "HumanoidSelectPrimaryWeaponButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectPrimaryWeaponButton);
                    break;
                case "HumanoidSelectSecondaryWeaponButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectSecondaryWeaponButton);
                    break;
                case "HumanoidHideWeaponButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidHideWeaponButton);
                    break;
                case "HumanoidZoomButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidZoomButton);
                    break;
                case "HumanoidReloadButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidReloadButton);
                    break;
                case "HumanoidThrowGrenadeButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidThrowGrenadeButton);
                    break;
                case "HumanoidMeleeButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidMeleeButton);
                    break;
                case "HumanoidOpenAccessPanelButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidOpenAccessPanelButton);
                    break;
                case "HumanoidSecondaryInteractButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSecondaryInteractButton);
                    break;
                case "HumanoidSwitchToRechargeTool":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchToRechargeTool);
                    break;
                case "HumanoidSwitchToCompAnalyser":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchToCompAnalyser);
                    break;
                case "HumanoidToggleToolModeButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleToolModeButton);
                    break;
                case "HumanoidToggleNightVisionButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    break;
                case "HumanoidSwitchToSuitTool":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchToSuitTool);
                    break;
                case "HumanoidToggleFlashlightButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton);
                    break;
                case "GalaxyMapOpen_Humanoid":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    break;
                case "SystemMapOpen_Humanoid":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    break;
                case "FocusCommsPanel_Humanoid":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    break;
                case "QuickCommsPanel_Humanoid":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].QuickCommsPanel_Humanoid);
                    break;
                case "HumanoidConflictContextualUIButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidConflictContextualUIButton);
                    break;
                case "HumanoidToggleShieldsButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleShieldsButton);
                    break;

                case "HumanoidRotateLeftButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidRotateLeftButton);
                    break;
                case "HumanoidRotateRightButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidRotateRightButton);
                    break;
                case "HumanoidPitchUpButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPitchUpButton);
                    break;
                case "HumanoidPitchDownButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPitchDownButton);
                    break;
                case "HumanoidSwitchWeapon":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchWeapon);
                    break;
                case "HumanoidSelectUtilityWeaponButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectUtilityWeaponButton);
                    break;
                case "HumanoidSelectNextWeaponButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectNextWeaponButton);
                    break;
                case "HumanoidSelectPreviousWeaponButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousWeaponButton);
                    break;
                case "HumanoidSelectNextGrenadeTypeButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectNextGrenadeTypeButton);
                    break;
                case "HumanoidSelectPreviousGrenadeTypeButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousGrenadeTypeButton);
                    break;
                case "HumanoidToggleMissionHelpPanelButton":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleMissionHelpPanelButton);
                    break;
                case "HumanoidPing":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPing);
                    break;

                case "HumanoidEmoteSlot1":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot1);
                    break;
                case "HumanoidEmoteSlot2":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot2);
                    break;
                case "HumanoidEmoteSlot3":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot3);
                    break;
                case "HumanoidEmoteSlot4":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot4);
                    break;
                case "HumanoidEmoteSlot5":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot5);
                    break;
                case "HumanoidEmoteSlot6":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot6);
                    break;
                case "HumanoidEmoteSlot7":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot7);
                    break;
                case "HumanoidEmoteSlot8":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot8);
                    break;

            }
        }

        public override void KeyReleased(KeyPayload payload)
		{
			if (Program.Binding == null)
			{
				ForceStop = true;
				return;
			}

			ForceStop = false;

			switch (settings.Function)
			{
				case "OrderFocusTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderFocusTarget);
					break;
				case "OrderAggressiveBehaviour":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderAggressiveBehaviour);
					break;
				case "OrderDefensiveBehaviour":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderDefensiveBehaviour);
					break;
				case "OpenOrders":
					SendKeypressUp(Program.Binding[BindingType.Ship].OpenOrders);
					break;
				case "OrderRequestDock":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderRequestDock);
					break;
				case "OrderFollow":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderFollow);
					break;
				case "OrderHoldFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderHoldFire);
					break;
				case "OrderHoldPosition":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrderHoldPosition);
					break;
				case "HeadLookPitchDown":
					SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookPitchDown);
					break;
				case "HeadLookYawLeft":
					SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookYawLeft);
					break;
				case "HeadLookYawRight":
					SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookYawRight);
					break;
				case "HeadLookPitchUp":
					SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookPitchUp);
					break;
				case "HeadLookReset":
					SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookReset);
					break;
				case "OpenCodexGoToDiscovery":
					SendKeypressUp(Program.Binding[BindingType.Ship].OpenCodexGoToDiscovery);
					break;
				case "FriendsMenu":
					SendKeypressUp(Program.Binding[BindingType.Ship].FriendsMenu);
					break;
				case "Pause":
					SendKeypressUp(Program.Binding[BindingType.Ship].Pause);
					break;
				case "MicrophoneMute":
					SendKeypressUp(Program.Binding[BindingType.Ship].MicrophoneMute);
					break;

				case "NightVisionToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].NightVisionToggle);
					break;

				case "HMDReset":
					SendKeypressUp(Program.Binding[BindingType.Ship].HMDReset);
					break;
				case "OculusReset":
					SendKeypressUp(Program.Binding[BindingType.Ship].OculusReset);
					break;
				case "RadarDecreaseRange":
					SendKeypressUp(Program.Binding[BindingType.Ship].RadarDecreaseRange);
					break;
				case "RadarIncreaseRange":
					SendKeypressUp(Program.Binding[BindingType.Ship].RadarIncreaseRange);
					break;
				case "MultiCrewThirdPersonFovInButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovInButton);
					break;
				case "MultiCrewThirdPersonFovOutButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovOutButton);
					break;
				case "MultiCrewPrimaryFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewPrimaryFire);
					break;
				case "MultiCrewSecondaryFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewSecondaryFire);
					break;
				case "MultiCrewToggleMode":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewToggleMode);
					break;
				case "MultiCrewThirdPersonPitchDownButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchDownButton);
					break;
				case "MultiCrewThirdPersonPitchUpButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchUpButton);
					break;
				case "MultiCrewPrimaryUtilityFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewPrimaryUtilityFire);
					break;
				case "MultiCrewSecondaryUtilityFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewSecondaryUtilityFire);
					break;
				case "MultiCrewCockpitUICycleBackward":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleBackward);
					break;
				case "MultiCrewCockpitUICycleForward":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleForward);
					break;
				case "MultiCrewThirdPersonYawLeftButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawLeftButton);
					break;
				case "MultiCrewThirdPersonYawRightButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawRightButton);
					break;
				case "SAAThirdPersonFovInButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonFovInButton);
					break;
				case "SAAThirdPersonFovOutButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonFovOutButton);
					break;
				case "ExplorationFSSEnter":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSEnter);
					break;
				case "ExplorationSAAExitThirdPerson":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAExitThirdPerson);
					break;
				case "ExplorationFSSQuit":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSQuit);
					break;
				case "ExplorationFSSShowHelp":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSShowHelp);
					break;
                case "ExplorationSAANextGenus":
                    SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAANextGenus);
                    break;
                case "ExplorationSAAPreviousGenus":
                    SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAPreviousGenus);
                    break;
                case "ExplorationSAAShowHelp":
                    SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSDiscoveryScan);
					break;
				case "ExplorationFSSCameraPitchDecreaseButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchDecreaseButton);
					break;
				case "ExplorationFSSCameraPitchIncreaseButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchIncreaseButton);
					break;
				case "ExplorationFSSRadioTuningX_Decrease":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Decrease);
					break;
				case "ExplorationFSSRadioTuningX_Increase":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Increase);
					break;
				case "ExplorationFSSCameraYawDecreaseButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawDecreaseButton);
					break;
				case "ExplorationFSSCameraYawIncreaseButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawIncreaseButton);
					break;
				case "SAAThirdPersonPitchDownButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonPitchDownButton);
					break;
				case "SAAThirdPersonPitchUpButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonPitchUpButton);
					break;
				case "ExplorationFSSMiniZoomIn":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomIn);
					break;
				case "ExplorationFSSMiniZoomOut":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomOut);
					break;
				case "ExplorationFSSTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSTarget);
					break;
				case "ExplorationSAAChangeScannedAreaViewToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAChangeScannedAreaViewToggle);
					break;
				case "SAAThirdPersonYawLeftButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonYawLeftButton);
					break;
				case "SAAThirdPersonYawRightButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonYawRightButton);
					break;
				case "ExplorationFSSZoomIn":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSZoomIn);
					break;
				case "ExplorationFSSZoomOut":
					SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSZoomOut);
					break;
				case "FocusCommsPanel":
					SendKeypressUp(Program.Binding[BindingType.Ship].FocusCommsPanel);
					break;
				case "FocusLeftPanel":
					SendKeypressUp(Program.Binding[BindingType.Ship].FocusLeftPanel);
					break;
				case "QuickCommsPanel":
					SendKeypressUp(Program.Binding[BindingType.Ship].QuickCommsPanel);
					break;
				case "FocusRadarPanel":
					SendKeypressUp(Program.Binding[BindingType.Ship].FocusRadarPanel);
					break;
				case "FocusRightPanel":
					SendKeypressUp(Program.Binding[BindingType.Ship].FocusRightPanel);
					break;
				case "UIFocus":
					SendKeypressUp(Program.Binding[BindingType.Ship].UIFocus);
					break;
				case "TargetWingman0":
					SendKeypressUp(Program.Binding[BindingType.Ship].TargetWingman0);
					break;
				case "TargetWingman1":
					SendKeypressUp(Program.Binding[BindingType.Ship].TargetWingman1);
					break;
				case "TargetWingman2":
					SendKeypressUp(Program.Binding[BindingType.Ship].TargetWingman2);
					break;
				case "WingNavLock":
					SendKeypressUp(Program.Binding[BindingType.Ship].WingNavLock);
					break;
				case "SelectTargetsTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].SelectTargetsTarget);
					break;
				case "FireChaffLauncher":
					SendKeypressUp(Program.Binding[BindingType.Ship].FireChaffLauncher);
					break;
				case "ChargeECM":
					SendKeypressUp(Program.Binding[BindingType.Ship].ChargeECM);
					break;
				case "IncreaseEnginesPower":
					SendKeypressUp(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
					break;
				case "PrimaryFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].PrimaryFire);
					break;
				case "SecondaryFire":
					SendKeypressUp(Program.Binding[BindingType.Ship].SecondaryFire);
					break;
				case "DeployHardpointToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].DeployHardpointToggle);
					break;
				case "DeployHeatSink":
					SendKeypressUp(Program.Binding[BindingType.Ship].DeployHeatSink);
					break;
				case "SelectHighestThreat":
					SendKeypressUp(Program.Binding[BindingType.Ship].SelectHighestThreat);
					break;
				case "CycleNextTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].CycleNextTarget);
					break;
				case "CycleFireGroupNext":
					SendKeypressUp(Program.Binding[BindingType.Ship].CycleFireGroupNext);
					break;
				case "CycleNextHostileTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].CycleNextHostileTarget);
					break;
				case "CycleNextSubsystem":
					SendKeypressUp(Program.Binding[BindingType.Ship].CycleNextSubsystem);
					break;
				case "CyclePreviousTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].CyclePreviousTarget);
					break;
				case "CycleFireGroupPrevious":
					SendKeypressUp(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
					break;
				case "CyclePreviousHostileTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].CyclePreviousHostileTarget);
					break;
				case "CyclePreviousSubsystem":
					SendKeypressUp(Program.Binding[BindingType.Ship].CyclePreviousSubsystem);
					break;
				case "ResetPowerDistribution":
					SendKeypressUp(Program.Binding[BindingType.Ship].ResetPowerDistribution);
					break;
				case "UseShieldCell":
					SendKeypressUp(Program.Binding[BindingType.Ship].UseShieldCell);
					break;
                case "TriggerFieldNeutraliser":
                    SendKeypressUp(Program.Binding[BindingType.Ship].TriggerFieldNeutraliser);
                    break;
                case "IncreaseSystemsPower":
					SendKeypressUp(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
					break;
				case "SelectTarget":
					SendKeypressUp(Program.Binding[BindingType.Ship].SelectTarget);
					break;
				case "IncreaseWeaponsPower":
					SendKeypressUp(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
					break;
				case "ShowPGScoreSummaryInput":
					SendKeypressUp(Program.Binding[BindingType.Ship].ShowPGScoreSummaryInput);
					break;
				case "EjectAllCargo":
					SendKeypressUp(Program.Binding[BindingType.Ship].EjectAllCargo);
					break;
				case "EngineColourToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].EngineColourToggle);
					break;
				case "PlayerHUDModeToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
					break;
				case "OrbitLinesToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].OrbitLinesToggle);
					break;
				case "MouseReset":
					SendKeypressUp(Program.Binding[BindingType.Ship].MouseReset);
					break;
				case "HeadLookToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookToggle);
					break;
				case "WeaponColourToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].WeaponColourToggle);
					break;
				case "SetSpeedMinus100":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus100);
					break;
				case "SetSpeed100":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed100);
					break;
				case "SetSpeedMinus25":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus25);
					break;
				case "SetSpeed25":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed25);
					break;
				case "SetSpeedMinus50":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus50);
					break;
				case "SetSpeed50":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed50);
					break;
				case "SetSpeedMinus75":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus75);
					break;
				case "SetSpeed75":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed75);
					break;
				case "SetSpeedZero":
					SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedZero);
					break;
				case "UseAlternateFlightValuesToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].UseAlternateFlightValuesToggle);
					break;
				case "UseBoostJuice":
					SendKeypressUp(Program.Binding[BindingType.Ship].UseBoostJuice);
					break;
				case "ToggleCargoScoop":
					SendKeypressUp(Program.Binding[BindingType.Ship].ToggleCargoScoop);
					break;
				case "ToggleFlightAssist":
					SendKeypressUp(Program.Binding[BindingType.Ship].ToggleFlightAssist);
					break;
				case "ForwardKey":
					SendKeypressUp(Program.Binding[BindingType.Ship].ForwardKey);
					break;
				case "ForwardThrustButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].ForwardThrustButton);
					break;
				case "ForwardThrustButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].ForwardThrustButton_Landing);
					break;
				case "GalaxyMapOpen":
					SendKeypressUp(Program.Binding[BindingType.Ship].GalaxyMapOpen);
					break;
				case "Hyperspace":
					SendKeypressUp(Program.Binding[BindingType.Ship].Hyperspace);
					break;
				case "HyperSuperCombination":
					SendKeypressUp(Program.Binding[BindingType.Ship].HyperSuperCombination);
					break;
				case "LandingGearToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].LandingGearToggle);
					break;
				case "ShipSpotLightToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
					break;
				case "TargetNextRouteSystem":
					SendKeypressUp(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
					break;
				case "PitchDownButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].PitchDownButton);
					break;
				case "PitchDownButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].PitchDownButton_Landing);
					break;
				case "PitchUpButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].PitchUpButton);
					break;
				case "PitchUpButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].PitchUpButton_Landing);
					break;
				case "ToggleReverseThrottleInput":
					SendKeypressUp(Program.Binding[BindingType.Ship].ToggleReverseThrottleInput);
					break;
				case "BackwardKey":
					SendKeypressUp(Program.Binding[BindingType.Ship].BackwardKey);
					break;
				case "BackwardThrustButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].BackwardThrustButton);
					break;
				case "BackwardThrustButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].BackwardThrustButton_Landing);
					break;
				case "RollLeftButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].RollLeftButton);
					break;
				case "RollLeftButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].RollLeftButton_Landing);
					break;
				case "RollRightButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].RollRightButton);
					break;
				case "RollRightButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].RollRightButton_Landing);
					break;
				case "DisableRotationCorrectToggle":
					SendKeypressUp(Program.Binding[BindingType.Ship].DisableRotationCorrectToggle);
					break;
				case "ToggleButtonUpInput":
					SendKeypressUp(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
					break;
				case "Supercruise":
					SendKeypressUp(Program.Binding[BindingType.Ship].Supercruise);
					break;
				case "SystemMapOpen":
					SendKeypressUp(Program.Binding[BindingType.Ship].SystemMapOpen);
					break;
				case "DownThrustButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].DownThrustButton);
					break;
				case "DownThrustButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].DownThrustButton_Landing);
					break;
				case "LeftThrustButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].LeftThrustButton);
					break;
				case "LeftThrustButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].LeftThrustButton_Landing);
					break;
				case "RightThrustButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].RightThrustButton);
					break;
				case "RightThrustButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].RightThrustButton_Landing);
					break;
				case "UpThrustButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].UpThrustButton);
					break;
				case "UpThrustButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].UpThrustButton_Landing);
					break;
				case "YawLeftButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].YawLeftButton);
					break;
				case "YawLeftButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].YawLeftButton_Landing);
					break;
				case "YawRightButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].YawRightButton);
					break;
				case "YawRightButton_Landing":
					SendKeypressUp(Program.Binding[BindingType.Ship].YawRightButton_Landing);
					break;
				case "YawToRollButton":
					SendKeypressUp(Program.Binding[BindingType.Ship].YawToRollButton);
					break;


                // general

                case "CycleNextPage":
                    SendKeypressUp(Program.Binding[BindingType.General].CycleNextPage);
                    break;
                case "CycleNextPanel":
                    SendKeypressUp(Program.Binding[BindingType.General].CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    SendKeypressUp(Program.Binding[BindingType.General].CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    SendKeypressUp(Program.Binding[BindingType.General].CyclePreviousPanel);
                    break;
                case "UI_Back":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Back);
                    break;
                case "UI_Down":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Down);
                    break;
                case "UI_Left":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Left);
                    break;
                case "UI_Right":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Right);
                    break;
                case "UI_Select":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Select);
                    break;
                case "UI_Toggle":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Toggle);
                    break;
                case "UI_Up":
                    SendKeypressUp(Program.Binding[BindingType.General].UI_Up);
                    break;

                case "CamTranslateBackward":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    SendKeypressUp(Program.Binding[BindingType.General].CamPitchDown);
                    break;
                case "CamPitchUp":
                    SendKeypressUp(Program.Binding[BindingType.General].CamPitchUp);
                    break;
                case "CamTranslateRight":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateUp);
                    break;
                case "CamYawLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].CamYawLeft);
                    break;
                case "CamYawRight":
                    SendKeypressUp(Program.Binding[BindingType.General].CamYawRight);
                    break;
                case "CamTranslateZHold":
                    SendKeypressUp(Program.Binding[BindingType.General].CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    SendKeypressUp(Program.Binding[BindingType.General].CamZoomIn);
                    break;
                case "CamZoomOut":
                    SendKeypressUp(Program.Binding[BindingType.General].CamZoomOut);
                    break;

                case "MoveFreeCamBackwards":
                    SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamLeft);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    SendKeypressUp(Program.Binding[BindingType.General].ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamRight);
                    break;
                case "MoveFreeCamUp":
                    SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamUp);
                    break;
                case "FreeCamSpeedDec":
                    SendKeypressUp(Program.Binding[BindingType.General].FreeCamSpeedDec);
                    break;
                case "ToggleFreeCam":
                    SendKeypressUp(Program.Binding[BindingType.General].ToggleFreeCam);
                    break;
                case "FreeCamSpeedInc":
                    SendKeypressUp(Program.Binding[BindingType.General].FreeCamSpeedInc);
                    break;
                case "FreeCamToggleHUD":
                    SendKeypressUp(Program.Binding[BindingType.General].FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    SendKeypressUp(Program.Binding[BindingType.General].FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    SendKeypressUp(Program.Binding[BindingType.General].FreeCamZoomOut);
                    break;

                case "PhotoCameraToggle":
                    SendKeypressUp(Program.Binding[BindingType.General].PhotoCameraToggle);
                    break;
                case "StorePitchCameraDown":
                    SendKeypressUp(Program.Binding[BindingType.General].StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    SendKeypressUp(Program.Binding[BindingType.General].StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    SendKeypressUp(Program.Binding[BindingType.General].StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    SendKeypressUp(Program.Binding[BindingType.General].StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    SendKeypressUp(Program.Binding[BindingType.General].StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    SendKeypressUp(Program.Binding[BindingType.General].StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    SendKeypressUp(Program.Binding[BindingType.General].StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    SendKeypressUp(Program.Binding[BindingType.General].ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraNine);
                    break;
                case "VanityCameraTen":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraTen);
                    break;

                case "PitchCameraDown":
                    SendKeypressUp(Program.Binding[BindingType.General].PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    SendKeypressUp(Program.Binding[BindingType.General].PitchCameraUp);
                    break;

                case "RollCameraLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].RollCameraLeft);
                    break;
                case "RollCameraRight":
                    SendKeypressUp(Program.Binding[BindingType.General].RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    SendKeypressUp(Program.Binding[BindingType.General].ToggleRotationLock);
                    break;
                case "YawCameraLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].YawCameraLeft);
                    break;
                case "YawCameraRight":
                    SendKeypressUp(Program.Binding[BindingType.General].YawCameraRight);
                    break;
                case "FStopDec":
                    SendKeypressUp(Program.Binding[BindingType.General].FStopDec);
                    break;
                case "QuitCamera":
                    SendKeypressUp(Program.Binding[BindingType.General].QuitCamera);
                    break;
                case "FocusDistanceInc":
                    SendKeypressUp(Program.Binding[BindingType.General].FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    SendKeypressUp(Program.Binding[BindingType.General].FocusDistanceDec);
                    break;
                case "FStopInc":
                    SendKeypressUp(Program.Binding[BindingType.General].FStopInc);
                    break;
                case "FixCameraRelativeToggle":
                    SendKeypressUp(Program.Binding[BindingType.General].FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    SendKeypressUp(Program.Binding[BindingType.General].FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    SendKeypressUp(Program.Binding[BindingType.General].VanityCameraScrollLeft);
                    break;

                case "CommanderCreator_Redo":
                    SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Undo);
                    break;

                case "GalnetAudio_ClearQueue":
                    SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_ClearQueue);
                    break;
                case "GalnetAudio_SkipForward":
                    SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_SkipForward);
                    break;
                case "GalnetAudio_Play_Pause":
                    SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_SkipBackward);
                    break;

                // in srv

                case "ToggleDriveAssist":
                    SendKeypressUp(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;
                case "SteerLeftButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].SteerLeftButton);
                    break;
                case "SteerRightButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].SteerRightButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonMax":
                    SendKeypressUp(Program.Binding[BindingType.Srv].DecreaseSpeedButtonMax);
                    break;
                case "IncreaseSpeedButtonPartial":
                    SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseSpeedButtonPartial);
                    break;
                case "DecreaseSpeedButtonPartial":
                    SendKeypressUp(Program.Binding[BindingType.Srv].DecreaseSpeedButtonPartial);
                    break;
                case "RecallDismissShip":
                    SendKeypressUp(Program.Binding[BindingType.Srv].RecallDismissShip);
                    break;
                case "VerticalThrustersButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].VerticalThrustersButton);
                    break;

                case "PhotoCameraToggle_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].PhotoCameraToggle_Buggy);
                    break;

                case "FocusCommsPanel_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    break;
                case "GalaxyMapOpen_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;
                case "HeadlightsBuggyButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    break;
                case "BuggyPitchDownButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyPitchUpButton);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    SendKeypressUp(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    break;

                // on foot

                case "HumanoidClearAuthorityLevel":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidClearAuthorityLevel);
                    break;
                case "HumanoidHealthPack":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidHealthPack);
                    break;
                case "HumanoidBattery":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidBattery);
                    break;
                case "HumanoidSelectFragGrenade":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectFragGrenade);
                    break;
                case "HumanoidSelectEMPGrenade":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectEMPGrenade);
                    break;
                case "HumanoidSelectShieldGrenade":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectShieldGrenade);
                    break;

                case "PhotoCameraToggle_Humanoid":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].PhotoCameraToggle_Humanoid);
                    break;
                case "HumanoidForwardButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidForwardButton);
                    break;
                case "HumanoidBackwardButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidBackwardButton);
                    break;
                case "HumanoidStrafeLeftButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidStrafeLeftButton);
                    break;
                case "HumanoidStrafeRightButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidStrafeRightButton);
                    break;
                case "HumanoidSprintButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSprintButton);
                    break;
                case "HumanoidCrouchButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidCrouchButton);
                    break;
                case "HumanoidJumpButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidJumpButton);
                    break;
                case "HumanoidPrimaryInteractButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPrimaryInteractButton);
                    break;
                case "HumanoidItemWheelButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidItemWheelButton);
                    break;
                case "HumanoidEmoteWheelButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteWheelButton);
                    break;
                case "HumanoidUtilityWheelCycleMode":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidUtilityWheelCycleMode);
                    break;

                case "HumanoidPrimaryFireButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPrimaryFireButton);
                    break;
                case "HumanoidSelectPrimaryWeaponButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectPrimaryWeaponButton);
                    break;
                case "HumanoidSelectSecondaryWeaponButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectSecondaryWeaponButton);
                    break;
                case "HumanoidHideWeaponButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidHideWeaponButton);
                    break;
                case "HumanoidZoomButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidZoomButton);
                    break;
                case "HumanoidReloadButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidReloadButton);
                    break;
                case "HumanoidThrowGrenadeButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidThrowGrenadeButton);
                    break;
                case "HumanoidMeleeButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidMeleeButton);
                    break;
                case "HumanoidOpenAccessPanelButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidOpenAccessPanelButton);
                    break;
                case "HumanoidSecondaryInteractButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSecondaryInteractButton);
                    break;
                case "HumanoidSwitchToRechargeTool":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchToRechargeTool);
                    break;
                case "HumanoidSwitchToCompAnalyser":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchToCompAnalyser);
                    break;
                case "HumanoidToggleToolModeButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleToolModeButton);
                    break;
                case "HumanoidToggleNightVisionButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    break;
                case "HumanoidSwitchToSuitTool":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchToSuitTool);
                    break;
                case "HumanoidToggleFlashlightButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton);
                    break;
                case "GalaxyMapOpen_Humanoid":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    break;
                case "SystemMapOpen_Humanoid":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    break;
                case "FocusCommsPanel_Humanoid":
                    SendKeypressDown(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    break;
                case "QuickCommsPanel_Humanoid":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].QuickCommsPanel_Humanoid);
                    break;
                case "HumanoidConflictContextualUIButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidConflictContextualUIButton);
                    break;
                case "HumanoidToggleShieldsButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleShieldsButton);
                    break;

                case "HumanoidRotateLeftButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidRotateLeftButton);
                    break;
                case "HumanoidRotateRightButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidRotateRightButton);
                    break;
                case "HumanoidPitchUpButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPitchUpButton);
                    break;
                case "HumanoidPitchDownButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPitchDownButton);
                    break;
                case "HumanoidSwitchWeapon":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchWeapon);
                    break;
                case "HumanoidSelectUtilityWeaponButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectUtilityWeaponButton);
                    break;
                case "HumanoidSelectNextWeaponButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectNextWeaponButton);
                    break;
                case "HumanoidSelectPreviousWeaponButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousWeaponButton);
                    break;
                case "HumanoidSelectNextGrenadeTypeButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectNextGrenadeTypeButton);
                    break;
                case "HumanoidSelectPreviousGrenadeTypeButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousGrenadeTypeButton);
                    break;

                case "HumanoidToggleMissionHelpPanelButton":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleMissionHelpPanelButton);
                    break;
                case "HumanoidPing":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPing);
                    break;

                case "HumanoidEmoteSlot1":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot1);
                    break;
                case "HumanoidEmoteSlot2":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot2);
                    break;
                case "HumanoidEmoteSlot3":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot3);
                    break;
                case "HumanoidEmoteSlot4":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot4);
                    break;
                case "HumanoidEmoteSlot5":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot5);
                    break;
                case "HumanoidEmoteSlot6":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot6);
                    break;
                case "HumanoidEmoteSlot7":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot7);
                    break;
                case "HumanoidEmoteSlot8":
                    SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot8);
                    break;

            }

            /*
        <select class="sdpi-item-value select sdProperty" id="function" oninput="setSettings()">
            <optgroup label="Navigation">
                <option value="BackwardKey">Reverse Thrust</option>
                <option value="BackwardThrustButton">Reverse thrust</option>
                <option value="BackwardThrustButton_Landing">Reverse Thrust (Lndg)</option>
                <option value="DownThrustButton">Thrust Down</option>
                <option value="DownThrustButton_Landing">Thrust Down (Lndg)</option>
                <option value="ForwardKey">Forward Thrust</option>
                <option value="ForwardThrustButton">Forward Thrust</option>
                <option value="ForwardThrustButton_Landing">Forward Thrust (Lndg)</option>
                <option value="LeftThrustButton">Thrust Left</option>
                <option value="LeftThrustButton_Landing">Thrust Left (Lndg)</option>
                <option value="PitchDownButton">Pitch Down</option>
                <option value="PitchDownButton_Landing">Pitch Down (Lndg)</option>
                <option value="PitchUpButton">Pitch Up</option>
                <option value="PitchUpButton_Landing">Pitch Up (Lndg)</option>
                <option value="RightThrustButton">Thrust Right</option>
                <option value="RightThrustButton_Landing">Thrust Right (Lndg)</option>
                <option value="UpThrustButton">Thrust Up</option>
                <option value="UpThrustButton_Landing">Thrust Up (Lndg)</option>
                <option value="YawLeftButton">Yaw Left</option>
                <option value="YawLeftButton_Landing">Yaw Left (Lndg)</option>
                <option value="YawRightButton">Yaw Right</option>
                <option value="YawRightButton_Landing">Yaw Right (Lndg)</option>
                <option value="YawToRollButton">Yaw To Roll</option>
                <option value="RollLeftButton">Roll Left</option>
                <option value="RollLeftButton_Landing">Roll Left (Lndg)</option>
                <option value="RollRightButton">Roll Right</option>
                <option value="RollRightButton_Landing">Roll Right (Lndg)</option>
            </optgroup>
            <optgroup label="Ship">
                <option value="ShowPGScoreSummaryInput">CQC Score</option>
                <option value="UIFocus">UI Focus</option>
            </optgroup>
            <optgroup label="Camera">
                <option value="FixCameraRelativeToggle">Lock to Vehicle</option>
                <option value="FixCameraWorldToggle">Lock to World</option>
                <option value="FocusDistanceDec">Focus Nearer</option>
                <option value="FocusDistanceInc">Focus Further</option>
                <option value="FreeCamSpeedDec">Dec Cam Speed</option>
                <option value="FreeCamSpeedInc">Inc Cam Speed</option>
                <option value="FreeCamToggleHUD">Toggle HUD</option>
                <option value="FreeCamZoomIn">Zoom In</option>
                <option value="FreeCamZoomOut">Zoom Out</option>
                <option value="FStopDec">Dec Blur</option>
                <option value="FStopInc">Inc Blur</option>
                <option value="MoveFreeCamBackwards">Cam Backwards</option>
                <option value="MoveFreeCamDown">Cam Down</option>
                <option value="MoveFreeCamForward">Cam Forwards</option>
                <option value="MoveFreeCamLeft">Cam Left</option>
                <option value="MoveFreeCamRight">Cam Right</option>
                <option value="MoveFreeCamUp">Cam Up</option>
                <option value="PhotoCameraToggle">External Cam</option>
                <option value="PhotoCameraToggle_Buggy">External Cam Buggy</option>
                <option value="PhotoCameraToggle_Humanoid">External Cam Cmdr</option>
                <option value="PitchCameraDown">Cam Pitch Down</option>
                <option value="PitchCameraUp">Cam Pitch Up</option>
                <option value="QuitCamera">Exit free Cam</option>
                <option value="RollCameraLeft">Cam Roll Left</option>
                <option value="RollCameraRight">Cam Roll Right</option>
                <option value="StoreCamZoomIn">Store Cam Zoom In</option>
                <option value="StoreCamZoomOut">Store Cam Zoom Out</option>
                <option value="StoreEnableRotation">Store Cam Rotation</option>
                <option value="StorePitchCameraDown">Store Cam Pitch Down</option>
                <option value="StorePitchCameraUp">Store Cam Pitch Up</option>
                <option value="StoreToggle">Store Toggle Preview</option>
                <option value="StoreYawCameraLeft">Store Cam Yaw Left</option>
                <option value="StoreYawCameraRight">Store Cam Yaw Right</option>
                <option value="ToggleAdvanceMode">Advanced Cam</option>
                <option value="ToggleFreeCam">Free Cam</option>
                <option value="ToggleReverseThrottleInputFreeCam">Cam Reverse</option>
                <option value="ToggleRotationLock">Cam Rotation Lock</option>
                <option value="VanityCameraEight">Cam - Back</option>
                <option value="VanityCameraFive">Cam - Co-Pilot 1</option>
                <option value="VanityCameraFour">Cam - Commander 2</option>
                <option value="VanityCameraNine">Cam - Back</option>
                <option value="VanityCameraTen">Cam - Back Low</option>
                <option value="VanityCameraOne">Cam - Cockpit Front</option>
                <option value="VanityCameraScrollLeft">Prev Cam</option>
                <option value="VanityCameraScrollRight">Next Cam</option>
                <option value="VanityCameraSeven">Cam - Front</option>
                <option value="VanityCameraSix">Cam - Co-Pilot 2</option>
                <option value="VanityCameraThree">Cam - Commander 1</option>
                <option value="VanityCameraTwo">Cam - Cockpit Back</option>
                <option value="YawCameraLeft">Cam Yaw Left</option>
                <option value="YawCameraRight">Cam Yaw Right</option>
            </optgroup>
            <optgroup label="Galaxy map">
                <option value="CamPitchDown">GalMap Pitch Down</option>
                <option value="CamPitchUp">GalMap Pitch Up</option>
                <option value="CamTranslateDown">GalMap Down</option>
                <option value="CamTranslateUp">GalMap Up</option>
                <option value="CamTranslateZHold">GalMap Z Hold</option>
                <option value="CamYawLeft">GalMap Yaw Left</option>
                <option value="CamYawRight">GalMap Yaw Right</option>
                <option value="CamZoomIn">GalMap Zoom In</option>
                <option value="CamZoomOut">GalMap Zoom Out</option>
            </optgroup>
            <optgroup label="Head look">
                <option value="HeadLookPitchDown">Look Down</option>
                <option value="HeadLookYawLeft">Look Left</option>
                <option value="HeadLookYawRight">Look Right</option>
                <option value="HeadLookPitchUp">Look Up</option>
                <option value="HeadLookReset">Reset Headlook</option>
            </optgroup>
            <optgroup label="Holo-Me">
                <option value="CommanderCreator_Redo">Redo Holo-Me</option>
                <option value="CommanderCreator_Rotation">Rotate Holo-Me</option>
                <option value="CommanderCreator_Rotation_MouseToggle">Toggle Holo-Me Rotation</option>
                <option value="CommanderCreator_Undo">Undo Holo-Me</option>
            </optgroup>
            <optgroup label="Multicrew">
                <option value="MultiCrewCockpitUICycleBackward">UI Backward</option>
                <option value="MultiCrewCockpitUICycleForward">UI Forward</option>
                <option value="MultiCrewPrimaryFire">Fire 1</option>
                <option value="MultiCrewPrimaryUtilityFire">Primary Utility</option>
                <option value="MultiCrewSecondaryFire">Fire 2</option>
                <option value="MultiCrewSecondaryUtilityFire">Secondary Utility</option>
                <option value="MultiCrewThirdPersonFovInButton">Field of View In</option>
                <option value="MultiCrewThirdPersonFovOutButton">Field of View Out</option>
                <option value="MultiCrewThirdPersonPitchDownButton">Pitch Down</option>
                <option value="MultiCrewThirdPersonPitchUpButton">Pitch Up</option>
                <option value="MultiCrewThirdPersonYawLeftButton">Yaw Left</option>
                <option value="MultiCrewThirdPersonYawRightButton">Yaw Right</option>
                <option value="MultiCrewToggleMode">Multicrew Mode</option>
            </optgroup>
            <optgroup label="Scanners">
                <option value="ExplorationFSSCameraPitchDecreaseButton">FSS Pitch Down</option>
                <option value="ExplorationFSSCameraPitchIncreaseButton">FSS Pitch Up</option>
                <option value="ExplorationFSSCameraYawDecreaseButton">FSS Yaw Left</option>
                <option value="ExplorationFSSCameraYawIncreaseButton">FSS Yaw Right</option>
                <option value="ExplorationFSSDiscoveryScan">FSS Honk</option>
                <option value="ExplorationFSSMiniZoomIn">Step Zoom FSS In</option>
                <option value="ExplorationFSSMiniZoomOut">Step Zoom FSS Out</option>
                <option value="ExplorationFSSRadioTuningX_Decrease">FSS Tune Left</option>
                <option value="ExplorationFSSRadioTuningX_Increase">FSS Tune Right</option>
                <option value="ExplorationFSSShowHelp">FSS Help</option>
                <option value="ExplorationFSSTarget">Target FSS</option>
                <option value="ExplorationFSSZoomIn">Zoom FSS In</option>
                <option value="ExplorationFSSZoomOut">Zoom FSS Out</option>
                <option value="ExplorationSAAChangeScannedAreaViewToggle">Toggle Planet Front/Back</option>
                <option value="ExplorationSAAExitThirdPerson">Exit DSS</option>
                <option value="ExplorationSAANextGenus">DSS Next Genus</option>
                <option value="ExplorationSAAPreviousGenus">DSS Previous Genus</option>
                <option value="ExplorationSAAShowHelp">DSS Show Help</option>
                <option value="SAAThirdPersonFovInButton">DSS Field of View In</option>
                <option value="SAAThirdPersonFovOutButton">DSS Field of View Out</option>
                <option value="SAAThirdPersonPitchDownButton">Pitch Down (DSS)</option>
                <option value="SAAThirdPersonPitchUpButton">Pitch Up (DSS)</option>
                <option value="SAAThirdPersonYawLeftButton">Yaw Left (DSS)</option>
                <option value="SAAThirdPersonYawRightButton">Yaw Right (DSS)</option>
            </optgroup>
            <optgroup label="SRV">
                <option value="BuggyPitchDownButton">Pitch Down</option>
                <option value="BuggyPitchUpButton">Pitch Up</option>
                <option value="BuggyPrimaryFireButton">Primary Weapons</option>
                <option value="BuggySecondaryFireButton">Secondary Weapons</option>
                <option value="BuggyRollLeft">Roll Left</option>
                <option value="BuggyRollLeftButton">Roll Left</option>
                <option value="BuggyRollRight">Roll Right</option>
                <option value="BuggyRollRightButton">Roll Right</option>
                <option value="BuggyTurretPitchDownButton">Turret Down</option>
                <option value="BuggyTurretPitchUpButton">Turret Up</option>
                <option value="BuggyTurretYawLeftButton">Turret Left</option>
                <option value="BuggyTurretYawRightButton">Turret Right</option>
                <option value="EjectAllCargo_Buggy">Eject All Cargo</option>
                <option value="FocusCommsPanel_Buggy">Comms Panel</option>
                <option value="FocusLeftPanel_Buggy">Nav Panel</option>
                <option value="FocusRadarPanel_Buggy">Role Panel</option>
                <option value="FocusRightPanel_Buggy">Systems Panel</option>
                <option value="HeadLookToggle_Buggy">Toggle Headlook</option>
                <option value="IncreaseSpeedButtonPartial">Inc Speed</option>
                <option value="DecreaseSpeedButtonPartial">Dec Speed</option>
                <option value="QuickCommsPanel_Buggy">Quick Comms</option>
                <option value="SteerLeftButton">Steer Left</option>
                <option value="SteerRightButton">Steer Right</option>
                <option value="UIFocus_Buggy">UI Focus</option>
                <option value="VerticalThrustersButton">Vertical Thrusters</option>
            </optgroup>
            <optgroup label="UI">
                <option value="CycleNextPage">Next Page</option>
                <option value="CycleNextPanel">Next Panel</option>
                <option value="CyclePreviousPage">Prev Page</option>
                <option value="CyclePreviousPanel">Prev Panel</option>
                <option value="UI_Back">UI Back</option>
                <option value="UI_Down">UI Down</option>
                <option value="UI_Left">UI Left</option>
                <option value="UI_Right">UI Right</option>
                <option value="UI_Select">UI Select</option>
                <option value="UI_Toggle">UI Toggle</option>
                <option value="UI_Up">UI Up</option>
            </optgroup>
        </select>

             */

        }

        public override void Dispose()
        {
            base.Dispose();

            //Logger.Instance.LogMessage(TracingLevel.DEBUG, "Destructor called #1");
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
