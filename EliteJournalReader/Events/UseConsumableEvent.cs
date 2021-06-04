using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "UseConsumable" event contains:

    /*
     */
    public class UseConsumableEvent : JournalEvent<UseConsumableEvent.UseConsumableEventArgs>
    {
        public UseConsumableEvent() : base("UseConsumable") { }

        public class UseConsumableEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Type { get; set; }

        }
    }
}
