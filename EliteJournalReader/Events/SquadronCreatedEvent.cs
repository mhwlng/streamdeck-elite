using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class SquadronCreatedEvent : JournalEvent<SquadronCreatedEvent.SquadronCreatedEventArgs>
    {
        public SquadronCreatedEvent() : base("SquadronCreated") { }

        public class SquadronCreatedEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
