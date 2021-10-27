using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class CreateSuitLoadoutEvent : JournalEvent<CreateSuitLoadoutEvent.CreateSuitLoadoutEventArgs>
    {
        public CreateSuitLoadoutEvent() : base("CreateSuitLoadout") { }

        public class CreateSuitLoadoutEventArgs : JournalEventArgs
        {
            public struct Module
            {
                public string SlotName { get; set; }
                public string SuitModuleID { get; set; }
                public string ModuleName { get; set; }
                public string ModuleName_Localised { get; set; }
            }
            public string SuitID { get; set; }
            public string SuitName { get; set; }
            public string LoadoutID { get; set; }
            public string LoadoutName { get; set; }
            public List<Module> Modules { get; set; }
            public string[] SuitMods;
        }
    }
}
