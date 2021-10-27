using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when using SAA scanner on a planet or rings
    //Parameters:
    //�	SystemAddress
    //�	BodyName
    //�	BodyID
    //�	Signals: (array)
    //  o   Type
    //  o   Count
    public partial class SAASignalsFoundEvent : JournalEvent<SAASignalsFoundEvent.SAASignalsFoundEventArgs>
    {
        public SAASignalsFoundEvent() : base("SAASignalsFound") { }

        public class SAASignalsFoundEventArgs : JournalEventArgs
        {
            public long SystemAddress { get; set; }
            public string BodyName { get; set; }
            public long BodyID { get; set; }
            public SAASignal[] Signals { get; set; }
        }
    }
}
