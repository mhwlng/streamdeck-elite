using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when engaging a new member of crew
    //Parameters:
    //�	Name
    public class CrewHireEvent : JournalEvent<CrewHireEvent.CrewHireEventArgs>
    {
        public CrewHireEvent() : base("CrewHire") { }

        public class CrewHireEventArgs : JournalEventArgs
        {
            public long CrewID { get; set; }
            public string Name { get; set; }
            public string Faction { get; set; }
            public int Cost { get; set; }
            public CombatRank CombatRank { get; set; }
        }
    }
}
