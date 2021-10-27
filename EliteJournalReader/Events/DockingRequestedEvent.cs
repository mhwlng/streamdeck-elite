using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the player requests docking at a station
    //Parameters:
    //�	StationName: name of station
    public class DockingRequestedEvent : JournalEvent<DockingRequestedEvent.DockingRequestedEventArgs>
    {
        public DockingRequestedEvent() : base("DockingRequested") { }

        public class DockingRequestedEventArgs : JournalEventArgs
        {
            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }
            public DockedEvent.DockedEventArgs.LandingPad LandingPads { get; set; }
        }
    }
}
