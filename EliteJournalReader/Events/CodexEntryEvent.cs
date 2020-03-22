using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when a new discovery is added to the Codex
    //Parameters:
    //•	EntryID: an ID number
    //•	Name: string (+localisation)
    //•	SubCategory: string (+localisation)
    //•	Category: string (+localisation)
    //•	Region: string
    //•	System: string
    //•	SystemAddress
    //•	NearestDestination: name
    //•	IsNewEntry: bool
    //•	NewTraitsDiscovered: bool
    //•	Traits: [array of strings]
    //
    //The IsNewEntry and NewTraitsDiscovered fields are optional depending on the results of the scan, 
    //and the Traits field is only available for entries that have unlocked traits.
    public class CodexEntryEvent : JournalEvent<CodexEntryEvent.CodexEntryEventArgs>
    {
        public CodexEntryEvent() : base("CodexEntry") { }

        public class CodexEntryEventArgs : JournalEventArgs
        {
            public long EntryID { get; set; }
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string SubCategory { get; set; }
            public string SubCategory_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public string Region { get; set; }
            public string System { get; set; }
            public long SystemAddress { get; set; }
            public string NearestDestination { get; set; }
            public string NearestDestination_Localised { get; set; }
            public bool IsNewEntry { get; set; } = false;
            public bool NewTraitsDiscovered { get; set; } = false;
            public string[] Traits { get; set; }
        }
    }
}
