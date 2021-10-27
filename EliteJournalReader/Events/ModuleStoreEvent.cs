using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when fetching a previously stored module
    //Parameters:
    //�	Slot
    //�	Ship
    //�	ShipID
    //�	StoredItem
    //�	EngineerModifications: name of modification blueprint, if any
    //�	ReplacementItem (if a core module)
    //�	Cost (if any)
    public class ModuleStoreEvent : JournalEvent<ModuleStoreEvent.ModuleStoreEventArgs>
    {
        public ModuleStoreEvent() : base("ModuleStore") { }

        public class ModuleStoreEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string Slot { get; set; }
            public string Ship { get; set; }
            public string ShipId { get; set; }
            public string StoredItem { get; set; }
            public string StoredItem_Localised { get; set; }
            public string EngineerModifications { get; set; }
            public int Level { get; set; }
            public double Quality { get; set; }
            public bool Hot { get; set; }
            public string ReplacementItem { get; set; }
            public string ReplacementItem_Localised { get; set; }
            public int Cost { get; set; }
        }
    }
}
