using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when purchasing an SRV or Fighter
    //Parameters:
    //•	Type: type of vehicle being purchased (SRV or fighter model)
    //•	Loadout: variant
    //•	Cost: purchase cost
    //•	Count: number of vehicles purchased
    public class RestockVehicleEvent : JournalEvent<RestockVehicleEvent.RestockVehicleEventArgs>
    {
        public RestockVehicleEvent() : base("RestockVehicle") { }

        public class RestockVehicleEventArgs : JournalEventArgs
        {
            public string Type { get; set; }
            public string Loadout { get; set; }
            public int Cost { get; set; }
            public int Count { get; set; }
        }
    }
}
