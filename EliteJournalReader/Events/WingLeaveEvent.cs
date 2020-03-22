using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: this player has left a wing
    //Parameters: none
    public class WingLeaveEvent : JournalEvent<WingLeaveEvent.WingLeaveEventArgs>
    {
        public WingLeaveEvent() : base("WingLeave") { }

        public class WingLeaveEventArgs : JournalEventArgs
        {
        }
    }
}
