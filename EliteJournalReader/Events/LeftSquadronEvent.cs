using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class LeftSquadronEvent : JournalEvent<LeftSquadronEvent.LeftSquadronEventArgs>
    {
        public LeftSquadronEvent() : base("LeftSquadron") { }

        public class LeftSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
