using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Elite
{

    enum BindingType : int
    {
        General = 0,
        Ship = 1,
        Srv = 2,
        OnFoot = 3
    }

    [Serializable]
    [XmlRoot("Root")]

    public class UserBindings
    {
        [XmlAttribute]
        public string PresetName { get;  set; }
        [XmlAttribute]
        public long MajorVersion { get;  set; }
        [XmlAttribute]
        public long MinorVersion { get;  set; }

        public string KeyboardLayout { get;  set; }
        public string LockedDevice { get;  set; }
        public ValueInfo MouseXMode { get;  set; }
        public ValueInfo MouseXDecay { get;  set; }
        public ValueInfo MouseYMode { get;  set; }
        public ValueInfo MouseYDecay { get;  set; }
        public StandardBindingInfo MouseReset { get;  set; }
        public ValueInfo MouseSensitivity { get;  set; }
        public ValueInfo MouseDecayRate { get;  set; }
        public ValueInfo MouseDeadzone { get;  set; }
        public ValueInfo MouseLinearity { get;  set; }
        public ValueInfo MouseGUI { get;  set; }
        public AxisBindingInfo YawAxisRaw { get;  set; }
        public StandardBindingInfo YawLeftButton { get;  set; }
        public StandardBindingInfo YawRightButton { get;  set; }
        public ValueInfo YawToRollMode { get;  set; }
        public ValueInfo YawToRollSensitivity { get;  set; }
        public ToggleBindingInfo YawToRollButton { get;  set; }
        public AxisBindingInfo RollAxisRaw { get;  set; }
        public StandardBindingInfo RollLeftButton { get;  set; }
        public StandardBindingInfo RollRightButton { get;  set; }
        public AxisBindingInfo PitchAxisRaw { get;  set; }
        public StandardBindingInfo PitchUpButton { get;  set; }
        public StandardBindingInfo PitchDownButton { get;  set; }
        public AxisBindingInfo LateralThrustRaw { get;  set; }
        public StandardBindingInfo LeftThrustButton { get;  set; }
        public StandardBindingInfo RightThrustButton { get;  set; }
        public AxisBindingInfo VerticalThrustRaw { get;  set; }
        public StandardBindingInfo UpThrustButton { get;  set; }
        public StandardBindingInfo DownThrustButton { get;  set; }
        public AxisBindingInfo AheadThrust { get;  set; }
        public StandardBindingInfo ForwardThrustButton { get;  set; }
        public StandardBindingInfo BackwardThrustButton { get;  set; }
        public AxisBindingInfo YawAxisAlternate { get;  set; }
        public AxisBindingInfo RollAxisAlternate { get;  set; }
        public AxisBindingInfo PitchAxisAlternate { get;  set; }
        public AxisBindingInfo LateralThrustAlternate { get;  set; }
        public AxisBindingInfo VerticalThrustAlternate { get;  set; }
        public ToggleBindingInfo UseAlternateFlightValuesToggle { get;  set; }
        public AxisBindingInfo ThrottleAxis { get;  set; }
        public ValueInfo ThrottleRange { get;  set; }
        public ToggleBindingInfo ToggleReverseThrottleInput { get;  set; }
        public StandardBindingInfo ForwardKey { get;  set; }
        public StandardBindingInfo BackwardKey { get;  set; }
        public ValueInfo ThrottleIncrement { get;  set; }
        public StandardBindingInfo SetSpeedMinus100 { get;  set; }
        public StandardBindingInfo SetSpeedMinus75 { get;  set; }
        public StandardBindingInfo SetSpeedMinus50 { get;  set; }
        public StandardBindingInfo SetSpeedMinus25 { get;  set; }
        public StandardBindingInfo SetSpeedZero { get;  set; }
        public StandardBindingInfo SetSpeed25 { get;  set; }
        public StandardBindingInfo SetSpeed50 { get;  set; }
        public StandardBindingInfo SetSpeed75 { get;  set; }
        public StandardBindingInfo SetSpeed100 { get;  set; }
        public AxisBindingInfo YawAxis_Landing { get;  set; }
        public StandardBindingInfo YawLeftButton_Landing { get;  set; }
        public StandardBindingInfo YawRightButton_Landing { get;  set; }
        public ValueInfo YawToRollMode_Landing { get;  set; }
        public AxisBindingInfo PitchAxis_Landing { get;  set; }
        public StandardBindingInfo PitchUpButton_Landing { get;  set; }
        public StandardBindingInfo PitchDownButton_Landing { get;  set; }
        public AxisBindingInfo RollAxis_Landing { get;  set; }
        public StandardBindingInfo RollLeftButton_Landing { get;  set; }
        public StandardBindingInfo RollRightButton_Landing { get;  set; }
        public AxisBindingInfo LateralThrust_Landing { get;  set; }
        public StandardBindingInfo LeftThrustButton_Landing { get;  set; }
        public StandardBindingInfo RightThrustButton_Landing { get;  set; }
        public AxisBindingInfo VerticalThrust_Landing { get;  set; }
        public StandardBindingInfo UpThrustButton_Landing { get;  set; }
        public StandardBindingInfo DownThrustButton_Landing { get;  set; }
        public AxisBindingInfo AheadThrust_Landing { get;  set; }
        public StandardBindingInfo ForwardThrustButton_Landing { get;  set; }
        public StandardBindingInfo BackwardThrustButton_Landing { get;  set; }
        public ToggleBindingInfo ToggleFlightAssist { get;  set; }
        public ValueInfo YawToRollMode_FAOff { get;  set; }
        public StandardBindingInfo UseBoostJuice { get;  set; }
        public StandardBindingInfo HyperSuperCombination { get;  set; }
        public StandardBindingInfo Supercruise { get;  set; }
        public StandardBindingInfo Hyperspace { get;  set; }
        public ToggleBindingInfo DisableRotationCorrectToggle { get;  set; }
        public StandardBindingInfo OrbitLinesToggle { get;  set; }
        public StandardBindingInfo SelectTarget { get;  set; }
        public StandardBindingInfo CycleNextTarget { get;  set; }
        public StandardBindingInfo CyclePreviousTarget { get;  set; }
        public StandardBindingInfo SelectHighestThreat { get;  set; }
        public StandardBindingInfo CycleNextHostileTarget { get;  set; }
        public StandardBindingInfo CyclePreviousHostileTarget { get;  set; }
        public StandardBindingInfo TargetWingman0 { get;  set; }
        public StandardBindingInfo TargetWingman1 { get;  set; }
        public StandardBindingInfo TargetWingman2 { get;  set; }
        public StandardBindingInfo SelectTargetsTarget { get;  set; }
        public StandardBindingInfo WingNavLock { get;  set; }
        public StandardBindingInfo CycleNextSubsystem { get;  set; }
        public StandardBindingInfo CyclePreviousSubsystem { get;  set; }
        public StandardBindingInfo TargetNextRouteSystem { get;  set; }
        public StandardBindingInfo PrimaryFire { get;  set; }
        public StandardBindingInfo SecondaryFire { get;  set; }
        public StandardBindingInfo CycleFireGroupNext { get;  set; }
        public StandardBindingInfo CycleFireGroupPrevious { get;  set; }
        public StandardBindingInfo DeployHardpointToggle { get;  set; }
        public ValueInfo DeployHardpointsOnFire { get;  set; }
        public ToggleBindingInfo ToggleButtonUpInput { get;  set; }
        public StandardBindingInfo DeployHeatSink { get;  set; }
        public StandardBindingInfo ShipSpotLightToggle { get;  set; }
        public AxisBindingInfo RadarRangeAxis { get;  set; }
        public StandardBindingInfo RadarIncreaseRange { get;  set; }
        public StandardBindingInfo RadarDecreaseRange { get;  set; }
        public StandardBindingInfo IncreaseEnginesPower { get;  set; }
        public StandardBindingInfo IncreaseWeaponsPower { get;  set; }
        public StandardBindingInfo IncreaseSystemsPower { get;  set; }
        public StandardBindingInfo ResetPowerDistribution { get;  set; }
        public StandardBindingInfo HMDReset { get;  set; }
        public ToggleBindingInfo ToggleCargoScoop { get;  set; }
        public StandardBindingInfo EjectAllCargo { get;  set; }
        public StandardBindingInfo LandingGearToggle { get;  set; }
        public ToggleBindingInfo MicrophoneMute { get;  set; }
        public ValueInfo MuteButtonMode { get;  set; }
        public ValueInfo CqcMuteButtonMode { get;  set; }
        public StandardBindingInfo UseShieldCell { get;  set; }
        public StandardBindingInfo FireChaffLauncher { get;  set; }
        public ValueInfo EnableMenuGroups { get;  set; }
        public StandardBindingInfo NightVisionToggle { get; set; }
        public StandardBindingInfo UIFocus { get;  set; }
        public ValueInfo UIFocusMode { get;  set; }
        public StandardBindingInfo FocusLeftPanel { get;  set; }
        public StandardBindingInfo FocusCommsPanel { get;  set; }
        public ValueInfo FocusOnTextEntryField { get;  set; }
        public StandardBindingInfo QuickCommsPanel { get;  set; }
        public StandardBindingInfo FocusRadarPanel { get;  set; }
        public StandardBindingInfo FocusRightPanel { get;  set; }
        public ValueInfo LeftPanelFocusOptions { get;  set; }
        public ValueInfo CommsPanelFocusOptions { get;  set; }
        public ValueInfo RolePanelFocusOptions { get;  set; }
        public ValueInfo RightPanelFocusOptions { get;  set; }
        public StandardBindingInfo GalaxyMapOpen { get;  set; }
        public StandardBindingInfo SystemMapOpen { get;  set; }
        public ToggleBindingInfo ShowPGScoreSummaryInput { get;  set; }
        public ToggleBindingInfo HeadLookToggle { get;  set; }
        public StandardBindingInfo Pause { get;  set; }
        public StandardBindingInfo PlayerHUDModeToggle { get; set; }
        public StandardBindingInfo ExplorationFSSEnter { get; set; }

        public ValueInfo MouseHeadlook { get;  set; }
        public ValueInfo MouseHeadlookInvert { get;  set; }
        public ValueInfo MouseHeadlookSensitivity { get;  set; }
        public ValueInfo HeadlookDefault { get;  set; }
        public ValueInfo HeadlookIncrement { get;  set; }
        public ValueInfo HeadlookMode { get;  set; }
        public ValueInfo HeadlookResetOnToggle { get;  set; }
        public ValueInfo HeadlookSensitivity { get;  set; }
        public StandardBindingInfo HeadLookReset { get;  set; }
        public StandardBindingInfo HeadLookPitchUp { get;  set; }
        public StandardBindingInfo HeadLookPitchDown { get;  set; }
        public AxisBindingInfo HeadLookPitchAxisRaw { get;  set; }
        public StandardBindingInfo HeadLookYawLeft { get;  set; }
        public StandardBindingInfo HeadLookYawRight { get;  set; }
        public AxisBindingInfo HeadLookYawAxis { get;  set; }

        public StandardBindingInfo ExplorationFSSQuit { get; set; }

        public StandardBindingInfo OrderFocusTarget { get; set; }
        public StandardBindingInfo OrderAggressiveBehaviour { get; set; }
        public StandardBindingInfo OrderDefensiveBehaviour { get; set; }
        public StandardBindingInfo OpenOrders { get; set; }
        public StandardBindingInfo OrderRequestDock { get; set; }
        public StandardBindingInfo OrderFollow { get; set; }
        public StandardBindingInfo OrderHoldFire { get; set; }
        public StandardBindingInfo OrderHoldPosition { get; set; }
        public StandardBindingInfo OpenCodexGoToDiscovery { get; set; }
        public StandardBindingInfo FriendsMenu { get; set; }
        public StandardBindingInfo OculusReset { get; set; }
        public StandardBindingInfo MultiCrewThirdPersonFovInButton { get; set; }
        public StandardBindingInfo MultiCrewThirdPersonFovOutButton { get; set; }
        public StandardBindingInfo MultiCrewPrimaryFire { get; set; }
        public StandardBindingInfo MultiCrewSecondaryFire { get; set; }
        public StandardBindingInfo MultiCrewToggleMode { get; set; }
        public StandardBindingInfo MultiCrewThirdPersonPitchDownButton { get; set; }
        public StandardBindingInfo MultiCrewThirdPersonPitchUpButton { get; set; }
        public StandardBindingInfo MultiCrewPrimaryUtilityFire { get; set; }
        public StandardBindingInfo MultiCrewSecondaryUtilityFire { get; set; }
        public StandardBindingInfo MultiCrewCockpitUICycleBackward { get; set; }
        public StandardBindingInfo MultiCrewCockpitUICycleForward { get; set; }
        public StandardBindingInfo MultiCrewThirdPersonYawLeftButton { get; set; }
        public StandardBindingInfo MultiCrewThirdPersonYawRightButton { get; set; }
        public StandardBindingInfo SAAThirdPersonFovInButton { get; set; }
        public StandardBindingInfo SAAThirdPersonFovOutButton { get; set; }
        public StandardBindingInfo ExplorationSAAExitThirdPerson { get; set; }
        public StandardBindingInfo ExplorationSAANextGenus { get; set; }
        public StandardBindingInfo ExplorationSAAPreviousGenus { get; set; }
        public StandardBindingInfo ExplorationFSSShowHelp { get; set; }
        public StandardBindingInfo ExplorationFSSDiscoveryScan { get; set; }
        public StandardBindingInfo ExplorationFSSCameraPitchDecreaseButton { get; set; }
        public StandardBindingInfo ExplorationFSSCameraPitchIncreaseButton { get; set; }
        public StandardBindingInfo ExplorationFSSRadioTuningX_Decrease { get; set; }
        public StandardBindingInfo ExplorationFSSRadioTuningX_Increase { get; set; }
        public StandardBindingInfo ExplorationFSSCameraYawDecreaseButton { get; set; }
        public StandardBindingInfo ExplorationFSSCameraYawIncreaseButton { get; set; }
        public StandardBindingInfo SAAThirdPersonPitchDownButton { get; set; }
        public StandardBindingInfo SAAThirdPersonPitchUpButton { get; set; }
        public StandardBindingInfo ExplorationFSSMiniZoomIn { get; set; }
        public StandardBindingInfo ExplorationFSSMiniZoomOut { get; set; }
        public StandardBindingInfo ExplorationFSSTarget { get; set; }
        public ToggleBindingInfo ExplorationSAAChangeScannedAreaViewToggle { get; set; }
        public StandardBindingInfo SAAThirdPersonYawLeftButton { get; set; }
        public StandardBindingInfo SAAThirdPersonYawRightButton { get; set; }
        public StandardBindingInfo ExplorationFSSZoomIn { get; set; }
        public StandardBindingInfo ExplorationFSSZoomOut { get; set; }
        public StandardBindingInfo ChargeECM { get; set; }
        public StandardBindingInfo EngineColourToggle { get; set; }
        public StandardBindingInfo WeaponColourToggle { get; set; }


        // general

        public StandardBindingInfo CycleNextPanel { get; set; }
        public StandardBindingInfo CyclePreviousPanel { get; set; }
        public StandardBindingInfo CycleNextPage { get; set; }
        public StandardBindingInfo CyclePreviousPage { get; set; }

        public StandardBindingInfo UI_Up { get; set; }
        public StandardBindingInfo UI_Down { get; set; }
        public StandardBindingInfo UI_Left { get; set; }
        public StandardBindingInfo UI_Right { get; set; }
        public StandardBindingInfo UI_Select { get; set; }
        public StandardBindingInfo UI_Back { get; set; }
        public StandardBindingInfo UI_Toggle { get; set; }

        public AxisBindingInfo CamPitchAxis { get; set; }
        public StandardBindingInfo CamPitchUp { get; set; }
        public StandardBindingInfo CamPitchDown { get; set; }
        public AxisBindingInfo CamYawAxis { get; set; }
        public StandardBindingInfo CamYawLeft { get; set; }
        public StandardBindingInfo CamYawRight { get; set; }
        public AxisBindingInfo CamTranslateYAxis { get; set; }
        public StandardBindingInfo CamTranslateForward { get; set; }
        public StandardBindingInfo CamTranslateBackward { get; set; }
        public AxisBindingInfo CamTranslateXAxis { get; set; }
        public StandardBindingInfo CamTranslateLeft { get; set; }
        public StandardBindingInfo CamTranslateRight { get; set; }
        public AxisBindingInfo CamTranslateZAxis { get; set; }
        public StandardBindingInfo CamTranslateUp { get; set; }
        public StandardBindingInfo CamTranslateDown { get; set; }
        public AxisBindingInfo CamZoomAxis { get; set; }
        public StandardBindingInfo CamZoomIn { get; set; }
        public StandardBindingInfo CamZoomOut { get; set; }
        public ToggleBindingInfo CamTranslateZHold { get; set; }

        public StandardBindingInfo MoveFreeCamBackwards { get; set; }
        public StandardBindingInfo MoveFreeCamDown { get; set; }
        public StandardBindingInfo MoveFreeCamForward { get; set; }
        public StandardBindingInfo MoveFreeCamLeft { get; set; }
        public ToggleBindingInfo ToggleReverseThrottleInputFreeCam { get; set; }
        public StandardBindingInfo MoveFreeCamRight { get; set; }
        public StandardBindingInfo MoveFreeCamUp { get; set; }
        public StandardBindingInfo FreeCamSpeedDec { get; set; }
        public StandardBindingInfo ToggleFreeCam { get; set; }
        public StandardBindingInfo FreeCamSpeedInc { get; set; }
        public StandardBindingInfo FreeCamToggleHUD { get; set; }
        public StandardBindingInfo FreeCamZoomIn { get; set; }
        public StandardBindingInfo FreeCamZoomOut { get; set; }

        public StandardBindingInfo PhotoCameraToggle { get; set; }
        public ValueInfo EnableCameraLockOn { get; set; }
        public StandardBindingInfo StorePitchCameraDown { get; set; }
        public StandardBindingInfo StorePitchCameraUp { get; set; }
        public StandardBindingInfo StoreEnableRotation { get; set; }
        public StandardBindingInfo StoreYawCameraLeft { get; set; }
        public StandardBindingInfo StoreYawCameraRight { get; set; }
        public StandardBindingInfo StoreCamZoomIn { get; set; }
        public StandardBindingInfo StoreCamZoomOut { get; set; }
        public StandardBindingInfo StoreToggle { get; set; }
        public StandardBindingInfo ToggleAdvanceMode { get; set; }
        public StandardBindingInfo VanityCameraEight { get; set; }
        public StandardBindingInfo VanityCameraTwo { get; set; }
        public StandardBindingInfo VanityCameraOne { get; set; }
        public StandardBindingInfo VanityCameraThree { get; set; }
        public StandardBindingInfo VanityCameraFour { get; set; }
        public StandardBindingInfo VanityCameraFive { get; set; }
        public StandardBindingInfo VanityCameraSix { get; set; }
        public StandardBindingInfo VanityCameraSeven { get; set; }
        public StandardBindingInfo VanityCameraNine { get; set; }
        public StandardBindingInfo PitchCameraDown { get; set; }
        public StandardBindingInfo PitchCameraUp { get; set; }
        public StandardBindingInfo RollCameraLeft { get; set; }
        public StandardBindingInfo RollCameraRight { get; set; }
        public StandardBindingInfo ToggleRotationLock { get; set; }

        public StandardBindingInfo YawCameraLeft { get; set; }
        public StandardBindingInfo YawCameraRight { get; set; }
        public StandardBindingInfo FStopDec { get; set; }
        public StandardBindingInfo QuitCamera { get; set; }
        public StandardBindingInfo FocusDistanceInc { get; set; }
        public StandardBindingInfo FocusDistanceDec { get; set; }
        public StandardBindingInfo FStopInc { get; set; }
        public StandardBindingInfo FixCameraRelativeToggle { get; set; }
        public StandardBindingInfo FixCameraWorldToggle { get; set; }
        public StandardBindingInfo VanityCameraScrollRight { get; set; }
        public StandardBindingInfo VanityCameraScrollLeft { get; set; }

        public StandardBindingInfo CommanderCreator_Redo { get; set; }
        public StandardBindingInfo CommanderCreator_Rotation { get; set; }
        public StandardBindingInfo CommanderCreator_Rotation_MouseToggle { get; set; }
        public StandardBindingInfo CommanderCreator_Undo { get; set; }

        public StandardBindingInfo GalnetAudio_ClearQueue { get; set; }
        public StandardBindingInfo GalnetAudio_SkipForward { get; set; }
        public StandardBindingInfo GalnetAudio_Play_Pause { get; set; }
        public StandardBindingInfo GalnetAudio_SkipBackward { get; set; }

        // srv

        public ToggleBindingInfo ToggleDriveAssist { get; set; }
        public AxisBindingInfo SteeringAxis { get; set; }
        public StandardBindingInfo SteerLeftButton { get; set; }
        public StandardBindingInfo SteerRightButton { get; set; }
        public ValueInfo DriveAssistDefault { get; set; }
        public ValueInfo MouseTurretXMode { get; set; }
        public ValueInfo MouseTurretXDecay { get; set; }
        public ValueInfo MouseTurretYMode { get; set; }
        public ValueInfo MouseTurretYDecay { get; set; }
        public StandardBindingInfo IncreaseSpeedButtonMax { get; set; }
        public StandardBindingInfo DecreaseSpeedButtonMax { get; set; }
        public StandardBindingInfo DecreaseSpeedButtonPartial { get; set; }
        public StandardBindingInfo IncreaseSpeedButtonPartial { get; set; }
        public AxisBindingInfo IncreaseSpeedButton { get; set; }
        public AxisBindingInfo DecreaseSpeedButton { get; set; }
        public StandardBindingInfo RecallDismissShip { get; set; }
        public ToggleBindingInfo VerticalThrustersButton { get; set; }

        public ToggleBindingInfo PhotoCameraToggle_Buggy { get; set; }
        public ValueInfo MouseBuggySteeringXMode { get; set; }
        public ValueInfo MouseBuggySteeringXDecay { get; set; }
        public ValueInfo MouseBuggyRollingXMode { get; set; }
        public ValueInfo MouseBuggyRollingXDecay { get; set; }
        public ValueInfo MouseBuggyYMode { get; set; }
        public ValueInfo MouseBuggyYDecay { get; set; }
        public AxisBindingInfo BuggyRollAxisRaw { get; set; }
        public StandardBindingInfo BuggyRollLeftButton { get; set; }
        public StandardBindingInfo BuggyRollRightButton { get; set; }
        public AxisBindingInfo BuggyPitchAxis { get; set; }
        public StandardBindingInfo BuggyPitchUpButton { get; set; }
        public StandardBindingInfo BuggyPitchDownButton { get; set; }
        public StandardBindingInfo BuggyPrimaryFireButton { get; set; }
        public StandardBindingInfo BuggySecondaryFireButton { get; set; }
        public ToggleBindingInfo AutoBreakBuggyButton { get; set; }
        public StandardBindingInfo HeadlightsBuggyButton { get; set; }
        public StandardBindingInfo ToggleBuggyTurretButton { get; set; }
        public StandardBindingInfo SelectTargetBuggy { get; set; }
        public AxisBindingInfo BuggyTurretYawAxisRaw { get; set; }
        public StandardBindingInfo BuggyTurretYawLeftButton { get; set; }
        public StandardBindingInfo BuggyTurretYawRightButton { get; set; }
        public AxisBindingInfo BuggyTurretPitchAxisRaw { get; set; }
        public StandardBindingInfo BuggyTurretPitchUpButton { get; set; }
        public StandardBindingInfo BuggyTurretPitchDownButton { get; set; }
        public AxisBindingInfo DriveSpeedAxis { get; set; }
        public ValueInfo BuggyThrottleRange { get; set; }
        public ToggleBindingInfo BuggyToggleReverseThrottleInput { get; set; }
        public ValueInfo BuggyThrottleIncrement { get; set; }
        public StandardBindingInfo IncreaseEnginesPower_Buggy { get; set; }
        public StandardBindingInfo IncreaseWeaponsPower_Buggy { get; set; }
        public StandardBindingInfo IncreaseSystemsPower_Buggy { get; set; }
        public StandardBindingInfo ResetPowerDistribution_Buggy { get; set; }
        public ToggleBindingInfo ToggleCargoScoop_Buggy { get; set; }
        public StandardBindingInfo EjectAllCargo_Buggy { get; set; }
        public StandardBindingInfo UIFocus_Buggy { get; set; }
        public StandardBindingInfo FocusLeftPanel_Buggy { get; set; }
        public StandardBindingInfo FocusCommsPanel_Buggy { get; set; }
        public StandardBindingInfo QuickCommsPanel_Buggy { get; set; }
        public StandardBindingInfo FocusRadarPanel_Buggy { get; set; }
        public StandardBindingInfo FocusRightPanel_Buggy { get; set; }
        public StandardBindingInfo GalaxyMapOpen_Buggy { get; set; }
        public StandardBindingInfo SystemMapOpen_Buggy { get; set; }
        public ToggleBindingInfo HeadLookToggle_Buggy { get; set; }
        public StandardBindingInfo SelectTarget_Buggy { get; set; }
        public StandardBindingInfo BuggyRollLeft { get; set; }
        public StandardBindingInfo BuggyRollRight { get; set; }

        // On Foot

        public ToggleBindingInfo PhotoCameraToggle_Humanoid { get; set; }

        public StandardBindingInfo HumanoidForwardButton { get; set; }
        public StandardBindingInfo HumanoidBackwardButton { get; set; }
        public StandardBindingInfo HumanoidStrafeLeftButton { get; set; }
        public StandardBindingInfo HumanoidStrafeRightButton { get; set; }
        public StandardBindingInfo HumanoidSprintButton { get; set; }
        public StandardBindingInfo HumanoidCrouchButton { get; set; }
        public StandardBindingInfo HumanoidJumpButton { get; set; }
        public StandardBindingInfo HumanoidPrimaryInteractButton { get; set; }
        public StandardBindingInfo HumanoidSecondaryInteractButton { get; set; }
        public StandardBindingInfo HumanoidItemWheelButton { get; set; }
        public StandardBindingInfo HumanoidPrimaryFireButton { get; set; }
        public StandardBindingInfo HumanoidZoomButton { get; set; }
        public StandardBindingInfo HumanoidThrowGrenadeButton { get; set; }
        public StandardBindingInfo HumanoidMeleeButton { get; set; }
        public StandardBindingInfo HumanoidReloadButton { get; set; }
        public StandardBindingInfo HumanoidSelectPrimaryWeaponButton { get; set; }
        public StandardBindingInfo HumanoidSelectSecondaryWeaponButton { get; set; }
        public StandardBindingInfo HumanoidHideWeaponButton { get; set; }
        public StandardBindingInfo HumanoidToggleFlashlightButton { get; set; }
        public StandardBindingInfo HumanoidToggleNightVisionButton { get; set; }
        public StandardBindingInfo HumanoidToggleShieldsButton { get; set; }
        public StandardBindingInfo HumanoidSwitchToRechargeTool { get; set; }
        public StandardBindingInfo HumanoidSwitchToCompAnalyser { get; set; }
        public StandardBindingInfo HumanoidSwitchToSuitTool { get; set; }
        public StandardBindingInfo HumanoidToggleToolModeButton { get; set; }
        public StandardBindingInfo HumanoidToggleMissionHelpPanelButton { get; set; }
        public StandardBindingInfo GalaxyMapOpen_Humanoid { get; set; }
        public StandardBindingInfo SystemMapOpen_Humanoid { get; set; }
        public StandardBindingInfo FocusCommsPanel_Humanoid { get; set; }
        public StandardBindingInfo QuickCommsPanel_Humanoid { get; set; }
        public StandardBindingInfo HumanoidOpenAccessPanelButton { get; set; }
        public StandardBindingInfo HumanoidConflictContextualUIButton { get; set; }

        public StandardBindingInfo HumanoidRotateLeftButton { get; set; }
        public StandardBindingInfo HumanoidRotateRightButton { get; set; }
        public StandardBindingInfo HumanoidPitchUpButton { get; set; }
        public StandardBindingInfo HumanoidPitchDownButton { get; set; }
        public StandardBindingInfo HumanoidSwitchWeapon { get; set; }
        public StandardBindingInfo HumanoidSelectUtilityWeaponButton { get; set; }
        public StandardBindingInfo HumanoidSelectNextWeaponButton { get; set; }
        public StandardBindingInfo HumanoidSelectPreviousWeaponButton { get; set; }
        public StandardBindingInfo HumanoidSelectNextGrenadeTypeButton { get; set; }
        public StandardBindingInfo HumanoidSelectPreviousGrenadeTypeButton { get; set; }

        public StandardBindingInfo HumanoidClearAuthorityLevel { get; set; }
        public StandardBindingInfo HumanoidHealthPack { get; set; }
        public StandardBindingInfo HumanoidBattery { get; set; }
        public StandardBindingInfo HumanoidSelectFragGrenade { get; set; }
        public StandardBindingInfo HumanoidSelectEMPGrenade { get; set; }
        public StandardBindingInfo HumanoidSelectShieldGrenade { get; set; }

    }

    public  class AxisBindingInfo
    {
        public Binding Binding { get;  set; }
        public ValueInfo Inverted { get;  set; }
        public ValueInfo Deadzone { get;  set; }
    }

    public  class Binding
    {
        [XmlAttribute]
        public string Device { get;  set; }
        [XmlAttribute]
        public string Key { get;  set; }
    }

    public  class ValueInfo
    {
        [XmlAttribute]
        public string Value { get;  set; }
    }


    public  class StandardBindingInfo
    {
        public PrimaryInfo Primary { get;  set; }
        public SecondaryInfo Secondary { get;  set; }
    }

    public  class ToggleBindingInfo : StandardBindingInfo
    {
        public ValueInfo ToggleOn { get;  set; }
    }


    public  class PrimaryInfo
    {
        [XmlAttribute]
        public string Device { get;  set; }
        [XmlAttribute]
        public string Key { get;  set; }
        [XmlElement("Modifier")]
        public List<Binding> Modifier { get; set; }
    }

    public  class SecondaryInfo
    {
        [XmlAttribute]
        public string Device { get;  set; }
        [XmlAttribute]
        public string Key { get;  set; }
        [XmlElement("Modifier")]
        public List<Binding> Modifier { get;  set; }
    }

}
