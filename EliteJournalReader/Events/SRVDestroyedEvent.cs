using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the player's SRV is destroyed
    //Parameters: none
    public class SRVDestroyedEvent : JournalEvent<SRVDestroyedEvent.SRVDestroyedEventArgs>
    {
        public SRVDestroyedEvent() : base("SRVDestroyed") { }

        public class SRVDestroyedEventArgs : JournalEventArgs
        {
            public long ID { get; set; }
            public string SRVType { get; set; }
        }
    }
}
