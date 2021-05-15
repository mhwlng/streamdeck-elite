using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "LoadoutEquipModule" event contains:

    /*
     */
    public class LoadoutEquipModuleEvent : JournalEvent<LoadoutEquipModuleEvent.LoadoutEquipModuleEventArgs>
    {
        public LoadoutEquipModuleEvent() : base("LoadoutEquipModule") { }

        public class LoadoutEquipModuleEventArgs : JournalEventArgs
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
