using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //The "BookTaxi" event contains:

    /*
     {"timestamp":"2021-03-31T22:00:17Z","event":"BookTaxi",
    "Cost":100,
    "DestinationSystem":"Adityan",
    "DestinationLocation":"Konscak Penal colony"}
     */
    public class BookTaxiEvent : JournalEvent<BookTaxiEvent.BookTaxiEventArgs>
    {
        public BookTaxiEvent() : base("BookTaxi") { }

        public class BookTaxiEventArgs : JournalEventArgs
        {
            public long Cost { get; set; }
            public string DestinationSystem { get; set; }
            public string DestinationLocation { get; set; }
        }
    }
}
