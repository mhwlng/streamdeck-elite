using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class ProspectedAsteroidEvent : JournalEvent<ProspectedAsteroidEvent.ProspectedAsteroidEventArgs>
    {
        public ProspectedAsteroidEvent() : base("ProspectedAsteroid") { }

        public class ProspectedAsteroidEventArgs : JournalEventArgs
        {
            public ScanItemComponent[] Materials { get; set; }
            public string Content { get; set; }
            public string MotherlodeMaterial { get; set; }
            public double Percentage { get; set; }
        }
    }
}
