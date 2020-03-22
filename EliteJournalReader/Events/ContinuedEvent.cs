using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: if the journal file grows to 500k lines, we write this event, close the file, and start a new one
    //Parameters:
    //•	Message: next part number
    public class ContinuedEvent : JournalEvent<ContinuedEvent.ContinuedEventArgs>
    {
        public ContinuedEvent() : base("Continued")
        {

        }

        internal override JournalEventArgs FireEvent(object sender, JObject evt)
        {
            var args = base.FireEvent(sender, evt);

            // a continued event signals that a new file is coming, so
            // let's start polling for it
            var watcher = sender as JournalWatcher;
            watcher?.StartPollingForNewJournal();

            return args;
        }

        public class ContinuedEventArgs : JournalEventArgs
        {
            public int Part { get; set; }
        }
    }
}
