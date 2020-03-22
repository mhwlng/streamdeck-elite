using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when exchanging materials at the Material trader contact
    //Parameters:
    //•	MarketID
    //•	TraderType
    //•	Paid
    //   o   Material
    //   o   Category
    //   o   Quantity
    //•	Received
    //   o   Material
    //   o   Category
    //   o   Quantity
    public class MaterialTradeEvent : JournalEvent<MaterialTradeEvent.MaterialTradeEventArgs>
    {
        public MaterialTradeEvent() : base("MaterialTrade") { }

        public class MaterialTradeEventArgs : JournalEventArgs
        {
            public struct MaterialTraded
            {
                public string Material;
                public string Material_Localised;
                public string Category;
                public string Category_Localised;
                public int Quantity;
            }

            public long MarketID { get; set; }
            public string TraderType { get; set; }
            public MaterialTraded Paid { get; set; }
            public MaterialTraded Received { get; set; }
        }
    }
}
