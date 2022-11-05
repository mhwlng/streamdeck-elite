using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When another player leaves your ship's crew
    //Parameters:
    //Crew: player's commander name
    //Telepresence: (bool) (only from Odyssey build)
    public class EndCrewSessionEvent : JournalEvent<EndCrewSessionEvent.EndCrewSessionEventArgs>
    {
        public EndCrewSessionEvent() : base("EndCrewSession") { }

        public class EndCrewSessionEventArgs : JournalEventArgs
        {
            public bool OnCrime { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
