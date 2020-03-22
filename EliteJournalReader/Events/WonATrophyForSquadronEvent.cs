using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class WonATrophyForSquadronEvent : JournalEvent<WonATrophyForSquadronEvent.WonATrophyForSquadronEventArgs>
    {
        public WonATrophyForSquadronEvent() : base("WonATrophyForSquadron") { }

        public class WonATrophyForSquadronEventArgs : JournalEventArgs
        {
            public string SquadronName { get; set; }
        }
    }
}
