using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: Player has bought a fleet carrier
    //•	BoughtAtmarket: marketid
    //•	CarrierID : marketid
    //•	Location: starsystem name
    //•	Price: number
    //•	Variant: string
    //•	Callsign: string
    public class CarrierBuyEvent : JournalEvent<CarrierBuyEvent.CarrierBuyEventArgs>
    {
        public CarrierBuyEvent() : base("CarrierBuy") { }

        public class CarrierBuyEventArgs : JournalEventArgs
        {
            public long BoughtAtMarket { get; set; }
            public long CarrierID { get; set; }
            public string Location { get; set; }
            public long Price { get; set; }
            public string Variant { get; set; }
            public string Callsign { get; set; }
        }
    }
}
