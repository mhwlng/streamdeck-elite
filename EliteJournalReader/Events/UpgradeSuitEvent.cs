using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class UpgradeSuitEvent : JournalEvent<UpgradeSuitEvent.UpgradeSuitEventArgs>
    {
        public UpgradeSuitEvent() : base("UpgradeSuit") { }

        public class UpgradeSuitEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string SuitID { get; set; }
            public string Class { get; set; }

            public long Cost { get; set; }
        }
    }
}
