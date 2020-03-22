using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when scooping fuel from a star
    //Parameters:
    //•	Scooped: tons fuel scooped
    //•	Total: total fuel level after scooping
    public class FuelScoopEvent : JournalEvent<FuelScoopEvent.FuelScoopEventArgs>
    {
        public FuelScoopEvent() : base("FuelScoop") { }

        public class FuelScoopEventArgs : JournalEventArgs
        {
            public double Scooped { get; set; }
            public double Total { get; set; }
        }
    }
}
