using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class DropShipDeployEvent : JournalEvent<DropShipDeployEvent.DropShipDeployEventArgs>
    {
        public DropShipDeployEvent() : base("DropShipDeploy") { }

        public class DropShipDeployEventArgs : JournalEventArgs
        {
            public string StarSystem { get; set; }
            public long SystemAddress { get; set; }
            public string Body { get; set; }
            public long BodyID { get; set; }
            public bool OnStation { get; set; }
            public bool OnPlanet { get; set; }
        }
    }
}
