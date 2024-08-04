using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When the current plotted nav route is cleared
    public class NavRouteClearEvent : JournalEvent<NavRouteClearEvent.NavRouteClearEventArgs>
    {
        public NavRouteClearEvent() : base("NavRouteClear") { }

        public class NavRouteClearEventArgs : JournalEventArgs
        {
        }
    }
}
