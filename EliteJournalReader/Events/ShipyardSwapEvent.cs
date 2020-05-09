using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when switching to another ship already stored at this station
    //Parameters:
    //•	ShipType: type of ship being switched to
    //•	ShipID
    //•	StoreOldShip: (if storing old ship) type of ship being stored
    //•	StoreShipID
    //•	SellOldShip: (if selling old ship) type of ship being sold
    //•	SellShipID
    public class ShipyardSwapEvent : JournalEvent<ShipyardSwapEvent.ShipyardSwapEventArgs>
    {
        public ShipyardSwapEvent() : base("ShipyardSwap") { }

        public class ShipyardSwapEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public int ShipID { get; set; }
            public string StoreOldShip { get; set; }
            public int? StoreShipID { get; set; }
            public string SellOldShip { get; set; }
            public int? SellShipID { get; set; }
            public int? SellPrice { get; set; }  
        }
    }
}
