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
    public class SystemsShutdownEvent : JournalEvent<SystemsShutdownEvent.SystemsShutdownEventArgs>
    {
        public SystemsShutdownEvent() : base("SystemsShutdown") { }

        public class SystemsShutdownEventArgs : JournalEventArgs
        {
        }
    }
}
