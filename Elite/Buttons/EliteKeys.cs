using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using BarRaider.SdTools;
using EliteJournalReader.Events;
using System.Runtime;

namespace Elite.Buttons
{
    static class EliteKeys
    {
        private static void HandleFireGroup(int fireGroup)
        {
            var isDisabled = (EliteData.StatusData.OnFoot ||
                              EliteData.StatusData.InSRV ||
                              EliteData.StatusData.Docked ||
                              EliteData.StatusData.Landed ||
                              EliteData.StatusData.LandingGearDown ||
                              EliteData.StatusData.FsdJump //||

                    //EliteData.StatusData.Supercruise ||
                    //EliteData.StatusData.CargoScoopDeployed ||
                    //EliteData.StatusData.SilentRunning ||
                    //EliteData.StatusData.ScoopingFuel ||
                    //EliteData.StatusData.IsInDanger ||
                    //EliteData.StatusData.BeingInterdicted ||
                    //EliteData.StatusData.HudInAnalysisMode ||
                    //EliteData.StatusData.FsdMassLocked ||
                    //EliteData.StatusData.FsdCharging ||
                    //EliteData.StatusData.FsdCooldown ||

                    //EliteData.StatusData.HardpointsDeployed
                );

            if (!isDisabled)
            {
                var cycle = fireGroup - EliteData.StatusData.Firegroup;

                if (cycle < 0)
                {
                    for (var f = 0; f < -cycle; f++)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                        Thread.Sleep(70);
                    }
                }
                else if (cycle > 0)
                {
                    for (var f = 0; f < cycle; f++)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                        Thread.Sleep(70);
                    }
                }
            }
        }
        public static void SendKeypress(string function)
        {
            if (StreamDeckCommon.InputRunning || Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;
            var isPrimary = false;

            switch (function)
            {
                case "OrderFocusTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderFocusTarget);
                    break;
                case "OrderAggressiveBehaviour":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderAggressiveBehaviour);
                    break;
                case "OrderDefensiveBehaviour":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderDefensiveBehaviour);
                    break;
                case "OpenOrders":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OpenOrders);
                    break;
                case "OrderRequestDock":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderRequestDock);
                    break;
                case "OrderFollow":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderFollow);
                    break;
                case "OrderHoldFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderHoldFire);
                    break;
                case "OrderHoldPosition":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrderHoldPosition);
                    break;

                case "HeadLookPitchDown":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HeadLookPitchDown);
                    break;
                case "HeadLookYawLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HeadLookYawLeft);
                    break;
                case "HeadLookYawRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HeadLookYawRight);
                    break;
                case "HeadLookPitchUp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HeadLookPitchUp);
                    break;
                case "HeadLookReset":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HeadLookReset);
                    break;
                case "OpenCodexGoToDiscovery":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OpenCodexGoToDiscovery);
                    break;
                case "FriendsMenu":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FriendsMenu);
                    break;
                case "Pause":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].Pause);
                    break;
                case "MicrophoneMute":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MicrophoneMute);
                    break;

                case "HMDReset":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HMDReset);
                    break;
                case "OculusReset":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OculusReset);
                    break;
                case "RadarDecreaseRange":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RadarDecreaseRange);
                    break;
                case "RadarIncreaseRange":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RadarIncreaseRange);
                    break;
                case "MultiCrewThirdPersonFovInButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovInButton);
                    break;
                case "MultiCrewThirdPersonFovOutButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovOutButton);
                    break;
                case "MultiCrewPrimaryFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewPrimaryFire);
                    break;
                case "MultiCrewSecondaryFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewSecondaryFire);
                    break;
                case "MultiCrewToggleMode":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewToggleMode);
                    break;
                case "MultiCrewThirdPersonPitchDownButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchDownButton);
                    break;
                case "MultiCrewThirdPersonPitchUpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchUpButton);
                    break;
                case "MultiCrewPrimaryUtilityFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewPrimaryUtilityFire);
                    break;
                case "MultiCrewSecondaryUtilityFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewSecondaryUtilityFire);
                    break;
                case "MultiCrewCockpitUICycleBackward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleBackward);
                    break;
                case "MultiCrewCockpitUICycleForward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleForward);
                    break;
                case "MultiCrewThirdPersonYawLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawLeftButton);
                    break;
                case "MultiCrewThirdPersonYawRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawRightButton);
                    break;
                case "SAAThirdPersonFovInButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonFovInButton);
                    break;
                case "SAAThirdPersonFovOutButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonFovOutButton);
                    break;
                case "ExplorationFSSEnter":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSEnter);
                    break;
                case "ExplorationSAAExitThirdPerson":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAExitThirdPerson);
                    break;
                case "ExplorationFSSQuit":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSQuit);
                    break;
                case "ExplorationFSSShowHelp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSShowHelp);
                    break;
                case "ExplorationSAANextGenus":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAANextGenus);
                    break;
                case "ExplorationSAAPreviousGenus":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAPreviousGenus);
                    break;
                case "ExplorationSAAShowHelp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSDiscoveryScan);
                    break;
                case "ExplorationFSSCameraPitchDecreaseButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchDecreaseButton);
                    break;
                case "ExplorationFSSCameraPitchIncreaseButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchIncreaseButton);
                    break;
                case "ExplorationFSSRadioTuningX_Decrease":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Decrease);
                    break;
                case "ExplorationFSSRadioTuningX_Increase":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Increase);
                    break;
                case "ExplorationFSSCameraYawDecreaseButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawDecreaseButton);
                    break;
                case "ExplorationFSSCameraYawIncreaseButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawIncreaseButton);
                    break;
                case "SAAThirdPersonPitchDownButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonPitchDownButton);
                    break;
                case "SAAThirdPersonPitchUpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonPitchUpButton);
                    break;
                case "ExplorationFSSMiniZoomIn":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomIn);
                    break;
                case "ExplorationFSSMiniZoomOut":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomOut);
                    break;
                case "ExplorationFSSTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSTarget);
                    break;
                case "ExplorationSAAChangeScannedAreaViewToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAChangeScannedAreaViewToggle);
                    break;
                case "SAAThirdPersonYawLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonYawLeftButton);
                    break;
                case "SAAThirdPersonYawRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonYawRightButton);
                    break;
                case "ExplorationFSSZoomIn":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSZoomIn);
                    break;
                case "ExplorationFSSZoomOut":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSZoomOut);
                    break;
                case "FocusCommsPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    break;
                case "QuickCommsPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].QuickCommsPanel);
                    break;
                case "FocusRadarPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusRightPanel);
                    break;
                case "UIFocus":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].UIFocus);
                    break;
                case "TargetWingman0":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].TargetWingman0);
                    break;
                case "TargetWingman1":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].TargetWingman1);
                    break;
                case "TargetWingman2":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].TargetWingman2);
                    break;
                case "WingNavLock":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].WingNavLock);
                    break;
                case "SelectTargetsTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SelectTargetsTarget);
                    break;
                case "FireChaffLauncher":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FireChaffLauncher);
                    break;
                case "ChargeECM":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ChargeECM);
                    break;
                case "IncreaseEnginesPower":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
                    break;
                case "PrimaryFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PrimaryFire);
                    break;
                case "SecondaryFire":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SecondaryFire);
                    break;
                case "DeployHeatSink":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DeployHeatSink);
                    break;
                case "SelectHighestThreat":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SelectHighestThreat);
                    break;
                case "CycleNextTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleNextTarget);
                    break;
                case "CycleFireGroupNext":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                    break;
                case "CycleNextHostileTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleNextHostileTarget);
                    break;
                case "CycleNextSubsystem":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleNextSubsystem);
                    break;
                case "CyclePreviousTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CyclePreviousTarget);
                    break;
                case "CycleFireGroupPrevious":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                    break;
                case "CyclePreviousHostileTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CyclePreviousHostileTarget);
                    break;
                case "CyclePreviousSubsystem":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].CyclePreviousSubsystem);
                    break;
                case "ResetPowerDistribution":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ResetPowerDistribution);
                    break;
                case "UseShieldCell":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].UseShieldCell);
                    break;
                case "TriggerFieldNeutraliser":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].TriggerFieldNeutraliser);
                    break;
                case "IncreaseSystemsPower":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
                    break;
                case "SelectTarget":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SelectTarget);
                    break;
                case "IncreaseWeaponsPower":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
                    break;
                case "ShowPGScoreSummaryInput":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ShowPGScoreSummaryInput);
                    break;
                case "EjectAllCargo":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].EjectAllCargo);
                    break;
                case "EngineColourToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].EngineColourToggle);
                    break;
                case "OrbitLinesToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].OrbitLinesToggle);
                    break;
                case "MouseReset":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].MouseReset);
                    break;
                case "HeadLookToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HeadLookToggle);
                    break;
                case "WeaponColourToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].WeaponColourToggle);
                    break;
                case "SetSpeedMinus100":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus100);
                    break;
                case "SetSpeed100":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeed100);
                    break;
                case "SetSpeedMinus25":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus25);
                    break;
                case "SetSpeed25":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeed25);
                    break;
                case "SetSpeedMinus50":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus50);
                    break;
                case "SetSpeed50":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeed50);
                    break;
                case "SetSpeedMinus75":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus75);
                    break;
                case "SetSpeed75":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeed75);
                    break;
                case "SetSpeedZero":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SetSpeedZero);
                    break;
                case "UseAlternateFlightValuesToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].UseAlternateFlightValuesToggle);
                    break;
                case "UseBoostJuice":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].UseBoostJuice);
                    break;
                case "ForwardKey":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ForwardKey);
                    break;
                case "ForwardThrustButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ForwardThrustButton);
                    break;
                case "ForwardThrustButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ForwardThrustButton_Landing);
                    break;
                case "GalaxyMapOpen":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    break;
                case "HyperSuperCombination":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].HyperSuperCombination);
                    break;
                case "TargetNextRouteSystem":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
                    break;
                case "PitchDownButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PitchDownButton);
                    break;
                case "PitchDownButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PitchDownButton_Landing);
                    break;
                case "PitchUpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PitchUpButton);
                    break;
                case "PitchUpButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PitchUpButton_Landing);
                    break;
                case "ToggleReverseThrottleInput":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleReverseThrottleInput);
                    break;
                case "BackwardKey":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].BackwardKey);
                    break;
                case "BackwardThrustButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].BackwardThrustButton);
                    break;
                case "BackwardThrustButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].BackwardThrustButton_Landing);
                    break;
                case "RollLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RollLeftButton);
                    break;
                case "RollLeftButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RollLeftButton_Landing);
                    break;
                case "RollRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RollRightButton);
                    break;
                case "RollRightButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RollRightButton_Landing);
                    break;
                case "DisableRotationCorrectToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DisableRotationCorrectToggle);
                    break;
                case "SystemMapOpen":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SystemMapOpen);
                    break;
                case "DownThrustButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DownThrustButton);
                    break;
                case "DownThrustButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DownThrustButton_Landing);
                    break;
                case "LeftThrustButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].LeftThrustButton);
                    break;
                case "LeftThrustButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].LeftThrustButton_Landing);
                    break;
                case "RightThrustButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RightThrustButton);
                    break;
                case "RightThrustButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].RightThrustButton_Landing);
                    break;
                case "UpThrustButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].UpThrustButton);
                    break;
                case "UpThrustButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].UpThrustButton_Landing);
                    break;
                case "YawLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].YawLeftButton);
                    break;
                case "YawLeftButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].YawLeftButton_Landing);
                    break;
                case "YawRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].YawRightButton);
                    break;
                case "YawRightButton_Landing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].YawRightButton_Landing);
                    break;
                case "YawToRollButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].YawToRollButton);
                    break;


                case "Supercruise":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].Supercruise);
                    break;
                case "Hyperspace":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].Hyperspace);
                    break;




                case "PlayerHUDModeToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    break;

                case "ToggleCargoScoop":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    break;

                case "ToggleFlightAssist":
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    break;

                case "DeployHardpointToggle":
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    break;

                case "LandingGearToggle":
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].LandingGearToggle);
                    break;

                case "ShipSpotLightToggle":
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    break;

                case "NightVisionToggle":
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].NightVisionToggle);
                    break;

                case "ToggleButtonUpInput":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    break;



                case "PlayerHUDModeToggle-AM":
                    isPrimary = EliteData.StatusData.HudInAnalysisMode;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    }
                    break;
                case "PlayerHUDModeToggle-CM":
                    isPrimary = EliteData.StatusData.HudInAnalysisMode;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    }
                    break;

                case "ToggleCargoScoop-ON":
                    isPrimary = EliteData.StatusData.CargoScoopDeployed;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    }
                    break;
                case "ToggleCargoScoop-OFF":
                    isPrimary = EliteData.StatusData.CargoScoopDeployed;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    }
                    break;

                case "ToggleFlightAssist-ON":
                    isPrimary = !EliteData.StatusData.FlightAssistOff;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    }
                    break;
                case "ToggleFlightAssist-OFF":
                    isPrimary = !EliteData.StatusData.FlightAssistOff;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    }
                    break;

                case "DeployHardpointToggle-ON":
                    isPrimary = EliteData.StatusData.HardpointsDeployed;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    }
                    break;
                case "DeployHardpointToggle-OFF":
                    isPrimary = EliteData.StatusData.HardpointsDeployed;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    }
                    break;

                case "LandingGearToggle-ON":
                    isPrimary = EliteData.StatusData.LandingGearDown;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].LandingGearToggle);
                    }
                    break;
                case "LandingGearToggle-OFF":
                    isPrimary = EliteData.StatusData.LandingGearDown;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].LandingGearToggle);
                    }
                    break;

                case "ShipSpotLightToggle-ON":
                    isPrimary = EliteData.StatusData.LightsOn || EliteData.StatusData.SrvHighBeam;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    }
                    break;
                case "ShipSpotLightToggle-OFF":
                    isPrimary = EliteData.StatusData.LightsOn || EliteData.StatusData.SrvHighBeam;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    }
                    break;

                case "NightVisionToggle-ON":
                    isPrimary = EliteData.StatusData.NightVision;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].NightVisionToggle);
                    }
                    break;
                case "NightVisionToggle-OFF":
                    isPrimary = EliteData.StatusData.NightVision;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].NightVisionToggle);
                    }
                    break;

                case "ToggleButtonUpInput-ON":
                    isPrimary = EliteData.StatusData.SilentRunning;
                    if (!isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    }
                    break;
                case "ToggleButtonUpInput-OFF":
                    isPrimary = EliteData.StatusData.SilentRunning;
                    if (isPrimary)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    }
                    break;


                case "FocusCommsPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.CommsPanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                        else if (EliteData.StatusData.OnFoot)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    }
                    break;
                case "FocusLeftPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.ExternalPanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    }
                    break;
                case "FocusRadarPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.RolePanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    }
                    break;
                case "FocusRightPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.InternalPanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].FocusRightPanel);
                    }
                    break;
                case "GalaxyMapOpen-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.GalaxyMap;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                        else if (EliteData.StatusData.OnFoot)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    }
                    break;
                case "SystemMapOpen-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.SystemMap || EliteData.StatusData.GuiFocus == StatusGuiFocus.Orrery;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                        else if (EliteData.StatusData.OnFoot)
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                        else
                            StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Ship].SystemMapOpen);
                    }
                    break;

                // fire groups 

                case "FireGroup-A":
                    HandleFireGroup(0);
                    break;
                case "FireGroup-B":
                    HandleFireGroup(1);
                    break;
                case "FireGroup-C":
                    HandleFireGroup(2);
                    break;
                case "FireGroup-D":
                    HandleFireGroup(3);
                    break;
                case "FireGroup-E":
                    HandleFireGroup(4);
                    break;
                case "FireGroup-F":
                    HandleFireGroup(5);
                    break;
                case "FireGroup-G":
                    HandleFireGroup(6);
                    break;
                case "FireGroup-H":
                    HandleFireGroup(7);
                    break;

                // general

                case "CycleNextPage":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CycleNextPage);
                    break;
                case "CycleNextPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CyclePreviousPanel);
                    break;
                case "UI_Back":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Back);
                    break;
                case "UI_Down":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Down);
                    break;
                case "UI_Left":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Left);
                    break;
                case "UI_Right":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Right);
                    break;
                case "UI_Select":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Select);
                    break;
                case "UI_Toggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Toggle);
                    break;
                case "UI_Up":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].UI_Up);
                    break;

                case "CamTranslateBackward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamPitchDown);
                    break;
                case "CamPitchUp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamPitchUp);
                    break;
                case "CamTranslateRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateUp);
                    break;
                case "CamYawLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamYawLeft);
                    break;
                case "CamYawRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamYawRight);
                    break;
                case "CamTranslateZHold":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamZoomIn);
                    break;
                case "CamZoomOut":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CamZoomOut);
                    break;

                case "MoveFreeCamBackwards":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].MoveFreeCamLeft);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].MoveFreeCamRight);
                    break;
                case "MoveFreeCamUp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].MoveFreeCamUp);
                    break;
                case "FreeCamSpeedDec":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FreeCamSpeedDec);
                    break;
                case "ToggleFreeCam":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].ToggleFreeCam);
                    break;
                case "FreeCamSpeedInc":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FreeCamSpeedInc);
                    break;
                case "FreeCamToggleHUD":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FreeCamZoomOut);
                    break;

                case "PhotoCameraToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].PhotoCameraToggle);
                    break;
                case "StorePitchCameraDown":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraNine);
                    break;
                case "VanityCameraTen":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraTen);
                    break;
                case "PitchCameraDown":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].PitchCameraUp);
                    break;
                case "RollCameraLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].RollCameraLeft);
                    break;
                case "RollCameraRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].ToggleRotationLock);
                    break;
                case "YawCameraLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].YawCameraLeft);
                    break;
                case "YawCameraRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].YawCameraRight);
                    break;
                case "FStopDec":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FStopDec);
                    break;
                case "QuitCamera":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].QuitCamera);
                    break;
                case "FocusDistanceInc":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FocusDistanceDec);
                    break;
                case "FStopInc":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FStopInc);
                    break;
                case "FixCameraRelativeToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].VanityCameraScrollLeft);
                    break;

                case "CommanderCreator_Redo":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Undo);
                    break;

                case "GalnetAudio_ClearQueue":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].GalnetAudio_ClearQueue);
                    break;
                case "GalnetAudio_SkipForward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].GalnetAudio_SkipForward);
                    break;
                case "GalnetAudio_Play_Pause":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.General].GalnetAudio_SkipBackward);
                    break;

                // in srv

                case "ToggleDriveAssist":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;
                case "SteerLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].SteerLeftButton);
                    break;
                case "SteerRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].SteerRightButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonMax":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].DecreaseSpeedButtonMax);
                    break;
                case "IncreaseSpeedButtonPartial":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseSpeedButtonPartial);
                    break;
                case "DecreaseSpeedButtonPartial":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].DecreaseSpeedButtonPartial);
                    break;
                case "RecallDismissShip":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].RecallDismissShip);
                    break;
                case "VerticalThrustersButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].VerticalThrustersButton);
                    break;

                case "PhotoCameraToggle_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].PhotoCameraToggle_Buggy);
                    break;
                case "FocusCommsPanel_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    break;
                case "GalaxyMapOpen_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;
                case "HeadlightsBuggyButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    break;
                case "BuggyPitchDownButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyPitchUpButton);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].BuggyRollRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    break;

                // on foot

                case "HumanoidClearAuthorityLevel":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidClearAuthorityLevel);
                    break;
                case "HumanoidHealthPack":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidHealthPack);
                    break;
                case "HumanoidBattery":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidBattery);
                    break;
                case "HumanoidSelectFragGrenade":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectFragGrenade);
                    break;
                case "HumanoidSelectEMPGrenade":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectEMPGrenade);
                    break;
                case "HumanoidSelectShieldGrenade":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectShieldGrenade);
                    break;

                case "PhotoCameraToggle_Humanoid":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].PhotoCameraToggle_Humanoid);
                    break;
                case "HumanoidForwardButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidForwardButton);
                    break;
                case "HumanoidBackwardButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidBackwardButton);
                    break;
                case "HumanoidStrafeLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidStrafeLeftButton);
                    break;
                case "HumanoidStrafeRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidStrafeRightButton);
                    break;
                case "HumanoidSprintButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSprintButton);
                    break;
                case "HumanoidCrouchButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidCrouchButton);
                    break;
                case "HumanoidJumpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidJumpButton);
                    break;
                case "HumanoidPrimaryInteractButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPrimaryInteractButton);
                    break;
                case "HumanoidItemWheelButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidItemWheelButton);
                    break;
                case "HumanoidEmoteWheelButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteWheelButton);
                    break;
                case "HumanoidUtilityWheelCycleMode":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidUtilityWheelCycleMode);
                    break;

                case "HumanoidPrimaryFireButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPrimaryFireButton);
                    break;
                case "HumanoidSelectPrimaryWeaponButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectPrimaryWeaponButton);
                    break;
                case "HumanoidSelectSecondaryWeaponButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectSecondaryWeaponButton);
                    break;
                case "HumanoidHideWeaponButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidHideWeaponButton);
                    break;
                case "HumanoidZoomButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidZoomButton);
                    break;
                case "HumanoidReloadButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidReloadButton);
                    break;
                case "HumanoidThrowGrenadeButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidThrowGrenadeButton);
                    break;
                case "HumanoidMeleeButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidMeleeButton);
                    break;
                case "HumanoidOpenAccessPanelButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidOpenAccessPanelButton);
                    break;
                case "HumanoidSecondaryInteractButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSecondaryInteractButton);
                    break;
                case "HumanoidSwitchToRechargeTool":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchToRechargeTool);
                    break;
                case "HumanoidSwitchToCompAnalyser":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchToCompAnalyser);
                    break;
                case "HumanoidToggleToolModeButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleToolModeButton);
                    break;
                case "HumanoidToggleNightVisionButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    break;
                case "HumanoidSwitchToSuitTool":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchToSuitTool);
                    break;
                case "HumanoidToggleFlashlightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton);
                    break;
                case "GalaxyMapOpen_Humanoid":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    break;
                case "SystemMapOpen_Humanoid":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    break;
                case "FocusCommsPanel_Humanoid":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    break;
                case "QuickCommsPanel_Humanoid":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].QuickCommsPanel_Humanoid);
                    break;
                case "HumanoidConflictContextualUIButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidConflictContextualUIButton);
                    break;
                case "HumanoidToggleShieldsButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleShieldsButton);
                    break;

                case "HumanoidRotateLeftButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidRotateLeftButton);
                    break;
                case "HumanoidRotateRightButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidRotateRightButton);
                    break;
                case "HumanoidPitchUpButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPitchUpButton);
                    break;
                case "HumanoidPitchDownButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPitchDownButton);
                    break;
                case "HumanoidSwitchWeapon":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchWeapon);
                    break;
                case "HumanoidSelectUtilityWeaponButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectUtilityWeaponButton);
                    break;
                case "HumanoidSelectNextWeaponButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectNextWeaponButton);
                    break;
                case "HumanoidSelectPreviousWeaponButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousWeaponButton);
                    break;
                case "HumanoidSelectNextGrenadeTypeButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectNextGrenadeTypeButton);
                    break;
                case "HumanoidSelectPreviousGrenadeTypeButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousGrenadeTypeButton);
                    break;
                case "HumanoidToggleMissionHelpPanelButton":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleMissionHelpPanelButton);
                    break;
                case "HumanoidPing":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPing);
                    break;

                case "HumanoidEmoteSlot1":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot1);
                    break;
                case "HumanoidEmoteSlot2":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot2);
                    break;
                case "HumanoidEmoteSlot3":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot3);
                    break;
                case "HumanoidEmoteSlot4":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot4);
                    break;
                case "HumanoidEmoteSlot5":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot5);
                    break;
                case "HumanoidEmoteSlot6":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot6);
                    break;
                case "HumanoidEmoteSlot7":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot7);
                    break;
                case "HumanoidEmoteSlot8":
                    StreamDeckCommon.SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot8);
                    break;

            }

            /*
           <select class="sdpi-item-value select sdProperty" id="function" oninput="setSettings()">
             <optgroup label="On Foot">
                 <option value="HumanoidForwardButton">Forward</option>
                 <option value="HumanoidBackwardButton">Backward</option>
                 <option value="HumanoidStrafeLeftButton">Strafe Left</option>
                 <option value="HumanoidStrafeRightButton">Strafe Righ</option>
                 <option value="HumanoidRotateLeftButton">Rotate Left</option>
                 <option value="HumanoidRotateRightButton">Rotate Right</option>
                 <option value="HumanoidPitchUpButton">Pitch Up</option>
                 <option value="HumanoidPitchDownButton">Pitch Down</option>
                 <option value="HumanoidSprintButton">Sprint</option>
                 <option value="HumanoidCrouchButton">Crouch</option>
                 <option value="HumanoidJumpButton">Jump</option>
                 <option value="HumanoidItemWheelButton">Item Wheel</option>
                 <option value="HumanoidEmoteWheelButton">Emote Wheel</option>
                 <option value="HumanoidUtilityWheelCycleMode">Cycle Wheel Mode</option>
                 <option value="HumanoidPrimaryFireButton">Primary Fire</option>
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


        public static void SendKeypressDown(string function)
        {
            if (Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            switch (function)
            {
                case "OrderFocusTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderFocusTarget);
                    break;
                case "OrderAggressiveBehaviour":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderAggressiveBehaviour);
                    break;
                case "OrderDefensiveBehaviour":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderDefensiveBehaviour);
                    break;
                case "OpenOrders":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OpenOrders);
                    break;
                case "OrderRequestDock":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderRequestDock);
                    break;
                case "OrderFollow":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderFollow);
                    break;
                case "OrderHoldFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderHoldFire);
                    break;
                case "OrderHoldPosition":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrderHoldPosition);
                    break;

                case "HeadLookPitchDown":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookPitchDown);
                    break;
                case "HeadLookYawLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookYawLeft);
                    break;
                case "HeadLookYawRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookYawRight);
                    break;
                case "HeadLookPitchUp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookPitchUp);
                    break;
                case "HeadLookReset":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookReset);
                    break;
                case "OpenCodexGoToDiscovery":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OpenCodexGoToDiscovery);
                    break;
                case "FriendsMenu":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].FriendsMenu);
                    break;
                case "Pause":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].Pause);
                    break;
                case "MicrophoneMute":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MicrophoneMute);
                    break;

                case "NightVisionToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].NightVisionToggle);
                    break;

                case "HMDReset":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HMDReset);
                    break;
                case "OculusReset":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OculusReset);
                    break;
                case "RadarDecreaseRange":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RadarDecreaseRange);
                    break;
                case "RadarIncreaseRange":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RadarIncreaseRange);
                    break;
                case "MultiCrewThirdPersonFovInButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovInButton);
                    break;
                case "MultiCrewThirdPersonFovOutButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovOutButton);
                    break;
                case "MultiCrewPrimaryFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewPrimaryFire);
                    break;
                case "MultiCrewSecondaryFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewSecondaryFire);
                    break;
                case "MultiCrewToggleMode":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewToggleMode);
                    break;
                case "MultiCrewThirdPersonPitchDownButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchDownButton);
                    break;
                case "MultiCrewThirdPersonPitchUpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchUpButton);
                    break;
                case "MultiCrewPrimaryUtilityFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewPrimaryUtilityFire);
                    break;
                case "MultiCrewSecondaryUtilityFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewSecondaryUtilityFire);
                    break;
                case "MultiCrewCockpitUICycleBackward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleBackward);
                    break;
                case "MultiCrewCockpitUICycleForward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleForward);
                    break;
                case "MultiCrewThirdPersonYawLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawLeftButton);
                    break;
                case "MultiCrewThirdPersonYawRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawRightButton);
                    break;
                case "SAAThirdPersonFovInButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonFovInButton);
                    break;
                case "SAAThirdPersonFovOutButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonFovOutButton);
                    break;
                case "ExplorationFSSEnter":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSEnter);
                    break;
                case "ExplorationSAAExitThirdPerson":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAExitThirdPerson);
                    break;
                case "ExplorationFSSQuit":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSQuit);
                    break;
                case "ExplorationFSSShowHelp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSShowHelp);
                    break;
                case "ExplorationSAANextGenus":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAANextGenus);
                    break;
                case "ExplorationSAAPreviousGenus":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAPreviousGenus);
                    break;
                case "ExplorationSAAShowHelp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSDiscoveryScan);
                    break;
                case "ExplorationFSSCameraPitchDecreaseButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchDecreaseButton);
                    break;
                case "ExplorationFSSCameraPitchIncreaseButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchIncreaseButton);
                    break;
                case "ExplorationFSSRadioTuningX_Decrease":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Decrease);
                    break;
                case "ExplorationFSSRadioTuningX_Increase":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Increase);
                    break;
                case "ExplorationFSSCameraYawDecreaseButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawDecreaseButton);
                    break;
                case "ExplorationFSSCameraYawIncreaseButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawIncreaseButton);
                    break;
                case "SAAThirdPersonPitchDownButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonPitchDownButton);
                    break;
                case "SAAThirdPersonPitchUpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonPitchUpButton);
                    break;
                case "ExplorationFSSMiniZoomIn":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomIn);
                    break;
                case "ExplorationFSSMiniZoomOut":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomOut);
                    break;
                case "ExplorationFSSTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSTarget);
                    break;
                case "ExplorationSAAChangeScannedAreaViewToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationSAAChangeScannedAreaViewToggle);
                    break;
                case "SAAThirdPersonYawLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonYawLeftButton);
                    break;
                case "SAAThirdPersonYawRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SAAThirdPersonYawRightButton);
                    break;
                case "ExplorationFSSZoomIn":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSZoomIn);
                    break;
                case "ExplorationFSSZoomOut":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ExplorationFSSZoomOut);
                    break;
                case "FocusCommsPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    break;
                case "QuickCommsPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].QuickCommsPanel);
                    break;
                case "FocusRadarPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].FocusRightPanel);
                    break;
                case "UIFocus":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].UIFocus);
                    break;
                case "TargetWingman0":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].TargetWingman0);
                    break;
                case "TargetWingman1":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].TargetWingman1);
                    break;
                case "TargetWingman2":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].TargetWingman2);
                    break;
                case "WingNavLock":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].WingNavLock);
                    break;
                case "SelectTargetsTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SelectTargetsTarget);
                    break;
                case "FireChaffLauncher":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].FireChaffLauncher);
                    break;
                case "ChargeECM":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ChargeECM);
                    break;
                case "IncreaseEnginesPower":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
                    break;
                case "PrimaryFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].PrimaryFire);
                    break;
                case "SecondaryFire":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SecondaryFire);
                    break;
                case "DeployHardpointToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    break;
                case "DeployHeatSink":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].DeployHeatSink);
                    break;
                case "SelectHighestThreat":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SelectHighestThreat);
                    break;
                case "CycleNextTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CycleNextTarget);
                    break;
                case "CycleFireGroupNext":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                    break;
                case "CycleNextHostileTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CycleNextHostileTarget);
                    break;
                case "CycleNextSubsystem":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CycleNextSubsystem);
                    break;
                case "CyclePreviousTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CyclePreviousTarget);
                    break;
                case "CycleFireGroupPrevious":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                    break;
                case "CyclePreviousHostileTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CyclePreviousHostileTarget);
                    break;
                case "CyclePreviousSubsystem":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].CyclePreviousSubsystem);
                    break;
                case "ResetPowerDistribution":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ResetPowerDistribution);
                    break;
                case "UseShieldCell":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].UseShieldCell);
                    break;
                case "TriggerFieldNeutraliser":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].TriggerFieldNeutraliser);
                    break;
                case "IncreaseSystemsPower":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
                    break;
                case "SelectTarget":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SelectTarget);
                    break;
                case "IncreaseWeaponsPower":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
                    break;
                case "ShowPGScoreSummaryInput":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ShowPGScoreSummaryInput);
                    break;
                case "EjectAllCargo":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].EjectAllCargo);
                    break;
                case "EngineColourToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].EngineColourToggle);
                    break;
                case "PlayerHUDModeToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    break;
                case "OrbitLinesToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].OrbitLinesToggle);
                    break;
                case "MouseReset":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].MouseReset);
                    break;
                case "HeadLookToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HeadLookToggle);
                    break;
                case "WeaponColourToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].WeaponColourToggle);
                    break;
                case "SetSpeedMinus100":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus100);
                    break;
                case "SetSpeed100":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed100);
                    break;
                case "SetSpeedMinus25":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus25);
                    break;
                case "SetSpeed25":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed25);
                    break;
                case "SetSpeedMinus50":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus50);
                    break;
                case "SetSpeed50":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed50);
                    break;
                case "SetSpeedMinus75":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedMinus75);
                    break;
                case "SetSpeed75":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeed75);
                    break;
                case "SetSpeedZero":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SetSpeedZero);
                    break;
                case "UseAlternateFlightValuesToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].UseAlternateFlightValuesToggle);
                    break;
                case "UseBoostJuice":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].UseBoostJuice);
                    break;
                case "ToggleCargoScoop":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    break;
                case "ToggleFlightAssist":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    break;
                case "ForwardKey":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ForwardKey);
                    break;
                case "ForwardThrustButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ForwardThrustButton);
                    break;
                case "ForwardThrustButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ForwardThrustButton_Landing);
                    break;
                case "GalaxyMapOpen":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    break;
                case "Hyperspace":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].Hyperspace);
                    break;
                case "HyperSuperCombination":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].HyperSuperCombination);
                    break;
                case "LandingGearToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].LandingGearToggle);
                    break;
                case "ShipSpotLightToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    break;
                case "TargetNextRouteSystem":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
                    break;
                case "PitchDownButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].PitchDownButton);
                    break;
                case "PitchDownButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].PitchDownButton_Landing);
                    break;
                case "PitchUpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].PitchUpButton);
                    break;
                case "PitchUpButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].PitchUpButton_Landing);
                    break;
                case "ToggleReverseThrottleInput":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ToggleReverseThrottleInput);
                    break;
                case "BackwardKey":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].BackwardKey);
                    break;
                case "BackwardThrustButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].BackwardThrustButton);
                    break;
                case "BackwardThrustButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].BackwardThrustButton_Landing);
                    break;
                case "RollLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RollLeftButton);
                    break;
                case "RollLeftButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RollLeftButton_Landing);
                    break;
                case "RollRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RollRightButton);
                    break;
                case "RollRightButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RollRightButton_Landing);
                    break;
                case "DisableRotationCorrectToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].DisableRotationCorrectToggle);
                    break;
                case "ToggleButtonUpInput":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    break;
                case "Supercruise":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].Supercruise);
                    break;
                case "SystemMapOpen":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].SystemMapOpen);
                    break;
                case "DownThrustButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].DownThrustButton);
                    break;
                case "DownThrustButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].DownThrustButton_Landing);
                    break;
                case "LeftThrustButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].LeftThrustButton);
                    break;
                case "LeftThrustButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].LeftThrustButton_Landing);
                    break;
                case "RightThrustButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RightThrustButton);
                    break;
                case "RightThrustButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].RightThrustButton_Landing);
                    break;
                case "UpThrustButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].UpThrustButton);
                    break;
                case "UpThrustButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].UpThrustButton_Landing);
                    break;
                case "YawLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].YawLeftButton);
                    break;
                case "YawLeftButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].YawLeftButton_Landing);
                    break;
                case "YawRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].YawRightButton);
                    break;
                case "YawRightButton_Landing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].YawRightButton_Landing);
                    break;
                case "YawToRollButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Ship].YawToRollButton);
                    break;

                // general

                case "UI_Back":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Back);
                    break;
                case "UI_Down":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Down);
                    break;
                case "UI_Left":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Left);
                    break;
                case "UI_Right":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Right);
                    break;
                case "UI_Select":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Select);
                    break;
                case "UI_Toggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Toggle);
                    break;
                case "UI_Up":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].UI_Up);
                    break;

                case "CycleNextPage":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CycleNextPage);
                    break;
                case "CycleNextPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CyclePreviousPanel);
                    break;

                case "CamTranslateBackward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamPitchDown);
                    break;
                case "CamPitchUp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamPitchUp);
                    break;
                case "CamTranslateRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateUp);
                    break;
                case "CamYawLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamYawLeft);
                    break;
                case "CamYawRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamYawRight);
                    break;
                case "CamTranslateZHold":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamZoomIn);
                    break;
                case "CamZoomOut":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CamZoomOut);
                    break;

                case "MoveFreeCamBackwards":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamLeft);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamRight);
                    break;
                case "MoveFreeCamUp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].MoveFreeCamUp);
                    break;
                case "FreeCamSpeedDec":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FreeCamSpeedDec);
                    break;
                case "ToggleFreeCam":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].ToggleFreeCam);
                    break;
                case "FreeCamSpeedInc":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FreeCamSpeedInc);
                    break;
                case "FreeCamToggleHUD":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FreeCamZoomOut);
                    break;

                case "PhotoCameraToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].PhotoCameraToggle);
                    break;
                case "StorePitchCameraDown":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraNine);
                    break;
                case "VanityCameraTen":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraTen);
                    break;
                case "PitchCameraDown":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].PitchCameraUp);
                    break;
                case "RollCameraLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].RollCameraLeft);
                    break;
                case "RollCameraRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].ToggleRotationLock);
                    break;
                case "YawCameraLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].YawCameraLeft);
                    break;
                case "YawCameraRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].YawCameraRight);
                    break;
                case "FStopDec":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FStopDec);
                    break;
                case "QuitCamera":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].QuitCamera);
                    break;
                case "FocusDistanceInc":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FocusDistanceDec);
                    break;
                case "FStopInc":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FStopInc);
                    break;
                case "FixCameraRelativeToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].VanityCameraScrollLeft);
                    break;

                case "CommanderCreator_Redo":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].CommanderCreator_Undo);
                    break;

                case "GalnetAudio_ClearQueue":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_ClearQueue);
                    break;
                case "GalnetAudio_SkipForward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_SkipForward);
                    break;
                case "GalnetAudio_Play_Pause":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.General].GalnetAudio_SkipBackward);
                    break;

                // in srv

                case "ToggleDriveAssist":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;
                case "SteerLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].SteerLeftButton);
                    break;
                case "SteerRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].SteerRightButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonMax":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].DecreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonPartial":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].DecreaseSpeedButtonPartial);
                    break;
                case "IncreaseSpeedButtonPartial":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseSpeedButtonPartial);
                    break;
                case "RecallDismissShip":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].RecallDismissShip);
                    break;
                case "VerticalThrustersButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].VerticalThrustersButton);
                    break;

                case "PhotoCameraToggle_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].PhotoCameraToggle_Buggy);
                    break;

                case "FocusCommsPanel_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    break;
                case "GalaxyMapOpen_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;
                case "HeadlightsBuggyButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    break;
                case "BuggyPitchDownButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyPitchUpButton);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].BuggyRollRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    break;

                // on foot

                case "HumanoidClearAuthorityLevel":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidClearAuthorityLevel);
                    break;
                case "HumanoidHealthPack":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidHealthPack);
                    break;
                case "HumanoidBattery":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidBattery);
                    break;
                case "HumanoidSelectFragGrenade":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectFragGrenade);
                    break;
                case "HumanoidSelectEMPGrenade":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectEMPGrenade);
                    break;
                case "HumanoidSelectShieldGrenade":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectShieldGrenade);
                    break;

                case "PhotoCameraToggle_Humanoid":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].PhotoCameraToggle_Humanoid);
                    break;
                case "HumanoidForwardButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidForwardButton);
                    break;
                case "HumanoidBackwardButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidBackwardButton);
                    break;
                case "HumanoidStrafeLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidStrafeLeftButton);
                    break;
                case "HumanoidStrafeRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidStrafeRightButton);
                    break;
                case "HumanoidSprintButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSprintButton);
                    break;
                case "HumanoidCrouchButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidCrouchButton);
                    break;
                case "HumanoidJumpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidJumpButton);
                    break;
                case "HumanoidPrimaryInteractButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPrimaryInteractButton);
                    break;
                case "HumanoidItemWheelButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidItemWheelButton);
                    break;
                case "HumanoidEmoteWheelButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteWheelButton);
                    break;
                case "HumanoidUtilityWheelCycleMode":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidUtilityWheelCycleMode);
                    break;

                case "HumanoidPrimaryFireButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPrimaryFireButton);
                    break;
                case "HumanoidSelectPrimaryWeaponButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectPrimaryWeaponButton);
                    break;
                case "HumanoidSelectSecondaryWeaponButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectSecondaryWeaponButton);
                    break;
                case "HumanoidHideWeaponButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidHideWeaponButton);
                    break;
                case "HumanoidZoomButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidZoomButton);
                    break;
                case "HumanoidReloadButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidReloadButton);
                    break;
                case "HumanoidThrowGrenadeButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidThrowGrenadeButton);
                    break;
                case "HumanoidMeleeButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidMeleeButton);
                    break;
                case "HumanoidOpenAccessPanelButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidOpenAccessPanelButton);
                    break;
                case "HumanoidSecondaryInteractButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSecondaryInteractButton);
                    break;
                case "HumanoidSwitchToRechargeTool":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchToRechargeTool);
                    break;
                case "HumanoidSwitchToCompAnalyser":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchToCompAnalyser);
                    break;
                case "HumanoidToggleToolModeButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleToolModeButton);
                    break;
                case "HumanoidToggleNightVisionButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    break;
                case "HumanoidSwitchToSuitTool":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchToSuitTool);
                    break;
                case "HumanoidToggleFlashlightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton);
                    break;
                case "GalaxyMapOpen_Humanoid":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    break;
                case "SystemMapOpen_Humanoid":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    break;
                case "FocusCommsPanel_Humanoid":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    break;
                case "QuickCommsPanel_Humanoid":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].QuickCommsPanel_Humanoid);
                    break;
                case "HumanoidConflictContextualUIButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidConflictContextualUIButton);
                    break;
                case "HumanoidToggleShieldsButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleShieldsButton);
                    break;

                case "HumanoidRotateLeftButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidRotateLeftButton);
                    break;
                case "HumanoidRotateRightButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidRotateRightButton);
                    break;
                case "HumanoidPitchUpButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPitchUpButton);
                    break;
                case "HumanoidPitchDownButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPitchDownButton);
                    break;
                case "HumanoidSwitchWeapon":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSwitchWeapon);
                    break;
                case "HumanoidSelectUtilityWeaponButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectUtilityWeaponButton);
                    break;
                case "HumanoidSelectNextWeaponButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectNextWeaponButton);
                    break;
                case "HumanoidSelectPreviousWeaponButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousWeaponButton);
                    break;
                case "HumanoidSelectNextGrenadeTypeButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectNextGrenadeTypeButton);
                    break;
                case "HumanoidSelectPreviousGrenadeTypeButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousGrenadeTypeButton);
                    break;
                case "HumanoidToggleMissionHelpPanelButton":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidToggleMissionHelpPanelButton);
                    break;
                case "HumanoidPing":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidPing);
                    break;

                case "HumanoidEmoteSlot1":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot1);
                    break;
                case "HumanoidEmoteSlot2":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot2);
                    break;
                case "HumanoidEmoteSlot3":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot3);
                    break;
                case "HumanoidEmoteSlot4":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot4);
                    break;
                case "HumanoidEmoteSlot5":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot5);
                    break;
                case "HumanoidEmoteSlot6":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot6);
                    break;
                case "HumanoidEmoteSlot7":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot7);
                    break;
                case "HumanoidEmoteSlot8":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot8);
                    break;

            }
        }

        public static void SendKeypressUp(string function)
        {
            if (Program.Binding == null)
            {
                StreamDeckCommon.ForceStop = true;
                return;
            }

            StreamDeckCommon.ForceStop = false;

            switch (function)
            {
                case "OrderFocusTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderFocusTarget);
                    break;
                case "OrderAggressiveBehaviour":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderAggressiveBehaviour);
                    break;
                case "OrderDefensiveBehaviour":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderDefensiveBehaviour);
                    break;
                case "OpenOrders":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OpenOrders);
                    break;
                case "OrderRequestDock":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderRequestDock);
                    break;
                case "OrderFollow":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderFollow);
                    break;
                case "OrderHoldFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderHoldFire);
                    break;
                case "OrderHoldPosition":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrderHoldPosition);
                    break;
                case "HeadLookPitchDown":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookPitchDown);
                    break;
                case "HeadLookYawLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookYawLeft);
                    break;
                case "HeadLookYawRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookYawRight);
                    break;
                case "HeadLookPitchUp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookPitchUp);
                    break;
                case "HeadLookReset":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookReset);
                    break;
                case "OpenCodexGoToDiscovery":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OpenCodexGoToDiscovery);
                    break;
                case "FriendsMenu":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].FriendsMenu);
                    break;
                case "Pause":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].Pause);
                    break;
                case "MicrophoneMute":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MicrophoneMute);
                    break;

                case "NightVisionToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].NightVisionToggle);
                    break;

                case "HMDReset":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HMDReset);
                    break;
                case "OculusReset":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OculusReset);
                    break;
                case "RadarDecreaseRange":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RadarDecreaseRange);
                    break;
                case "RadarIncreaseRange":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RadarIncreaseRange);
                    break;
                case "MultiCrewThirdPersonFovInButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovInButton);
                    break;
                case "MultiCrewThirdPersonFovOutButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovOutButton);
                    break;
                case "MultiCrewPrimaryFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewPrimaryFire);
                    break;
                case "MultiCrewSecondaryFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewSecondaryFire);
                    break;
                case "MultiCrewToggleMode":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewToggleMode);
                    break;
                case "MultiCrewThirdPersonPitchDownButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchDownButton);
                    break;
                case "MultiCrewThirdPersonPitchUpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchUpButton);
                    break;
                case "MultiCrewPrimaryUtilityFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewPrimaryUtilityFire);
                    break;
                case "MultiCrewSecondaryUtilityFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewSecondaryUtilityFire);
                    break;
                case "MultiCrewCockpitUICycleBackward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleBackward);
                    break;
                case "MultiCrewCockpitUICycleForward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleForward);
                    break;
                case "MultiCrewThirdPersonYawLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawLeftButton);
                    break;
                case "MultiCrewThirdPersonYawRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawRightButton);
                    break;
                case "SAAThirdPersonFovInButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonFovInButton);
                    break;
                case "SAAThirdPersonFovOutButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonFovOutButton);
                    break;
                case "ExplorationFSSEnter":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSEnter);
                    break;
                case "ExplorationSAAExitThirdPerson":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAExitThirdPerson);
                    break;
                case "ExplorationFSSQuit":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSQuit);
                    break;
                case "ExplorationFSSShowHelp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSShowHelp);
                    break;
                case "ExplorationSAANextGenus":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAANextGenus);
                    break;
                case "ExplorationSAAPreviousGenus":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAPreviousGenus);
                    break;
                case "ExplorationSAAShowHelp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSDiscoveryScan);
                    break;
                case "ExplorationFSSCameraPitchDecreaseButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchDecreaseButton);
                    break;
                case "ExplorationFSSCameraPitchIncreaseButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchIncreaseButton);
                    break;
                case "ExplorationFSSRadioTuningX_Decrease":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Decrease);
                    break;
                case "ExplorationFSSRadioTuningX_Increase":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Increase);
                    break;
                case "ExplorationFSSCameraYawDecreaseButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawDecreaseButton);
                    break;
                case "ExplorationFSSCameraYawIncreaseButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawIncreaseButton);
                    break;
                case "SAAThirdPersonPitchDownButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonPitchDownButton);
                    break;
                case "SAAThirdPersonPitchUpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonPitchUpButton);
                    break;
                case "ExplorationFSSMiniZoomIn":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomIn);
                    break;
                case "ExplorationFSSMiniZoomOut":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomOut);
                    break;
                case "ExplorationFSSTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSTarget);
                    break;
                case "ExplorationSAAChangeScannedAreaViewToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationSAAChangeScannedAreaViewToggle);
                    break;
                case "SAAThirdPersonYawLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonYawLeftButton);
                    break;
                case "SAAThirdPersonYawRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SAAThirdPersonYawRightButton);
                    break;
                case "ExplorationFSSZoomIn":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSZoomIn);
                    break;
                case "ExplorationFSSZoomOut":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ExplorationFSSZoomOut);
                    break;
                case "FocusCommsPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    break;
                case "QuickCommsPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].QuickCommsPanel);
                    break;
                case "FocusRadarPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].FocusRightPanel);
                    break;
                case "UIFocus":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].UIFocus);
                    break;
                case "TargetWingman0":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].TargetWingman0);
                    break;
                case "TargetWingman1":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].TargetWingman1);
                    break;
                case "TargetWingman2":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].TargetWingman2);
                    break;
                case "WingNavLock":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].WingNavLock);
                    break;
                case "SelectTargetsTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SelectTargetsTarget);
                    break;
                case "FireChaffLauncher":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].FireChaffLauncher);
                    break;
                case "ChargeECM":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ChargeECM);
                    break;
                case "IncreaseEnginesPower":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
                    break;
                case "PrimaryFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].PrimaryFire);
                    break;
                case "SecondaryFire":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SecondaryFire);
                    break;
                case "DeployHardpointToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    break;
                case "DeployHeatSink":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].DeployHeatSink);
                    break;
                case "SelectHighestThreat":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SelectHighestThreat);
                    break;
                case "CycleNextTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CycleNextTarget);
                    break;
                case "CycleFireGroupNext":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                    break;
                case "CycleNextHostileTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CycleNextHostileTarget);
                    break;
                case "CycleNextSubsystem":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CycleNextSubsystem);
                    break;
                case "CyclePreviousTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CyclePreviousTarget);
                    break;
                case "CycleFireGroupPrevious":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                    break;
                case "CyclePreviousHostileTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CyclePreviousHostileTarget);
                    break;
                case "CyclePreviousSubsystem":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].CyclePreviousSubsystem);
                    break;
                case "ResetPowerDistribution":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ResetPowerDistribution);
                    break;
                case "UseShieldCell":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].UseShieldCell);
                    break;
                case "TriggerFieldNeutraliser":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].TriggerFieldNeutraliser);
                    break;
                case "IncreaseSystemsPower":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
                    break;
                case "SelectTarget":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SelectTarget);
                    break;
                case "IncreaseWeaponsPower":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
                    break;
                case "ShowPGScoreSummaryInput":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ShowPGScoreSummaryInput);
                    break;
                case "EjectAllCargo":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].EjectAllCargo);
                    break;
                case "EngineColourToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].EngineColourToggle);
                    break;
                case "PlayerHUDModeToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    break;
                case "OrbitLinesToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].OrbitLinesToggle);
                    break;
                case "MouseReset":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].MouseReset);
                    break;
                case "HeadLookToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HeadLookToggle);
                    break;
                case "WeaponColourToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].WeaponColourToggle);
                    break;
                case "SetSpeedMinus100":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus100);
                    break;
                case "SetSpeed100":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed100);
                    break;
                case "SetSpeedMinus25":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus25);
                    break;
                case "SetSpeed25":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed25);
                    break;
                case "SetSpeedMinus50":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus50);
                    break;
                case "SetSpeed50":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed50);
                    break;
                case "SetSpeedMinus75":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedMinus75);
                    break;
                case "SetSpeed75":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeed75);
                    break;
                case "SetSpeedZero":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SetSpeedZero);
                    break;
                case "UseAlternateFlightValuesToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].UseAlternateFlightValuesToggle);
                    break;
                case "UseBoostJuice":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].UseBoostJuice);
                    break;
                case "ToggleCargoScoop":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    break;
                case "ToggleFlightAssist":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    break;
                case "ForwardKey":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ForwardKey);
                    break;
                case "ForwardThrustButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ForwardThrustButton);
                    break;
                case "ForwardThrustButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ForwardThrustButton_Landing);
                    break;
                case "GalaxyMapOpen":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    break;
                case "Hyperspace":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].Hyperspace);
                    break;
                case "HyperSuperCombination":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].HyperSuperCombination);
                    break;
                case "LandingGearToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].LandingGearToggle);
                    break;
                case "ShipSpotLightToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    break;
                case "TargetNextRouteSystem":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
                    break;
                case "PitchDownButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].PitchDownButton);
                    break;
                case "PitchDownButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].PitchDownButton_Landing);
                    break;
                case "PitchUpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].PitchUpButton);
                    break;
                case "PitchUpButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].PitchUpButton_Landing);
                    break;
                case "ToggleReverseThrottleInput":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ToggleReverseThrottleInput);
                    break;
                case "BackwardKey":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].BackwardKey);
                    break;
                case "BackwardThrustButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].BackwardThrustButton);
                    break;
                case "BackwardThrustButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].BackwardThrustButton_Landing);
                    break;
                case "RollLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RollLeftButton);
                    break;
                case "RollLeftButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RollLeftButton_Landing);
                    break;
                case "RollRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RollRightButton);
                    break;
                case "RollRightButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RollRightButton_Landing);
                    break;
                case "DisableRotationCorrectToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].DisableRotationCorrectToggle);
                    break;
                case "ToggleButtonUpInput":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    break;
                case "Supercruise":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].Supercruise);
                    break;
                case "SystemMapOpen":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].SystemMapOpen);
                    break;
                case "DownThrustButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].DownThrustButton);
                    break;
                case "DownThrustButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].DownThrustButton_Landing);
                    break;
                case "LeftThrustButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].LeftThrustButton);
                    break;
                case "LeftThrustButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].LeftThrustButton_Landing);
                    break;
                case "RightThrustButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RightThrustButton);
                    break;
                case "RightThrustButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].RightThrustButton_Landing);
                    break;
                case "UpThrustButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].UpThrustButton);
                    break;
                case "UpThrustButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].UpThrustButton_Landing);
                    break;
                case "YawLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].YawLeftButton);
                    break;
                case "YawLeftButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].YawLeftButton_Landing);
                    break;
                case "YawRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].YawRightButton);
                    break;
                case "YawRightButton_Landing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].YawRightButton_Landing);
                    break;
                case "YawToRollButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Ship].YawToRollButton);
                    break;


                // general

                case "CycleNextPage":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CycleNextPage);
                    break;
                case "CycleNextPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CyclePreviousPanel);
                    break;
                case "UI_Back":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Back);
                    break;
                case "UI_Down":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Down);
                    break;
                case "UI_Left":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Left);
                    break;
                case "UI_Right":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Right);
                    break;
                case "UI_Select":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Select);
                    break;
                case "UI_Toggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Toggle);
                    break;
                case "UI_Up":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].UI_Up);
                    break;

                case "CamTranslateBackward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamPitchDown);
                    break;
                case "CamPitchUp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamPitchUp);
                    break;
                case "CamTranslateRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateUp);
                    break;
                case "CamYawLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamYawLeft);
                    break;
                case "CamYawRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamYawRight);
                    break;
                case "CamTranslateZHold":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamZoomIn);
                    break;
                case "CamZoomOut":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CamZoomOut);
                    break;

                case "MoveFreeCamBackwards":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamLeft);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamRight);
                    break;
                case "MoveFreeCamUp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].MoveFreeCamUp);
                    break;
                case "FreeCamSpeedDec":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FreeCamSpeedDec);
                    break;
                case "ToggleFreeCam":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].ToggleFreeCam);
                    break;
                case "FreeCamSpeedInc":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FreeCamSpeedInc);
                    break;
                case "FreeCamToggleHUD":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FreeCamZoomOut);
                    break;

                case "PhotoCameraToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].PhotoCameraToggle);
                    break;
                case "StorePitchCameraDown":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraNine);
                    break;
                case "VanityCameraTen":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraTen);
                    break;

                case "PitchCameraDown":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].PitchCameraUp);
                    break;

                case "RollCameraLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].RollCameraLeft);
                    break;
                case "RollCameraRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].ToggleRotationLock);
                    break;
                case "YawCameraLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].YawCameraLeft);
                    break;
                case "YawCameraRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].YawCameraRight);
                    break;
                case "FStopDec":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FStopDec);
                    break;
                case "QuitCamera":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].QuitCamera);
                    break;
                case "FocusDistanceInc":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FocusDistanceDec);
                    break;
                case "FStopInc":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FStopInc);
                    break;
                case "FixCameraRelativeToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].VanityCameraScrollLeft);
                    break;

                case "CommanderCreator_Redo":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].CommanderCreator_Undo);
                    break;

                case "GalnetAudio_ClearQueue":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_ClearQueue);
                    break;
                case "GalnetAudio_SkipForward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_SkipForward);
                    break;
                case "GalnetAudio_Play_Pause":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.General].GalnetAudio_SkipBackward);
                    break;

                // in srv

                case "ToggleDriveAssist":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;
                case "SteerLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].SteerLeftButton);
                    break;
                case "SteerRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].SteerRightButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonMax":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].DecreaseSpeedButtonMax);
                    break;
                case "IncreaseSpeedButtonPartial":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseSpeedButtonPartial);
                    break;
                case "DecreaseSpeedButtonPartial":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].DecreaseSpeedButtonPartial);
                    break;
                case "RecallDismissShip":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].RecallDismissShip);
                    break;
                case "VerticalThrustersButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].VerticalThrustersButton);
                    break;

                case "PhotoCameraToggle_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].PhotoCameraToggle_Buggy);
                    break;

                case "FocusCommsPanel_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    break;
                case "GalaxyMapOpen_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;
                case "HeadlightsBuggyButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    break;
                case "BuggyPitchDownButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyPitchUpButton);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].BuggyRollRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    break;

                // on foot

                case "HumanoidClearAuthorityLevel":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidClearAuthorityLevel);
                    break;
                case "HumanoidHealthPack":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidHealthPack);
                    break;
                case "HumanoidBattery":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidBattery);
                    break;
                case "HumanoidSelectFragGrenade":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectFragGrenade);
                    break;
                case "HumanoidSelectEMPGrenade":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectEMPGrenade);
                    break;
                case "HumanoidSelectShieldGrenade":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectShieldGrenade);
                    break;

                case "PhotoCameraToggle_Humanoid":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].PhotoCameraToggle_Humanoid);
                    break;
                case "HumanoidForwardButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidForwardButton);
                    break;
                case "HumanoidBackwardButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidBackwardButton);
                    break;
                case "HumanoidStrafeLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidStrafeLeftButton);
                    break;
                case "HumanoidStrafeRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidStrafeRightButton);
                    break;
                case "HumanoidSprintButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSprintButton);
                    break;
                case "HumanoidCrouchButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidCrouchButton);
                    break;
                case "HumanoidJumpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidJumpButton);
                    break;
                case "HumanoidPrimaryInteractButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPrimaryInteractButton);
                    break;
                case "HumanoidItemWheelButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidItemWheelButton);
                    break;
                case "HumanoidEmoteWheelButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteWheelButton);
                    break;
                case "HumanoidUtilityWheelCycleMode":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidUtilityWheelCycleMode);
                    break;

                case "HumanoidPrimaryFireButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPrimaryFireButton);
                    break;
                case "HumanoidSelectPrimaryWeaponButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectPrimaryWeaponButton);
                    break;
                case "HumanoidSelectSecondaryWeaponButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectSecondaryWeaponButton);
                    break;
                case "HumanoidHideWeaponButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidHideWeaponButton);
                    break;
                case "HumanoidZoomButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidZoomButton);
                    break;
                case "HumanoidReloadButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidReloadButton);
                    break;
                case "HumanoidThrowGrenadeButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidThrowGrenadeButton);
                    break;
                case "HumanoidMeleeButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidMeleeButton);
                    break;
                case "HumanoidOpenAccessPanelButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidOpenAccessPanelButton);
                    break;
                case "HumanoidSecondaryInteractButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSecondaryInteractButton);
                    break;
                case "HumanoidSwitchToRechargeTool":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchToRechargeTool);
                    break;
                case "HumanoidSwitchToCompAnalyser":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchToCompAnalyser);
                    break;
                case "HumanoidToggleToolModeButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleToolModeButton);
                    break;
                case "HumanoidToggleNightVisionButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    break;
                case "HumanoidSwitchToSuitTool":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchToSuitTool);
                    break;
                case "HumanoidToggleFlashlightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton);
                    break;
                case "GalaxyMapOpen_Humanoid":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    break;
                case "SystemMapOpen_Humanoid":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    break;
                case "FocusCommsPanel_Humanoid":
                    StreamDeckCommon.SendKeypressDown(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    break;
                case "QuickCommsPanel_Humanoid":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].QuickCommsPanel_Humanoid);
                    break;
                case "HumanoidConflictContextualUIButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidConflictContextualUIButton);
                    break;
                case "HumanoidToggleShieldsButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleShieldsButton);
                    break;

                case "HumanoidRotateLeftButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidRotateLeftButton);
                    break;
                case "HumanoidRotateRightButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidRotateRightButton);
                    break;
                case "HumanoidPitchUpButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPitchUpButton);
                    break;
                case "HumanoidPitchDownButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPitchDownButton);
                    break;
                case "HumanoidSwitchWeapon":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSwitchWeapon);
                    break;
                case "HumanoidSelectUtilityWeaponButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectUtilityWeaponButton);
                    break;
                case "HumanoidSelectNextWeaponButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectNextWeaponButton);
                    break;
                case "HumanoidSelectPreviousWeaponButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousWeaponButton);
                    break;
                case "HumanoidSelectNextGrenadeTypeButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectNextGrenadeTypeButton);
                    break;
                case "HumanoidSelectPreviousGrenadeTypeButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousGrenadeTypeButton);
                    break;

                case "HumanoidToggleMissionHelpPanelButton":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidToggleMissionHelpPanelButton);
                    break;
                case "HumanoidPing":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidPing);
                    break;

                case "HumanoidEmoteSlot1":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot1);
                    break;
                case "HumanoidEmoteSlot2":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot2);
                    break;
                case "HumanoidEmoteSlot3":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot3);
                    break;
                case "HumanoidEmoteSlot4":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot4);
                    break;
                case "HumanoidEmoteSlot5":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot5);
                    break;
                case "HumanoidEmoteSlot6":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot6);
                    break;
                case "HumanoidEmoteSlot7":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot7);
                    break;
                case "HumanoidEmoteSlot8":
                    StreamDeckCommon.SendKeypressUp(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot8);
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


    }
}
