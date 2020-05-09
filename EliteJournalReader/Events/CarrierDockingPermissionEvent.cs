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
    //When written: If you should ever reset your game
    //Parameters:
    //•	Name: commander name
    public class CarrierDockingPermissionEvent : JournalEvent<CarrierDockingPermissionEvent.CarrierDockingPermissionEventArgs>
    {
        public CarrierDockingPermissionEvent() : base("CarrierDockingPermission") { }

        public class CarrierDockingPermissionEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string DockingAccess { get; set; }
            public bool AllowNotorious { get; set; }
        }
    }
}
