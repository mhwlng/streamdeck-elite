using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when receiving a reward for a community goal
    //Parameters:
    //•	Name
    //•	System
    //•	Reward
    public class CommunityGoalRewardEvent : JournalEvent<CommunityGoalRewardEvent.CommunityGoalRewardEventArgs>
    {
        public CommunityGoalRewardEvent() : base("CommunityGoalReward") { }

        public class CommunityGoalRewardEventArgs : JournalEventArgs
        {
            public long CGID { get; set; }
            public string Name { get; set; }
            public string System { get; set; }
            public int Reward { get; set; }
        }
    }
}
