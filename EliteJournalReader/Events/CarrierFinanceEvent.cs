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
    public class CarrierFinanceEvent : JournalEvent<CarrierFinanceEvent.CarrierFinanceEventArgs>
    {
        public CarrierFinanceEvent() : base("CarrierFinance") { }

        public class CarrierFinanceEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public double TaxRate { get; set; }
            public long CarrierBalance { get; set; }
            public long ReserveBalance { get; set; }
            public long AvailableBalance { get; set; }
            public double ReservePercent { get; set; }

        }
    }
}
