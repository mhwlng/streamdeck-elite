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
    public class CarrierDepositFuelEvent : JournalEvent<CarrierDepositFuelEvent.CarrierDepositFuelEventArgs>
    {
        public CarrierDepositFuelEvent() : base("CarrierDepositFuel") { }

        public class CarrierDepositFuelEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public long Amount { get; set; }
            public long Total { get; set; }
        }
    }
}
