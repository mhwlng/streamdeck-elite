using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class InvitedToSquadronEvent : JournalEvent<InvitedToSquadronEvent.InvitedToSquadronEventArgs>
    {
        public InvitedToSquadronEvent() : base("InvitedToSquadron") { }

        public class InvitedToSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
