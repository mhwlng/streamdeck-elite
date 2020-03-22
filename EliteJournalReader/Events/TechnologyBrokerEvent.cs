using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when using the Technology Broker to unlock new purchasable technology
    //Parameters:
    //•	BrokerType
    //•	MarketID
    //•	ItemsUnlocked: the name(s) of the new item unlocked(available in Outfitting)
    //•	Commodities:
    //o Name: name of item
    //o   Count: number of items used
    //•	Materials:
    //o Name
    //o Count
    //o Category
    public class TechnologyBrokerEvent : JournalEvent<TechnologyBrokerEvent.TechnologyBrokerEventArgs>
    {
        public TechnologyBrokerEvent() : base("TechnologyBroker") { }

        public class TechnologyBrokerEventArgs : JournalEventArgs
        {
            public string BrokerType { get; set; }
            public long MarketID { get; set; }
            public string ItemUnlocked { get; set; }
            public string ItemUnlocked_Localised { get; set; }
            public Commodity[] Commodities { get; set; }
            public Material[] Materials { get; set; }
        }
    }
}
