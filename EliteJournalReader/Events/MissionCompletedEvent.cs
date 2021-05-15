using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when a mission is completed
    //Parameters:
    //•	Name: mission type
    //•	Faction: faction name
    //•	MissionID
    //Optional parameters (depending on mission type)
    //•	Commodity
    //•	Count
    //•	Target
    //•	TargetType
    //•	TargetFaction
    //•	Reward: value of reward
    //•	Donation: donation offered (for altruism missions)
    //•	PermitsAwarded:[] (names of any permits awarded, as a JSON array)
    //•	MaterialsReward:[] (name, category and count)
    //•	FactionEffects: array of records
    //    o   Faction
    //    o   Effects: array of Effect and Trend value pairs
    //    o   Influence: array of SystemAddress and Trend value pairs
    //    o   Reputation: Trend value

    public class MissionCompletedEvent : JournalEvent<MissionCompletedEvent.MissionCompletedEventArgs>
    {
        public MissionCompletedEvent() : base("MissionCompleted") { }

        public class MissionCompletedEventArgs : JournalEventArgs
        {
            public struct CommodityRewardItem
            {
                public string Name;
                public string Name_Localised;
                public int Count;
            }

            public struct MaterialRewardItem
            {
                public string Name;
                public string Name_Localised;
                public string Category;
                public string Category_Localised;
                public int Count;
            }

            public struct FactionEffectsDesc
            {
                public string Faction;
                public FactionEffect[] Effects;
                public FactionInfluenceEffect[] Influence;
                public string Reputation;
                public string ReputationTrend;
            }

            public struct FactionEffect
            {
                public string Effect;
                public string Effect_Localised;
                public string Trend;
            }

            public struct FactionInfluenceEffect
            {
                public long SystemAddress;
                public string Trend;
                public string Influence;
            }

            public string Faction { get; set; }
            public string Name { get; set; }
            public string MissionID { get; set; }
            public string Commodity { get; set; }
            public string Commodity_Localised { get; set; }
            public int? Count { get; set; }
            public string Target { get; set; }
            public string TargetType { get; set; }
            public string TargetFaction { get; set; }
            public int Reward { get; set; }
            public string Donation { get; set; }
            public int? Donated { get; set; }
            public string[] PermitsAwarded { get; set; }
            public CommodityRewardItem[] CommodityReward { get; set; }
            public MaterialRewardItem[] MaterialsReward { get; set; }
            public FactionEffectsDesc[] FactionEffects { get; set; }
        }
    }
}
