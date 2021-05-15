using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "TransferMicroResources" event contains:

    /*
     {"timestamp":"2021-03-31T21:05:36Z","event":"TransferMicroResources",
    "Transfers":[{"Name":"healthpack",
                  "Name_Localised":"Medkit",
                  "Category":"Consumable",
                  "Count":3,
                  "Direction":"ToBackpack"},
        ]}
     */
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
                public int Count { get; set; }
                public string Direction { get; set; }
            }
            public Transfer[] Transfers { get; set; }

        }
    }
}
