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
    //When written: at startup
    //Parameters:
    //•	Active: (array of objects)
    //•	Failed: (array of objects)
    //•	Complete: (array of objects)

    //Each object contains:
    //•	MissionID
    //•	Name
    //•	PassengerMission: bool
    //•	Expires: time left in seconds
    public class MissionsEvent : JournalEvent<MissionsEvent.MissionsEventArgs>
    {
        public MissionsEvent() : base("Missions") { }

        public class MissionsEventArgs : JournalEventArgs
        {
            public Mission[] Active { get; set; }
            public Mission[] Failed { get; set; }
            public Mission[] Complete { get; set; }

        }
    }
}
