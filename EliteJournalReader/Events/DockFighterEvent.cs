using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when docking a fighter back with the mothership
    //Parameters: none
    public class DockFighterEvent : JournalEvent<DockFighterEvent.DockFighterEventArgs>
    {
        public DockFighterEvent() : base("DockFighter") { }

        public class DockFighterEventArgs : JournalEventArgs
        {
            public long ID { get; set; }
        }
    }
}
