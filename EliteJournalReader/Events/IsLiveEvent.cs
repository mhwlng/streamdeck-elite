using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class IsLiveEvent : JournalEvent<IsLiveEvent.IsLiveEventArgs>
    {
        public IsLiveEvent() : base("MagicMau.IsLiveEvent") { }

        public class IsLiveEventArgs : JournalEventArgs
        {
        }
    }
}
