using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when selling a module in outfitting
    //Parameters:
    //�	Slot
    //�	SellItem
    //�	SellPrice
    //�	Ship
    public class ModuleSellRemoteEvent : JournalEvent<ModuleSellRemoteEvent.ModuleSellRemoteEventArgs>
    {
        public ModuleSellRemoteEvent() : base("ModuleSellRemote") { }

        public class ModuleSellRemoteEventArgs : JournalEventArgs
        {
            public string StorageSlot { get; set; }
            public string SellItem { get; set; }
            public string SellItem_Localised { get; set; }
            public int SellPrice { get; set; }
            public string Ship { get; set; }
            public string ShipId { get; set; }
            public string ServerId { get; set; }
        }
    }
}
