using System;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable StringLiteralTypo

//using EliteAPI.Logging;

namespace Elite.Buttons
{

    [PluginActionId("com.mhwlng.elite.static")]
    public class Static : EliteBase
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


        public Static(SDConnection connection, InitialPayload payload) : base(connection, payload)
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
                HandleFilenames();
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
				case "PhotoCameraToggle":
					SendKeypress(Program.Bindings.PhotoCameraToggle);
					break;
				case "PhotoCameraToggle_Buggy":
					SendKeypress(Program.Bindings.PhotoCameraToggle_Buggy);
					break;
				case "StorePitchCameraDown":
					SendKeypress(Program.Bindings.StorePitchCameraDown);
					break;
				case "StorePitchCameraUp":
					SendKeypress(Program.Bindings.StorePitchCameraUp);
					break;
				case "StoreEnableRotation":
					SendKeypress(Program.Bindings.StoreEnableRotation);
					break;
				case "StoreYawCameraLeft":
					SendKeypress(Program.Bindings.StoreYawCameraLeft);
					break;
				case "StoreYawCameraRight":
					SendKeypress(Program.Bindings.StoreYawCameraRight);
					break;
				case "StoreCamZoomIn":
					SendKeypress(Program.Bindings.StoreCamZoomIn);
					break;
				case "StoreCamZoomOut":
					SendKeypress(Program.Bindings.StoreCamZoomOut);
					break;
				case "StoreToggle":
					SendKeypress(Program.Bindings.StoreToggle);
					break;
				case "ToggleAdvanceMode":
					SendKeypress(Program.Bindings.ToggleAdvanceMode);
					break;
				case "VanityCameraEight":
					SendKeypress(Program.Bindings.VanityCameraEight);
					break;
				case "VanityCameraTwo":
					SendKeypress(Program.Bindings.VanityCameraTwo);
					break;
				case "VanityCameraOne":
					SendKeypress(Program.Bindings.VanityCameraOne);
					break;
				case "VanityCameraThree":
					SendKeypress(Program.Bindings.VanityCameraThree);
					break;
				case "VanityCameraFour":
					SendKeypress(Program.Bindings.VanityCameraFour);
					break;
				case "VanityCameraFive":
					SendKeypress(Program.Bindings.VanityCameraFive);
					break;
				case "VanityCameraSix":
					SendKeypress(Program.Bindings.VanityCameraSix);
					break;
				case "VanityCameraSeven":
					SendKeypress(Program.Bindings.VanityCameraSeven);
					break;
				case "VanityCameraNine":
					SendKeypress(Program.Bindings.VanityCameraNine);
					break;
				case "MoveFreeCamBackwards":
					SendKeypress(Program.Bindings.MoveFreeCamBackwards);
					break;
				case "MoveFreeCamDown":
					SendKeypress(Program.Bindings.MoveFreeCamDown);
					break;
				case "MoveFreeCamForward":
					SendKeypress(Program.Bindings.MoveFreeCamForward);
					break;
				case "MoveFreeCamLeft":
					SendKeypress(Program.Bindings.MoveFreeCamLeft);
					break;
				case "PitchCameraDown":
					SendKeypress(Program.Bindings.PitchCameraDown);
					break;
				case "PitchCameraUp":
					SendKeypress(Program.Bindings.PitchCameraUp);
					break;
				case "ToggleReverseThrottleInputFreeCam":
					SendKeypress(Program.Bindings.ToggleReverseThrottleInputFreeCam);
					break;
				case "MoveFreeCamRight":
					SendKeypress(Program.Bindings.MoveFreeCamRight);
					break;
				case "RollCameraLeft":
					SendKeypress(Program.Bindings.RollCameraLeft);
					break;
				case "RollCameraRight":
					SendKeypress(Program.Bindings.RollCameraRight);
					break;
				case "ToggleRotationLock":
					SendKeypress(Program.Bindings.ToggleRotationLock);
					break;
				case "MoveFreeCamUp":
					SendKeypress(Program.Bindings.MoveFreeCamUp);
					break;
				case "YawCameraLeft":
					SendKeypress(Program.Bindings.YawCameraLeft);
					break;
				case "YawCameraRight":
					SendKeypress(Program.Bindings.YawCameraRight);
					break;
				case "FStopDec":
					SendKeypress(Program.Bindings.FStopDec);
					break;
				case "FreeCamSpeedDec":
					SendKeypress(Program.Bindings.FreeCamSpeedDec);
					break;
				case "QuitCamera":
					SendKeypress(Program.Bindings.QuitCamera);
					break;
				case "FocusDistanceInc":
					SendKeypress(Program.Bindings.FocusDistanceInc);
					break;
				case "FocusDistanceDec":
					SendKeypress(Program.Bindings.FocusDistanceDec);
					break;
				case "ToggleFreeCam":
					SendKeypress(Program.Bindings.ToggleFreeCam);
					break;
				case "FStopInc":
					SendKeypress(Program.Bindings.FStopInc);
					break;
				case "FreeCamSpeedInc":
					SendKeypress(Program.Bindings.FreeCamSpeedInc);
					break;
				case "FixCameraRelativeToggle":
					SendKeypress(Program.Bindings.FixCameraRelativeToggle);
					break;
				case "FixCameraWorldToggle":
					SendKeypress(Program.Bindings.FixCameraWorldToggle);
					break;
				case "VanityCameraScrollRight":
					SendKeypress(Program.Bindings.VanityCameraScrollRight);
					break;
				case "VanityCameraScrollLeft":
					SendKeypress(Program.Bindings.VanityCameraScrollLeft);
					break;
				case "FreeCamToggleHUD":
					SendKeypress(Program.Bindings.FreeCamToggleHUD);
					break;
				case "FreeCamZoomIn":
					SendKeypress(Program.Bindings.FreeCamZoomIn);
					break;
				case "FreeCamZoomOut":
					SendKeypress(Program.Bindings.FreeCamZoomOut);
					break;
				case "OrderFocusTarget":
					SendKeypress(Program.Bindings.OrderFocusTarget);
					break;
				case "OrderAggressiveBehaviour":
					SendKeypress(Program.Bindings.OrderAggressiveBehaviour);
					break;
				case "OrderDefensiveBehaviour":
					SendKeypress(Program.Bindings.OrderDefensiveBehaviour);
					break;
				case "OpenOrders":
					SendKeypress(Program.Bindings.OpenOrders);
					break;
				case "OrderRequestDock":
					SendKeypress(Program.Bindings.OrderRequestDock);
					break;
				case "OrderFollow":
					SendKeypress(Program.Bindings.OrderFollow);
					break;
				case "OrderHoldFire":
					SendKeypress(Program.Bindings.OrderHoldFire);
					break;
				case "OrderHoldPosition":
					SendKeypress(Program.Bindings.OrderHoldPosition);
					break;
				case "CamTranslateBackward":
					SendKeypress(Program.Bindings.CamTranslateBackward);
					break;
				case "CamTranslateDown":
					SendKeypress(Program.Bindings.CamTranslateDown);
					break;
				case "CamTranslateForward":
					SendKeypress(Program.Bindings.CamTranslateForward);
					break;
				case "CamTranslateLeft":
					SendKeypress(Program.Bindings.CamTranslateLeft);
					break;
				case "CamPitchDown":
					SendKeypress(Program.Bindings.CamPitchDown);
					break;
				case "CamPitchUp":
					SendKeypress(Program.Bindings.CamPitchUp);
					break;
				case "CamTranslateRight":
					SendKeypress(Program.Bindings.CamTranslateRight);
					break;
				case "CamTranslateUp":
					SendKeypress(Program.Bindings.CamTranslateUp);
					break;
				case "CamYawLeft":
					SendKeypress(Program.Bindings.CamYawLeft);
					break;
				case "CamYawRight":
					SendKeypress(Program.Bindings.CamYawRight);
					break;
				case "CamTranslateZHold":
					SendKeypress(Program.Bindings.CamTranslateZHold);
					break;
				case "CamZoomIn":
					SendKeypress(Program.Bindings.CamZoomIn);
					break;
				case "CamZoomOut":
					SendKeypress(Program.Bindings.CamZoomOut);
					break;
				case "HeadLookPitchDown":
					SendKeypress(Program.Bindings.HeadLookPitchDown);
					break;
				case "HeadLookYawLeft":
					SendKeypress(Program.Bindings.HeadLookYawLeft);
					break;
				case "HeadLookYawRight":
					SendKeypress(Program.Bindings.HeadLookYawRight);
					break;
				case "HeadLookPitchUp":
					SendKeypress(Program.Bindings.HeadLookPitchUp);
					break;
				case "HeadLookReset":
					SendKeypress(Program.Bindings.HeadLookReset);
					break;
				case "CommanderCreator_Redo":
					SendKeypress(Program.Bindings.CommanderCreator_Redo);
					break;
				case "CommanderCreator_Rotation":
					SendKeypress(Program.Bindings.CommanderCreator_Rotation);
					break;
				case "CommanderCreator_Rotation_MouseToggle":
					SendKeypress(Program.Bindings.CommanderCreator_Rotation_MouseToggle);
					break;
				case "CommanderCreator_Undo":
					SendKeypress(Program.Bindings.CommanderCreator_Undo);
					break;
				case "GalnetAudio_ClearQueue":
					SendKeypress(Program.Bindings.GalnetAudio_ClearQueue);
					break;
				case "OpenCodexGoToDiscovery":
					SendKeypress(Program.Bindings.OpenCodexGoToDiscovery);
					break;
				case "FriendsMenu":
					SendKeypress(Program.Bindings.FriendsMenu);
					break;
				case "Pause":
					SendKeypress(Program.Bindings.Pause);
					break;
				case "MicrophoneMute":
					SendKeypress(Program.Bindings.MicrophoneMute);
					break;
				case "GalnetAudio_SkipForward":
					SendKeypress(Program.Bindings.GalnetAudio_SkipForward);
					break;
				case "NightVisionToggle":
					SendKeypress(Program.Bindings.NightVisionToggle);
					break;
				case "GalnetAudio_Play_Pause":
					SendKeypress(Program.Bindings.GalnetAudio_Play_Pause);
					break;
				case "GalnetAudio_SkipBackward":
					SendKeypress(Program.Bindings.GalnetAudio_SkipBackward);
					break;
				case "HMDReset":
					SendKeypress(Program.Bindings.HMDReset);
					break;
				case "OculusReset":
					SendKeypress(Program.Bindings.OculusReset);
					break;
				case "RadarDecreaseRange":
					SendKeypress(Program.Bindings.RadarDecreaseRange);
					break;
				case "RadarIncreaseRange":
					SendKeypress(Program.Bindings.RadarIncreaseRange);
					break;
				case "MultiCrewThirdPersonFovInButton":
					SendKeypress(Program.Bindings.MultiCrewThirdPersonFovInButton);
					break;
				case "MultiCrewThirdPersonFovOutButton":
					SendKeypress(Program.Bindings.MultiCrewThirdPersonFovOutButton);
					break;
				case "MultiCrewPrimaryFire":
					SendKeypress(Program.Bindings.MultiCrewPrimaryFire);
					break;
				case "MultiCrewSecondaryFire":
					SendKeypress(Program.Bindings.MultiCrewSecondaryFire);
					break;
				case "MultiCrewToggleMode":
					SendKeypress(Program.Bindings.MultiCrewToggleMode);
					break;
				case "MultiCrewThirdPersonPitchDownButton":
					SendKeypress(Program.Bindings.MultiCrewThirdPersonPitchDownButton);
					break;
				case "MultiCrewThirdPersonPitchUpButton":
					SendKeypress(Program.Bindings.MultiCrewThirdPersonPitchUpButton);
					break;
				case "MultiCrewPrimaryUtilityFire":
					SendKeypress(Program.Bindings.MultiCrewPrimaryUtilityFire);
					break;
				case "MultiCrewSecondaryUtilityFire":
					SendKeypress(Program.Bindings.MultiCrewSecondaryUtilityFire);
					break;
				case "MultiCrewCockpitUICycleBackward":
					SendKeypress(Program.Bindings.MultiCrewCockpitUICycleBackward);
					break;
				case "MultiCrewCockpitUICycleForward":
					SendKeypress(Program.Bindings.MultiCrewCockpitUICycleForward);
					break;
				case "MultiCrewThirdPersonYawLeftButton":
					SendKeypress(Program.Bindings.MultiCrewThirdPersonYawLeftButton);
					break;
				case "MultiCrewThirdPersonYawRightButton":
					SendKeypress(Program.Bindings.MultiCrewThirdPersonYawRightButton);
					break;
				case "SAAThirdPersonFovInButton":
					SendKeypress(Program.Bindings.SAAThirdPersonFovInButton);
					break;
				case "SAAThirdPersonFovOutButton":
					SendKeypress(Program.Bindings.SAAThirdPersonFovOutButton);
					break;
				case "ExplorationFSSEnter":
					SendKeypress(Program.Bindings.ExplorationFSSEnter);
					break;
				case "ExplorationSAAExitThirdPerson":
					SendKeypress(Program.Bindings.ExplorationSAAExitThirdPerson);
					break;
				case "ExplorationFSSQuit":
					SendKeypress(Program.Bindings.ExplorationFSSQuit);
					break;
				case "ExplorationFSSShowHelp":
					SendKeypress(Program.Bindings.ExplorationFSSShowHelp);
					break;
				case "ExplorationFSSDiscoveryScan":
					SendKeypress(Program.Bindings.ExplorationFSSDiscoveryScan);
					break;
				case "ExplorationFSSCameraPitchDecreaseButton":
					SendKeypress(Program.Bindings.ExplorationFSSCameraPitchDecreaseButton);
					break;
				case "ExplorationFSSCameraPitchIncreaseButton":
					SendKeypress(Program.Bindings.ExplorationFSSCameraPitchIncreaseButton);
					break;
				case "ExplorationFSSRadioTuningX_Decrease":
					SendKeypress(Program.Bindings.ExplorationFSSRadioTuningX_Decrease);
					break;
				case "ExplorationFSSRadioTuningX_Increase":
					SendKeypress(Program.Bindings.ExplorationFSSRadioTuningX_Increase);
					break;
				case "ExplorationFSSCameraYawDecreaseButton":
					SendKeypress(Program.Bindings.ExplorationFSSCameraYawDecreaseButton);
					break;
				case "ExplorationFSSCameraYawIncreaseButton":
					SendKeypress(Program.Bindings.ExplorationFSSCameraYawIncreaseButton);
					break;
				case "SAAThirdPersonPitchDownButton":
					SendKeypress(Program.Bindings.SAAThirdPersonPitchDownButton);
					break;
				case "SAAThirdPersonPitchUpButton":
					SendKeypress(Program.Bindings.SAAThirdPersonPitchUpButton);
					break;
				case "ExplorationFSSMiniZoomIn":
					SendKeypress(Program.Bindings.ExplorationFSSMiniZoomIn);
					break;
				case "ExplorationFSSMiniZoomOut":
					SendKeypress(Program.Bindings.ExplorationFSSMiniZoomOut);
					break;
				case "ExplorationFSSTarget":
					SendKeypress(Program.Bindings.ExplorationFSSTarget);
					break;
				case "ExplorationSAAChangeScannedAreaViewToggle":
					SendKeypress(Program.Bindings.ExplorationSAAChangeScannedAreaViewToggle);
					break;
				case "SAAThirdPersonYawLeftButton":
					SendKeypress(Program.Bindings.SAAThirdPersonYawLeftButton);
					break;
				case "SAAThirdPersonYawRightButton":
					SendKeypress(Program.Bindings.SAAThirdPersonYawRightButton);
					break;
				case "ExplorationFSSZoomIn":
					SendKeypress(Program.Bindings.ExplorationFSSZoomIn);
					break;
				case "ExplorationFSSZoomOut":
					SendKeypress(Program.Bindings.ExplorationFSSZoomOut);
					break;
				case "FocusCommsPanel":
					SendKeypress(Program.Bindings.FocusCommsPanel);
					break;
				case "FocusLeftPanel":
					SendKeypress(Program.Bindings.FocusLeftPanel);
					break;
				case "QuickCommsPanel":
					SendKeypress(Program.Bindings.QuickCommsPanel);
					break;
				case "FocusRadarPanel":
					SendKeypress(Program.Bindings.FocusRadarPanel);
					break;
				case "FocusRightPanel":
					SendKeypress(Program.Bindings.FocusRightPanel);
					break;
				case "UIFocus":
					SendKeypress(Program.Bindings.UIFocus);
					break;
				case "TargetWingman0":
					SendKeypress(Program.Bindings.TargetWingman0);
					break;
				case "TargetWingman1":
					SendKeypress(Program.Bindings.TargetWingman1);
					break;
				case "TargetWingman2":
					SendKeypress(Program.Bindings.TargetWingman2);
					break;
				case "WingNavLock":
					SendKeypress(Program.Bindings.WingNavLock);
					break;
				case "SelectTargetsTarget":
					SendKeypress(Program.Bindings.SelectTargetsTarget);
					break;
				case "FireChaffLauncher":
					SendKeypress(Program.Bindings.FireChaffLauncher);
					break;
				case "ChargeECM":
					SendKeypress(Program.Bindings.ChargeECM);
					break;
				case "IncreaseEnginesPower":
					SendKeypress(Program.Bindings.IncreaseEnginesPower);
					break;
				case "PrimaryFire":
					SendKeypress(Program.Bindings.PrimaryFire);
					break;
				case "SecondaryFire":
					SendKeypress(Program.Bindings.SecondaryFire);
					break;
				case "DeployHardpointToggle":
					SendKeypress(Program.Bindings.DeployHardpointToggle);
					break;
				case "DeployHeatSink":
					SendKeypress(Program.Bindings.DeployHeatSink);
					break;
				case "SelectHighestThreat":
					SendKeypress(Program.Bindings.SelectHighestThreat);
					break;
				case "CycleNextTarget":
					SendKeypress(Program.Bindings.CycleNextTarget);
					break;
				case "CycleFireGroupNext":
					SendKeypress(Program.Bindings.CycleFireGroupNext);
					break;
				case "CycleNextHostileTarget":
					SendKeypress(Program.Bindings.CycleNextHostileTarget);
					break;
				case "CycleNextSubsystem":
					SendKeypress(Program.Bindings.CycleNextSubsystem);
					break;
				case "CyclePreviousTarget":
					SendKeypress(Program.Bindings.CyclePreviousTarget);
					break;
				case "CycleFireGroupPrevious":
					SendKeypress(Program.Bindings.CycleFireGroupPrevious);
					break;
				case "CyclePreviousHostileTarget":
					SendKeypress(Program.Bindings.CyclePreviousHostileTarget);
					break;
				case "CyclePreviousSubsystem":
					SendKeypress(Program.Bindings.CyclePreviousSubsystem);
					break;
				case "ResetPowerDistribution":
					SendKeypress(Program.Bindings.ResetPowerDistribution);
					break;
				case "UseShieldCell":
					SendKeypress(Program.Bindings.UseShieldCell);
					break;
				case "IncreaseSystemsPower":
					SendKeypress(Program.Bindings.IncreaseSystemsPower);
					break;
				case "SelectTarget":
					SendKeypress(Program.Bindings.SelectTarget);
					break;
				case "IncreaseWeaponsPower":
					SendKeypress(Program.Bindings.IncreaseWeaponsPower);
					break;
				case "ShowPGScoreSummaryInput":
					SendKeypress(Program.Bindings.ShowPGScoreSummaryInput);
					break;
				case "EjectAllCargo":
					SendKeypress(Program.Bindings.EjectAllCargo);
					break;
				case "EngineColourToggle":
					SendKeypress(Program.Bindings.EngineColourToggle);
					break;
				case "PlayerHUDModeToggle":
					SendKeypress(Program.Bindings.PlayerHUDModeToggle);
					break;
				case "OrbitLinesToggle":
					SendKeypress(Program.Bindings.OrbitLinesToggle);
					break;
				case "MouseReset":
					SendKeypress(Program.Bindings.MouseReset);
					break;
				case "HeadLookToggle":
					SendKeypress(Program.Bindings.HeadLookToggle);
					break;
				case "WeaponColourToggle":
					SendKeypress(Program.Bindings.WeaponColourToggle);
					break;
				case "SetSpeedMinus100":
					SendKeypress(Program.Bindings.SetSpeedMinus100);
					break;
				case "SetSpeed100":
					SendKeypress(Program.Bindings.SetSpeed100);
					break;
				case "SetSpeedMinus25":
					SendKeypress(Program.Bindings.SetSpeedMinus25);
					break;
				case "SetSpeed25":
					SendKeypress(Program.Bindings.SetSpeed25);
					break;
				case "SetSpeedMinus50":
					SendKeypress(Program.Bindings.SetSpeedMinus50);
					break;
				case "SetSpeed50":
					SendKeypress(Program.Bindings.SetSpeed50);
					break;
				case "SetSpeedMinus75":
					SendKeypress(Program.Bindings.SetSpeedMinus75);
					break;
				case "SetSpeed75":
					SendKeypress(Program.Bindings.SetSpeed75);
					break;
				case "SetSpeedZero":
					SendKeypress(Program.Bindings.SetSpeedZero);
					break;
				case "UseAlternateFlightValuesToggle":
					SendKeypress(Program.Bindings.UseAlternateFlightValuesToggle);
					break;
				case "UseBoostJuice":
					SendKeypress(Program.Bindings.UseBoostJuice);
					break;
				case "ToggleCargoScoop":
					SendKeypress(Program.Bindings.ToggleCargoScoop);
					break;
				case "ToggleFlightAssist":
					SendKeypress(Program.Bindings.ToggleFlightAssist);
					break;
				case "ForwardKey":
					SendKeypress(Program.Bindings.ForwardKey);
					break;
				case "ForwardThrustButton":
					SendKeypress(Program.Bindings.ForwardThrustButton);
					break;
				case "ForwardThrustButton_Landing":
					SendKeypress(Program.Bindings.ForwardThrustButton_Landing);
					break;
				case "GalaxyMapOpen":
					SendKeypress(Program.Bindings.GalaxyMapOpen);
					break;
				case "Hyperspace":
					SendKeypress(Program.Bindings.Hyperspace);
					break;
				case "HyperSuperCombination":
					SendKeypress(Program.Bindings.HyperSuperCombination);
					break;
				case "LandingGearToggle":
					SendKeypress(Program.Bindings.LandingGearToggle);
					break;
				case "ShipSpotLightToggle":
					SendKeypress(Program.Bindings.ShipSpotLightToggle);
					break;
				case "TargetNextRouteSystem":
					SendKeypress(Program.Bindings.TargetNextRouteSystem);
					break;
				case "PitchDownButton":
					SendKeypress(Program.Bindings.PitchDownButton);
					break;
				case "PitchDownButton_Landing":
					SendKeypress(Program.Bindings.PitchDownButton_Landing);
					break;
				case "PitchUpButton":
					SendKeypress(Program.Bindings.PitchUpButton);
					break;
				case "PitchUpButton_Landing":
					SendKeypress(Program.Bindings.PitchUpButton_Landing);
					break;
				case "ToggleReverseThrottleInput":
					SendKeypress(Program.Bindings.ToggleReverseThrottleInput);
					break;
				case "BackwardKey":
					SendKeypress(Program.Bindings.BackwardKey);
					break;
				case "BackwardThrustButton":
					SendKeypress(Program.Bindings.BackwardThrustButton);
					break;
				case "BackwardThrustButton_Landing":
					SendKeypress(Program.Bindings.BackwardThrustButton_Landing);
					break;
				case "RollLeftButton":
					SendKeypress(Program.Bindings.RollLeftButton);
					break;
				case "RollLeftButton_Landing":
					SendKeypress(Program.Bindings.RollLeftButton_Landing);
					break;
				case "RollRightButton":
					SendKeypress(Program.Bindings.RollRightButton);
					break;
				case "RollRightButton_Landing":
					SendKeypress(Program.Bindings.RollRightButton_Landing);
					break;
				case "DisableRotationCorrectToggle":
					SendKeypress(Program.Bindings.DisableRotationCorrectToggle);
					break;
				case "ToggleButtonUpInput":
					SendKeypress(Program.Bindings.ToggleButtonUpInput);
					break;
				case "Supercruise":
					SendKeypress(Program.Bindings.Supercruise);
					break;
				case "SystemMapOpen":
					SendKeypress(Program.Bindings.SystemMapOpen);
					break;
				case "DownThrustButton":
					SendKeypress(Program.Bindings.DownThrustButton);
					break;
				case "DownThrustButton_Landing":
					SendKeypress(Program.Bindings.DownThrustButton_Landing);
					break;
				case "LeftThrustButton":
					SendKeypress(Program.Bindings.LeftThrustButton);
					break;
				case "LeftThrustButton_Landing":
					SendKeypress(Program.Bindings.LeftThrustButton_Landing);
					break;
				case "RightThrustButton":
					SendKeypress(Program.Bindings.RightThrustButton);
					break;
				case "RightThrustButton_Landing":
					SendKeypress(Program.Bindings.RightThrustButton_Landing);
					break;
				case "UpThrustButton":
					SendKeypress(Program.Bindings.UpThrustButton);
					break;
				case "UpThrustButton_Landing":
					SendKeypress(Program.Bindings.UpThrustButton_Landing);
					break;
				case "YawLeftButton":
					SendKeypress(Program.Bindings.YawLeftButton);
					break;
				case "YawLeftButton_Landing":
					SendKeypress(Program.Bindings.YawLeftButton_Landing);
					break;
				case "YawRightButton":
					SendKeypress(Program.Bindings.YawRightButton);
					break;
				case "YawRightButton_Landing":
					SendKeypress(Program.Bindings.YawRightButton_Landing);
					break;
				case "YawToRollButton":
					SendKeypress(Program.Bindings.YawToRollButton);
					break;
				case "FocusCommsPanel_Buggy":
					SendKeypress(Program.Bindings.FocusCommsPanel_Buggy);
					break;
				case "EjectAllCargo_Buggy":
					SendKeypress(Program.Bindings.EjectAllCargo_Buggy);
					break;
				case "FocusLeftPanel_Buggy":
					SendKeypress(Program.Bindings.FocusLeftPanel_Buggy);
					break;
				case "QuickCommsPanel_Buggy":
					SendKeypress(Program.Bindings.QuickCommsPanel_Buggy);
					break;
				case "FocusRadarPanel_Buggy":
					SendKeypress(Program.Bindings.FocusRadarPanel_Buggy);
					break;
				case "FocusRightPanel_Buggy":
					SendKeypress(Program.Bindings.FocusRightPanel_Buggy);
					break;
				case "HeadLookToggle_Buggy":
					SendKeypress(Program.Bindings.HeadLookToggle_Buggy);
					break;
				case "UIFocus_Buggy":
					SendKeypress(Program.Bindings.UIFocus_Buggy);
					break;
				case "IncreaseEnginesPower_Buggy":
					SendKeypress(Program.Bindings.IncreaseEnginesPower_Buggy);
					break;
				case "BuggyPrimaryFireButton":
					SendKeypress(Program.Bindings.BuggyPrimaryFireButton);
					break;
				case "ResetPowerDistribution_Buggy":
					SendKeypress(Program.Bindings.ResetPowerDistribution_Buggy);
					break;
				case "BuggySecondaryFireButton":
					SendKeypress(Program.Bindings.BuggySecondaryFireButton);
					break;
				case "IncreaseSystemsPower_Buggy":
					SendKeypress(Program.Bindings.IncreaseSystemsPower_Buggy);
					break;
				case "SelectTarget_Buggy":
					SendKeypress(Program.Bindings.SelectTarget_Buggy);
					break;
				case "BuggyTurretPitchDownButton":
					SendKeypress(Program.Bindings.BuggyTurretPitchDownButton);
					break;
				case "BuggyTurretYawLeftButton":
					SendKeypress(Program.Bindings.BuggyTurretYawLeftButton);
					break;
				case "ToggleBuggyTurretButton":
					SendKeypress(Program.Bindings.ToggleBuggyTurretButton);
					break;
				case "BuggyTurretYawRightButton":
					SendKeypress(Program.Bindings.BuggyTurretYawRightButton);
					break;
				case "BuggyTurretPitchUpButton":
					SendKeypress(Program.Bindings.BuggyTurretPitchUpButton);
					break;
				case "IncreaseWeaponsPower_Buggy":
					SendKeypress(Program.Bindings.IncreaseWeaponsPower_Buggy);
					break;
				case "ToggleCargoScoop_Buggy":
					SendKeypress(Program.Bindings.ToggleCargoScoop_Buggy);
					break;
				case "DecreaseSpeedButtonPartial":
					SendKeypress(Program.Bindings.DecreaseSpeedButtonPartial);
					break;
				case "ToggleDriveAssist":
					SendKeypress(Program.Bindings.ToggleDriveAssist);
					break;
				case "GalaxyMapOpen_Buggy":
					SendKeypress(Program.Bindings.GalaxyMapOpen_Buggy);
					break;
				case "AutoBreakBuggyButton":
					SendKeypress(Program.Bindings.AutoBreakBuggyButton);
					break;
				case "IncreaseSpeedButtonPartial":
					SendKeypress(Program.Bindings.IncreaseSpeedButtonPartial);
					break;
				case "HeadlightsBuggyButton":
					SendKeypress(Program.Bindings.HeadlightsBuggyButton);
					break;
				case "IncreaseSpeedButtonMax":
					SendKeypress(Program.Bindings.IncreaseSpeedButtonMax);
					break;
				case "BuggyPitchDownButton":
					SendKeypress(Program.Bindings.BuggyPitchDownButton);
					break;
				case "BuggyPitchUpButton":
					SendKeypress(Program.Bindings.BuggyPitchUpButton);
					break;
				case "RecallDismissShip":
					SendKeypress(Program.Bindings.RecallDismissShip);
					break;
				case "BuggyToggleReverseThrottleInput":
					SendKeypress(Program.Bindings.BuggyToggleReverseThrottleInput);
					break;
				case "BuggyRollLeft":
					SendKeypress(Program.Bindings.BuggyRollLeft);
					break;
				case "BuggyRollLeftButton":
					SendKeypress(Program.Bindings.BuggyRollLeftButton);
					break;
				case "BuggyRollRight":
					SendKeypress(Program.Bindings.BuggyRollRight);
					break;
				case "BuggyRollRightButton":
					SendKeypress(Program.Bindings.BuggyRollRightButton);
					break;
				case "SteerLeftButton":
					SendKeypress(Program.Bindings.SteerLeftButton);
					break;
				case "SteerRightButton":
					SendKeypress(Program.Bindings.SteerRightButton);
					break;
				case "SystemMapOpen_Buggy":
					SendKeypress(Program.Bindings.SystemMapOpen_Buggy);
					break;
				case "VerticalThrustersButton":
					SendKeypress(Program.Bindings.VerticalThrustersButton);
					break;
				case "DecreaseSpeedButtonMax":
					SendKeypress(Program.Bindings.DecreaseSpeedButtonMax);
					break;
				case "CycleNextPage":
					SendKeypress(Program.Bindings.CycleNextPage);
					break;
				case "CycleNextPanel":
					SendKeypress(Program.Bindings.CycleNextPanel);
					break;
				case "CyclePreviousPage":
					SendKeypress(Program.Bindings.CyclePreviousPage);
					break;
				case "CyclePreviousPanel":
					SendKeypress(Program.Bindings.CyclePreviousPanel);
					break;
				case "UI_Back":
					SendKeypress(Program.Bindings.UI_Back);
					break;
				case "UI_Down":
					SendKeypress(Program.Bindings.UI_Down);
					break;
				case "UI_Left":
					SendKeypress(Program.Bindings.UI_Left);
					break;
				case "UI_Right":
					SendKeypress(Program.Bindings.UI_Right);
					break;
				case "UI_Select":
					SendKeypress(Program.Bindings.UI_Select);
					break;
				case "UI_Toggle":
					SendKeypress(Program.Bindings.UI_Toggle);
					break;
				case "UI_Up":
					SendKeypress(Program.Bindings.UI_Up);
					break;
			}

			/*
        <select class="sdpi-item-value select sdProperty" id="function" oninput="setSettings()">
            <optgroup label="Combat">
                <option value="DeployHardpointToggle">Hardpoints</option>
                <option value="DeployHeatSink">Heatsink</option>
                <option value="FireChaffLauncher">Chaff</option>
                <option value="IncreaseEnginesPower">ENG</option>
                <option value="IncreaseSystemsPower">SYS</option>
                <option value="IncreaseWeaponsPower">WEP</option>
                <option value="ResetPowerDistribution">RST</option>
                <option value="PrimaryFire">Fire 1</option>
                <option value="SecondaryFire">Fire 2</option>
                <option value="SelectHighestThreat">Highest Threat</option>
                <option value="UseShieldCell">SCB</option>
            </optgroup>
            <optgroup label="Fighter">
            </optgroup>
            <optgroup label="Misc">
                <option value="NightVisionToggle">Night Vision</option>
                <option value="RadarDecreaseRange">Dec Sensor Range</option>
                <option value="RadarIncreaseRange">Inc Sensor Range</option>
            </optgroup>
            <optgroup label="Navigation">
                <option value="BackwardKey">Reverse Thrust</option>
                <option value="BackwardThrustButton">Reverse thrust</option>
                <option value="BackwardThrustButton_Landing">Reverse Thrust (Lndg)</option>
                <option value="DownThrustButton">Thrust Down</option>
                <option value="DownThrustButton_Landing">Thrust Down (Lndg)</option>
                <option value="ForwardKey">Forward Thrust</option>
                <option value="ForwardThrustButton">Forward Thrust</option>
                <option value="ForwardThrustButton_Landing">Forward Thrust (Lndg)</option>
                <option value="Hyperspace">Hyperspace</option>
                <option value="HyperSuperCombination">Hyperspace/Supercruise</option>
                <option value="LandingGearToggle">Landing Gear</option>
                <option value="LeftThrustButton">Thrust Left</option>
                <option value="LeftThrustButton_Landing">Thrust Left (Lndg)</option>
                <option value="PitchDownButton">Pitch Down</option>
                <option value="PitchDownButton_Landing">Pitch Down (Lndg)</option>
                <option value="PitchUpButton">Pitch Up</option>
                <option value="PitchUpButton_Landing">Pitch Up (Lndg)</option>
                <option value="RightThrustButton">Thrust Right</option>
                <option value="RightThrustButton_Landing">Thrust Right (Lndg)</option>
                <option value="ShipSpotLightToggle">Lights</option>
                <option value="Supercruise">Supercruise</option>
                <option value="SystemMapOpen">System Map</option>
                <option value="ToggleButtonUpInput">Silent Running</option>
                <option value="ToggleCargoScoop">Cargo Scoop</option>
                <option value="ToggleFlightAssist">Flight Assist</option>
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
                <option value="PlayerHUDModeToggle">HUD Mode</option>
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
                <option value="GalaxyMapOpen">Galaxy Map</option>
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
                <option value="ExplorationFSSCameraPitchDecreaseButton">FSS Pitch Down </option>
                <option value="ExplorationFSSCameraPitchIncreaseButton">FSS Pitch Up </option>
                <option value="ExplorationFSSCameraYawDecreaseButton">FSS Yaw Left </option>
                <option value="ExplorationFSSCameraYawIncreaseButton">FSS Yaw Right </option>
                <option value="ExplorationFSSDiscoveryScan">FSS Honk</option>
                <option value="ExplorationFSSEnter">Enter FSS</option>
                <option value="ExplorationFSSMiniZoomIn">Step Zoom FSS In</option>
                <option value="ExplorationFSSMiniZoomOut">Step Zoom FSS Out</option>
                <option value="ExplorationFSSQuit">Exit FSS</option>
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
                <option value="AutoBreakBuggyButton">Handbrake</option>
                <option value="BuggyPitchDownButton">Pitch Down</option>
                <option value="BuggyPitchUpButton">Pitch Up</option>
                <option value="BuggyPrimaryFireButton">Primary Weapons</option>
                <option value="BuggyRollLeft">Roll Left</option>
                <option value="BuggyRollLeftButton">Roll Left</option>
                <option value="BuggyRollRight">Roll Right</option>
                <option value="BuggyRollRightButton">Roll Right</option>
                <option value="BuggySecondaryFireButton">Secondary Weapons</option>
                <option value="BuggyToggleReverseThrottleInput">Reverse</option>
                <option value="BuggyTurretPitchDownButton">Turret Down</option>
                <option value="BuggyTurretPitchUpButton">Turret Up</option>
                <option value="BuggyTurretYawLeftButton">Turret Left</option>
                <option value="BuggyTurretYawRightButton">Turret Right</option>
                <option value="DecreaseSpeedButtonMax">Zero Speed</option>
                <option value="DecreaseSpeedButtonPartial">Dec Speed</option>
                <option value="EjectAllCargo_Buggy">Eject All Cargo</option>
                <option value="FocusCommsPanel_Buggy">Comms Panel</option>
                <option value="FocusLeftPanel_Buggy">Nav Panel</option>
                <option value="FocusRadarPanel_Buggy">Role Panel</option>
                <option value="FocusRightPanel_Buggy">Systems Panel</option>
                <option value="GalaxyMapOpen_Buggy">GalMap</option>
                <option value="HeadlightsBuggyButton">Lights</option>
                <option value="HeadLookToggle_Buggy">Toggle Headlook</option>
                <option value="IncreaseSpeedButtonMax">Maximum Speed</option>
                <option value="IncreaseSpeedButtonPartial">Inc Speed</option>
                <option value="IncreaseEnginesPower_Buggy">ENG</option>
                <option value="IncreaseSystemsPower_Buggy">SYS</option>
                <option value="IncreaseWeaponsPower_Buggy">WEP</option>
                <option value="ResetPowerDistribution_Buggy">RST</option>
                <option value="QuickCommsPanel_Buggy">Quick Comms</option>
                <option value="RecallDismissShip">Recall/Dismiss Ship</option>
                <option value="SelectTarget_Buggy">Target Ahead</option>
                <option value="SteerLeftButton">Steer Left</option>
                <option value="SteerRightButton">Steer Right</option>
                <option value="SystemMapOpen_Buggy">SysMap</option>
                <option value="ToggleBuggyTurretButton">Turret Mode</option>
                <option value="ToggleCargoScoop_Buggy">Cargo Scoop</option>
                <option value="ToggleDriveAssist">Drive Assist</option>
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
