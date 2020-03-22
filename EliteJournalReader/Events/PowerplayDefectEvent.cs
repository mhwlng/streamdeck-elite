using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when a player defects from one power to another
    //Parameters:
    //•	FromPower
    //•	ToPower
    public class PowerplayDefectEvent : JournalEvent<PowerplayDefectEvent.PowerplayDefectEventArgs>
    {
        public PowerplayDefectEvent() : base("PowerplayDefect") { }

        public class PowerplayDefectEventArgs : JournalEventArgs
        {
            public string FromPower { get; set; }
            public string ToPower { get; set; }
        }
    }
}
