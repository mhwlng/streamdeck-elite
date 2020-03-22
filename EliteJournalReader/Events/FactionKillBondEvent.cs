using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: Player rewarded for taking part in a combat zone
    //Parameters: 
    //•	Reward
    //•	AwardingFaction
    //•	VictimFaction
    public class FactionKillBondEvent : JournalEvent<FactionKillBondEvent.FactionKillBondEventArgs>
    {
        public FactionKillBondEvent() : base("FactionKillBond") { }

        public class FactionKillBondEventArgs : JournalEventArgs
        {
            public string AwardingFaction { get; set; }
            public string VictimFaction { get; set; }
            public int Reward { get; set; }
        }
    }
}
