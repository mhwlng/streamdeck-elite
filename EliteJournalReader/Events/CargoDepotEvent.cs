using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when collecting or delivering cargo for a wing mission, or if a wing member updates progress
    //    Parameters:
    //•	MissionID:(int)
    //•	UpdateType:(string) (one of: "Collect", "Deliver", "WingUpdate")
    //•	CargoType
    //•	Count
    //•	StartMarketID(int)
    //•	EndMarketID(int)
    //•	ItemsCollected(int)
    //•	ItemsDelivered(int)
    //•	TotalItemsToDeliver(int)
    //•	Progress:(float)
    //The CargoType and Count are included when you collect or deliver gods, they are not included for a wing update.
    //The Progress value actually represents pending progress for goods in transit: (ItemsCollected-ItemsDelievered)/TotalItemsToDeliver

    public class CargoDepotEvent : JournalEvent<CargoDepotEvent.CargoDepotEventArgs>
    {
        public CargoDepotEvent() : base("CargoDepot") { }

        public class CargoDepotEventArgs : JournalEventArgs
        {
            public string MissionID { get; set; }
            public string UpdateType { get; set; }
            public string CargoType { get; set; }
            public string CargoType_Localised { get; set; }
            public int Count { get; set; }
            public long StartMarketID { get; set; }
            public long EndMarketID { get; set; }
            public int ItemsCollected { get; set; }
            public int ItemsDelivered { get; set; }
            public int TotalItemsToDeliver { get; set; }
            public double Progress { get; set; }
        }
    }
}
