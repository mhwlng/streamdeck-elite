using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when repairing modules using the Auto Field Maintenance Unit(AFMU)
    //Parameters:
    //•	Module: module name
    //•	FullyRepaired: (bool)
    //•	Health; (float 0.0..1.0)

    //If the AFMU runs out of ammo, the module may not be fully repaired.
    public class AfmuRepairsEvent : JournalEvent<AfmuRepairsEvent.AfmuRepairsEventArgs>
    {
        public AfmuRepairsEvent() : base("AfmuRepairs") { }

        public class AfmuRepairsEventArgs : JournalEventArgs
        {
            public string Module { get; set; }
            public bool FullyRepaired { get; set; }
            public double Health { get; set; }
        }
    }
}
