using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class CancelDropshipEvent : JournalEvent<CancelDropshipEvent.CancelDropshipEventArgs>
    {
        public CancelDropshipEvent() : base("CancelDropship") { }

        public class CancelDropshipEventArgs : JournalEventArgs
        {
            public long Refund { get; set; }
        }
    }
}
