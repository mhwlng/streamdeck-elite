using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when using the discovery scanner, and new body discoveries are displayed in the cockpit info window.Note you can get two or three of these in a row, where some bodies are discovered by the automatic passive scan, before the active scan is complete.
    //Parameters:
    //•	SystemAddress
    //•	Bodies: number of new bodies discovered
    public class DiscoveryScanEvent : JournalEvent<DiscoveryScanEvent.DiscoveryScanEventArgs>
    {
        public DiscoveryScanEvent() : base("DiscoveryScan") { }

        public class DiscoveryScanEventArgs : JournalEventArgs
        {
            public long SystemAddress { get; set; }
            public int Bodies { get; set; }
        }
    }
}
