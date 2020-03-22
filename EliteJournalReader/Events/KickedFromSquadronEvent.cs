using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class KickedFromSquadronEvent : JournalEvent<KickedFromSquadronEvent.KickedFromSquadronEventArgs>
    {
        public KickedFromSquadronEvent() : base("KickedFromSquadron") { }

        public class KickedFromSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
