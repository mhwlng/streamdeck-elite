using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when dropping from Supercruise at a USS
    //Parameters:
    //•	USSType: description of USS
    //•	USSThreat: threat level
    public class USSDropEvent : JournalEvent<USSDropEvent.USSDropEventArgs>
    {
        public USSDropEvent() : base("USSDrop") { }

        public class USSDropEventArgs : JournalEventArgs
        {
            public string USSType { get; set; }
            public int USSThreat { get; set; }
        }
    }
}
