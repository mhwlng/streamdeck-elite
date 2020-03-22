using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when performing a full system scan(“Honk”)
    //Parameters:
    //•	Progress: (a value in range 0-1 showing how completely the system has been scanned)
    //•	BodyCount: number of stellar bodies in system
    //•	NonBodyCount: Number of non-body signals found
    public class FSSSignalDiscoveredEvent : JournalEvent<FSSSignalDiscoveredEvent.FSSSignalDiscoveredEventArgs>
    {
        public FSSSignalDiscoveredEvent() : base("FSSSignalDiscovered") { }

        public class FSSSignalDiscoveredEventArgs : JournalEventArgs
        {
            public string SignalName { get; set; }
            public string SignalName_Localised { get; set; }
            public string SpawningState { get; set; }
            public string SpawningFaction { get; set; }
            public double TimeRemaining { get; set; }
            public bool IsStation { get; set; } = false;
            public int ThreatLevel { get; set; } = 0;
            public long SystemAddress { get; set; }
            public string USSType { get; set; }
        }
    }
}
