using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: Creating a new commander
    //Parameters:
    //•	Name: (new) commander name
    //•	Package: selected starter package
    public class NewCommanderEvent : JournalEvent<NewCommanderEvent.NewCommanderEventArgs>
    {
        public NewCommanderEvent() : base("NewCommander") { }

        public class NewCommanderEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public string Package { get; set; }
        }
    }
}
