using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //    When written: when accessing shipyard in a station
    //Parameters:
    //•	MarketID
    //•	StationName
    //•	StarSystem

    //The full price list is written to a separate file, in the same folder as the journal, Shipyard.json
    //•	Pricelist: array of objects
    //o   ShipType
    //o   ShipPrice
    public class ShipyardEvent : JournalEvent<ShipyardEvent.ShipyardEventArgs>
    {
        public ShipyardEvent() : base("Shipyard") { }

        public class ShipyardEventArgs : JournalEventArgs
        {
            public string StationName { get; set; }
            public long MarketID { get; set; }
            public string StarSystem { get; set; }
        }
    }
}
