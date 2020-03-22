using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class MaterialDiscoveredEvent : JournalEvent<MaterialDiscoveredEvent.MaterialDiscoveredEventArgs>
    {
        public MaterialDiscoveredEvent() : base("MaterialDiscovered") { }

        public class MaterialDiscoveredEventArgs : JournalEventArgs
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public int DiscoveryNumber { get; set; }
        }
    }
}
