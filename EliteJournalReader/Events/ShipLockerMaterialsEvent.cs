using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
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
