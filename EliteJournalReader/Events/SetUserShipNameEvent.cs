using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when assigning a name to the ship in Starport Services
    //Parameters:
    //�	Ship: Ship model(eg CobraMkIII)
    //�	ShipID: player's ship ID number
    //�	UserShipName: selected name
    //�	UserShipId: selected ship id
    public class SetUserShipNameEvent : JournalEvent<SetUserShipNameEvent.SetUserShipNameEventArgs>
    {
        public SetUserShipNameEvent() : base("SetUserShipName") { }

        public class SetUserShipNameEventArgs : JournalEventArgs
        {
            public string Ship { get; set; }
            public string ShipID { get; set; }
            public string UserShipName { get; set; }
            public string UserShipId { get; set; }
        }
    }
}
