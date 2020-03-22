using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //This is written when a crew member's combat rank increases
    //Parameters:
    //•	NpcCrewId
    //•	RankCombat
    public class NpcCrewRankEvent : JournalEvent<NpcCrewRankEvent.NpcCrewRankEventArgs>
    {
        public NpcCrewRankEvent() : base("NpcCrewRank") { }

        public class NpcCrewRankEventArgs : JournalEventArgs
        {
            public long NpcCrewId { get; set; }
            public CombatRank RankCombat { get; set; }
        }
    }
}
