using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //    When written: player is awarded a bounty for a kill
    //Parameters: 
    //�	Rewards: an array of Faction names and the Reward values, as the target can have multiple bounties payable by different factions
    //�	VictimFaction: the victim�s faction
    //�	TotalReward
    //�	SharedWithOthers: if credit for the kill is shared with other players, this has the number of other players involved
    public class BountyEvent : JournalEvent<BountyEvent.BountyEventArgs>
    {
        public BountyEvent() : base("Bounty") { }

        public class BountyEventArgs : JournalEventArgs
        {
            public struct FactionReward
            {
                public string Faction;
                public int Reward;
            }
            public string Target { get; set; }
            public string Target_Localised { get; set; }

            public FactionReward[] Rewards { get; set; }
            public string VictimFaction { get; set; }
            public int TotalReward { get; set; }
            public int SharedWithOthers { get; set; } = 0;
        }
    }
}
