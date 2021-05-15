using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when starting a mission
    //Parameters:
    //•	Name: name of mission
    //•	Faction: faction offering mission
    //•	MissionID
    //•	Influence: effect on influence(None/Low/Med/High)
    //•	Reputation: effect on reputation(None/Low/Med/High)
    //•	Reward: expected cash reward
    //•	Wing: bool
    //Optional Parameters (depending on mission type)
    //•	Commodity: commodity type
    //•	Count: number required / to deliver
    //•	Target: name of target
    //•	TargetType: type of target
    //•	TargetFaction: target’s faction
    public class MissionAcceptedEvent : JournalEvent<MissionAcceptedEvent.MissionAcceptedEventArgs>
    {
        public MissionAcceptedEvent() : base("MissionAccepted") { }

        public class MissionAcceptedEventArgs : JournalEventArgs
        {
            public string MissionID { get; set; }
            public string Name { get; set; }
            public string LocalisedName { get; set; }
            public string Faction { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<InfluenceLevel>))]
            public InfluenceLevel Influence { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<ReputationLevel>))]
            public ReputationLevel Reputation { get; set; }

            public int Reward { get; set; }
            public bool Wing { get; set; }

            public string Commodity { get; set; }
            public string Commodity_Localised { get; set; }
            public int? Count { get; set; }
            public string Target { get; set; }
            public string TargetType { get; set; }
            public string TargetFaction { get; set; }
            public int? KillCount { get; set; }
            public DateTime? Expiry { get; set; }
            public string DestinationSystem { get; set; }
            public string DestinationStation { get; set; }
            public int? PassengerCount { get; set; }
            public bool? PassengerVIPs { get; set; }
            public bool? PassengerWanted { get; set; }
            public string PassengerType { get; set; }
            public string Donation { get; set; }
            public int? Donated { get; set; }

        }
    }
}
