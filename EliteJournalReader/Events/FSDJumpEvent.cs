using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteJournalReader.Events
{
    //When written: when jumping from one star system to another
    //Parameters:
    //	StarSystem: name of destination starsystem
    //	StarPos: star position, as a Json array [x, y, z], in light years
    //	Body: star's body name
    //	JumpDist: distance jumped
    //	FuelUsed
    //	FuelLevel
    //	BoostUsed: whether FSD boost was used
    //	SystemFaction: system controlling faction
    //    o Name
    //    o FactionState
    //	SystemAllegiance
    //	SystemEconomy
    //	SystemSecondEconomy
    //	SystemGovernment
    //	SystemSecurity
    //	Population
    //	Wanted
    //	Factions: an array of info for the local minor factions
    //    o Name
    //    o FactionState
    //    o Government
    //    o Influence
    //    o Happiness
    //    o MyReputation
    //    o PendingStates: array(if any) with State name and Trend value
    //    o RecovingStates: array(if any)with State name and Trend value
    //    o ActiveStates: array with State names (Note active states do not have a Trend value)
    //    o SquadronFaction:true (if player is in squadron aligned to this faction)
    //    o HappiestSystem:true (if player squadron faction, and this is happiest system)
    //    o HomeSystem:true(if player squadron faction, and this is home system)
    //	Conflicts: an array of info about local conflicts(if any)
    //    o WarType
    //    o Status
    //    o Faction1: { Name, Stake, WonDays }
    //    o Faction2: { Name, Stake, WonDays }
    //If the player is pledged to a Power in Powerplay, and the star system is involved in powerplay,
    //	Powers: a json array with the names of any powers contesting the system, or the name of the controlling power
    //	PowerplayState: the system state - one of("InPrepareRadius", "Prepared", "Exploited", "Contested", "Controlled", "Turmoil", "HomeSystem")
    public class FSDJumpEvent : JournalEvent<FSDJumpEvent.FSDJumpEventArgs>
    {
        public FSDJumpEvent() : base("FSDJump") { }

        public class FSDJumpEventArgs : JournalEventArgs
        {
            public bool Taxi { get; set; }
            public bool Multicrew { get; set; }


            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }

            [JsonConverter(typeof(SystemPositionConverter))]
            public SystemPosition StarPos { get; set; }

            public string Body { get; set; }
            public double JumpDist { get; set; }
            public double FuelUsed { get; set; }
            public double FuelLevel { get; set; }
            public bool BoostUsed { get; set; }
            public Faction SystemFaction { get; set; }
            public string SystemAllegiance { get; set; }
            public string SystemEconomy { get; set; }
            public string SystemEconomy_Localised { get; set; }
            public string SystemSecondEconomy { get; set; }
            public string SystemSecondEconomy_Localised { get; set; }
            public string SystemGovernment { get; set; }
            public string SystemGovernment_Localised { get; set; }
            public string SystemSecurity { get; set; }
            public string SystemSecurity_Localised { get; set; }
            public long Population { get; set; }
            public bool Wanted { get; set; }
            public string[] Powers { get; set; }

            public string PowerplayState { get; set; }

            public Faction[] Factions { get; set; }

            public Conflict[] Conflicts { get; set; }

            public override JournalEventArgs Clone()
            {
                var clone = (FSDJumpEventArgs)base.Clone();
                clone.SystemFaction = SystemFaction?.Clone();
                clone.Factions = Factions?.Select(f => f.Clone()).ToArray();
                clone.Conflicts = Conflicts?.Select(c => c.Clone()).ToArray();
                return clone;
            }
        }
    }
}
