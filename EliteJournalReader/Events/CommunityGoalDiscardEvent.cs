using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when opting out of a community goal
    //Parameters:
    //•	Name
    //•	System
    public class CommunityGoalDiscardEvent : JournalEvent<CommunityGoalDiscardEvent.CommunityGoalDiscardEventArgs>
    {
        public CommunityGoalDiscardEvent() : base("CommunityGoalDiscard") { }

        public class CommunityGoalDiscardEventArgs : JournalEventArgs
        {
            public long CGID { get; set; }
            public string Name { get; set; }
            public string System { get; set; }
        }
    }
}
