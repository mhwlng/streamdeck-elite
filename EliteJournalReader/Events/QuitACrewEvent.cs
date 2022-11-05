using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When you leave another player ship's crew
    //Parameters:
    //Captain: Helm player's commander name
    //Telepresence: (bool) (only from Odyssey build)
    public class QuitACrewEvent : JournalEvent<QuitACrewEvent.QuitACrewEventArgs>
    {
        public QuitACrewEvent() : base("QuitACrew") { }

        public class QuitACrewEventArgs : JournalEventArgs
        {
            public string Captain { get; set; }
            public bool Telepresence { get; set; }
        }
    }
}
