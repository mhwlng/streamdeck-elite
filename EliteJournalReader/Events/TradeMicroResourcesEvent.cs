using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "TradeMicroResources" event contains:

    /*
   
     */
    public class TradeMicroResourcesEvent : JournalEvent<TradeMicroResourcesEvent.TradeMicroResourcesEventArgs>
    {
        public TradeMicroResourcesEvent() : base("TradeMicroResources") { }

        public class TradeMicroResourcesEventArgs : JournalEventArgs
        {
            public struct Offer
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public string Category { get; set; }
                public int Count { get; set; }
            }
            public Offer[] Offered { get; set; }

            public string Received { get; set; }
            public string Received_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public int Count { get; set; }
            public long MarketID { get; set; }
        }
    }
}
