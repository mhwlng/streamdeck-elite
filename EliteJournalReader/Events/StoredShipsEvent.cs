using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //    When written: when visiting shipyard
    //
    //    Parameters:
    //�	MarketID
    //�	StationName
    //�	StarSystem
    //�	ShipsHere: (array of objects)
    //o ShipID
    //o ShipType
    //o Name(if named)
    //o Value
    //o Hot
    //�	ShipsRemote: (array of objects)
    //o ShipID
    //o ShipType
    //o Name(if named)
    //o Value
    //o Hot
    //
    //If the ship is in transit:
    //o InTransit: true
    //
    //If the ship is not in transit:
    //o StarSystem
    //o ShipMarketID
    //o TransferPrice
    //o TransferType

    public class StoredShipsEvent : JournalEvent<StoredShipsEvent.StoredShipsEventArgs>
    {
        public StoredShipsEvent() : base("StoredShips") { }

        public class StoredShipsEventArgs : JournalEventArgs
        {
            public struct StoredShip
            {
                public string ShipID;
                public string ShipType;
                public string ShipType_Localised;
                public string Name;
                public int Value;
                public bool Hot;
                public bool InTransit;
                public string StarSystem;
                public long ShipMarketID;
                public int TransferPrice;
                public string TransferType;
            }

            public long MarketID { get; set; }
            public string StationName { get; set; }
            public string StarSystem { get; set; }
            public StoredShip[] ShipsHere { get; set; }
            public StoredShip[] ShipsRemote { get; set; }
        }
    }
}
