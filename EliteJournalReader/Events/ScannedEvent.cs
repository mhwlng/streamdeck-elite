using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the player's ship has been scanned
    //(note the "Scan Detected" indication is at the start of the scan, this is written at the end of a successful scan)
    //Parameters:
    //•	ScanType: Cargo, Crime, Cabin, Data or Unknown
    public class ScannedEvent : JournalEvent<ScannedEvent.ScannedEventArgs>
    {
        public ScannedEvent() : base("Scanned") { }

        public class ScannedEventArgs : JournalEventArgs
        {
            public string ScanType { get; set; }
        }
    }
}
