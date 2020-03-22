using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: on a clean shutdown of the game
    //Parameters: none
    public class ShutdownEvent : JournalEvent<ShutdownEvent.ShutdownEventArgs>
    {
        public ShutdownEvent() : base("Shutdown") { }

        public class ShutdownEventArgs : JournalEventArgs
        {
        }
    }
}
