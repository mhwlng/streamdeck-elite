using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the player's ship has been repaired by a repair drone
    //Parameters:
    //•	HullRepaired
    //•	CockpitRepaired
    //•	CorrosionRepaired

    //Each of these is a number indicating the amount of damage that has been repaired
    public class RepairDroneEvent : JournalEvent<RepairDroneEvent.RepairDroneEventArgs>
    {
        public RepairDroneEvent() : base("RepairDrone") { }

        public class RepairDroneEventArgs : JournalEventArgs
        {
            public double? HullRepaired { get; set; }
            public double? CockpitRepaired { get; set; }
            public double? CorrosionRepaired { get; set; }
        }
    }
}
