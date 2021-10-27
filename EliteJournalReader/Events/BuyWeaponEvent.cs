using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class BuyWeaponEvent : JournalEvent<BuyWeaponEvent.BuyWeaponEventArgs>
    {
        public BuyWeaponEvent() : base("BuyWeapon") { }

        public class BuyWeaponEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public long Price { get; set; }
            public string SuitModuleID { get; set; }
            public string Class { get; set; }
            public string[] WeaponMods { get; set; }
        }
    }
}
