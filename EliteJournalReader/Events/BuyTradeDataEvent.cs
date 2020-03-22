using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when buying trade data in the galaxy map
    //Parameters:
    //•	System: star system requested
    //•	Cost: cost of data
    public class BuyTradeDataEvent : JournalEvent<BuyTradeDataEvent.BuyTradeDataEventArgs>
    {
        public BuyTradeDataEvent() : base("BuyTradeData") { }

        public class BuyTradeDataEventArgs : JournalEventArgs
        {
            public string System { get; set; }
            public int Cost { get; set; }
        }
    }
}
