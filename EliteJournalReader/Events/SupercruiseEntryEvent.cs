using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: entering supercruise from normal space
    //Parameters:
    //•	Starsystem
    public class SupercruiseEntryEvent : JournalEvent<SupercruiseEntryEvent.SupercruiseEntryEventArgs>
    {
        public SupercruiseEntryEvent() : base("SupercruiseEntry") { }

        public class SupercruiseEntryEventArgs : JournalEventArgs
        {
            public long SystemAddress { get; set; }
            public string StarSystem { get; set; }
        }
    }
}
