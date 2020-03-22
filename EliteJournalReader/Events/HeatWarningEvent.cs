using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: player was HeatWarning by player or npc
    //Parameters: 
    //•	Submitted: true or false
    public class HeatWarningEvent : JournalEvent<HeatWarningEvent.HeatWarningEventArgs>
    {
        public HeatWarningEvent() : base("HeatWarning") { }

        public class HeatWarningEventArgs : JournalEventArgs
        {
        }
    }
}
