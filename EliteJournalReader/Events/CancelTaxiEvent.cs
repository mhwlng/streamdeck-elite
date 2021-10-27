using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class CancelTaxiEvent : JournalEvent<CancelTaxiEvent.CancelTaxiEventArgs>
    {
        public CancelTaxiEvent() : base("CancelTaxi") { }

        public class CancelTaxiEventArgs : JournalEventArgs
        {
            public long Refund { get; set; }
        }
    }
}
