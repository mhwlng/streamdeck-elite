using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteJournalReader
{
    public enum SoldierRank
    {
        Defenceless = 0,
        [Description("Mostly Defenceless")] MostlyDefenceless,
        Rookie,
        Soldier,
        Gunslinger,
        Warrior,
        Gladiator,
        Deadeye,
        Elite
    }

    public enum ExobiologistRank
    {
        Directionless = 0,
        [Description("Mostly Directionless")] MostlyDirectionless,
        Compiler,
        Collector,
        Cataloguer,
        Taxonomist,
        Ecologist,
        Geneticist,
        Elite
    }

    public enum CombatRank
    {
        Harmless = 0,
        [Description("Mostly Harmless")] MostlyHarmless,
        Novice,
        Competent,
        Expert,
        Master,
        Dangerous,
        Deadly,
        Elite
    }

    public enum TradeRank
    {
        Penniless = 0,
        [Description("Mostly Penniless")] MostlyPenniless,
        Peddler,
        Dealer,
        Merchant,
        Broker,
        Entrepreneur,
        Tycoon,
        Elite
    }

    public enum ExplorationRank
    {
        Aimless = 0,
        [Description("Mostly Aimless")] MostlyAimless,
        Scout,
        Surveyor,
        Explorer,
        Pathfinder,
        Ranger,
        Pioneer,
        Elite
    }

    public enum FederationRank
    {
        None = 0,
        Recruit,
        Cadet,
        Midshipman,
        PettyOfficer,
        ChiefPettyOfficer,
        WarrantOfficer,
        Ensign,
        Lieutenant,
        LtCommander,
        PostCommander,
        PostCaptain,
        RearAdmiral,
        ViceAdmiral,
        Admiral
    }

    public enum EmpireRank
    {
        None = 0,
        Outsider,
        Serf,
        Master,
        Squire,
        Knight,
        Lord,
        Baron,
        Viscount,
        Count,
        Earl,
        Marquis,
        Duke,
        Prince,
        King
    }

    public enum CQCRank
    {
        Helpless = 0,
        MostlyHelpless,
        Amateur,
        SemiProfessional,
        Professional,
        Champion,
        Hero,
        Legend,
        Elite
    }
}
