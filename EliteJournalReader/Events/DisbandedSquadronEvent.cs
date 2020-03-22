using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class DisbandedSquadronEvent : JournalEvent<DisbandedSquadronEvent.DisbandedSquadronEventArgs>
    {
        public DisbandedSquadronEvent() : base("DisbandedSquadron") { }

        public class DisbandedSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
