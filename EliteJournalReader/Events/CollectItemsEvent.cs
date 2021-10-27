using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class CollectItemsEvent : JournalEvent<CollectItemsEvent.CollectItemsEventArgs>
    {
        public CollectItemsEvent() : base("CollectItems") { }

        public class CollectItemsEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public long OwnerID { get; set; }
            public int Count { get; set; }
            public bool Stolen { get; set; }
        }
    }
}
