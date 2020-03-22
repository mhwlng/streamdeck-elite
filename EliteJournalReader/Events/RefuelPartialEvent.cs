using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when refuelling (10%)
    //Parameters:
    //•	Cost: cost of fuel
    //•	Amount: tons of fuel purchased
    public class RefuelPartialEvent : JournalEvent<RefuelPartialEvent.RefuelPartialEventArgs>
    {
        public RefuelPartialEvent() : base("RefuelPartial") { }

        public class RefuelPartialEventArgs : JournalEventArgs
        {
            public int Cost { get; set; }
            public double Amount { get; set; }
        }
    }
}
