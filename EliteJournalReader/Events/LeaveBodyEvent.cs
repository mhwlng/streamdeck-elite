using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when flying away from a planet, and distance increases above the 'Orbital Cruise' altitude
    //Parameters:
    //•	StarSystem
    //•	SystemAddress
    //•	Body
    //•	BodyID
    public class LeaveBodyEvent : JournalEvent<LeaveBodyEvent.LeaveBodyEventArgs>
    {
        public LeaveBodyEvent() : base("LeaveBody") { }

        public class LeaveBodyEventArgs : JournalEventArgs
        {
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }
        }
    }
}
