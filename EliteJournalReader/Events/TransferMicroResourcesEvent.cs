using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class TransferMicroResourcesEvent : JournalEvent<TransferMicroResourcesEvent.TransferMicroResourcesEventArgs>
    {
        public TransferMicroResourcesEvent() : base("TransferMicroResources") { }

        public class TransferMicroResourcesEventArgs : JournalEventArgs
        {
            public struct Transfer
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public string Category { get; set; }
                public int LockerOldCount { get; set; }
                public int LockerNewCount { get; set; }
                public string Direction { get; set; }
            }
            public Transfer[] Transfers { get; set; }
        }
    }
}
