using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class BuyMicroResourcesEvent : JournalEvent<BuyMicroResourcesEvent.BuyMicroResourcesEventArgs>
    {
        public BuyMicroResourcesEvent() : base("BuyMicroResources") { }

        public class BuyMicroResourcesEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public int Count { get; set; }
            public long Price { get; set; }
            public long MarketID { get; set; }
        }
    }
}
