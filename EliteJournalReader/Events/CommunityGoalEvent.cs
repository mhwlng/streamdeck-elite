using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when checking the status of a community goal
    //This event contains the current status of all community goals the player is currently subscribed to
    //Parameters:
    //•	CurrentGoals: an array with an entry for each CG, containing:
    //o CGID: a unique ID number for this CG
    //o   Title: the description of the CG
    //o   SystemName
    //o   MarketName
    //o   Expiry: time and date
    //o   IsComplete: Boolean
    //o   CurrentTotal
    //o   PlayerContribution
    //o   NumContributors
    //o   PlayerPercentileBand

    //If the community goal is constructed with a fixed-size top rank (ie max reward for top 10 players)
    //o TopRankSize: (integer)
    //o PlayerInTopRank: (Boolean)

    //If the community goal has reached the first success tier:
    //o TierReached
    //o Bonus
    public class CommunityGoalEvent : JournalEvent<CommunityGoalEvent.CommunityGoalEventArgs>
    {
        public CommunityGoalEvent() : base("CommunityGoal") { }

        public class CommunityGoalEventArgs : JournalEventArgs
        {
            public struct CurrentGoal
            {
                public long CGID;
                public string Title;
                public string SystemName;
                public string MarketName;
                public DateTime Expiry;
                public bool IsCompleted;
                public long CurrentTotal;
                public long PlayerContribution;
                public long NumContributors;
                public int? PlayerPercentileBand;
                public int? TopRankSize;
                public bool? PlayerInTopRank;
                public string TierReached;
                public long? Bonus;
                public Tier TopTier;
            }

            public struct Tier
            {
                public string Name;
                public string Bonus;
            }
            
            public CurrentGoal[] CurrentGoals { get; set; }
        }
    }
}
