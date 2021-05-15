using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "SellOrganicData" event contains:

    /*
     */
    public class SellOrganicDataEvent : JournalEvent<SellOrganicDataEvent.SellOrganicDataEventArgs>
    {
        public SellOrganicDataEvent() : base("SellOrganicData") { }

        public class SellOrganicDataEventArgs : JournalEventArgs
        {
            public class BioDateItem
            {
                public string Genus { get; set; }
                public string Species { get; set; }
                public long Value { get; set; }
                public long Bonus { get; set; }
            }

            public long MarketID { get; set; }
            public BioDateItem [] BioData { get; set; }

        }
    }
}
