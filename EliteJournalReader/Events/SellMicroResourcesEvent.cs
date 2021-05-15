using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "SellMicroResources" event contains:

    /*
     {"timestamp":"2021-03-31T19:57:54Z","event":"SellMicroResources",
    "TotalCount":13,
    "MicroResources":[
    {"Name":"encryptedmemorychip",
    "Name_Localised":"Encrypted Memory Chip",
    "Category":"Component",
    "Count":1},
    ],
    "Price":4100,
    "MarketID":3221558784}
     */

    public class SellMicroResourcesEvent : JournalEvent<SellMicroResourcesEvent.SellMicroResourcesEventArgs>
    {
        public SellMicroResourcesEvent() : base("SellMicroResources") { }

        public class SellMicroResourcesEventArgs : JournalEventArgs
        {
            public struct MicroResource
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public string Category { get; set; }
                public int Count { get; set; }
            }

            public int TotalCount { get; set; }
            public MicroResource[] MicroResources { get; set; }
            public long Price { get; set; }
            public long MarketID { get; set; }
        }
    }
}
