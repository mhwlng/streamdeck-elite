using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when delivering powerplay commodities
    //Parameters:
    //•	Power
    //•	Type
    //•	Count
    public class PowerplayDeliverEvent : JournalEvent<PowerplayDeliverEvent.PowerplayDeliverEventArgs>
    {
        public PowerplayDeliverEvent() : base("PowerplayDeliver") { }

        public class PowerplayDeliverEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public string Type { get; set; }
            public int Count { get; set; }
        }
    }
}
