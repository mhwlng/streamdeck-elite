using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when dismissing a member of crew
    //Parameters:
    //�	Name
    public class CrewFireEvent : JournalEvent<CrewFireEvent.CrewFireEventArgs>
    {
        public CrewFireEvent() : base("CrewFire") { }

        public class CrewFireEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public long CrewID { get; set; }
        }
    }
}
