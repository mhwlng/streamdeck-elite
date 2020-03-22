using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when paying legacy fines
    //Parameters:
    //•	Amount
    public class PayLegacyFinesEvent : JournalEvent<PayLegacyFinesEvent.PayLegacyFinesEventArgs>
    {
        public PayLegacyFinesEvent() : base("PayLegacyFines") { }

        public class PayLegacyFinesEventArgs : JournalEventArgs
        {
            public int Amount { get; set; }
            public double? BrokerPercentage { get; set; }
        }
    }
}
