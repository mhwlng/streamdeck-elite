using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when enough material has been collected from a solar jet code (at a white dwarf or neutron star) for a jump boost
    //Parameters:
    //•	BoostValue
    public class JetConeBoostEvent : JournalEvent<JetConeBoostEvent.JetConeBoostEventArgs>
    {
        public JetConeBoostEvent() : base("JetConeBoost") { }

        public class JetConeBoostEventArgs : JournalEventArgs
        {
            public double BoostValue { get; set; }
        }
    }
}
