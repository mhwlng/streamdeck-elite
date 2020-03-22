using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteJournalReader.Events
{
    //When written: when the station denies a docking request
    //Parameters:
    //•	StationName: name of station
    //•	Reason: reason for denial
    //
    //Reasons include: NoSpace, TooLarge, Hostile, Offences, Distance, ActiveFighter, NoReason
    public class DockingDeniedEvent : JournalEvent<DockingDeniedEvent.DockingDeniedEventArgs>
    {
        public DockingDeniedEvent() : base("DockingDenied") { }

        public class DockingDeniedEventArgs : JournalEventArgs
        {
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<DockingDeniedReason>))]
            public DockingDeniedReason Reason { get; set; }
        }
    }
}
