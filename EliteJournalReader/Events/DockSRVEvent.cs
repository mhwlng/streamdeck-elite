using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when docking an SRV with the ship
    //Parameters: none
    public class DockSRVEvent : JournalEvent<DockSRVEvent.DockSRVEventArgs>
    {
        public DockSRVEvent() : base("DockSRV") { }

        public class DockSRVEventArgs : JournalEventArgs
        {
            public long ID { get; set; }
            public string SRVType { get; set; }
        }
    }
}
