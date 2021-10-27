using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when moving a module to a different slot on the ship
    //Parameters:
    //�	FromSlot
    //�	ToSlot
    //�	FromItem
    //�	ToItem
    //�	Ship
    //�	ShipID
    public class ModuleSwapEvent : JournalEvent<ModuleSwapEvent.ModuleSwapEventArgs>
    {
        public ModuleSwapEvent() : base("ModuleSwap") { }

        public class ModuleSwapEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string FromSlot { get; set; }
            public string ToSlot { get; set; }
            public string FromItem { get; set; }
            public string FromItem_Localised { get; set; }
            public string ToItem { get; set; }
            public string ToItem_Localised { get; set; }
            public string Ship { get; set; }
            public string ShipID { get; set; }
        }
    }
}
