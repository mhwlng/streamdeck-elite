using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when purchasing ammunition
    //Parameters:
    //•	Cost
    public class BuyAmmoEvent : JournalEvent<BuyAmmoEvent.BuyAmmoEventArgs>
    {
        public BuyAmmoEvent() : base("BuyAmmo") { }

        public class BuyAmmoEventArgs : JournalEventArgs
        {
            public int Cost { get; set; }
        }
    }
}
