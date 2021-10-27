using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class BookDropshipEvent : JournalEvent<BookDropshipEvent.BookDropshipEventArgs>
    {
        public BookDropshipEvent() : base("BookDropship") { }

        public class BookDropshipEventArgs : JournalEventArgs
        {
            public long Cost { get; set; }

            public string DestinationSystem { get; set; }

            public string DestinationLocation { get; set; }
        }
    }
}
