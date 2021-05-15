using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "LoadoutRemoveModule" event contains:

    /*
     */
    public class LoadoutRemoveModuleEvent : JournalEvent<LoadoutRemoveModuleEvent.LoadoutRemoveModuleEventArgs>
    {
        public LoadoutRemoveModuleEvent() : base("LoadoutRemoveModule") { }

        public class LoadoutRemoveModuleEventArgs : JournalEventArgs
        {
            public string SuitID { get; set; }
            public string SuitName { get; set; }
            public string LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public string ModuleName { get; set; }
            public string SuitModuleID { get; set; }

        }
    }
}
