using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when synthesis is used to repair or rearm
    //Parameters:
    //•	Name: synthesis blueprint
    //•	Materials: JSON object listing materials used and quantities
    public class SynthesisEvent : JournalEvent<SynthesisEvent.SynthesisEventArgs>
    {
        public SynthesisEvent() : base("Synthesis") { }

        public class SynthesisEventArgs : JournalEventArgs
        {
            public string Name { get; set; }
            public Material[] Materials { get; set; }
        }
    }
}
