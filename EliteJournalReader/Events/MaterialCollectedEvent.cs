using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: whenever materials are collected 
    //Parameters: 
    //•	Category: type of material (Raw/Encoded/Manufactured)
    //•	Name: name of material
    public class MaterialCollectedEvent : JournalEvent<MaterialCollectedEvent.MaterialCollectedEventArgs>
    {
        public MaterialCollectedEvent() : base("MaterialCollected") { }

        public class MaterialCollectedEventArgs : JournalEventArgs
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }
    }
}
