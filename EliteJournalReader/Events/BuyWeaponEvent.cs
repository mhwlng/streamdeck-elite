using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "BuyWeapon" event contains:

    /*
     {"timestamp":"2021-03-31T10:24:47Z","event":"BuyWeapon",
    "Name":"Wpn_M_Launcher_Rocket_SAuto",
    "Name_Localised":"Karma L-6",
    "Price":175000}
     */
    public class BuyWeaponEvent : JournalEvent<BuyWeaponEvent.BuyWeaponEventArgs>
    {
        public BuyWeaponEvent() : base("BuyWeapon") { }

        public class BuyWeaponEventArgs : JournalEventArgs
        { 
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public long Price { get; set; }

            public string SuitModuleID { get; set; }
        }
    }
}
