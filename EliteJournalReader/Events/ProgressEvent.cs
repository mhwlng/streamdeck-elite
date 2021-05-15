using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: at startup
    //Parameters:
    //•	Combat: percent progress to next rank
    //•	Trade: 		“
    //•	Explore: 	“
    //•	Empire: 	“
    //•	Federation: 	“
    //•	CQC: 		“
    public class ProgressEvent : JournalEvent<ProgressEvent.ProgressEventArgs>
    {
        public ProgressEvent() : base("Progress") { }

        public class ProgressEventArgs : JournalEventArgs
        {
            public int Combat { get; set; }
            public int Trade { get; set; }
            public int Explore { get; set; }
            public int Empire { get; set; }
            public int Federation { get; set; }
            public int CQC { get; set; }
            public int Soldier { get; set; }
            public int Exobiologist { get; set; }
        }
    }
}
