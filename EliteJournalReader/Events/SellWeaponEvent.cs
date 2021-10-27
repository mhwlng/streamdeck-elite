using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class SellWeaponEvent : JournalEvent<SellWeaponEvent.SellWeaponEventArgs>
    {
        public SellWeaponEvent() : base("SellWeapon") { }

        public class SellWeaponEventArgs : JournalEventArgs
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
