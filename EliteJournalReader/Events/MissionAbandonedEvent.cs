using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when a mission has been abandoned
    //Parameters:
    //•	Name: name of mission
    public class MissionAbandonedEvent : JournalEvent<MissionAbandonedEvent.MissionAbandonedEventArgs>
    {
        public MissionAbandonedEvent() : base("MissionAbandoned") { }

        public class MissionAbandonedEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string MissionID { get; set; }
            public int Fine { get; set; }
        }
    }
}
