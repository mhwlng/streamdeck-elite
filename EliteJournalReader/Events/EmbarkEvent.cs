using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "Embark" event contains:

    /*
     {"timestamp":"2021-03-31T22:01:06Z","event":"Embark",
    "SRV":false,
    "Taxi":true,
    "Multicrew":false
    "ID": 0}
     */
    public class EmbarkEvent : JournalEvent<EmbarkEvent.EmbarkEventArgs>
    {
        public EmbarkEvent() : base("Embark") { }

        public class EmbarkEventArgs : JournalEventArgs
        {
            public bool SRV { get; set; }
            public bool Taxi { get; set; }
            public bool Multicrew { get; set; }

            public int ID { get; set; }

            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }

            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }

            public string StationName { get; set; }
            public string StationType { get; set; }
            public long MarketID { get; set; }

        }
    }
}
