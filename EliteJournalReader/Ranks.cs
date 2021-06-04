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
        Elite,
        [Description("Elite I")] Elite1,
        [Description("Elite II")] Elite2,
        [Description("Elite III")] Elite3,
        [Description("Elite IV")] Elite4,
        [Description("Elite V")] Elite5
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
        Elite,
        [Description("Elite I")] Elite1,
        [Description("Elite II")] Elite2,
        [Description("Elite III")] Elite3,
        [Description("Elite IV")] Elite4,
        [Description("Elite V")] Elite5
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
        Elite,
        [Description("Elite I")] Elite1,
        [Description("Elite II")] Elite2,
        [Description("Elite III")] Elite3,
        [Description("Elite IV")] Elite4,
        [Description("Elite V")] Elite5
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
        Elite,
        [Description("Elite I")] Elite1,
        [Description("Elite II")] Elite2,
        [Description("Elite III")] Elite3,
        [Description("Elite IV")] Elite4,
        [Description("Elite V")] Elite5
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
        Elite,
        [Description("Elite I")] Elite1,
        [Description("Elite II")] Elite2,
        [Description("Elite III")] Elite3,
        [Description("Elite IV")] Elite4,
        [Description("Elite V")] Elite5
    }

    public enum FederationRank
    {
        None = 0,
        Recruit,
        Cadet,
        Midshipman,
        [Description("Petty Officer")] PettyOfficer,
        [Description("Chief Petty Officer")] ChiefPettyOfficer,
        [Description("Warrant Officer")] WarrantOfficer,
        Ensign,
        Lieutenant,
        LtCommander,
        [Description("Post Commander")] PostCommander,
        [Description("Post Captain")] PostCaptain,
        [Description("Rear Admiral")] RearAdmiral,
        [Description("Vice Admiral")] ViceAdmiral,
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
        [Description("Mostly Helpless")] MostlyHelpless,
        Amateur,
        [Description("Semi Professional")] SemiProfessional,
        Professional,
        Champion,
        Hero,
        Legend,
        Elite,
        [Description("Elite I")] Elite1,
        [Description("Elite II")] Elite2,
        [Description("Elite III")] Elite3,
        [Description("Elite IV")] Elite4,
        [Description("Elite V")] Elite5
    }
}
