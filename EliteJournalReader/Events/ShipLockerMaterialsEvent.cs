using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "ShipLockerMaterials" event contains:
    /*
     {"timestamp":"2021-03-31T10:21:35Z","event":"ShipLockerMaterials",
    "Items":[
    {"Name":"suitschematic",
    "Name_Localised":"Suit Schematic",
    "OwnerID":0,
    "MissionID":18446744073709551615,
    "Count":1}],
    "Components":[],
    "Consumables":[
    {"Name":"amm_grenade_frag",
     "Name_Localised":"Frag Grenade",
     "OwnerID":0,
     "MissionID":18446744073709551615,
     "Count":9}
    ]}
     */
    public class ShipLockerMaterialsEvent : JournalEvent<ShipLockerMaterialsEvent.ShipLockerMaterialsEventArgs>
    {
        public ShipLockerMaterialsEvent() : base("ShipLockerMaterials") { }

        public class ShipLockerMaterialsEventArgs : JournalEventArgs
        {
            public struct Item
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public long OwnerID { get; set; }
                public string MissionID { get; set; }
                public int Count { get; set; }
            }
            public struct Component
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public long OwnerID { get; set; }
                public string MissionID { get; set; }
                public int Count { get; set; }
            }
            public struct Consumable
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public long OwnerID { get; set; }
                public string MissionID { get; set; }
                public int Count { get; set; }
            }
            public struct DataItem
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public long OwnerID { get; set; }
                public string MissionID { get; set; }
                public int Count { get; set; }
            }

            public Item[] Items { get; set; }
            public Component[] Components { get; set; }
            public Consumable[] Consumables { get; set; }
            public DataItem[] Data { get; set; }


        }
    }
}
