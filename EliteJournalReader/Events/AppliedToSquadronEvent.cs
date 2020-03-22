using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class AppliedToSquadronEvent : JournalEvent<AppliedToSquadronEvent.AppliedToSquadronEventArgs>
    {
        public AppliedToSquadronEvent() : base("AppliedToSquadron") { }

        public class AppliedToSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
