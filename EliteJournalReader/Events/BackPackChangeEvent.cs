using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{

    public class BackPackChangeEvent : JournalEvent<BackPackChangeEvent.BackPackChangeEventArgs>
    {
        public BackPackChangeEvent() : base("BackpackChange") { }

        public class BackPackChangeEventArgs : JournalEventArgs
        {
            public struct Item
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public long OwnerID { get; set; }
                public string MissionID { get; set; }
                public int Count { get; set; }
                public string Type { get; set; }
            }

            public Item[] Added { get; set; }
            public Item[] Removed { get; set; }

        }
    }
}
