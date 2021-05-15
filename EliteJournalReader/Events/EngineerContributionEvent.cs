using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when offering items cash or bounties to an Engineer to gain access
    //Parameters:
    //•	Engineer: name of engineer
    //•	Type: type of contribution(Commodity, materials, Credits, Bond, Bounty)
    //•	Commodity
    //•	Material
    //•	Faction(for bond or bounty)
    //•	Quantity: amount offered this time
    //•	TotalQuantity: total amount now donated
    public class EngineerContributionEvent : JournalEvent<EngineerContributionEvent.EngineerContributionEventArgs>
    {
        public EngineerContributionEvent() : base("EngineerContribution") { }

        public class EngineerContributionEventArgs : JournalEventArgs
        {
            public string Engineer { get; set; }
            public string EngineerID { get; set; }
            public string Type { get; set; }
            public string Commodity { get; set; }
            public string Commodity_Localised { get; set; }
            public string Material { get; set; }
            public string Material_Localised { get; set; }
            public string Faction { get; set; }
            public int Quantity { get; set; }
            public int TotalQuantity { get; set; }
        }
    }
}
