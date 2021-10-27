using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when requesting a ship at another station be transported to this station
    //Parameters:
    //�	ShipType: type of ship
    //�	ShipID
    //�	System: where it is
    //�	Distance: how far away
    //�	TransferPrice: cost of transfer
    //�	TransferTime: (in seconds)
    public class ShipyardTransferEvent : JournalEvent<ShipyardTransferEvent.ShipyardTransferEventArgs>
    {
        public ShipyardTransferEvent() : base("ShipyardTransfer") { }

        public class ShipyardTransferEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string ShipId { get; set; }
            public string System { get; set; }
            public double Distance { get; set; }
            public int TransferPrice { get; set; }
            public int TransferTime { get; set; }
        }
    }
}
