using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when in multicrew, in Helm player's log, when a crew member launches a fighter
    //Parameters:
    //Crew: name of crew member launching in fighter
    //Telepresence: (bool) (only from Odyssey build)
    public class CrewLaunchFighterEvent : JournalEvent<CrewLaunchFighterEvent.CrewLaunchFighterEventArgs>
    {
        public CrewLaunchFighterEvent() : base("CrewLaunchFighter") { }

        public class CrewLaunchFighterEventArgs : JournalEventArgs
        {
            public string Crew { get; set; }
            public long CrewID { get; set; }
            public long ID { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
