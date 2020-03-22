using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: Player has escaped interdiction
    //Parameters: 
    //•	Interdictor: interdicting pilot name
    //•	IsPlayer: whether player or npc
    public class EscapeInterdictionEvent : JournalEvent<EscapeInterdictionEvent.EscapeInterdictionEventArgs>
    {
        public EscapeInterdictionEvent() : base("EscapeInterdiction") { }

        public class EscapeInterdictionEventArgs : JournalEventArgs
        {
            public string Interdictor { get; set; }
            public bool IsPlayer { get; set; }
        }
    }
}
