using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "BuySuit" event contains:

    /*
     { "timestamp":"2021-04-10T12:13:43Z", "event":"BuySuit", "Name":"UtilitySuit_Class1", "Name_Localised":"Maverick Suit", "Price":150000 }
     */
    public class BuySuitEvent : JournalEvent<BuySuitEvent.BuySuitEventArgs>
    {
        public BuySuitEvent() : base("BuySuit") { }

        public class BuySuitEventArgs : JournalEventArgs
        { 
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public long Price { get; set; }

            public string SuitID { get; set; }
        }
    }
}
