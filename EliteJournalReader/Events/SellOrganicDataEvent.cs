using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class SellOrganicDataEvent : JournalEvent<SellOrganicDataEvent.SellOrganicDataEventArgs>
    {
        public SellOrganicDataEvent() : base("SellOrganicData") { }

        public class SellOrganicDataEventArgs : JournalEventArgs
        {
            public class BioDataItem
            {
                public string Genus { get; set; }
                public string Species { get; set; }
                public long Value { get; set; }
                public long Bonus { get; set; }
            }

            public long MarketID { get; set; }
            public BioDataItem [] BioData { get; set; }
        }
    }
}
