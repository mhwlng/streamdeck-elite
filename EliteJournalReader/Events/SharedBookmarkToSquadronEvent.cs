using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class SharedBookmarkToSquadronEvent : JournalEvent<SharedBookmarkToSquadronEvent.SharedBookmarkToSquadronEventArgs>
    {
        public SharedBookmarkToSquadronEvent() : base("SharedBookmarkToSquadron") { }

        public class SharedBookmarkToSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
