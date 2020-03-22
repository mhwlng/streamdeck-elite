using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when selling goods in the market
    //Parameters:
    //•	Type: cargo type
    //•	Count: number of units
    //•	SellPrice: price per unit
    //•	TotalSale: total sale value
    //•	AvgPricePaid: average price paid
    //•	IllegalGoods: (not always present) whether goods are illegal here
    //•	StolenGoods: (not always present) whether goods were stolen
    //•	BlackMarket: (not always present) whether selling in a black market
    public class MarketSellEvent : JournalEvent<MarketSellEvent.MarketSellEventArgs>
    {
        public MarketSellEvent() : base("MarketSell") { }

        public class MarketSellEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public int Count { get; set; }
            public int SellPrice { get; set; }
            public long TotalSale { get; set; }
            public double AvgPricePaid { get; set; }
            public bool IllegalGoods { get; set; } = false;
            public bool StolenGoods { get; set; } = false;
            public bool BlackMarket { get; set; } = false;
        }
    }
}
