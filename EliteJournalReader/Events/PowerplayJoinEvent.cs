using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when joining up with a power
    //Parameters:
    //•	Power
    public class PowerplayJoinEvent : JournalEvent<PowerplayJoinEvent.PowerplayJoinEventArgs>
    {
        public PowerplayJoinEvent() : base("PowerplayJoin") { }

        public class PowerplayJoinEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
        }
    }
}
