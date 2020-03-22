using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when passing through the jet code from a white dwarf or neutron star has caused damage to a ship module
    //Parameters:
    //•	Module: the name of the module that has taken some damage
    public class JetConeDamageEvent : JournalEvent<JetConeDamageEvent.JetConeDamageEventArgs>
    {
        public JetConeDamageEvent() : base("JetConeDamage") { }

        public class JetConeDamageEventArgs : JournalEventArgs
        {
            public string Module { get; set; }
            public string Module_Localised { get; set; }
        }
    }
}
