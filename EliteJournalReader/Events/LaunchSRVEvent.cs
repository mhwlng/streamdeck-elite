using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: deploying the SRV from a ship onto planet surface
    //Parameters:
    //Loadout
    public class LaunchSRVEvent : JournalEvent<LaunchSRVEvent.LaunchSRVEventArgs>
    {
        public LaunchSRVEvent() : base("LaunchSRV") { }

        public class LaunchSRVEventArgs : JournalEventArgs
        {
            public string Loadout { get; set; }
            public long ID { get; set; }
            public string SRVType { get; set; }
        }
    }
}
