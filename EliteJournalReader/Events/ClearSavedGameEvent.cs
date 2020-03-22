using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class ClearSavedGameEvent : JournalEvent<ClearSavedGameEvent.ClearSavedGameEventArgs>
    {
        public ClearSavedGameEvent() : base("ClearSavedGame") { }

        public class ClearSavedGameEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
        }
    }
}
