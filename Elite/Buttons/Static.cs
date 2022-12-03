using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BarRaider.SdTools;
using EliteJournalReader.Events;
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
                    ClickSoundFilename = string.Empty
				};

                return instance;
            }

            [JsonProperty(PropertyName = "function")]
            public string Function { get; set; }

            [FilenameProperty]
            [JsonProperty(PropertyName = "clickSound")]
            public string ClickSoundFilename { get; set; }

		}


		PluginSettings settings;
        private CachedSound _clickSound = null;


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
                HandleFileNames();
            }

        }

        private void HandleFireGroup(int fireGroup)
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
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                        Thread.Sleep(70);
                    }
                }
                else if (cycle > 0)
                {
                    for (var f = 0; f < cycle; f++)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                        Thread.Sleep(70);
                    }
                }
            }
        }

        public override void KeyPressed(KeyPayload payload)
        {
            if (InputRunning || Program.Binding == null)
            {
                ForceStop = true;
                return;
            }

            ForceStop = false;
            var isPrimary = false;

            switch (settings.Function)
            {
                case "OrderFocusTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderFocusTarget);
                    break;
                case "OrderAggressiveBehaviour":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderAggressiveBehaviour);
                    break;
                case "OrderDefensiveBehaviour":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderDefensiveBehaviour);
                    break;
                case "OpenOrders":
                    SendKeypress(Program.Binding[BindingType.Ship].OpenOrders);
                    break;
                case "OrderRequestDock":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderRequestDock);
                    break;
                case "OrderFollow":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderFollow);
                    break;
                case "OrderHoldFire":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderHoldFire);
                    break;
                case "OrderHoldPosition":
                    SendKeypress(Program.Binding[BindingType.Ship].OrderHoldPosition);
                    break;
          
                case "HeadLookPitchDown":
                    SendKeypress(Program.Binding[BindingType.Ship].HeadLookPitchDown);
                    break;
                case "HeadLookYawLeft":
                    SendKeypress(Program.Binding[BindingType.Ship].HeadLookYawLeft);
                    break;
                case "HeadLookYawRight":
                    SendKeypress(Program.Binding[BindingType.Ship].HeadLookYawRight);
                    break;
                case "HeadLookPitchUp":
                    SendKeypress(Program.Binding[BindingType.Ship].HeadLookPitchUp);
                    break;
                case "HeadLookReset":
                    SendKeypress(Program.Binding[BindingType.Ship].HeadLookReset);
                    break;
                case "OpenCodexGoToDiscovery":
                    SendKeypress(Program.Binding[BindingType.Ship].OpenCodexGoToDiscovery);
                    break;
                case "FriendsMenu":
                    SendKeypress(Program.Binding[BindingType.Ship].FriendsMenu);
                    break;
                case "Pause":
                    SendKeypress(Program.Binding[BindingType.Ship].Pause);
                    break;
                case "MicrophoneMute":
                    SendKeypress(Program.Binding[BindingType.Ship].MicrophoneMute);
                    break;

                case "HMDReset":
                    SendKeypress(Program.Binding[BindingType.Ship].HMDReset);
                    break;
                case "OculusReset":
                    SendKeypress(Program.Binding[BindingType.Ship].OculusReset);
                    break;
                case "RadarDecreaseRange":
                    SendKeypress(Program.Binding[BindingType.Ship].RadarDecreaseRange);
                    break;
                case "RadarIncreaseRange":
                    SendKeypress(Program.Binding[BindingType.Ship].RadarIncreaseRange);
                    break;
                case "MultiCrewThirdPersonFovInButton":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovInButton);
                    break;
                case "MultiCrewThirdPersonFovOutButton":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonFovOutButton);
                    break;
                case "MultiCrewPrimaryFire":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewPrimaryFire);
                    break;
                case "MultiCrewSecondaryFire":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewSecondaryFire);
                    break;
                case "MultiCrewToggleMode":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewToggleMode);
                    break;
                case "MultiCrewThirdPersonPitchDownButton":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchDownButton);
                    break;
                case "MultiCrewThirdPersonPitchUpButton":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonPitchUpButton);
                    break;
                case "MultiCrewPrimaryUtilityFire":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewPrimaryUtilityFire);
                    break;
                case "MultiCrewSecondaryUtilityFire":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewSecondaryUtilityFire);
                    break;
                case "MultiCrewCockpitUICycleBackward":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleBackward);
                    break;
                case "MultiCrewCockpitUICycleForward":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewCockpitUICycleForward);
                    break;
                case "MultiCrewThirdPersonYawLeftButton":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawLeftButton);
                    break;
                case "MultiCrewThirdPersonYawRightButton":
                    SendKeypress(Program.Binding[BindingType.Ship].MultiCrewThirdPersonYawRightButton);
                    break;
                case "SAAThirdPersonFovInButton":
                    SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonFovInButton);
                    break;
                case "SAAThirdPersonFovOutButton":
                    SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonFovOutButton);
                    break;
                case "ExplorationFSSEnter":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSEnter);
                    break;
                case "ExplorationSAAExitThirdPerson":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAExitThirdPerson);
                    break;
                case "ExplorationFSSQuit":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSQuit);
                    break;
                case "ExplorationFSSShowHelp":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSShowHelp);
                    break;
                case "ExplorationSAANextGenus":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAANextGenus);
                    break;
                case "ExplorationSAAPreviousGenus":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAPreviousGenus);
                    break;
                case "ExplorationSAAShowHelp":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAShowHelp);
                    break;
                case "ExplorationFSSDiscoveryScan":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSDiscoveryScan);
                    break;
                case "ExplorationFSSCameraPitchDecreaseButton":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchDecreaseButton);
                    break;
                case "ExplorationFSSCameraPitchIncreaseButton":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraPitchIncreaseButton);
                    break;
                case "ExplorationFSSRadioTuningX_Decrease":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Decrease);
                    break;
                case "ExplorationFSSRadioTuningX_Increase":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSRadioTuningX_Increase);
                    break;
                case "ExplorationFSSCameraYawDecreaseButton":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawDecreaseButton);
                    break;
                case "ExplorationFSSCameraYawIncreaseButton":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSCameraYawIncreaseButton);
                    break;
                case "SAAThirdPersonPitchDownButton":
                    SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonPitchDownButton);
                    break;
                case "SAAThirdPersonPitchUpButton":
                    SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonPitchUpButton);
                    break;
                case "ExplorationFSSMiniZoomIn":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomIn);
                    break;
                case "ExplorationFSSMiniZoomOut":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSMiniZoomOut);
                    break;
                case "ExplorationFSSTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSTarget);
                    break;
                case "ExplorationSAAChangeScannedAreaViewToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationSAAChangeScannedAreaViewToggle);
                    break;
                case "SAAThirdPersonYawLeftButton":
                    SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonYawLeftButton);
                    break;
                case "SAAThirdPersonYawRightButton":
                    SendKeypress(Program.Binding[BindingType.Ship].SAAThirdPersonYawRightButton);
                    break;
                case "ExplorationFSSZoomIn":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSZoomIn);
                    break;
                case "ExplorationFSSZoomOut":
                    SendKeypress(Program.Binding[BindingType.Ship].ExplorationFSSZoomOut);
                    break;
                case "FocusCommsPanel":
                    SendKeypress(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    break;
                case "FocusLeftPanel":
                    SendKeypress(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    break;
                case "QuickCommsPanel":
                    SendKeypress(Program.Binding[BindingType.Ship].QuickCommsPanel);
                    break;
                case "FocusRadarPanel":
                    SendKeypress(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    break;
                case "FocusRightPanel":
                    SendKeypress(Program.Binding[BindingType.Ship].FocusRightPanel);
                    break;
                case "UIFocus":
                    SendKeypress(Program.Binding[BindingType.Ship].UIFocus);
                    break;
                case "TargetWingman0":
                    SendKeypress(Program.Binding[BindingType.Ship].TargetWingman0);
                    break;
                case "TargetWingman1":
                    SendKeypress(Program.Binding[BindingType.Ship].TargetWingman1);
                    break;
                case "TargetWingman2":
                    SendKeypress(Program.Binding[BindingType.Ship].TargetWingman2);
                    break;
                case "WingNavLock":
                    SendKeypress(Program.Binding[BindingType.Ship].WingNavLock);
                    break;
                case "SelectTargetsTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].SelectTargetsTarget);
                    break;
                case "FireChaffLauncher":
                    SendKeypress(Program.Binding[BindingType.Ship].FireChaffLauncher);
                    break;
                case "ChargeECM":
                    SendKeypress(Program.Binding[BindingType.Ship].ChargeECM);
                    break;
                case "IncreaseEnginesPower":
                    SendKeypress(Program.Binding[BindingType.Ship].IncreaseEnginesPower);
                    break;
                case "PrimaryFire":
                    SendKeypress(Program.Binding[BindingType.Ship].PrimaryFire);
                    break;
                case "SecondaryFire":
                    SendKeypress(Program.Binding[BindingType.Ship].SecondaryFire);
                    break;
                case "DeployHeatSink":
                    SendKeypress(Program.Binding[BindingType.Ship].DeployHeatSink);
                    break;
                case "SelectHighestThreat":
                    SendKeypress(Program.Binding[BindingType.Ship].SelectHighestThreat);
                    break;
                case "CycleNextTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].CycleNextTarget);
                    break;
                case "CycleFireGroupNext":
                    SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupNext);
                    break;
                case "CycleNextHostileTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].CycleNextHostileTarget);
                    break;
                case "CycleNextSubsystem":
                    SendKeypress(Program.Binding[BindingType.Ship].CycleNextSubsystem);
                    break;
                case "CyclePreviousTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].CyclePreviousTarget);
                    break;
                case "CycleFireGroupPrevious":
                    SendKeypress(Program.Binding[BindingType.Ship].CycleFireGroupPrevious);
                    break;
                case "CyclePreviousHostileTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].CyclePreviousHostileTarget);
                    break;
                case "CyclePreviousSubsystem":
                    SendKeypress(Program.Binding[BindingType.Ship].CyclePreviousSubsystem);
                    break;
                case "ResetPowerDistribution":
                    SendKeypress(Program.Binding[BindingType.Ship].ResetPowerDistribution);
                    break;
                case "UseShieldCell":
                    SendKeypress(Program.Binding[BindingType.Ship].UseShieldCell);
                    break;
                case "TriggerFieldNeutraliser":
                    SendKeypress(Program.Binding[BindingType.Ship].TriggerFieldNeutraliser);
                    break;
                case "IncreaseSystemsPower":
                    SendKeypress(Program.Binding[BindingType.Ship].IncreaseSystemsPower);
                    break;
                case "SelectTarget":
                    SendKeypress(Program.Binding[BindingType.Ship].SelectTarget);
                    break;
                case "IncreaseWeaponsPower":
                    SendKeypress(Program.Binding[BindingType.Ship].IncreaseWeaponsPower);
                    break;
                case "ShowPGScoreSummaryInput":
                    SendKeypress(Program.Binding[BindingType.Ship].ShowPGScoreSummaryInput);
                    break;
                case "EjectAllCargo":
                    SendKeypress(Program.Binding[BindingType.Ship].EjectAllCargo);
                    break;
                case "EngineColourToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].EngineColourToggle);
                    break;
                case "OrbitLinesToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].OrbitLinesToggle);
                    break;
                case "MouseReset":
                    SendKeypress(Program.Binding[BindingType.Ship].MouseReset);
                    break;
                case "HeadLookToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].HeadLookToggle);
                    break;
                case "WeaponColourToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].WeaponColourToggle);
                    break;
                case "SetSpeedMinus100":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus100);
                    break;
                case "SetSpeed100":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeed100);
                    break;
                case "SetSpeedMinus25":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus25);
                    break;
                case "SetSpeed25":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeed25);
                    break;
                case "SetSpeedMinus50":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus50);
                    break;
                case "SetSpeed50":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeed50);
                    break;
                case "SetSpeedMinus75":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeedMinus75);
                    break;
                case "SetSpeed75":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeed75);
                    break;
                case "SetSpeedZero":
                    SendKeypress(Program.Binding[BindingType.Ship].SetSpeedZero);
                    break;
                case "UseAlternateFlightValuesToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].UseAlternateFlightValuesToggle);
                    break;
                case "UseBoostJuice":
                    SendKeypress(Program.Binding[BindingType.Ship].UseBoostJuice);
                    break;
                case "ForwardKey":
                    SendKeypress(Program.Binding[BindingType.Ship].ForwardKey);
                    break;
                case "ForwardThrustButton":
                    SendKeypress(Program.Binding[BindingType.Ship].ForwardThrustButton);
                    break;
                case "ForwardThrustButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].ForwardThrustButton_Landing);
                    break;
                case "GalaxyMapOpen":
                    SendKeypress(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    break;
                case "HyperSuperCombination":
                    SendKeypress(Program.Binding[BindingType.Ship].HyperSuperCombination);
                    break;
                case "TargetNextRouteSystem":
                    SendKeypress(Program.Binding[BindingType.Ship].TargetNextRouteSystem);
                    break;
                case "PitchDownButton":
                    SendKeypress(Program.Binding[BindingType.Ship].PitchDownButton);
                    break;
                case "PitchDownButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].PitchDownButton_Landing);
                    break;
                case "PitchUpButton":
                    SendKeypress(Program.Binding[BindingType.Ship].PitchUpButton);
                    break;
                case "PitchUpButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].PitchUpButton_Landing);
                    break;
                case "ToggleReverseThrottleInput":
                    SendKeypress(Program.Binding[BindingType.Ship].ToggleReverseThrottleInput);
                    break;
                case "BackwardKey":
                    SendKeypress(Program.Binding[BindingType.Ship].BackwardKey);
                    break;
                case "BackwardThrustButton":
                    SendKeypress(Program.Binding[BindingType.Ship].BackwardThrustButton);
                    break;
                case "BackwardThrustButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].BackwardThrustButton_Landing);
                    break;
                case "RollLeftButton":
                    SendKeypress(Program.Binding[BindingType.Ship].RollLeftButton);
                    break;
                case "RollLeftButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].RollLeftButton_Landing);
                    break;
                case "RollRightButton":
                    SendKeypress(Program.Binding[BindingType.Ship].RollRightButton);
                    break;
                case "RollRightButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].RollRightButton_Landing);
                    break;
                case "DisableRotationCorrectToggle":
                    SendKeypress(Program.Binding[BindingType.Ship].DisableRotationCorrectToggle);
                    break;
                case "SystemMapOpen":
                    SendKeypress(Program.Binding[BindingType.Ship].SystemMapOpen);
                    break;
                case "DownThrustButton":
                    SendKeypress(Program.Binding[BindingType.Ship].DownThrustButton);
                    break;
                case "DownThrustButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].DownThrustButton_Landing);
                    break;
                case "LeftThrustButton":
                    SendKeypress(Program.Binding[BindingType.Ship].LeftThrustButton);
                    break;
                case "LeftThrustButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].LeftThrustButton_Landing);
                    break;
                case "RightThrustButton":
                    SendKeypress(Program.Binding[BindingType.Ship].RightThrustButton);
                    break;
                case "RightThrustButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].RightThrustButton_Landing);
                    break;
                case "UpThrustButton":
                    SendKeypress(Program.Binding[BindingType.Ship].UpThrustButton);
                    break;
                case "UpThrustButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].UpThrustButton_Landing);
                    break;
                case "YawLeftButton":
                    SendKeypress(Program.Binding[BindingType.Ship].YawLeftButton);
                    break;
                case "YawLeftButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].YawLeftButton_Landing);
                    break;
                case "YawRightButton":
                    SendKeypress(Program.Binding[BindingType.Ship].YawRightButton);
                    break;
                case "YawRightButton_Landing":
                    SendKeypress(Program.Binding[BindingType.Ship].YawRightButton_Landing);
                    break;
                case "YawToRollButton":
                    SendKeypress(Program.Binding[BindingType.Ship].YawToRollButton);
                    break;


                case "Supercruise":
                    SendKeypress(Program.Binding[BindingType.Ship].Supercruise);
                    break;
                case "Hyperspace":
                    SendKeypress(Program.Binding[BindingType.Ship].Hyperspace);
                    break;

                case "PlayerHUDModeToggle-AM":
                    isPrimary = EliteData.StatusData.HudInAnalysisMode;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    }
                    break;
                case "PlayerHUDModeToggle-CM":
                    isPrimary = EliteData.StatusData.HudInAnalysisMode;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].PlayerHUDModeToggle);
                    }
                    break;

                case "ToggleCargoScoop-ON":
                    isPrimary = EliteData.StatusData.CargoScoopDeployed;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    }
                    break;
                case "ToggleCargoScoop-OFF":
                    isPrimary = EliteData.StatusData.CargoScoopDeployed;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ToggleCargoScoop);
                    }
                    break;

                case "ToggleFlightAssist-ON":
                    isPrimary = !EliteData.StatusData.FlightAssistOff;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    }
                    break;
                case "ToggleFlightAssist-OFF":
                    isPrimary = !EliteData.StatusData.FlightAssistOff;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ToggleFlightAssist);
                    }
                    break;

                case "DeployHardpointToggle-ON":
                    isPrimary = EliteData.StatusData.HardpointsDeployed;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    }
                    break;
                case "DeployHardpointToggle-OFF":
                    isPrimary = EliteData.StatusData.HardpointsDeployed;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].DeployHardpointToggle);
                    }
                    break;

                case "LandingGearToggle-ON":
                    isPrimary = EliteData.StatusData.LandingGearDown;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].LandingGearToggle);
                    }
                    break;
                case "LandingGearToggle-OFF":
                    isPrimary = EliteData.StatusData.LandingGearDown;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].LandingGearToggle);
                    }
                    break;

                case "ShipSpotLightToggle-ON":
                    isPrimary = EliteData.StatusData.LightsOn || EliteData.StatusData.SrvHighBeam;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    }
                    break;
                case "ShipSpotLightToggle-OFF":
                    isPrimary = EliteData.StatusData.LightsOn || EliteData.StatusData.SrvHighBeam;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ShipSpotLightToggle);
                    }
                    break;

                case "NightVisionToggle-ON":
                    isPrimary = EliteData.StatusData.NightVision;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].NightVisionToggle);
                    }
                    break;
                case "NightVisionToggle-OFF":
                    isPrimary = EliteData.StatusData.NightVision;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].NightVisionToggle);
                    }
                    break;

                case "ToggleButtonUpInput-ON":
                    isPrimary = EliteData.StatusData.SilentRunning;
                    if (!isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    }
                    break;
                case "ToggleButtonUpInput-OFF":
                    isPrimary = EliteData.StatusData.SilentRunning;
                    if (isPrimary)
                    {
                        SendKeypress(Program.Binding[BindingType.Ship].ToggleButtonUpInput);
                    }
                    break;


                case "FocusCommsPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.CommsPanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            SendKeypress(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                        else if (EliteData.StatusData.OnFoot)
                            SendKeypress(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                        else
                            SendKeypress(Program.Binding[BindingType.Ship].FocusCommsPanel);
                    }
                    break;
                case "FocusLeftPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.ExternalPanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            SendKeypress(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                        else
                            SendKeypress(Program.Binding[BindingType.Ship].FocusLeftPanel);
                    }
                    break;
                case "FocusRadarPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.RolePanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            SendKeypress(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                        else
                            SendKeypress(Program.Binding[BindingType.Ship].FocusRadarPanel);
                    }
                    break;
                case "FocusRightPanel-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.InternalPanel;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            SendKeypress(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                        else
                            SendKeypress(Program.Binding[BindingType.Ship].FocusRightPanel);
                    }
                    break;
                case "GalaxyMapOpen-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.GalaxyMap;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            SendKeypress(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                        else if (EliteData.StatusData.OnFoot)
                            SendKeypress(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                        else
                            SendKeypress(Program.Binding[BindingType.Ship].GalaxyMapOpen);
                    }
                    break;
                case "SystemMapOpen-ON":
                    isPrimary = EliteData.StatusData.GuiFocus == StatusGuiFocus.SystemMap || EliteData.StatusData.GuiFocus == StatusGuiFocus.Orrery;
                    if (!isPrimary && EliteData.StatusData.GuiFocus != StatusGuiFocus.NoFocus)
                    {
                        SendKeypress(Program.Binding[BindingType.General].UI_Back);
                        Thread.Sleep(200);
                    }

                    if (!isPrimary)
                    {
                        if (EliteData.StatusData.InSRV)
                            SendKeypress(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                        else if (EliteData.StatusData.OnFoot)
                            SendKeypress(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                        else
                            SendKeypress(Program.Binding[BindingType.Ship].SystemMapOpen);
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
                    SendKeypress(Program.Binding[BindingType.General].CycleNextPage);
                    break;
                case "CycleNextPanel":
                    SendKeypress(Program.Binding[BindingType.General].CycleNextPanel);
                    break;
                case "CyclePreviousPage":
                    SendKeypress(Program.Binding[BindingType.General].CyclePreviousPage);
                    break;
                case "CyclePreviousPanel":
                    SendKeypress(Program.Binding[BindingType.General].CyclePreviousPanel);
                    break;
                case "UI_Back":
                    SendKeypress(Program.Binding[BindingType.General].UI_Back);
                    break;
                case "UI_Down":
                    SendKeypress(Program.Binding[BindingType.General].UI_Down);
                    break;
                case "UI_Left":
                    SendKeypress(Program.Binding[BindingType.General].UI_Left);
                    break;
                case "UI_Right":
                    SendKeypress(Program.Binding[BindingType.General].UI_Right);
                    break;
                case "UI_Select":
                    SendKeypress(Program.Binding[BindingType.General].UI_Select);
                    break;
                case "UI_Toggle":
                    SendKeypress(Program.Binding[BindingType.General].UI_Toggle);
                    break;
                case "UI_Up":
                    SendKeypress(Program.Binding[BindingType.General].UI_Up);
                    break;

                case "CamTranslateBackward":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateBackward);
                    break;
                case "CamTranslateDown":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateDown);
                    break;
                case "CamTranslateForward":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateForward);
                    break;
                case "CamTranslateLeft":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateLeft);
                    break;
                case "CamPitchDown":
                    SendKeypress(Program.Binding[BindingType.General].CamPitchDown);
                    break;
                case "CamPitchUp":
                    SendKeypress(Program.Binding[BindingType.General].CamPitchUp);
                    break;
                case "CamTranslateRight":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateRight);
                    break;
                case "CamTranslateUp":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateUp);
                    break;
                case "CamYawLeft":
                    SendKeypress(Program.Binding[BindingType.General].CamYawLeft);
                    break;
                case "CamYawRight":
                    SendKeypress(Program.Binding[BindingType.General].CamYawRight);
                    break;
                case "CamTranslateZHold":
                    SendKeypress(Program.Binding[BindingType.General].CamTranslateZHold);
                    break;
                case "CamZoomIn":
                    SendKeypress(Program.Binding[BindingType.General].CamZoomIn);
                    break;
                case "CamZoomOut":
                    SendKeypress(Program.Binding[BindingType.General].CamZoomOut);
                    break;

                case "MoveFreeCamBackwards":
                    SendKeypress(Program.Binding[BindingType.General].MoveFreeCamBackwards);
                    break;
                case "MoveFreeCamDown":
                    SendKeypress(Program.Binding[BindingType.General].MoveFreeCamDown);
                    break;
                case "MoveFreeCamForward":
                    SendKeypress(Program.Binding[BindingType.General].MoveFreeCamForward);
                    break;
                case "MoveFreeCamLeft":
                    SendKeypress(Program.Binding[BindingType.General].MoveFreeCamLeft);
                    break;
                case "ToggleReverseThrottleInputFreeCam":
                    SendKeypress(Program.Binding[BindingType.General].ToggleReverseThrottleInputFreeCam);
                    break;
                case "MoveFreeCamRight":
                    SendKeypress(Program.Binding[BindingType.General].MoveFreeCamRight);
                    break;
                case "MoveFreeCamUp":
                    SendKeypress(Program.Binding[BindingType.General].MoveFreeCamUp);
                    break;
                case "FreeCamSpeedDec":
                    SendKeypress(Program.Binding[BindingType.General].FreeCamSpeedDec);
                    break;
                case "ToggleFreeCam":
                    SendKeypress(Program.Binding[BindingType.General].ToggleFreeCam);
                    break;
                case "FreeCamSpeedInc":
                    SendKeypress(Program.Binding[BindingType.General].FreeCamSpeedInc);
                    break;
                case "FreeCamToggleHUD":
                    SendKeypress(Program.Binding[BindingType.General].FreeCamToggleHUD);
                    break;
                case "FreeCamZoomIn":
                    SendKeypress(Program.Binding[BindingType.General].FreeCamZoomIn);
                    break;
                case "FreeCamZoomOut":
                    SendKeypress(Program.Binding[BindingType.General].FreeCamZoomOut);
                    break;

                case "PhotoCameraToggle":
                    SendKeypress(Program.Binding[BindingType.General].PhotoCameraToggle);
                    break;
                case "StorePitchCameraDown":
                    SendKeypress(Program.Binding[BindingType.General].StorePitchCameraDown);
                    break;
                case "StorePitchCameraUp":
                    SendKeypress(Program.Binding[BindingType.General].StorePitchCameraUp);
                    break;
                case "StoreEnableRotation":
                    SendKeypress(Program.Binding[BindingType.General].StoreEnableRotation);
                    break;
                case "StoreYawCameraLeft":
                    SendKeypress(Program.Binding[BindingType.General].StoreYawCameraLeft);
                    break;
                case "StoreYawCameraRight":
                    SendKeypress(Program.Binding[BindingType.General].StoreYawCameraRight);
                    break;
                case "StoreCamZoomIn":
                    SendKeypress(Program.Binding[BindingType.General].StoreCamZoomIn);
                    break;
                case "StoreCamZoomOut":
                    SendKeypress(Program.Binding[BindingType.General].StoreCamZoomOut);
                    break;
                case "StoreToggle":
                    SendKeypress(Program.Binding[BindingType.General].StoreToggle);
                    break;
                case "ToggleAdvanceMode":
                    SendKeypress(Program.Binding[BindingType.General].ToggleAdvanceMode);
                    break;
                case "VanityCameraEight":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraEight);
                    break;
                case "VanityCameraTwo":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraTwo);
                    break;
                case "VanityCameraOne":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraOne);
                    break;
                case "VanityCameraThree":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraThree);
                    break;
                case "VanityCameraFour":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraFour);
                    break;
                case "VanityCameraFive":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraFive);
                    break;
                case "VanityCameraSix":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraSix);
                    break;
                case "VanityCameraSeven":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraSeven);
                    break;
                case "VanityCameraNine":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraNine);
                    break;
                case "VanityCameraTen":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraTen);
                    break;
                case "PitchCameraDown":
                    SendKeypress(Program.Binding[BindingType.General].PitchCameraDown);
                    break;
                case "PitchCameraUp":
                    SendKeypress(Program.Binding[BindingType.General].PitchCameraUp);
                    break;
                case "RollCameraLeft":
                    SendKeypress(Program.Binding[BindingType.General].RollCameraLeft);
                    break;
                case "RollCameraRight":
                    SendKeypress(Program.Binding[BindingType.General].RollCameraRight);
                    break;
                case "ToggleRotationLock":
                    SendKeypress(Program.Binding[BindingType.General].ToggleRotationLock);
                    break;
                case "YawCameraLeft":
                    SendKeypress(Program.Binding[BindingType.General].YawCameraLeft);
                    break;
                case "YawCameraRight":
                    SendKeypress(Program.Binding[BindingType.General].YawCameraRight);
                    break;
                case "FStopDec":
                    SendKeypress(Program.Binding[BindingType.General].FStopDec);
                    break;
                case "QuitCamera":
                    SendKeypress(Program.Binding[BindingType.General].QuitCamera);
                    break;
                case "FocusDistanceInc":
                    SendKeypress(Program.Binding[BindingType.General].FocusDistanceInc);
                    break;
                case "FocusDistanceDec":
                    SendKeypress(Program.Binding[BindingType.General].FocusDistanceDec);
                    break;
                case "FStopInc":
                    SendKeypress(Program.Binding[BindingType.General].FStopInc);
                    break;
                case "FixCameraRelativeToggle":
                    SendKeypress(Program.Binding[BindingType.General].FixCameraRelativeToggle);
                    break;
                case "FixCameraWorldToggle":
                    SendKeypress(Program.Binding[BindingType.General].FixCameraWorldToggle);
                    break;
                case "VanityCameraScrollRight":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraScrollRight);
                    break;
                case "VanityCameraScrollLeft":
                    SendKeypress(Program.Binding[BindingType.General].VanityCameraScrollLeft);
                    break;

                case "CommanderCreator_Redo":
                    SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Redo);
                    break;
                case "CommanderCreator_Rotation":
                    SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Rotation);
                    break;
                case "CommanderCreator_Rotation_MouseToggle":
                    SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Rotation_MouseToggle);
                    break;
                case "CommanderCreator_Undo":
                    SendKeypress(Program.Binding[BindingType.General].CommanderCreator_Undo);
                    break;

                case "GalnetAudio_ClearQueue":
                    SendKeypress(Program.Binding[BindingType.General].GalnetAudio_ClearQueue);
                    break;
                case "GalnetAudio_SkipForward":
                    SendKeypress(Program.Binding[BindingType.General].GalnetAudio_SkipForward);
                    break;
                case "GalnetAudio_Play_Pause":
                    SendKeypress(Program.Binding[BindingType.General].GalnetAudio_Play_Pause);
                    break;
                case "GalnetAudio_SkipBackward":
                    SendKeypress(Program.Binding[BindingType.General].GalnetAudio_SkipBackward);
                    break;

                // in srv

                case "ToggleDriveAssist":
                    SendKeypress(Program.Binding[BindingType.Srv].ToggleDriveAssist);
                    break;
                case "SteerLeftButton":
                    SendKeypress(Program.Binding[BindingType.Srv].SteerLeftButton);
                    break;
                case "SteerRightButton":
                    SendKeypress(Program.Binding[BindingType.Srv].SteerRightButton);
                    break;
                case "IncreaseSpeedButtonMax":
                    SendKeypress(Program.Binding[BindingType.Srv].IncreaseSpeedButtonMax);
                    break;
                case "DecreaseSpeedButtonMax":
                    SendKeypress(Program.Binding[BindingType.Srv].DecreaseSpeedButtonMax);
                    break;
                case "IncreaseSpeedButtonPartial":
                    SendKeypress(Program.Binding[BindingType.Srv].IncreaseSpeedButtonPartial);
                    break;
                case "DecreaseSpeedButtonPartial":
                    SendKeypress(Program.Binding[BindingType.Srv].DecreaseSpeedButtonPartial);
                    break;
                case "RecallDismissShip":
                    SendKeypress(Program.Binding[BindingType.Srv].RecallDismissShip);
                    break;
                case "VerticalThrustersButton":
                    SendKeypress(Program.Binding[BindingType.Srv].VerticalThrustersButton);
                    break;

                case "PhotoCameraToggle_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].PhotoCameraToggle_Buggy);
                    break;
                case "FocusCommsPanel_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].FocusCommsPanel_Buggy);
                    break;
                case "EjectAllCargo_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].EjectAllCargo_Buggy);
                    break;
                case "FocusLeftPanel_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].FocusLeftPanel_Buggy);
                    break;
                case "QuickCommsPanel_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].QuickCommsPanel_Buggy);
                    break;
                case "FocusRadarPanel_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].FocusRadarPanel_Buggy);
                    break;
                case "FocusRightPanel_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].FocusRightPanel_Buggy);
                    break;
                case "HeadLookToggle_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].HeadLookToggle_Buggy);
                    break;
                case "UIFocus_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].UIFocus_Buggy);
                    break;
                case "IncreaseEnginesPower_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].IncreaseEnginesPower_Buggy);
                    break;
                case "BuggyPrimaryFireButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyPrimaryFireButton);
                    break;
                case "ResetPowerDistribution_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].ResetPowerDistribution_Buggy);
                    break;
                case "BuggySecondaryFireButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggySecondaryFireButton);
                    break;
                case "IncreaseSystemsPower_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].IncreaseSystemsPower_Buggy);
                    break;
                case "SelectTarget_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].SelectTarget_Buggy);
                    break;
                case "BuggyTurretPitchDownButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretPitchDownButton);
                    break;
                case "BuggyTurretYawLeftButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretYawLeftButton);
                    break;
                case "ToggleBuggyTurretButton":
                    SendKeypress(Program.Binding[BindingType.Srv].ToggleBuggyTurretButton);
                    break;
                case "BuggyTurretYawRightButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretYawRightButton);
                    break;
                case "BuggyTurretPitchUpButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyTurretPitchUpButton);
                    break;
                case "IncreaseWeaponsPower_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].IncreaseWeaponsPower_Buggy);
                    break;
                case "ToggleCargoScoop_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].ToggleCargoScoop_Buggy);
                    break;
                case "GalaxyMapOpen_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].GalaxyMapOpen_Buggy);
                    break;
                case "AutoBreakBuggyButton":
                    SendKeypress(Program.Binding[BindingType.Srv].AutoBreakBuggyButton);
                    break;
                case "HeadlightsBuggyButton":
                    SendKeypress(Program.Binding[BindingType.Srv].HeadlightsBuggyButton);
                    break;
                case "BuggyPitchDownButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyPitchDownButton);
                    break;
                case "BuggyPitchUpButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyPitchUpButton);
                    break;
                case "BuggyToggleReverseThrottleInput":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyToggleReverseThrottleInput);
                    break;
                case "BuggyRollLeft":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyRollLeft);
                    break;
                case "BuggyRollLeftButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyRollLeftButton);
                    break;
                case "BuggyRollRight":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyRollRight);
                    break;
                case "BuggyRollRightButton":
                    SendKeypress(Program.Binding[BindingType.Srv].BuggyRollRightButton);
                    break;
                case "SystemMapOpen_Buggy":
                    SendKeypress(Program.Binding[BindingType.Srv].SystemMapOpen_Buggy);
                    break;

                // on foot

                case "HumanoidClearAuthorityLevel":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidClearAuthorityLevel);
                    break;
                case "HumanoidHealthPack":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidHealthPack);
                    break;
                case "HumanoidBattery":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidBattery);
                    break;
                case "HumanoidSelectFragGrenade":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectFragGrenade);
                    break;
                case "HumanoidSelectEMPGrenade":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectEMPGrenade);
                    break;
                case "HumanoidSelectShieldGrenade":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectShieldGrenade);
                    break;

                case "PhotoCameraToggle_Humanoid":
                    SendKeypress(Program.Binding[BindingType.OnFoot].PhotoCameraToggle_Humanoid);
                    break;
                case "HumanoidForwardButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidForwardButton);
                    break;
                case "HumanoidBackwardButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidBackwardButton);
                    break;
                case "HumanoidStrafeLeftButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidStrafeLeftButton);
                    break;
                case "HumanoidStrafeRightButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidStrafeRightButton);
                    break;
                case "HumanoidSprintButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSprintButton);
                    break;
                case "HumanoidCrouchButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidCrouchButton);
                    break;
                case "HumanoidJumpButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidJumpButton);
                    break;
                case "HumanoidPrimaryInteractButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPrimaryInteractButton);
                    break;
                case "HumanoidItemWheelButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidItemWheelButton);
                    break;
                case "HumanoidEmoteWheelButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteWheelButton);
                    break;
                case "HumanoidUtilityWheelCycleMode":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidUtilityWheelCycleMode);
                    break;

                case "HumanoidPrimaryFireButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPrimaryFireButton);
                    break;
                case "HumanoidSelectPrimaryWeaponButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectPrimaryWeaponButton);
                    break;
                case "HumanoidSelectSecondaryWeaponButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectSecondaryWeaponButton);
                    break;
                case "HumanoidHideWeaponButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidHideWeaponButton);
                    break;
                case "HumanoidZoomButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidZoomButton);
                    break;
                case "HumanoidReloadButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidReloadButton);
                    break;
                case "HumanoidThrowGrenadeButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidThrowGrenadeButton);
                    break;
                case "HumanoidMeleeButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidMeleeButton);
                    break;
                case "HumanoidOpenAccessPanelButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidOpenAccessPanelButton);
                    break;
                case "HumanoidSecondaryInteractButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSecondaryInteractButton);
                    break;
                case "HumanoidSwitchToRechargeTool":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchToRechargeTool);
                    break;
                case "HumanoidSwitchToCompAnalyser":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchToCompAnalyser);
                    break;
                case "HumanoidToggleToolModeButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleToolModeButton);
                    break;
                case "HumanoidToggleNightVisionButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleNightVisionButton);
                    break;
                case "HumanoidSwitchToSuitTool":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchToSuitTool);
                    break;
                case "HumanoidToggleFlashlightButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleFlashlightButton);
                    break;
                case "GalaxyMapOpen_Humanoid":
                    SendKeypress(Program.Binding[BindingType.OnFoot].GalaxyMapOpen_Humanoid);
                    break;
                case "SystemMapOpen_Humanoid":
                    SendKeypress(Program.Binding[BindingType.OnFoot].SystemMapOpen_Humanoid);
                    break;
                case "FocusCommsPanel_Humanoid":
                    SendKeypress(Program.Binding[BindingType.OnFoot].FocusCommsPanel_Humanoid);
                    break;
                case "QuickCommsPanel_Humanoid":
                    SendKeypress(Program.Binding[BindingType.OnFoot].QuickCommsPanel_Humanoid);
                    break;
                case "HumanoidConflictContextualUIButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidConflictContextualUIButton);
                    break;
                case "HumanoidToggleShieldsButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleShieldsButton);
                    break;

                case "HumanoidRotateLeftButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidRotateLeftButton);
                    break;
                case "HumanoidRotateRightButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidRotateRightButton);
                    break;
                case "HumanoidPitchUpButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPitchUpButton);
                    break;
                case "HumanoidPitchDownButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPitchDownButton);
                    break;
                case "HumanoidSwitchWeapon":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSwitchWeapon);
                    break;
                case "HumanoidSelectUtilityWeaponButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectUtilityWeaponButton);
                    break;
                case "HumanoidSelectNextWeaponButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectNextWeaponButton);
                    break;
                case "HumanoidSelectPreviousWeaponButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousWeaponButton);
                    break;
                case "HumanoidSelectNextGrenadeTypeButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectNextGrenadeTypeButton);
                    break;
                case "HumanoidSelectPreviousGrenadeTypeButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidSelectPreviousGrenadeTypeButton);
                    break;
                case "HumanoidToggleMissionHelpPanelButton":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidToggleMissionHelpPanelButton);
                    break;
                case "HumanoidPing":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidPing);
                    break;

                case "HumanoidEmoteSlot1":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot1);
                    break;
                case "HumanoidEmoteSlot2":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot2);
                    break;
                case "HumanoidEmoteSlot3":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot3);
                    break;
                case "HumanoidEmoteSlot4":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot4);
                    break;
                case "HumanoidEmoteSlot5":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot5);
                    break;
                case "HumanoidEmoteSlot6":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot6);
                    break;
                case "HumanoidEmoteSlot7":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot7);
                    break;
                case "HumanoidEmoteSlot8":
                    SendKeypress(Program.Binding[BindingType.OnFoot].HumanoidEmoteSlot8);
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

            if (_clickSound != null)
            {
                try
                {
                    AudioPlaybackEngine.Instance.PlaySound(_clickSound);
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, $"PlaySound: {ex}");
                }
            }

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

			Connection.SetSettingsAsync(JObject.FromObject(settings)).Wait();
		}

	}
}
