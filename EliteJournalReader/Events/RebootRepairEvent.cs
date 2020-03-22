using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the ‘reboot repair’ function is used
    //Parameters:
    //•	Modules: JSON array of names of modules repaired
    public class RebootRepairEvent : JournalEvent<RebootRepairEvent.RebootRepairEventArgs>
    {
        public RebootRepairEvent() : base("RebootRepair") { }

        public class RebootRepairEventArgs : JournalEventArgs
        {
            public string[] Modules { get; set; }
        }
    }
}
