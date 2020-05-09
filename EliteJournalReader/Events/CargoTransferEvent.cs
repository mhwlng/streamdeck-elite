using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: at startup, when loading from main menu
    //Parameters:
    //•	Inventory: array of cargo, with Name and Count for each
    public class CargoTransferEvent : JournalEvent<CargoEvent.CargoEventArgs>
    {
        public CargoTransferEvent() : base("CargoTransfer") { }

        public class CargoTransferEventArgs : JournalEventArgs
        {
            public CargoTransfer[] Transfers { get; set; }
        }
    }
}
