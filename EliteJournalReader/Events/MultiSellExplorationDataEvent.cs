using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when selling exploration data in Cartographics
    //Parameters:
    //•	Systems: JSON array of system names
    //•	Discovered: JSON array of discovered bodies
    //•	BaseValue: value of systems
    //•	Bonus: bonus for first discoveries
    //•	TotalEarnings: total credits received(including for example the 200% bonus if rank 5 with Li Yong Rui)
    public class MultiSellExplorationDataEvent : JournalEvent<MultiSellExplorationDataEvent.MultiSellExplorationDataEventArgs>
    {
        public MultiSellExplorationDataEvent() : base("MultiSellExplorationData") { }

        public class MultiSellExplorationDataEventArgs : JournalEventArgs
        {
            public SystemScan[] Discovered { get; set; }
            public long BaseValue { get; set; }
            public long Bonus { get; set; }
            public long TotalEarnings { get; set; }
        }
    }
}
