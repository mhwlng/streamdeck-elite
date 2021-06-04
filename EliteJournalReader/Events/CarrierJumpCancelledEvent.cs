using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class CarrierJumpCancelledEvent : JournalEvent<CarrierJumpCancelledEvent.CarrierJumpCancelledEventArgs>
    {
        public CarrierJumpCancelledEvent() : base("CarrierJumpCancelled") { }

        public class CarrierJumpCancelledEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
        }
    }
}