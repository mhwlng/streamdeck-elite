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
    //When written: when using any type of drone/limpet
    //Parameters:
    //•	Type: one of: "Hatchbreaker", "FuelTransfer", "Collection", "Prospector", "Repair", "Research", "Decontamination"
    public class LaunchDroneEvent : JournalEvent<LaunchDroneEvent.LaunchDroneEventArgs>
    {
        public LaunchDroneEvent() : base("LaunchDrone") { }

        public class LaunchDroneEventArgs : JournalEventArgs
        {
            [JsonConverter(typeof(ExtendedStringEnumConverter<DroneType>))]
            public DroneType Type { get; set; }
        }
    }
}
