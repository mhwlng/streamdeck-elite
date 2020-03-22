using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the ‘self destruct’ function is used
    //Parameters: none
    public class SelfDestructEvent : JournalEvent<SelfDestructEvent.SelfDestructEventArgs>
    {
        public SelfDestructEvent() : base("SelfDestruct") { }

        public class SelfDestructEventArgs : JournalEventArgs
        {
        }
    }
}
