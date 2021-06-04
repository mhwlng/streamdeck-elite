using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "TransferMicroResources" event contains:

    /*
    { "timestamp":"2021-05-29T07:40:42Z", "event":"TransferMicroResources", 
"Transfers":[ { "Name":"healthpack", "Name_Localised":"Medkit", "Category":"Consumable", "LockerOldCount":1, 
"LockerNewCount":0, "Direction":"ToBackpack" }, { "Name":"energycell", 
"Name_Localised":"Energy Cell", "Category":"Consumable", "LockerOldCount":2, "LockerNewCount":0, "Direction":"ToBackpack" },
 { "Name":"amm_grenade_emp", "Name_Localised":"Shield Disruptor", "Category":"Consumable", "LockerOldCount":1, 
"LockerNewCount":0, "Direction":"ToBackpack" }, { "Name":"amm_grenade_frag", "Name_Localised":"Frag Grenade", 
"Category":"Consumable", "LockerOldCount":1, "LockerNewCount":0, "Direction":"ToBackpack" }, 
{ "Name":"amm_grenade_shield", "Name_Localised":"Shield Projector", "Category":"Consumable", "LockerOldCount":1, 
"LockerNewCount":0, "Direction":"ToBackpack" } ] }


     */
    public class TransferMicroResourcesEvent : JournalEvent<TransferMicroResourcesEvent.TransferMicroResourcesEventArgs>
    {
        public TransferMicroResourcesEvent() : base("TransferMicroResources") { }

        public class TransferMicroResourcesEventArgs : JournalEventArgs
        {
            public struct Transfer
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public string Category { get; set; }
                public int LockerOldCount { get; set; }
                public int LockerNewCount { get; set; }
                public string Direction { get; set; }
            }
            public Transfer[] Transfers { get; set; }

        }
    }
}
