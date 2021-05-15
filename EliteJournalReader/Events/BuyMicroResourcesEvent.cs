using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "BuyMicroResources" event contains:

    /*
     {"timestamp":"2021-03-31T20:02:53Z","event":"BuyMicroResources",
    "Name":"amm_grenade_shield",
    "Name_Localised":"Shield Projector",
    "Category":"Consumable",
    "Count":1,
    "Price":2000,
    "MarketID":3221558784}
     */
    public class BuyMicroResourcesEvent : JournalEvent<BuyMicroResourcesEvent.BuyMicroResourcesEventArgs>
    {
        public BuyMicroResourcesEvent() : base("BuyMicroResources") { }

        public class BuyMicroResourcesEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Category { get; set; }
            public int Count { get; set; }
            public long Price { get; set; }
            public long MarketID { get; set; }
        }
    }
}
