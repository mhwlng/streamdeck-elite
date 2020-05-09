using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class CarrierTradeOrderEvent : JournalEvent<CarrierTradeOrderEvent.CarrierTradeOrderEventArgs>
    {
        public CarrierTradeOrderEvent() : base("CarrierTradeOrder") { }

        public class CarrierTradeOrderEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public bool BlackMarket { get; set; }
            public string Commodity { get; set; }
            public string Commodity_Localised { get; set; }
            public long PurchaseOrder { get; set; }
            public long SaleOrder { get; set; }
            public bool CancelTrade { get; set; } = false;
            public long Price { get; set; }
        }
    }
}
