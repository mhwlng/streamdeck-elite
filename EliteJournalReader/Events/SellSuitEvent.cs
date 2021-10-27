using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class SellSuitEvent : JournalEvent<SellSuitEvent.SellSuitEventArgs>
    {
        public SellSuitEvent() : base("SellSuit") { }

        public class SellSuitEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public long Price { get; set; }
            public long SuitID { get; set; }
            public string[] SuitMods { get; set; }
        }
    }
}
