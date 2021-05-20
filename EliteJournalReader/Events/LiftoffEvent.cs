using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when taking off from planet surface
    //Parameters:
    //•	Latitude
    //•	Longitude
    //•	PlayerControlled: (bool) false if ship dismissed when player is in SRV, true if player is taking off
    public class LiftoffEvent : JournalEvent<LiftoffEvent.LiftoffEventArgs>
    {
        public LiftoffEvent() : base("Liftoff") { }

        public class LiftoffEventArgs : JournalEventArgs
        {
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }
            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }
            public string NearestDestination { get; set; }
            public string NearestDestination_Localised { get; set; }
            public bool PlayerControlled { get; set; }
        }
    }
}
