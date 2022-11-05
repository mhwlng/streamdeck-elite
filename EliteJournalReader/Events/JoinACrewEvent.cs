using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When you join another player ship's crew
    //Parameters:
    //Captain: Helm player's commander name
    //Telepresence: (bool) (only from Odyssey build)
    public class JoinACrewEvent : JournalEvent<JoinACrewEvent.JoinACrewEventArgs>
    {
        public JoinACrewEvent() : base("JoinACrew") { }

        public class JoinACrewEventArgs : JournalEventArgs
        {
            public string Captain { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
