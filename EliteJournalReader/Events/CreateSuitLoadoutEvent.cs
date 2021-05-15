using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "CreateSuitLoadout" event contains:

    /*
     {"timestamp":"2021-03-31T10:30:33Z","event":"CreateSuitLoadout",
    "LoadoutID":4293000003,
    "LoadoutName":"Rocket Launcher with Kinetic Side Arm",
    "Modules":[
    {"SlotName":"PrimaryWeapon1",
     "ModuleName":"wpn_m_launcher_rocket_sauto",
     "ModuleName_Localised":"Karma L-6"},
    ]}
     */

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

            public Module[] Modules { get; set; }
        }
    }
}
