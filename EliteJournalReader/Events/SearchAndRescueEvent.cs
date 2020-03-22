using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when contributing materials to a "research" community goal
    //Parameters:
    //•	Name: material name
    //•	Category
    //•	Count
    public class SearchAndRescueEvent : JournalEvent<SearchAndRescueEvent.SearchAndRescueEventArgs>
    {
        public SearchAndRescueEvent() : base("SearchAndRescue") { }

        public class SearchAndRescueEventArgs : JournalEventArgs
        {
            public long MarketID { get; set; }
            public string Name { get; set; }            
            public int Count { get; set; }
            public int Reward { get; set; }
        }
    }
}
