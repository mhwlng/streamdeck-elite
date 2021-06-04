using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class CarrierNameChangedEvent : JournalEvent<CarrierNameChangedEvent.CarrierNameChangedEventArgs>
    {
        public CarrierNameChangedEvent() : base("CarrierNameChanged") { }

        public class CarrierNameChangedEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string Callsign { get; set; }
            public string Name { get; set; }
        }
    }
}