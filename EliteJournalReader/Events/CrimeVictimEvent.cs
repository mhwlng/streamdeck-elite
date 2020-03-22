using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when a crime is recorded against the player
    //Parameters:
    //•	CrimeType
    //•	Faction
    //Optional parameters (depending on crime)
    //•	Victim
    //•	Fine
    //•	Bounty
    public class CrimeVictimEvent : JournalEvent<CrimeVictimEvent.CrimeVictimEventArgs>
    {
        public CrimeVictimEvent() : base("CrimeVictim") { }

        public class CrimeVictimEventArgs : JournalEventArgs
        {
            public string Offender { get; set; }
            public string Offender_Localised { get; set; }
            public string CrimeType { get; set; }
            public string CrimeType_Localised { get; set; }
            public int? Fine { get; set; }
            public int? Bounty { get; set; }
        }
    }
}