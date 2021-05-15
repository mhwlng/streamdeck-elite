using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "BackPackMaterials" event contains:
    /*
     {"timestamp":"2021-03-31T21:32:03Z","event":"BackPackMaterials",
    "Items":[
    {"Name":"largecapacitypowerregulator",
     "Name_Localised":"Power Regulator",
     "OwnerID":6737826,
     "MissionID":737622845,
    "Count":1}],
    "Components":[],
    "Consumables":[]}
     */
    public class BackPackMaterialsEvent : JournalEvent<BackPackMaterialsEvent.BackPackMaterialsEventArgs>
    {
        public BackPackMaterialsEvent() : base("BackPackMaterials") { }

        public class BackPackMaterialsEventArgs : JournalEventArgs
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
