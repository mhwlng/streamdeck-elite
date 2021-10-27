using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
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
