using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the player cancels a docking request
    //Parameters:
    //•	StationName: name of station
    public class DockingCancelledEvent : JournalEvent<DockingCancelledEvent.DockingCancelledEventArgs>
    {
        public DockingCancelledEvent() : base("DockingCancelled") { }

        public class DockingCancelledEventArgs : JournalEventArgs
        {
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
        }
    }
}
