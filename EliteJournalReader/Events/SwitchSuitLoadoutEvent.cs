using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class SwitchSuitLoadoutEvent : JournalEvent<SwitchSuitLoadoutEvent.SwitchSuitLoadoutEventArgs>
    {
        public SwitchSuitLoadoutEvent() : base("SwitchSuitLoadout") { }

        public class SwitchSuitLoadoutEventArgs : JournalEventArgs
        {
            public class Module
            {
                public string SlotName { get; set; }
                public string SuitModuleID { get; set; }
                public string ModuleName { get; set; }
                public string ModuleName_Localised { get; set; }

                public string Class { get; set; }
            }

            public string SuitID { get; set; }
            public string SuitName { get; set; }
            public string[] SuitMods { get; set; }
            public string LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public Module[] Modules { get; set; }
        }
    }
}
