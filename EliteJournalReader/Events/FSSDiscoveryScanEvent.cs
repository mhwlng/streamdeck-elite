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
    public class FSSDiscoveryScanEvent : JournalEvent<FSSDiscoveryScanEvent.FSSDiscoveryScanEventArgs>
    {
        public FSSDiscoveryScanEvent() : base("FSSDiscoveryScan") { }

        public class FSSDiscoveryScanEventArgs : JournalEventArgs
        {
            public double Progress { get; set; }
            public int BodyCount { get; set; }
            public int NonBodyCount { get; set; }
        }
    }
}
