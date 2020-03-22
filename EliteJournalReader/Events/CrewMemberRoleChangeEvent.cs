using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When another player joins your ship's crew
    //Parameters:
    //•	Crew: player's commander name
    //•	Role: selected role
    public class CrewMemberRoleChangeEvent : JournalEvent<CrewMemberRoleChangeEvent.CrewMemberRoleChangeEventArgs>
    {
        public CrewMemberRoleChangeEvent() : base("CrewMemberRoleChange") { }

        public class CrewMemberRoleChangeEventArgs : JournalEventArgs
        {
            public string Crew { get; set; }
            public int CrewID { get; set; }
            public string Role { get; set; }
        }
    }
}
