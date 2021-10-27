using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //    When written: after using the �Surface Area Analysis� scanner
    //    Parameters:
    //�	Bodyname
    //�	BodyID
    //�	ProbesUsed: (int)
    //�	EfficiencyTarget: (int)

    public class SAAScanCompleteEvent : JournalEvent<SAAScanCompleteEvent.SAAScanCompleteEventArgs>
    {
        public SAAScanCompleteEvent() : base("SAAScanComplete") { }

        public class SAAScanCompleteEventArgs : JournalEventArgs
        {
            public long SystemAddress { get; set; }
            public string BodyName { get; set; }
            public long BodyID { get; set; }
            public int ProbesUsed { get; set; }
            public int EfficiencyTarget { get; set; }
        }
    }
}
