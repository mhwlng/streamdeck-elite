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
    public class CarrierCrewServicesEvent : JournalEvent<CarrierCrewServicesEvent.CarrierCrewServicesEventArgs>
    {
        public CarrierCrewServicesEvent() : base("CarrierCrewServices") { }

        public class CarrierCrewServicesEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string Operation { get; set; }
            public string CrewRole { get; set; }
            public string CrewName { get; set; }
        }
    }
}
