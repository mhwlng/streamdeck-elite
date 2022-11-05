using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: If you should ever reset your game
    //Parameters:
    //Name: commander name
    //Telepresence: (bool) (only from Odyssey build)
    public class ChangeCrewRoleEvent : JournalEvent<ChangeCrewRoleEvent.ChangeCrewRoleEventArgs>
    {
        public ChangeCrewRoleEvent() : base("ChangeCrewRole") { }

        public class ChangeCrewRoleEventArgs : JournalEventArgs
        {
            public RoleType Role { get; set; }
            public bool Telepresence { get; set; }
        }

        public enum RoleType
        {
            Unknown,
            Idle,
            FireCon,
            FighterCon
        }
    }
}
