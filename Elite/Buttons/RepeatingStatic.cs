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
                HandleFilenames();
            }

        }

        public override void KeyPressed(KeyPayload payload)
        {
            if (Program.Bindings == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;

            switch (settings.Function)
            {
                case "PhotoCameraToggle":
                    SendKeypressDown(Program.Bindings.PhotoCameraToggle);
                    break;
                case "PhotoCameraToggle_Buggy":
                    SendKeypressDown(Program.Bindings.PhotoCameraToggle_Buggy);
                    break;
                case "StorePitchCameraDown":
                    SendKeypressDown(Program.Bindings.StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    SendKeypressDown(Program.Bindings.StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    SendKeypressDown(Program.Bindings.StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    SendKeypressDown(Program.Bindings.StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    SendKeypressDown(Program.Bindings.StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    SendKeypressDown(Program.Bindings.StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    SendKeypressDown(Program.Bindings.StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    SendKeypressDown(Program.Bindings.StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    SendKeypressDown(Program.Bindings.ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    SendKeypressDown(Program.Bindings.VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    SendKeypressDown(Program.Bindings.VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    SendKeypressDown(Program.Bindings.VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    SendKeypressDown(Program.Bindings.VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    SendKeypressDown(Program.Bindings.VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    SendKeypressDown(Program.Bindings.VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    SendKeypressDown(Program.Bindings.VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    SendKeypressDown(Program.Bindings.VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    SendKeypressDown(Program.Bindings.VanityCameraNine);
                    break;
                case "MoveFreeCamBackwards":
                    SendKeypressDown(Program.Bindings.MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    SendKeypressDown(Program.Bindings.MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    SendKeypressDown(Program.Bindings.MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    SendKeypressDown(Program.Bindings.MoveFreeCamLeft);
                    break;
                case "PitchCameraDown":
                    SendKeypressDown(Program.Bindings.PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    SendKeypressDown(Program.Bindings.PitchCameraUp);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    SendKeypressDown(Program.Bindings.ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    SendKeypressDown(Program.Bindings.MoveFreeCamRight);
                    break;
                case "RollCameraLeft":
                    SendKeypressDown(Program.Bindings.RollCameraLeft);
                    break;
                case "RollCameraRight":
                    SendKeypressDown(Program.Bindings.RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    SendKeypressDown(Program.Bindings.ToggleRotationLock);
                    break;
                case "MoveFreeCamUp":
                    SendKeypressDown(Program.Bindings.MoveFreeCamUp);
                    break;
                case "YawCameraLeft":
                    SendKeypressDown(Program.Bindings.YawCameraLeft);
                    break;
                case "YawCameraRight":
                    SendKeypressDown(Program.Bindings.YawCameraRight);
                    break;
                case "FStopDec":
                    SendKeypressDown(Program.Bindings.FStopDec);
                    break;
                case "FreeCamSpeedDec":
                    SendKeypressDown(Program.Bindings.FreeCamSpeedDec);
                    break;
                case "QuitCamera":
                    SendKeypressDown(Program.Bindings.QuitCamera);
                    break;
                case "FocusDistanceInc":
                    SendKeypressDown(Program.Bindings.FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    SendKeypressDown(Program.Bindings.FocusDistanceDec);
                    break;
                case "ToggleFreeCam":
                    SendKeypressDown(Program.Bindings.ToggleFreeCam);
                    break;
                case "FStopInc":
                    SendKeypressDown(Program.Bindings.FStopInc);
                    break;
                case "FreeCamSpeedInc":
                    SendKeypressDown(Program.Bindings.FreeCamSpeedInc);
                    break;
                case "FixCameraRelativeToggle":
                    SendKeypressDown(Program.Bindings.FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    SendKeypressDown(Program.Bindings.FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    SendKeypressDown(Program.Bindings.VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    SendKeypressDown(Program.Bindings.VanityCameraScrollLeft);
                    break;
                case "FreeCamToggleHUD":
                    SendKeypressDown(Program.Bindings.FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    SendKeypressDown(Program.Bindings.FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    SendKeypressDown(Program.Bindings.FreeCamZoomOut);
                    break;
                case "OrderFocusTarget":
                    SendKeypressDown(Program.Bindings.OrderFocusTarget);
                    break;
                case "OrderAggressiveBehaviour":
                    SendKeypressDown(Program.Bindings.OrderAggressiveBehaviour);
                    break;
                case "OrderDefensiveBehaviour":
                    SendKeypressDown(Program.Bindings.OrderDefensiveBehaviour);
                    break;
                case "OpenOrders":
                    SendKeypressDown(Program.Bindings.OpenOrders);
                    break;
                case "OrderRequestDock":
                    SendKeypressDown(Program.Bindings.OrderRequestDock);
                    break;
                case "OrderFollow":
                    SendKeypressDown(Program.Bindings.OrderFollow);
                    break;
                case "OrderHoldFire":
                    SendKeypressDown(Program.Bindings.OrderHoldFire);
                    break;
                case "OrderHoldPosition":
                    SendKeypressDown(Program.Bindings.OrderHoldPosition);
                    break;
                case "CamTranslateBackward":
                    SendKeypressDown(Program.Bindings.CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    SendKeypressDown(Program.Bindings.CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    SendKeypressDown(Program.Bindings.CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    SendKeypressDown(Program.Bindings.CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    SendKeypressDown(Program.Bindings.CamPitchDown);
                    break;
                case "CamPitchUp":
                    SendKeypressDown(Program.Bindings.CamPitchUp);
                    break;
                case "CamTranslateRight":
                    SendKeypressDown(Program.Bindings.CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    SendKeypressDown(Program.Bindings.CamTranslateUp);
                    break;
                case "CamYawLeft":
                    SendKeypressDown(Program.Bindings.CamYawLeft);
                    break;
                case "CamYawRight":
                    SendKeypressDown(Program.Bindings.CamYawRight);
                    break;
                case "CamTranslateZHold":
                    SendKeypressDown(Program.Bindings.CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    SendKeypressDown(Program.Bindings.CamZoomIn);
                    break;
                case "CamZoomOut":
                    SendKeypressDown(Program.Bindings.CamZoomOut);
                    break;
                case "HeadLookPitchDown":
                    SendKeypressDown(Program.Bindings.HeadLookPitchDown);
                    break;
                case "HeadLookYawLeft":
                    SendKeypressDown(Program.Bindings.HeadLookYawLeft);
                    break;
                case "HeadLookYawRight":
                    SendKeypressDown(Program.Bindings.HeadLookYawRight);
                    break;
                case "HeadLookPitchUp":
                    SendKeypressDown(Program.Bindings.HeadLookPitchUp);
                    break;
                case "HeadLookReset":
                    SendKeypressDown(Program.Bindings.HeadLookReset);
                    break;
                case "CommanderCreator_Redo":
                    SendKeypressDown(Program.Bindings.CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    SendKeypressDown(Program.Bindings.CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    SendKeypressDown(Program.Bindings.CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    SendKeypressDown(Program.Bindings.CommanderCreator_Undo);
                    break;
                case "GalnetAudio_ClearQueue":
                    SendKeypressDown(Program.Bindings.GalnetAudio_ClearQueue);
                    break;
                case "OpenCodexGoToDiscovery":
                    SendKeypressDown(Program.Bindings.OpenCodexGoToDiscovery);
                    break;
                case "FriendsMenu":
                    SendKeypressDown(Program.Bindings.FriendsMenu);
                    break;
                case "Pause":
                    SendKeypressDown(Program.Bindings.Pause);
                    break;
                case "MicrophoneMute":
                    SendKeypressDown(Program.Bindings.MicrophoneMute);
                    break;
                case "GalnetAudio_SkipForward":
                    SendKeypressDown(Program.Bindings.GalnetAudio_SkipForward);
                    break;
                case "NightVisionToggle":
                    SendKeypressDown(Program.Bindings.NightVisionToggle);
                    break;
                case "GalnetAudio_Play_Pause":
                    SendKeypressDown(Program.Bindings.GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    SendKeypressDown(Program.Bindings.GalnetAudio_SkipBackward);
                    break;
                case "HMDReset":
                    SendKeypressDown(Program.Bindings.HMDReset);
                    break;
                case "OculusReset":
                    SendKeypressDown(Program.Bindings.OculusReset);
                    break;
                case "RadarDecreaseRange":
                    SendKeypressDown(Program.Bindings.RadarDecreaseRange);
                    break;
                case "RadarIncreaseRange":
                    SendKeypressDown(Program.Bindings.RadarIncreaseRange);
                    break;
                case "MultiCrewThirdPersonFovInButton":
                    SendKeypressDown(Program.Bindings.MultiCrewThirdPersonFovInButton);
                    break;
                case "MultiCrewThirdPersonFovOutButton":
                    SendKeypressDown(Program.Bindings.MultiCrewThirdPersonFovOutButton);
                    break;
                case "MultiCrewPrimaryFire":
                    SendKeypressDown(Program.Bindings.MultiCrewPrimaryFire);
                    break;
                case "MultiCrewSecondaryFire":
                    SendKeypressDown(Program.Bindings.MultiCrewSecondaryFire);
                    break;
                case "MultiCrewToggleMode":
                    SendKeypressDown(Program.Bindings.MultiCrewToggleMode);
                    break;
                case "MultiCrewThirdPersonPitchDownButton":
                    SendKeypressDown(Program.Bindings.MultiCrewThirdPersonPitchDownButton);
                    break;
                case "MultiCrewThirdPersonPitchUpButton":
                    SendKeypressDown(Program.Bindings.MultiCrewThirdPersonPitchUpButton);
                    break;
                case "MultiCrewPrimaryUtilityFire":
                    SendKeypressDown(Program.Bindings.MultiCrewPrimaryUtilityFire);
                    break;
                case "MultiCrewSecondaryUtilityFire":
                    SendKeypressDown(Program.Bindings.MultiCrewSecondaryUtilityFire);
                    break;
                case "MultiCrewCockpitUICycleBackward":
                    SendKeypressDown(Program.Bindings.MultiCrewCockpitUICycleBackward);
                    break;
                case "MultiCrewCockpitUICycleForward":
                    SendKeypressDown(Program.Bindings.MultiCrewCockpitUICycleForward);
                    break;
                case "MultiCrewThirdPersonYawLeftButton":
                    SendKeypressDown(Program.Bindings.MultiCrewThirdPersonYawLeftButton);
                    break;
                case "MultiCrewThirdPersonYawRightButton":
                    SendKeypressDown(Program.Bindings.MultiCrewThirdPersonYawRightButton);
                    break;
                case "SAAThirdPersonFovInButton":
                    SendKeypressDown(Program.Bindings.SAAThirdPersonFovInButton);
                    break;
                case "SAAThirdPersonFovOutButton":
                    SendKeypressDown(Program.Bindings.SAAThirdPersonFovOutButton);
                    break;
                case "ExplorationFSSEnter":
                    SendKeypressDown(Program.Bindings.ExplorationFSSEnter);
                    break;
                case "ExplorationSAAExitThirdPerson":
                    SendKeypressDown(Program.Bindings.ExplorationSAAExitThirdPerson);
                    break;
                case "ExplorationFSSQuit":
                    SendKeypressDown(Program.Bindings.ExplorationFSSQuit);
                    break;
                case "ExplorationFSSShowHelp":
                    SendKeypressDown(Program.Bindings.ExplorationFSSShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
                    SendKeypressDown(Program.Bindings.ExplorationFSSDiscoveryScan);
                    break;
                case "ExplorationFSSCameraPitchDecreaseButton":
                    SendKeypressDown(Program.Bindings.ExplorationFSSCameraPitchDecreaseButton);
                    break;
                case "ExplorationFSSCameraPitchIncreaseButton":
                    SendKeypressDown(Program.Bindings.ExplorationFSSCameraPitchIncreaseButton);
                    break;
                case "ExplorationFSSRadioTuningX_Decrease":
                    SendKeypressDown(Program.Bindings.ExplorationFSSRadioTuningX_Decrease);
                    break;
                case "ExplorationFSSRadioTuningX_Increase":
                    SendKeypressDown(Program.Bindings.ExplorationFSSRadioTuningX_Increase);
                    break;
                case "ExplorationFSSCameraYawDecreaseButton":
                    SendKeypressDown(Program.Bindings.ExplorationFSSCameraYawDecreaseButton);
                    break;
                case "ExplorationFSSCameraYawIncreaseButton":
                    SendKeypressDown(Program.Bindings.ExplorationFSSCameraYawIncreaseButton);
                    break;
                case "SAAThirdPersonPitchDownButton":
                    SendKeypressDown(Program.Bindings.SAAThirdPersonPitchDownButton);
                    break;
                case "SAAThirdPersonPitchUpButton":
                    SendKeypressDown(Program.Bindings.SAAThirdPersonPitchUpButton);
                    break;
                case "ExplorationFSSMiniZoomIn":
                    SendKeypressDown(Program.Bindings.ExplorationFSSMiniZoomIn);
                    break;
                case "ExplorationFSSMiniZoomOut":
                    SendKeypressDown(Program.Bindings.ExplorationFSSMiniZoomOut);
                    break;
                case "ExplorationFSSTarget":
                    SendKeypressDown(Program.Bindings.ExplorationFSSTarget);
                    break;
                case "ExplorationSAAChangeScannedAreaViewToggle":
                    SendKeypressDown(Program.Bindings.ExplorationSAAChangeScannedAreaViewToggle);
                    break;
                case "SAAThirdPersonYawLeftButton":
                    SendKeypressDown(Program.Bindings.SAAThirdPersonYawLeftButton);
                    break;
                case "SAAThirdPersonYawRightButton":
                    SendKeypressDown(Program.Bindings.SAAThirdPersonYawRightButton);
                    break;
                case "ExplorationFSSZoomIn":
                    SendKeypressDown(Program.Bindings.ExplorationFSSZoomIn);
                    break;
                case "ExplorationFSSZoomOut":
                    SendKeypressDown(Program.Bindings.ExplorationFSSZoomOut);
                    break;
                case "FocusCommsPanel":
                    SendKeypressDown(Program.Bindings.FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    SendKeypressDown(Program.Bindings.FocusLeftPanel);
                    break;
                case "QuickCommsPanel":
                    SendKeypressDown(Program.Bindings.QuickCommsPanel);
                    break;
                case "FocusRadarPanel":
                    SendKeypressDown(Program.Bindings.FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    SendKeypressDown(Program.Bindings.FocusRightPanel);
                    break;
                case "UIFocus":
                    SendKeypressDown(Program.Bindings.UIFocus);
                    break;
                case "TargetWingman0":
                    SendKeypressDown(Program.Bindings.TargetWingman0);
                    break;
                case "TargetWingman1":
                    SendKeypressDown(Program.Bindings.TargetWingman1);
                    break;
                case "TargetWingman2":
                    SendKeypressDown(Program.Bindings.TargetWingman2);
                    break;
                case "WingNavLock":
                    SendKeypressDown(Program.Bindings.WingNavLock);
                    break;
                case "SelectTargetsTarget":
                    SendKeypressDown(Program.Bindings.SelectTargetsTarget);
                    break;
                case "FireChaffLauncher":
                    SendKeypressDown(Program.Bindings.FireChaffLauncher);
                    break;
                case "ChargeECM":
                    SendKeypressDown(Program.Bindings.ChargeECM);
                    break;
                case "IncreaseEnginesPower":
                    SendKeypressDown(Program.Bindings.IncreaseEnginesPower);
                    break;
                case "PrimaryFire":
                    SendKeypressDown(Program.Bindings.PrimaryFire);
                    break;
                case "SecondaryFire":
                    SendKeypressDown(Program.Bindings.SecondaryFire);
                    break;
                case "DeployHardpointToggle":
                    SendKeypressDown(Program.Bindings.DeployHardpointToggle);
                    break;
                case "DeployHeatSink":
                    SendKeypressDown(Program.Bindings.DeployHeatSink);
                    break;
                case "SelectHighestThreat":
                    SendKeypressDown(Program.Bindings.SelectHighestThreat);
                    break;
                case "CycleNextTarget":
                    SendKeypressDown(Program.Bindings.CycleNextTarget);
                    break;
                case "CycleFireGroupNext":
                    SendKeypressDown(Program.Bindings.CycleFireGroupNext);
                    break;
                case "CycleNextHostileTarget":
                    SendKeypressDown(Program.Bindings.CycleNextHostileTarget);
                    break;
                case "CycleNextSubsystem":
                    SendKeypressDown(Program.Bindings.CycleNextSubsystem);
                    break;
                case "CyclePreviousTarget":
                    SendKeypressDown(Program.Bindings.CyclePreviousTarget);
                    break;
                case "CycleFireGroupPrevious":
                    SendKeypressDown(Program.Bindings.CycleFireGroupPrevious);
                    break;
                case "CyclePreviousHostileTarget":
                    SendKeypressDown(Program.Bindings.CyclePreviousHostileTarget);
                    break;
                case "CyclePreviousSubsystem":
                    SendKeypressDown(Program.Bindings.CyclePreviousSubsystem);
                    break;
                case "ResetPowerDistribution":
                    SendKeypressDown(Program.Bindings.ResetPowerDistribution);
                    break;
                case "UseShieldCell":
                    SendKeypressDown(Program.Bindings.UseShieldCell);
                    break;
                case "IncreaseSystemsPower":
                    SendKeypressDown(Program.Bindings.IncreaseSystemsPower);
                    break;
                case "SelectTarget":
                    SendKeypressDown(Program.Bindings.SelectTarget);
                    break;
                case "IncreaseWeaponsPower":
                    SendKeypressDown(Program.Bindings.IncreaseWeaponsPower);
                    break;
                case "ShowPGScoreSummaryInput":
                    SendKeypressDown(Program.Bindings.ShowPGScoreSummaryInput);
                    break;
                case "EjectAllCargo":
                    SendKeypressDown(Program.Bindings.EjectAllCargo);
                    break;
                case "EngineColourToggle":
                    SendKeypressDown(Program.Bindings.EngineColourToggle);
                    break;
                case "PlayerHUDModeToggle":
                    SendKeypressDown(Program.Bindings.PlayerHUDModeToggle);
                    break;
                case "OrbitLinesToggle":
                    SendKeypressDown(Program.Bindings.OrbitLinesToggle);
                    break;
                case "MouseReset":
                    SendKeypressDown(Program.Bindings.MouseReset);
                    break;
                case "HeadLookToggle":
                    SendKeypressDown(Program.Bindings.HeadLookToggle);
                    break;
                case "WeaponColourToggle":
                    SendKeypressDown(Program.Bindings.WeaponColourToggle);
                    break;
                case "SetSpeedMinus100":
                    SendKeypressDown(Program.Bindings.SetSpeedMinus100);
                    break;
                case "SetSpeed100":
                    SendKeypressDown(Program.Bindings.SetSpeed100);
                    break;
                case "SetSpeedMinus25":
                    SendKeypressDown(Program.Bindings.SetSpeedMinus25);
                    break;
                case "SetSpeed25":
                    SendKeypressDown(Program.Bindings.SetSpeed25);
                    break;
                case "SetSpeedMinus50":
                    SendKeypressDown(Program.Bindings.SetSpeedMinus50);
                    break;
                case "SetSpeed50":
                    SendKeypressDown(Program.Bindings.SetSpeed50);
                    break;
                case "SetSpeedMinus75":
                    SendKeypressDown(Program.Bindings.SetSpeedMinus75);
                    break;
                case "SetSpeed75":
                    SendKeypressDown(Program.Bindings.SetSpeed75);
                    break;
                case "SetSpeedZero":
                    SendKeypressDown(Program.Bindings.SetSpeedZero);
                    break;
                case "UseAlternateFlightValuesToggle":
                    SendKeypressDown(Program.Bindings.UseAlternateFlightValuesToggle);
                    break;
                case "UseBoostJuice":
                    SendKeypressDown(Program.Bindings.UseBoostJuice);
                    break;
                case "ToggleCargoScoop":
                    SendKeypressDown(Program.Bindings.ToggleCargoScoop);
                    break;
                case "ToggleFlightAssist":
                    SendKeypressDown(Program.Bindings.ToggleFlightAssist);
                    break;
                case "ForwardKey":
                    SendKeypressDown(Program.Bindings.ForwardKey);
                    break;
                case "ForwardThrustButton":
                    SendKeypressDown(Program.Bindings.ForwardThrustButton);
                    break;
                case "ForwardThrustButton_Landing":
                    SendKeypressDown(Program.Bindings.ForwardThrustButton_Landing);
                    break;
                case "GalaxyMapOpen":
                    SendKeypressDown(Program.Bindings.GalaxyMapOpen);
                    break;
                case "Hyperspace":
                    SendKeypressDown(Program.Bindings.Hyperspace);
                    break;
                case "HyperSuperCombination":
                    SendKeypressDown(Program.Bindings.HyperSuperCombination);
                    break;
                case "LandingGearToggle":
                    SendKeypressDown(Program.Bindings.LandingGearToggle);
                    break;
                case "ShipSpotLightToggle":
                    SendKeypressDown(Program.Bindings.ShipSpotLightToggle);
                    break;
                case "TargetNextRouteSystem":
                    SendKeypressDown(Program.Bindings.TargetNextRouteSystem);
                    break;
                case "PitchDownButton":
                    SendKeypressDown(Program.Bindings.PitchDownButton);
                    break;
                case "PitchDownButton_Landing":
                    SendKeypressDown(Program.Bindings.PitchDownButton_Landing);
                    break;
                case "PitchUpButton":
                    SendKeypressDown(Program.Bindings.PitchUpButton);
                    break;
                case "PitchUpButton_Landing":
                    SendKeypressDown(Program.Bindings.PitchUpButton_Landing);
                    break;
                case "ToggleReverseThrottleInput":
                    SendKeypressDown(Program.Bindings.ToggleReverseThrottleInput);
                    break;
                case "BackwardKey":
                    SendKeypressDown(Program.Bindings.BackwardKey);
                    break;
                case "BackwardThrustButton":
                    SendKeypressDown(Program.Bindings.BackwardThrustButton);
                    break;
                case "BackwardThrustButton_Landing":
                    SendKeypressDown(Program.Bindings.BackwardThrustButton_Landing);
                    break;
                case "RollLeftButton":
                    SendKeypressDown(Program.Bindings.RollLeftButton);
                    break;
                case "RollLeftButton_Landing":
                    SendKeypressDown(Program.Bindings.RollLeftButton_Landing);
                    break;
                case "RollRightButton":
                    SendKeypressDown(Program.Bindings.RollRightButton);
                    break;
                case "RollRightButton_Landing":
                    SendKeypressDown(Program.Bindings.RollRightButton_Landing);
                    break;
                case "DisableRotationCorrectToggle":
                    SendKeypressDown(Program.Bindings.DisableRotationCorrectToggle);
                    break;
                case "ToggleButtonUpInput":
                    SendKeypressDown(Program.Bindings.ToggleButtonUpInput);
                    break;
                case "Supercruise":
                    SendKeypressDown(Program.Bindings.Supercruise);
                    break;
                case "SystemMapOpen":
                    SendKeypressDown(Program.Bindings.SystemMapOpen);
                    break;
                case "DownThrustButton":
                    SendKeypressDown(Program.Bindings.DownThrustButton);
                    break;
                case "DownThrustButton_Landing":
                    SendKeypressDown(Program.Bindings.DownThrustButton_Landing);
                    break;
                case "LeftThrustButton":
                    SendKeypressDown(Program.Bindings.LeftThrustButton);
                    break;
                case "LeftThrustButton_Landing":
                    SendKeypressDown(Program.Bindings.LeftThrustButton_Landing);
                    break;
                case "RightThrustButton":
                    SendKeypressDown(Program.Bindings.RightThrustButton);
                    break;
                case "RightThrustButton_Landing":
                    SendKeypressDown(Program.Bindings.RightThrustButton_Landing);
                    break;
                case "UpThrustButton":
                    SendKeypressDown(Program.Bindings.UpThrustButton);
                    break;
                case "UpThrustButton_Landing":
                    SendKeypressDown(Program.Bindings.UpThrustButton_Landing);
                    break;
                case "YawLeftButton":
                    SendKeypressDown(Program.Bindings.YawLeftButton);
                    break;
                case "YawLeftButton_Landing":
                    SendKeypressDown(Program.Bindings.YawLeftButton_Landing);
                    break;
                case "YawRightButton":
                    SendKeypressDown(Program.Bindings.YawRightButton);
                    break;
                case "YawRightButton_Landing":
                    SendKeypressDown(Program.Bindings.YawRightButton_Landing);
                    break;
                case "YawToRollButton":
                    SendKeypressDown(Program.Bindings.YawToRollButton);
                    break;
                case "FocusCommsPanel_Buggy":
                    SendKeypressDown(Program.Bindings.FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    SendKeypressDown(Program.Bindings.EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    SendKeypressDown(Program.Bindings.FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    SendKeypressDown(Program.Bindings.QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    SendKeypressDown(Program.Bindings.FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    SendKeypressDown(Program.Bindings.FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    SendKeypressDown(Program.Bindings.HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    SendKeypressDown(Program.Bindings.UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    SendKeypressDown(Program.Bindings.IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    SendKeypressDown(Program.Bindings.BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    SendKeypressDown(Program.Bindings.ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    SendKeypressDown(Program.Bindings.BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    SendKeypressDown(Program.Bindings.IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    SendKeypressDown(Program.Bindings.SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    SendKeypressDown(Program.Bindings.BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    SendKeypressDown(Program.Bindings.BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    SendKeypressDown(Program.Bindings.ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    SendKeypressDown(Program.Bindings.BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    SendKeypressDown(Program.Bindings.BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    SendKeypressDown(Program.Bindings.IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    SendKeypressDown(Program.Bindings.ToggleCargoScoop_Buggy);
                    break;
                case "DecreaseSpeedButtonPartial":
                    SendKeypressDown(Program.Bindings.DecreaseSpeedButtonPartial);
                    break;
                case "ToggleDriveAssist":
                    SendKeypressDown(Program.Bindings.ToggleDriveAssist);
                    break;
                case "GalaxyMapOpen_Buggy":
                    SendKeypressDown(Program.Bindings.GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    SendKeypressDown(Program.Bindings.AutoBreakBuggyButton);
                    break;
                case "IncreaseSpeedButtonPartial":
                    SendKeypressDown(Program.Bindings.IncreaseSpeedButtonPartial);
                    break;
                case "HeadlightsBuggyButton":
                    SendKeypressDown(Program.Bindings.HeadlightsBuggyButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    SendKeypressDown(Program.Bindings.IncreaseSpeedButtonMax);
                    break;
                case "BuggyPitchDownButton":
                    SendKeypressDown(Program.Bindings.BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    SendKeypressDown(Program.Bindings.BuggyPitchUpButton);
                    break;
                case "RecallDismissShip":
                    SendKeypressDown(Program.Bindings.RecallDismissShip);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    SendKeypressDown(Program.Bindings.BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    SendKeypressDown(Program.Bindings.BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    SendKeypressDown(Program.Bindings.BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    SendKeypressDown(Program.Bindings.BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    SendKeypressDown(Program.Bindings.BuggyRollRightButton);
                    break;
                case "SteerLeftButton":
                    SendKeypressDown(Program.Bindings.SteerLeftButton);
                    break;
                case "SteerRightButton":
                    SendKeypressDown(Program.Bindings.SteerRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    SendKeypressDown(Program.Bindings.SystemMapOpen_Buggy);
                    break;
                case "VerticalThrustersButton":
                    SendKeypressDown(Program.Bindings.VerticalThrustersButton);
                    break;
                case "DecreaseSpeedButtonMax":
                    SendKeypressDown(Program.Bindings.DecreaseSpeedButtonMax);
                    break;
                case "CycleNextPage":
                    SendKeypressDown(Program.Bindings.CycleNextPage);
                    break;
                case "CycleNextPanel":
                    SendKeypressDown(Program.Bindings.CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    SendKeypressDown(Program.Bindings.CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    SendKeypressDown(Program.Bindings.CyclePreviousPanel);
                    break;
                case "UI_Back":
                    SendKeypressDown(Program.Bindings.UI_Back);
                    break;
                case "UI_Down":
                    SendKeypressDown(Program.Bindings.UI_Down);
                    break;
                case "UI_Left":
                    SendKeypressDown(Program.Bindings.UI_Left);
                    break;
                case "UI_Right":
                    SendKeypressDown(Program.Bindings.UI_Right);
                    break;
                case "UI_Select":
                    SendKeypressDown(Program.Bindings.UI_Select);
                    break;
                case "UI_Toggle":
                    SendKeypressDown(Program.Bindings.UI_Toggle);
                    break;
                case "UI_Up":
                    SendKeypressDown(Program.Bindings.UI_Up);
                    break;
            }
        }

        public override void KeyReleased(KeyPayload payload)
		{
			if (Program.Bindings == null)
			{
				ForceStop = true;
				return;
			}

			ForceStop = false;

			switch (settings.Function)
			{
				case "PhotoCameraToggle":
					SendKeypressUp(Program.Bindings.PhotoCameraToggle);
					break;
				case "PhotoCameraToggle_Buggy":
					SendKeypressUp(Program.Bindings.PhotoCameraToggle_Buggy);
					break;
				case "StorePitchCameraDown":
					SendKeypressUp(Program.Bindings.StorePitchCameraDown);
					break;
				case "StorePitchCameraUp":
					SendKeypressUp(Program.Bindings.StorePitchCameraUp);
					break;
				case "StoreEnableRotation":
					SendKeypressUp(Program.Bindings.StoreEnableRotation);
					break;
				case "StoreYawCameraLeft":
					SendKeypressUp(Program.Bindings.StoreYawCameraLeft);
					break;
				case "StoreYawCameraRight":
					SendKeypressUp(Program.Bindings.StoreYawCameraRight);
					break;
				case "StoreCamZoomIn":
					SendKeypressUp(Program.Bindings.StoreCamZoomIn);
					break;
				case "StoreCamZoomOut":
					SendKeypressUp(Program.Bindings.StoreCamZoomOut);
					break;
				case "StoreToggle":
					SendKeypressUp(Program.Bindings.StoreToggle);
					break;
				case "ToggleAdvanceMode":
					SendKeypressUp(Program.Bindings.ToggleAdvanceMode);
					break;
				case "VanityCameraEight":
					SendKeypressUp(Program.Bindings.VanityCameraEight);
					break;
				case "VanityCameraTwo":
					SendKeypressUp(Program.Bindings.VanityCameraTwo);
					break;
				case "VanityCameraOne":
					SendKeypressUp(Program.Bindings.VanityCameraOne);
					break;
				case "VanityCameraThree":
					SendKeypressUp(Program.Bindings.VanityCameraThree);
					break;
				case "VanityCameraFour":
					SendKeypressUp(Program.Bindings.VanityCameraFour);
					break;
				case "VanityCameraFive":
					SendKeypressUp(Program.Bindings.VanityCameraFive);
					break;
				case "VanityCameraSix":
					SendKeypressUp(Program.Bindings.VanityCameraSix);
					break;
				case "VanityCameraSeven":
					SendKeypressUp(Program.Bindings.VanityCameraSeven);
					break;
				case "VanityCameraNine":
					SendKeypressUp(Program.Bindings.VanityCameraNine);
					break;
				case "MoveFreeCamBackwards":
					SendKeypressUp(Program.Bindings.MoveFreeCamBackwards);
					break;
				case "MoveFreeCamDown":
					SendKeypressUp(Program.Bindings.MoveFreeCamDown);
					break;
				case "MoveFreeCamForward":
					SendKeypressUp(Program.Bindings.MoveFreeCamForward);
					break;
				case "MoveFreeCamLeft":
					SendKeypressUp(Program.Bindings.MoveFreeCamLeft);
					break;
				case "PitchCameraDown":
					SendKeypressUp(Program.Bindings.PitchCameraDown);
					break;
				case "PitchCameraUp":
					SendKeypressUp(Program.Bindings.PitchCameraUp);
					break;
				case "ToggleReverseThrottleInputFreeCam":
					SendKeypressUp(Program.Bindings.ToggleReverseThrottleInputFreeCam);
					break;
				case "MoveFreeCamRight":
					SendKeypressUp(Program.Bindings.MoveFreeCamRight);
					break;
				case "RollCameraLeft":
					SendKeypressUp(Program.Bindings.RollCameraLeft);
					break;
				case "RollCameraRight":
					SendKeypressUp(Program.Bindings.RollCameraRight);
					break;
				case "ToggleRotationLock":
					SendKeypressUp(Program.Bindings.ToggleRotationLock);
					break;
				case "MoveFreeCamUp":
					SendKeypressUp(Program.Bindings.MoveFreeCamUp);
					break;
				case "YawCameraLeft":
					SendKeypressUp(Program.Bindings.YawCameraLeft);
					break;
				case "YawCameraRight":
					SendKeypressUp(Program.Bindings.YawCameraRight);
					break;
				case "FStopDec":
					SendKeypressUp(Program.Bindings.FStopDec);
					break;
				case "FreeCamSpeedDec":
					SendKeypressUp(Program.Bindings.FreeCamSpeedDec);
					break;
				case "QuitCamera":
					SendKeypressUp(Program.Bindings.QuitCamera);
					break;
				case "FocusDistanceInc":
					SendKeypressUp(Program.Bindings.FocusDistanceInc);
					break;
				case "FocusDistanceDec":
					SendKeypressUp(Program.Bindings.FocusDistanceDec);
					break;
				case "ToggleFreeCam":
					SendKeypressUp(Program.Bindings.ToggleFreeCam);
					break;
				case "FStopInc":
					SendKeypressUp(Program.Bindings.FStopInc);
					break;
				case "FreeCamSpeedInc":
					SendKeypressUp(Program.Bindings.FreeCamSpeedInc);
					break;
				case "FixCameraRelativeToggle":
					SendKeypressUp(Program.Bindings.FixCameraRelativeToggle);
					break;
				case "FixCameraWorldToggle":
					SendKeypressUp(Program.Bindings.FixCameraWorldToggle);
					break;
				case "VanityCameraScrollRight":
					SendKeypressUp(Program.Bindings.VanityCameraScrollRight);
					break;
				case "VanityCameraScrollLeft":
					SendKeypressUp(Program.Bindings.VanityCameraScrollLeft);
					break;
				case "FreeCamToggleHUD":
					SendKeypressUp(Program.Bindings.FreeCamToggleHUD);
					break;
				case "FreeCamZoomIn":
					SendKeypressUp(Program.Bindings.FreeCamZoomIn);
					break;
				case "FreeCamZoomOut":
					SendKeypressUp(Program.Bindings.FreeCamZoomOut);
					break;
				case "OrderFocusTarget":
					SendKeypressUp(Program.Bindings.OrderFocusTarget);
					break;
				case "OrderAggressiveBehaviour":
					SendKeypressUp(Program.Bindings.OrderAggressiveBehaviour);
					break;
				case "OrderDefensiveBehaviour":
					SendKeypressUp(Program.Bindings.OrderDefensiveBehaviour);
					break;
				case "OpenOrders":
					SendKeypressUp(Program.Bindings.OpenOrders);
					break;
				case "OrderRequestDock":
					SendKeypressUp(Program.Bindings.OrderRequestDock);
					break;
				case "OrderFollow":
					SendKeypressUp(Program.Bindings.OrderFollow);
					break;
				case "OrderHoldFire":
					SendKeypressUp(Program.Bindings.OrderHoldFire);
					break;
				case "OrderHoldPosition":
					SendKeypressUp(Program.Bindings.OrderHoldPosition);
					break;
				case "CamTranslateBackward":
					SendKeypressUp(Program.Bindings.CamTranslateBackward);
					break;
				case "CamTranslateDown":
					SendKeypressUp(Program.Bindings.CamTranslateDown);
					break;
				case "CamTranslateForward":
					SendKeypressUp(Program.Bindings.CamTranslateForward);
					break;
				case "CamTranslateLeft":
					SendKeypressUp(Program.Bindings.CamTranslateLeft);
					break;
				case "CamPitchDown":
					SendKeypressUp(Program.Bindings.CamPitchDown);
					break;
				case "CamPitchUp":
					SendKeypressUp(Program.Bindings.CamPitchUp);
					break;
				case "CamTranslateRight":
					SendKeypressUp(Program.Bindings.CamTranslateRight);
					break;
				case "CamTranslateUp":
					SendKeypressUp(Program.Bindings.CamTranslateUp);
					break;
				case "CamYawLeft":
					SendKeypressUp(Program.Bindings.CamYawLeft);
					break;
				case "CamYawRight":
					SendKeypressUp(Program.Bindings.CamYawRight);
					break;
				case "CamTranslateZHold":
					SendKeypressUp(Program.Bindings.CamTranslateZHold);
					break;
				case "CamZoomIn":
					SendKeypressUp(Program.Bindings.CamZoomIn);
					break;
				case "CamZoomOut":
					SendKeypressUp(Program.Bindings.CamZoomOut);
					break;
				case "HeadLookPitchDown":
					SendKeypressUp(Program.Bindings.HeadLookPitchDown);
					break;
				case "HeadLookYawLeft":
					SendKeypressUp(Program.Bindings.HeadLookYawLeft);
					break;
				case "HeadLookYawRight":
					SendKeypressUp(Program.Bindings.HeadLookYawRight);
					break;
				case "HeadLookPitchUp":
					SendKeypressUp(Program.Bindings.HeadLookPitchUp);
					break;
				case "HeadLookReset":
					SendKeypressUp(Program.Bindings.HeadLookReset);
					break;
				case "CommanderCreator_Redo":
					SendKeypressUp(Program.Bindings.CommanderCreator_Redo);
					break;
				case "CommanderCreator_Rotation":
					SendKeypressUp(Program.Bindings.CommanderCreator_Rotation);
					break;
				case "CommanderCreator_Rotation_MouseToggle":
					SendKeypressUp(Program.Bindings.CommanderCreator_Rotation_MouseToggle);
					break;
				case "CommanderCreator_Undo":
					SendKeypressUp(Program.Bindings.CommanderCreator_Undo);
					break;
				case "GalnetAudio_ClearQueue":
					SendKeypressUp(Program.Bindings.GalnetAudio_ClearQueue);
					break;
				case "OpenCodexGoToDiscovery":
					SendKeypressUp(Program.Bindings.OpenCodexGoToDiscovery);
					break;
				case "FriendsMenu":
					SendKeypressUp(Program.Bindings.FriendsMenu);
					break;
				case "Pause":
					SendKeypressUp(Program.Bindings.Pause);
					break;
				case "MicrophoneMute":
					SendKeypressUp(Program.Bindings.MicrophoneMute);
					break;
				case "GalnetAudio_SkipForward":
					SendKeypressUp(Program.Bindings.GalnetAudio_SkipForward);
					break;
				case "NightVisionToggle":
					SendKeypressUp(Program.Bindings.NightVisionToggle);
					break;
				case "GalnetAudio_Play_Pause":
					SendKeypressUp(Program.Bindings.GalnetAudio_Play_Pause);
					break;
				case "GalnetAudio_SkipBackward":
					SendKeypressUp(Program.Bindings.GalnetAudio_SkipBackward);
					break;
				case "HMDReset":
					SendKeypressUp(Program.Bindings.HMDReset);
					break;
				case "OculusReset":
					SendKeypressUp(Program.Bindings.OculusReset);
					break;
				case "RadarDecreaseRange":
					SendKeypressUp(Program.Bindings.RadarDecreaseRange);
					break;
				case "RadarIncreaseRange":
					SendKeypressUp(Program.Bindings.RadarIncreaseRange);
					break;
				case "MultiCrewThirdPersonFovInButton":
					SendKeypressUp(Program.Bindings.MultiCrewThirdPersonFovInButton);
					break;
				case "MultiCrewThirdPersonFovOutButton":
					SendKeypressUp(Program.Bindings.MultiCrewThirdPersonFovOutButton);
					break;
				case "MultiCrewPrimaryFire":
					SendKeypressUp(Program.Bindings.MultiCrewPrimaryFire);
					break;
				case "MultiCrewSecondaryFire":
					SendKeypressUp(Program.Bindings.MultiCrewSecondaryFire);
					break;
				case "MultiCrewToggleMode":
					SendKeypressUp(Program.Bindings.MultiCrewToggleMode);
					break;
				case "MultiCrewThirdPersonPitchDownButton":
					SendKeypressUp(Program.Bindings.MultiCrewThirdPersonPitchDownButton);
					break;
				case "MultiCrewThirdPersonPitchUpButton":
					SendKeypressUp(Program.Bindings.MultiCrewThirdPersonPitchUpButton);
					break;
				case "MultiCrewPrimaryUtilityFire":
					SendKeypressUp(Program.Bindings.MultiCrewPrimaryUtilityFire);
					break;
				case "MultiCrewSecondaryUtilityFire":
					SendKeypressUp(Program.Bindings.MultiCrewSecondaryUtilityFire);
					break;
				case "MultiCrewCockpitUICycleBackward":
					SendKeypressUp(Program.Bindings.MultiCrewCockpitUICycleBackward);
					break;
				case "MultiCrewCockpitUICycleForward":
					SendKeypressUp(Program.Bindings.MultiCrewCockpitUICycleForward);
					break;
				case "MultiCrewThirdPersonYawLeftButton":
					SendKeypressUp(Program.Bindings.MultiCrewThirdPersonYawLeftButton);
					break;
				case "MultiCrewThirdPersonYawRightButton":
					SendKeypressUp(Program.Bindings.MultiCrewThirdPersonYawRightButton);
					break;
				case "SAAThirdPersonFovInButton":
					SendKeypressUp(Program.Bindings.SAAThirdPersonFovInButton);
					break;
				case "SAAThirdPersonFovOutButton":
					SendKeypressUp(Program.Bindings.SAAThirdPersonFovOutButton);
					break;
				case "ExplorationFSSEnter":
					SendKeypressUp(Program.Bindings.ExplorationFSSEnter);
					break;
				case "ExplorationSAAExitThirdPerson":
					SendKeypressUp(Program.Bindings.ExplorationSAAExitThirdPerson);
					break;
				case "ExplorationFSSQuit":
					SendKeypressUp(Program.Bindings.ExplorationFSSQuit);
					break;
				case "ExplorationFSSShowHelp":
					SendKeypressUp(Program.Bindings.ExplorationFSSShowHelp);
					break;
				case "ExplorationFSSDiscoveryScan":
					SendKeypressUp(Program.Bindings.ExplorationFSSDiscoveryScan);
					break;
				case "ExplorationFSSCameraPitchDecreaseButton":
					SendKeypressUp(Program.Bindings.ExplorationFSSCameraPitchDecreaseButton);
					break;
				case "ExplorationFSSCameraPitchIncreaseButton":
					SendKeypressUp(Program.Bindings.ExplorationFSSCameraPitchIncreaseButton);
					break;
				case "ExplorationFSSRadioTuningX_Decrease":
					SendKeypressUp(Program.Bindings.ExplorationFSSRadioTuningX_Decrease);
					break;
				case "ExplorationFSSRadioTuningX_Increase":
					SendKeypressUp(Program.Bindings.ExplorationFSSRadioTuningX_Increase);
					break;
				case "ExplorationFSSCameraYawDecreaseButton":
					SendKeypressUp(Program.Bindings.ExplorationFSSCameraYawDecreaseButton);
					break;
				case "ExplorationFSSCameraYawIncreaseButton":
					SendKeypressUp(Program.Bindings.ExplorationFSSCameraYawIncreaseButton);
					break;
				case "SAAThirdPersonPitchDownButton":
					SendKeypressUp(Program.Bindings.SAAThirdPersonPitchDownButton);
					break;
				case "SAAThirdPersonPitchUpButton":
					SendKeypressUp(Program.Bindings.SAAThirdPersonPitchUpButton);
					break;
				case "ExplorationFSSMiniZoomIn":
					SendKeypressUp(Program.Bindings.ExplorationFSSMiniZoomIn);
					break;
				case "ExplorationFSSMiniZoomOut":
					SendKeypressUp(Program.Bindings.ExplorationFSSMiniZoomOut);
					break;
				case "ExplorationFSSTarget":
					SendKeypressUp(Program.Bindings.ExplorationFSSTarget);
					break;
				case "ExplorationSAAChangeScannedAreaViewToggle":
					SendKeypressUp(Program.Bindings.ExplorationSAAChangeScannedAreaViewToggle);
					break;
				case "SAAThirdPersonYawLeftButton":
					SendKeypressUp(Program.Bindings.SAAThirdPersonYawLeftButton);
					break;
				case "SAAThirdPersonYawRightButton":
					SendKeypressUp(Program.Bindings.SAAThirdPersonYawRightButton);
					break;
				case "ExplorationFSSZoomIn":
					SendKeypressUp(Program.Bindings.ExplorationFSSZoomIn);
					break;
				case "ExplorationFSSZoomOut":
					SendKeypressUp(Program.Bindings.ExplorationFSSZoomOut);
					break;
				case "FocusCommsPanel":
					SendKeypressUp(Program.Bindings.FocusCommsPanel);
					break;
				case "FocusLeftPanel":
					SendKeypressUp(Program.Bindings.FocusLeftPanel);
					break;
				case "QuickCommsPanel":
					SendKeypressUp(Program.Bindings.QuickCommsPanel);
					break;
				case "FocusRadarPanel":
					SendKeypressUp(Program.Bindings.FocusRadarPanel);
					break;
				case "FocusRightPanel":
					SendKeypressUp(Program.Bindings.FocusRightPanel);
					break;
				case "UIFocus":
					SendKeypressUp(Program.Bindings.UIFocus);
					break;
				case "TargetWingman0":
					SendKeypressUp(Program.Bindings.TargetWingman0);
					break;
				case "TargetWingman1":
					SendKeypressUp(Program.Bindings.TargetWingman1);
					break;
				case "TargetWingman2":
					SendKeypressUp(Program.Bindings.TargetWingman2);
					break;
				case "WingNavLock":
					SendKeypressUp(Program.Bindings.WingNavLock);
					break;
				case "SelectTargetsTarget":
					SendKeypressUp(Program.Bindings.SelectTargetsTarget);
					break;
				case "FireChaffLauncher":
					SendKeypressUp(Program.Bindings.FireChaffLauncher);
					break;
				case "ChargeECM":
					SendKeypressUp(Program.Bindings.ChargeECM);
					break;
				case "IncreaseEnginesPower":
					SendKeypressUp(Program.Bindings.IncreaseEnginesPower);
					break;
				case "PrimaryFire":
					SendKeypressUp(Program.Bindings.PrimaryFire);
					break;
				case "SecondaryFire":
					SendKeypressUp(Program.Bindings.SecondaryFire);
					break;
				case "DeployHardpointToggle":
					SendKeypressUp(Program.Bindings.DeployHardpointToggle);
					break;
				case "DeployHeatSink":
					SendKeypressUp(Program.Bindings.DeployHeatSink);
					break;
				case "SelectHighestThreat":
					SendKeypressUp(Program.Bindings.SelectHighestThreat);
					break;
				case "CycleNextTarget":
					SendKeypressUp(Program.Bindings.CycleNextTarget);
					break;
				case "CycleFireGroupNext":
					SendKeypressUp(Program.Bindings.CycleFireGroupNext);
					break;
				case "CycleNextHostileTarget":
					SendKeypressUp(Program.Bindings.CycleNextHostileTarget);
					break;
				case "CycleNextSubsystem":
					SendKeypressUp(Program.Bindings.CycleNextSubsystem);
					break;
				case "CyclePreviousTarget":
					SendKeypressUp(Program.Bindings.CyclePreviousTarget);
					break;
				case "CycleFireGroupPrevious":
					SendKeypressUp(Program.Bindings.CycleFireGroupPrevious);
					break;
				case "CyclePreviousHostileTarget":
					SendKeypressUp(Program.Bindings.CyclePreviousHostileTarget);
					break;
				case "CyclePreviousSubsystem":
					SendKeypressUp(Program.Bindings.CyclePreviousSubsystem);
					break;
				case "ResetPowerDistribution":
					SendKeypressUp(Program.Bindings.ResetPowerDistribution);
					break;
				case "UseShieldCell":
					SendKeypressUp(Program.Bindings.UseShieldCell);
					break;
				case "IncreaseSystemsPower":
					SendKeypressUp(Program.Bindings.IncreaseSystemsPower);
					break;
				case "SelectTarget":
					SendKeypressUp(Program.Bindings.SelectTarget);
					break;
				case "IncreaseWeaponsPower":
					SendKeypressUp(Program.Bindings.IncreaseWeaponsPower);
					break;
				case "ShowPGScoreSummaryInput":
					SendKeypressUp(Program.Bindings.ShowPGScoreSummaryInput);
					break;
				case "EjectAllCargo":
					SendKeypressUp(Program.Bindings.EjectAllCargo);
					break;
				case "EngineColourToggle":
					SendKeypressUp(Program.Bindings.EngineColourToggle);
					break;
				case "PlayerHUDModeToggle":
					SendKeypressUp(Program.Bindings.PlayerHUDModeToggle);
					break;
				case "OrbitLinesToggle":
					SendKeypressUp(Program.Bindings.OrbitLinesToggle);
					break;
				case "MouseReset":
					SendKeypressUp(Program.Bindings.MouseReset);
					break;
				case "HeadLookToggle":
					SendKeypressUp(Program.Bindings.HeadLookToggle);
					break;
				case "WeaponColourToggle":
					SendKeypressUp(Program.Bindings.WeaponColourToggle);
					break;
				case "SetSpeedMinus100":
					SendKeypressUp(Program.Bindings.SetSpeedMinus100);
					break;
				case "SetSpeed100":
					SendKeypressUp(Program.Bindings.SetSpeed100);
					break;
				case "SetSpeedMinus25":
					SendKeypressUp(Program.Bindings.SetSpeedMinus25);
					break;
				case "SetSpeed25":
					SendKeypressUp(Program.Bindings.SetSpeed25);
					break;
				case "SetSpeedMinus50":
					SendKeypressUp(Program.Bindings.SetSpeedMinus50);
					break;
				case "SetSpeed50":
					SendKeypressUp(Program.Bindings.SetSpeed50);
					break;
				case "SetSpeedMinus75":
					SendKeypressUp(Program.Bindings.SetSpeedMinus75);
					break;
				case "SetSpeed75":
					SendKeypressUp(Program.Bindings.SetSpeed75);
					break;
				case "SetSpeedZero":
					SendKeypressUp(Program.Bindings.SetSpeedZero);
					break;
				case "UseAlternateFlightValuesToggle":
					SendKeypressUp(Program.Bindings.UseAlternateFlightValuesToggle);
					break;
				case "UseBoostJuice":
					SendKeypressUp(Program.Bindings.UseBoostJuice);
					break;
				case "ToggleCargoScoop":
					SendKeypressUp(Program.Bindings.ToggleCargoScoop);
					break;
				case "ToggleFlightAssist":
					SendKeypressUp(Program.Bindings.ToggleFlightAssist);
					break;
				case "ForwardKey":
					SendKeypressUp(Program.Bindings.ForwardKey);
					break;
				case "ForwardThrustButton":
					SendKeypressUp(Program.Bindings.ForwardThrustButton);
					break;
				case "ForwardThrustButton_Landing":
					SendKeypressUp(Program.Bindings.ForwardThrustButton_Landing);
					break;
				case "GalaxyMapOpen":
					SendKeypressUp(Program.Bindings.GalaxyMapOpen);
					break;
				case "Hyperspace":
					SendKeypressUp(Program.Bindings.Hyperspace);
					break;
				case "HyperSuperCombination":
					SendKeypressUp(Program.Bindings.HyperSuperCombination);
					break;
				case "LandingGearToggle":
					SendKeypressUp(Program.Bindings.LandingGearToggle);
					break;
				case "ShipSpotLightToggle":
					SendKeypressUp(Program.Bindings.ShipSpotLightToggle);
					break;
				case "TargetNextRouteSystem":
					SendKeypressUp(Program.Bindings.TargetNextRouteSystem);
					break;
				case "PitchDownButton":
					SendKeypressUp(Program.Bindings.PitchDownButton);
					break;
				case "PitchDownButton_Landing":
					SendKeypressUp(Program.Bindings.PitchDownButton_Landing);
					break;
				case "PitchUpButton":
					SendKeypressUp(Program.Bindings.PitchUpButton);
					break;
				case "PitchUpButton_Landing":
					SendKeypressUp(Program.Bindings.PitchUpButton_Landing);
					break;
				case "ToggleReverseThrottleInput":
					SendKeypressUp(Program.Bindings.ToggleReverseThrottleInput);
					break;
				case "BackwardKey":
					SendKeypressUp(Program.Bindings.BackwardKey);
					break;
				case "BackwardThrustButton":
					SendKeypressUp(Program.Bindings.BackwardThrustButton);
					break;
				case "BackwardThrustButton_Landing":
					SendKeypressUp(Program.Bindings.BackwardThrustButton_Landing);
					break;
				case "RollLeftButton":
					SendKeypressUp(Program.Bindings.RollLeftButton);
					break;
				case "RollLeftButton_Landing":
					SendKeypressUp(Program.Bindings.RollLeftButton_Landing);
					break;
				case "RollRightButton":
					SendKeypressUp(Program.Bindings.RollRightButton);
					break;
				case "RollRightButton_Landing":
					SendKeypressUp(Program.Bindings.RollRightButton_Landing);
					break;
				case "DisableRotationCorrectToggle":
					SendKeypressUp(Program.Bindings.DisableRotationCorrectToggle);
					break;
				case "ToggleButtonUpInput":
					SendKeypressUp(Program.Bindings.ToggleButtonUpInput);
					break;
				case "Supercruise":
					SendKeypressUp(Program.Bindings.Supercruise);
					break;
				case "SystemMapOpen":
					SendKeypressUp(Program.Bindings.SystemMapOpen);
					break;
				case "DownThrustButton":
					SendKeypressUp(Program.Bindings.DownThrustButton);
					break;
				case "DownThrustButton_Landing":
					SendKeypressUp(Program.Bindings.DownThrustButton_Landing);
					break;
				case "LeftThrustButton":
					SendKeypressUp(Program.Bindings.LeftThrustButton);
					break;
				case "LeftThrustButton_Landing":
					SendKeypressUp(Program.Bindings.LeftThrustButton_Landing);
					break;
				case "RightThrustButton":
					SendKeypressUp(Program.Bindings.RightThrustButton);
					break;
				case "RightThrustButton_Landing":
					SendKeypressUp(Program.Bindings.RightThrustButton_Landing);
					break;
				case "UpThrustButton":
					SendKeypressUp(Program.Bindings.UpThrustButton);
					break;
				case "UpThrustButton_Landing":
					SendKeypressUp(Program.Bindings.UpThrustButton_Landing);
					break;
				case "YawLeftButton":
					SendKeypressUp(Program.Bindings.YawLeftButton);
					break;
				case "YawLeftButton_Landing":
					SendKeypressUp(Program.Bindings.YawLeftButton_Landing);
					break;
				case "YawRightButton":
					SendKeypressUp(Program.Bindings.YawRightButton);
					break;
				case "YawRightButton_Landing":
					SendKeypressUp(Program.Bindings.YawRightButton_Landing);
					break;
				case "YawToRollButton":
					SendKeypressUp(Program.Bindings.YawToRollButton);
					break;
				case "FocusCommsPanel_Buggy":
					SendKeypressUp(Program.Bindings.FocusCommsPanel_Buggy);
					break;
				case "EjectAllCargo_Buggy":
					SendKeypressUp(Program.Bindings.EjectAllCargo_Buggy);
					break;
				case "FocusLeftPanel_Buggy":
					SendKeypressUp(Program.Bindings.FocusLeftPanel_Buggy);
					break;
				case "QuickCommsPanel_Buggy":
					SendKeypressUp(Program.Bindings.QuickCommsPanel_Buggy);
					break;
				case "FocusRadarPanel_Buggy":
					SendKeypressUp(Program.Bindings.FocusRadarPanel_Buggy);
					break;
				case "FocusRightPanel_Buggy":
					SendKeypressUp(Program.Bindings.FocusRightPanel_Buggy);
					break;
				case "HeadLookToggle_Buggy":
					SendKeypressUp(Program.Bindings.HeadLookToggle_Buggy);
					break;
				case "UIFocus_Buggy":
					SendKeypressUp(Program.Bindings.UIFocus_Buggy);
					break;
				case "IncreaseEnginesPower_Buggy":
					SendKeypressUp(Program.Bindings.IncreaseEnginesPower_Buggy);
					break;
				case "BuggyPrimaryFireButton":
					SendKeypressUp(Program.Bindings.BuggyPrimaryFireButton);
					break;
				case "ResetPowerDistribution_Buggy":
					SendKeypressUp(Program.Bindings.ResetPowerDistribution_Buggy);
					break;
				case "BuggySecondaryFireButton":
					SendKeypressUp(Program.Bindings.BuggySecondaryFireButton);
					break;
				case "IncreaseSystemsPower_Buggy":
					SendKeypressUp(Program.Bindings.IncreaseSystemsPower_Buggy);
					break;
				case "SelectTarget_Buggy":
					SendKeypressUp(Program.Bindings.SelectTarget_Buggy);
					break;
				case "BuggyTurretPitchDownButton":
					SendKeypressUp(Program.Bindings.BuggyTurretPitchDownButton);
					break;
				case "BuggyTurretYawLeftButton":
					SendKeypressUp(Program.Bindings.BuggyTurretYawLeftButton);
					break;
				case "ToggleBuggyTurretButton":
					SendKeypressUp(Program.Bindings.ToggleBuggyTurretButton);
					break;
				case "BuggyTurretYawRightButton":
					SendKeypressUp(Program.Bindings.BuggyTurretYawRightButton);
					break;
				case "BuggyTurretPitchUpButton":
					SendKeypressUp(Program.Bindings.BuggyTurretPitchUpButton);
					break;
				case "IncreaseWeaponsPower_Buggy":
					SendKeypressUp(Program.Bindings.IncreaseWeaponsPower_Buggy);
					break;
				case "ToggleCargoScoop_Buggy":
					SendKeypressUp(Program.Bindings.ToggleCargoScoop_Buggy);
					break;
				case "DecreaseSpeedButtonPartial":
					SendKeypressUp(Program.Bindings.DecreaseSpeedButtonPartial);
					break;
				case "ToggleDriveAssist":
					SendKeypressUp(Program.Bindings.ToggleDriveAssist);
					break;
				case "GalaxyMapOpen_Buggy":
					SendKeypressUp(Program.Bindings.GalaxyMapOpen_Buggy);
					break;
				case "AutoBreakBuggyButton":
					SendKeypressUp(Program.Bindings.AutoBreakBuggyButton);
					break;
				case "IncreaseSpeedButtonPartial":
					SendKeypressUp(Program.Bindings.IncreaseSpeedButtonPartial);
					break;
				case "HeadlightsBuggyButton":
					SendKeypressUp(Program.Bindings.HeadlightsBuggyButton);
					break;
				case "IncreaseSpeedButtonMax":
					SendKeypressUp(Program.Bindings.IncreaseSpeedButtonMax);
					break;
				case "BuggyPitchDownButton":
					SendKeypressUp(Program.Bindings.BuggyPitchDownButton);
					break;
				case "BuggyPitchUpButton":
					SendKeypressUp(Program.Bindings.BuggyPitchUpButton);
					break;
				case "RecallDismissShip":
					SendKeypressUp(Program.Bindings.RecallDismissShip);
					break;
				case "BuggyToggleReverseThrottleInput":
					SendKeypressUp(Program.Bindings.BuggyToggleReverseThrottleInput);
					break;
				case "BuggyRollLeft":
					SendKeypressUp(Program.Bindings.BuggyRollLeft);
					break;
				case "BuggyRollLeftButton":
					SendKeypressUp(Program.Bindings.BuggyRollLeftButton);
					break;
				case "BuggyRollRight":
					SendKeypressUp(Program.Bindings.BuggyRollRight);
					break;
				case "BuggyRollRightButton":
					SendKeypressUp(Program.Bindings.BuggyRollRightButton);
					break;
				case "SteerLeftButton":
					SendKeypressUp(Program.Bindings.SteerLeftButton);
					break;
				case "SteerRightButton":
					SendKeypressUp(Program.Bindings.SteerRightButton);
					break;
				case "SystemMapOpen_Buggy":
					SendKeypressUp(Program.Bindings.SystemMapOpen_Buggy);
					break;
				case "VerticalThrustersButton":
					SendKeypressUp(Program.Bindings.VerticalThrustersButton);
					break;
				case "DecreaseSpeedButtonMax":
					SendKeypressUp(Program.Bindings.DecreaseSpeedButtonMax);
					break;
				case "CycleNextPage":
					SendKeypressUp(Program.Bindings.CycleNextPage);
					break;
				case "CycleNextPanel":
					SendKeypressUp(Program.Bindings.CycleNextPanel);
					break;
				case "CyclePreviousPage":
					SendKeypressUp(Program.Bindings.CyclePreviousPage);
					break;
				case "CyclePreviousPanel":
					SendKeypressUp(Program.Bindings.CyclePreviousPanel);
					break;
				case "UI_Back":
					SendKeypressUp(Program.Bindings.UI_Back);
					break;
				case "UI_Down":
					SendKeypressUp(Program.Bindings.UI_Down);
					break;
				case "UI_Left":
					SendKeypressUp(Program.Bindings.UI_Left);
					break;
				case "UI_Right":
					SendKeypressUp(Program.Bindings.UI_Right);
					break;
				case "UI_Select":
					SendKeypressUp(Program.Bindings.UI_Select);
					break;
				case "UI_Toggle":
					SendKeypressUp(Program.Bindings.UI_Toggle);
					break;
				case "UI_Up":
					SendKeypressUp(Program.Bindings.UI_Up);
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
                <option value="VanityCameraNine">Cam - Low</option>
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
                <option value="CamTranslateBackward">GalMap Backward</option>
                <option value="CamTranslateDown">GalMap Down</option>
                <option value="CamTranslateForward">GalMap Forward</option>
                <option value="CamTranslateLeft">GalMap Left</option>
                <option value="CamTranslateRight">GalMap Right</option>
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
            HandleFilenames();
        }

        private void HandleFilenames()
        {
            Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
        }

    }
}
