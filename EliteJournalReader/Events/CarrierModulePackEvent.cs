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
    public class CarrierModulePackEvent : JournalEvent<CarrierModulePackEvent.CarrierModulePackEventArgs>
    {
        public CarrierModulePackEvent() : base("CarrierModulePack") { }

        public class CarrierModulePackEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string Operation { get; set; }
            public string PackTheme { get; set; }
            public int PackTier { get; set; }
            public long Cost { get; set; }
            public long Refund { get; set; }
        }
    }
}
