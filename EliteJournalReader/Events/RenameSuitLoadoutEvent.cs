using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class RenameSuitLoadoutEvent : JournalEvent<RenameSuitLoadoutEvent.RenameSuitLoadoutEventArgs>
    {
        public RenameSuitLoadoutEvent() : base("RenameSuitLoadout") { }

        public class RenameSuitLoadoutEventArgs : JournalEventArgs
        {
            public string SuitID { get; set; }
            public string SuitName { get; set; }
            public string LoadoutID { get; set; }
            public string Loadoutname { get; set; }

        }
    }
}
