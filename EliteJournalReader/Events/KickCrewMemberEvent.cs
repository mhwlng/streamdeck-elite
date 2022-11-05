using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When you force another player to leave your ship's crew
    //Parameters:
    //Crew: player's commander name
    //OnCrime: (bool) true if player is automatically kicked for committing a crime in a lawful session
    //Telepresence: (bool) (only from Odyssey build)
    public class KickCrewMemberEvent : JournalEvent<KickCrewMemberEvent.KickCrewMemberEventArgs>
    {
        public KickCrewMemberEvent() : base("KickCrewMember") { }

        public class KickCrewMemberEventArgs : JournalEventArgs
        {
            public string Crew { get; set; }
            public bool OnCrime { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
