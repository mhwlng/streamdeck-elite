using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When another player joins your ship's crew
    //Parameters:
    //Crew: player's commander name
    //Telepresence: (bool) (only from Odyssey build)
    public class CrewMemberJoinsEvent : JournalEvent<CrewMemberJoinsEvent.CrewMemberJoinsEventArgs>
    {
        public CrewMemberJoinsEvent() : base("CrewMemberJoins") { }

        public class CrewMemberJoinsEventArgs : JournalEventArgs
        {
            public string Crew { get; set; }
            public long CrewID { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
