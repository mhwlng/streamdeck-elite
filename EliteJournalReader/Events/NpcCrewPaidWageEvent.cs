using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //This is written when crew receive wages
    //Parameters:
    //•	NpcCrewId
    //•	Amount
    public class NpcCrewPaidWageEvent : JournalEvent<NpcCrewPaidWageEvent.NpcCrewPaidWageEventArgs>
    {
        public NpcCrewPaidWageEvent() : base("NpcCrewPaidWage") { }

        public class NpcCrewPaidWageEventArgs : JournalEventArgs
        {
            public long NpcCrewId { get; set; }
            public long Amount { get; set; }
        }
    }
}
