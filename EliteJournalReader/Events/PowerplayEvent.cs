using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: at startup, if player has pledged to a power
    //Parameters:
    //•	Power: name
    //•	Rank
    //•	Merits
    //•	Votes
    //•	TimePledged(time in seconds)

    public class PowerplayEvent : JournalEvent<PowerplayEvent.PowerplayEventArgs>
    {
        public PowerplayEvent() : base("Powerplay") { }

        public class PowerplayEventArgs : JournalEventArgs
        {
            public string Power { get; set; }
            public int Rank { get; set; }
            public int Merits { get; set; }
            public int Votes { get; set; }
            public long TimePledged { get; set; }
        }
    }
}
