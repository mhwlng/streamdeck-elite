using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class DropItemsEvent : JournalEvent<DropItemsEvent.DropItemsEventArgs>
    {
        public DropItemsEvent() : base("DropItems") { }

        public class DropItemsEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Type { get; set; }
            public string Type_Localised { get; set; }
            public long OwnerID { get; set; }
            public string MissionID { get; set; }
            public int Count { get; set; }
        }
    }
}
