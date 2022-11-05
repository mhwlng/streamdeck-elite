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
    //When written: at startup, or when being resurrected at a station
    //Parameters:
    //	StarSystem: name of destination starsystem
    //	StarPos: star position, as a Json array [x, y, z], in light years
    //	Body: star's body name
    //	BodyType
    //	DistFromStarLS: (unless close to main star)
    //	Docked: true (if docked)
    //	Latitude (if landed)
    //	Longitude (if landed)
    //	StationName: station name, (if docked)
    //	StationType: (if docked)
    //	MarketID
    //	SystemFaction: star system controlling faction
    //    o Name
    //    o FactionState
    //	Faction: star system controlling faction
    //	FactionState
    //	SystemAllegiance
    //	SystemEconomy
    //	SystemSecondEconomy
    //	SystemGovernment
    //	SystemSecurity
    //	Wanted
    //	Factions: an array with info on local minor factions (similar to FSDJump)
    //	Conflicts: an array with info on local conflicts(similar to FSDJump)
    //If the player is pledged to a Power in Powerplay, and the star system is involved in powerplay,
    //	Powers: a json array with the names of any powers contesting the system, or the name of the controlling power
    //	PowerplayState: the system state - one of("InPrepareRadius", "Prepared", "Exploited", "Contested", "Controlled", "Turmoil", "HomeSystem")
    public class CarrierJumpEvent : JournalEvent<CarrierJumpEvent.CarrierJumpEventArgs>
    {
        public CarrierJumpEvent() : base("CarrierJump") { }

        public class CarrierJumpEventArgs : JournalEventArgs
        {
            public bool Taxi { get; set; }
            public bool Multicrew { get; set; }

            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }

            [JsonConverter(typeof(SystemPositionConverter))]
            public SystemPosition StarPos { get; set; }

            public string Body { get; set; }
            public long BodyID { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<BodyType>))]
            public BodyType BodyType { get; set; }

            public bool Docked { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }

            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
            public Faction StationFaction { get; set; }
            public string StationGovernment { get; set; }
            public string StationAllegiance { get; set; }
            public string[] StationServices { get; set; }
            public Economy[] StationEconomies { get; set; }

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


            public bool Wanted { get; set; }
            public long? Population { get; set; }
            public string[] Powers { get; set; }

            public string PowerplayState { get; set; }

            public Faction[] Factions { get; set; }
            public Conflict[] Conflicts { get; set; }

            public override JournalEventArgs Clone()
            {
                var clone = (CarrierJumpEventArgs)base.Clone();
                clone.StationFaction = StationFaction?.Clone();
                clone.SystemFaction = SystemFaction?.Clone();
                clone.StationEconomies = StationEconomies?.Select(e => e.Clone()).ToArray();
                clone.Factions = Factions?.Select(f => f.Clone()).ToArray();
                clone.Conflicts = Conflicts?.Select(c => c.Clone()).ToArray();
                return clone;
            }
        }
    }
}
