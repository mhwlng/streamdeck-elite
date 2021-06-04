using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteJournalReader
{

    public enum ScanType
    {
        Unknown,
        Basic,
        Detailed,
        AutoScan,
        NavBeacon,
        NavBeaconDetail
    }

    public enum StarType
    {
        Unknown,

        // main sequence
        O,
        B,
        A,
        F,
        G,
        K,
        M,
        L,
        T,
        Y,

        // proto stars
        TTS,
        AeBe,

        // wolf-rayet
        W,
        WN,
        WNC,
        WC,
        WO,

        // carbon stars
        CS,
        C,
        CN,
        CJ,
        CH,
        CHd,

        MS,
        S,

        // white drafs
        D,
        DA,
        DAB,
        DAO,
        DAZ,
        DAV,
        DB,
        DBZ,
        DBV,
        DO,
        DOV,
        DQ,
        DC,
        DCV,
        DX,

        // neutron
        N,

        // black hole
        H,

        // exotic
        X,

        // other
        SupermassiveBlackHole,
        A_BlueWhiteSuperGiant,
        F_WhiteSuperGiant,
        M_RedSuperGiant,
        M_RedGiant,
        K_OrangeGiant,
        RoguePlanet,
        Nebula,
        StellarRemnantNebula
    }

    public enum StarLuminosity
    {
        None,
        I,
        Ia0,
        Ia,
        Ib,
        Iab,
        II,
        IIa,
        IIab,
        IIb,
        III,
        IIIa,
        IIIab,
        IIIb,
        IV,
        IVa,
        IVab,
        IVb,
        V,
        Va,
        Vab,
        Vb,
        Vz,
        VI,
        VII
    }


    public enum PlanetClass
    {
        Unknown,

        [Description("Metal rich body")]
        MetalRichBody,

        [Description("High metal content body")]
        HighMetalContentBody,

        [Description("Rocky body")]
        RockyBody,

        [Description("Icy body")]
        IcyBody,

        [Description("Rocky ice body")]
        RockyIceBody,

        [Description("Earthlike body")]
        EarthlikeBody,

        [Description("Water world")]
        WaterWorld,

        [Description("Ammonia world")]
        AmmoniaWorld,

        [Description("Water giant")]
        WaterGiant,

        [Description("Water giant with life")]
        WaterGiantWithLife,

        [Description("Gas giant with water based life")]
        GasGiantWithWaterBasedLife,

        [Description("Gas giant with ammonia based life")]
        GasGiantWithAmmoniaBasedLife,

        [Description("Sudarsky class I gas giant")]
        SudarskyClassIGasGiant,

        [Description("Sudarsky class II gas giant")]
        SudarskyClassIIGasGiant,

        [Description("Sudarsky class III gas giant")]
        SudarskyClassIIIGasGiant,

        [Description("Sudarsky class IV gas giant")]
        SudarskyClassIVGasGiant,

        [Description("Sudarsky class V gas giant")]
        SudarskyClassVGasGiant,

        [Description("Helium rich gas giant")]
        HeliumRichGasGiant,

        [Description("Helium gas giant")]
        HeliumGasGiant
    }

    public enum AtmosphereClass
    {
        Unknown,

        None,

        [Description("No atmosphere")]
        NoAtmosphere,

        [Description("Suitable for water-based life")]
        SuitableForWaterBasedLife,

        [Description("Ammonia and oxygen")]
        AmmoniaAndOxygen,

        Ammonia,

        Water,

        [Description("Carbon dioxide")]
        CarbonDioxide,

        [Description("Sulphur dioxide")]
        SulphurDioxide,

        Nitrogen,

        [Description("Water-rich")]
        WaterRich,

        [Description("Methane-rich")]
        MethaneRich,

        [Description("Ammonia-rich")]
        AmmoniaRich,

        [Description("Carbon dioxide-rich")]
        CarbonDioxideRich,

        Methane,

        Helium,

        [Description("Silicate vapour")]
        SilicateVapour,

        [Description("Metallic vapour")]
        MetallicVapour,

        [Description("Neon-rich")]
        NeonRich,

        [Description("Argon-rich")]
        ArgonRich,

        Neon,

        Argon,

        Oxygen
    }

    public enum OrganicScanType
    {
        Log,
        Sample,
        Analyse
    }

    public enum BodyType
    {
        Unknown,
        Null,
        Star,
        Planet,
        PlanetaryRing,
        StellarRing,
        Station,
        AsteroidCluster
    }

    public enum GameMode
    {
        Unknown,
        Open,
        Solo,
        Group,
        Console
    }

    public enum PowerplayState
    {
        Unknown,
        InPrepareRadius,
        Prepared,
        Exploited,
        Contested,
        Controlled,
        Turmoil,
        HomeSystem
    }

    public enum TerraformState
    {
        Unknown,
        None,
        Terraformable,
        Terraforming,
        Terraformed
    }

    public enum ReserveLevel
    {
        Unknown,

        [Description("DepletedResources")]
        Depleted,

        [Description("LowResources")]
        Low,

        [Description("CommonResources")]
        Common,

        [Description("MajorResources")]
        Major,

        [Description("PristineResources")]
        Pristine
    }

    public enum InfluenceLevel
    {
        Unknown,
        None,
        Low,
        Med,
        High
    }

    public enum ReputationLevel
    {
        Unknown,
        None,
        Low,
        Med,
        High
    }

    public enum JumpType
    {
        Unknown,
        Hyperspace,
        Supercruise
    }

    public enum TextChannel
    {
        Unknown,
        NPC,
        Local,
        StarSystem,
        Player,
        Wing,
        Squadron,
        Friend,
        VoiceChat
    }

    public enum DockingDeniedReason
    {
        Unknown,
        NoSpace,
        TooLarge,
        Hostile,
        Offences,
        Distance,
        ActiveFighter,
        NoReason
    }

    public enum ModuleAttribute
    {
        Size,
        Class,
        Mass,
        Integrity,
        PowerDraw,
        BootTime,
        ShieldBankSpinUp,
        ShieldBankDuration,
        ShieldBankReinforcement,
        ShieldBankHeat,
        DamageFalloffRange,
        DamagePerSecond,
        Damage,
        DistributorDraw,
        ThermalLoad,
        ArmourPenetration,
        MaximumRange,
        ShotSpeed,
        RateOfFire,
        BurstRateOfFire,
        BurstSize,
        AmmoClipSize,
        AmmoMaximum,
        RoundsPerShot,
        ReloadTime,
        BreachDamage,
        MinBreachChance,
        MaxBreachChance,
        Jitter,
        WeaponMode,
        DamageType,
        ShieldGenMinimumMass,
        ShieldGenOptimalMass,
        ShieldGenMaximumMass,
        ShieldGenMinStrength,
        ShieldGenStrength,
        ShieldGenMaxStrength,
        RegenRate,
        BrokenRegenRate,
        EnergyPerRegen,
        FSDOptimalMass,
        FSDHeatRate,
        MaxFuelPerJump,
        EngineMinimumMass,
        EngineOptimalMass,
        MaximumMass,
        EngineMinPerformance,
        EngineOptPerformance,
        EngineMaxPerformance,
        EngineHeatRate,
        PowerCapacity,
        HeatEfficiency,
        WeaponsCapacity,
        WeaponsRecharge,
        EnginesCapacity,
        EnginesRecharge,
        SystemsCapacity,
        SystemsRecharge,
        DefenceModifierHealthMultiplier,
        DefenceModifierHealthAddition,
        DefenceModifierShieldMultiplier,
        DefenceModifierShieldAddition,
        KineticResistance,
        ThermicResistance,
        ExplosiveResistance,
        CausticResistance,
        FSDInterdictorRange,
        FSDInterdictorFacingLimit,
        ScannerRange,
        DiscoveryScannerRange,
        DiscoveryScannerPassiveRange,
        MaxAngle,
        ScannerTimeToScan,
        ChaffJamDuration,
        ECMRange,
        ECMTimeToCharge,
        ECMActivePowerConsumption,
        ECMHeat,
        ECMCooldown,
        HeatSinkDuration,
        ThermalDrain,
        NumBuggySlots,
        CargoCapacity,
        MaxActiveDrones,
        DroneTargetRange,
        DroneLifeTime,
        DroneSpeed,
        DroneMultiTargetSpeed,
        DroneFuelCapacity,
        DroneRepairCapacity,
        DroneHackingTime,
        DroneMinJettisonedCargo,
        DroneMaxJettisonedCargo,
        FuelScoopRate,
        FuelCapacity,
        OxygenTimeCapacity,
        RefineryBins,
        AFMRepairCapacity,
        AFMRepairConsumption,
        AFMRepairPerAmmo,
        MaxRange,
        SensorTargetScanAngle,
        Range,
        VehicleCargoCapacity,
        VehicleHullMass,
        VehicleFuelCapacity,
        VehicleArmourHealth,
        VehicleShieldHealth,
        FighterMaxSpeed,
        FighterBoostSpeed,
        FighterPitchRate,
        FighterDPS,
        FighterYawRate,
        FighterRollRate,
        CabinCapacity,
        CabinClass,
        DisruptionBarrierRange,
        DisruptionBarrierChargeDuration,
        DisruptionBarrierActivePower,
        DisruptionBarrierCooldown,
        WingDamageReduction,
        WingMinDuration,
        WingMaxDuration,
        ShieldSacrificeAmountRemoved,
        ShieldSacrificeAmountGiven,
        FSDJumpRangeBoost,
        FSDFuelUseIncrease,
        BoostSpeedMultiplier,
        BoostAugmenterPowerUse,
        ModuleDefenceAbsorption,
        FalloffRange,
        DSS_RangeMult,
        DSS_AngleMult,
        DSS_RateMult,
        DSS_PatchRadius
    }

    public enum ReputationStatus
    {
        Hostile = -2,
        Unfriendly = -1,
        Neutral = 0,
        Cordial = 1,
        Friendly = 2,
        Allied = 3
    }

    public enum FriendStatus
    {
        Unknown,
        Requested,
        Declined,
        Added,
        Lost,
        Offline,
        Online
    }

    public enum DroneType
    {
        Unknown,
        Hatchbreaker,
        FuelTransfer,
        Collection,
        Prospector,
        Repair,
        Research,
        Decontamination
    }
}
