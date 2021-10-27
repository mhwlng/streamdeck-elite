using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class ScanOrganicEvent : JournalEvent<ScanOrganicEvent.ScanOrganicEventArgs>
    {
        public ScanOrganicEvent() : base("ScanOrganic") { }

        public class ScanOrganicEventArgs : JournalEventArgs
        {
            [JsonConverter(typeof(ExtendedStringEnumConverter<OrganicScanType>))]
            public OrganicScanType ScanType { get; set; }

            public string Genus { get; set; }
            public string Species { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }

        }
    }
}
