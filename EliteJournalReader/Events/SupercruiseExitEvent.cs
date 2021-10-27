using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: leaving supercruise for normal space
    //Parameters:
    //•	Starsystem
    //•	Body
    public class SupercruiseExitEvent : JournalEvent<SupercruiseExitEvent.SupercruiseExitEventArgs>
    {
        public SupercruiseExitEvent() : base("SupercruiseExit") { }

        public class SupercruiseExitEventArgs : JournalEventArgs
        {
            public bool Taxi { get; set; }
            public bool Multicrew { get; set; }

            public long  SystemAddress { get; set; }
            public string StarSystem { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<BodyType>))]
            public BodyType BodyType { get; set; }
        }
    }
}
