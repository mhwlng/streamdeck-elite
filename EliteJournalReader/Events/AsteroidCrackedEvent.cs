using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //    When written: when the player has broken up a ‘Motherlode’ asteroid for mining
    //    Parameters:
    //•	Body: name of nearest body
    public class AsteroidCrackedEvent : JournalEvent<AsteroidCrackedEvent.AsteroidCrackedEventArgs>
    {
        public AsteroidCrackedEvent() : base("AsteroidCracked") { }

        public class AsteroidCrackedEventArgs : JournalEventArgs
        {
            public string Body { get; set; }
        }
    }
}
