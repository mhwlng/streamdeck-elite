using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: at startup(after Rank and Progress)
    //This gives the player's reputation (on a scale of -100..+100) with the superpowers
    //Parameters:
    //•	Empire
    //•	Federation
    //•	Independent
    //•	Alliance

    //Note thresholds:
    //-100.. -90: hostile
    //-90.. -35: unfriendly
    //-35..+ 4: neutral
    //+4..+35: cordial
    //+35..+90: friendly
    //+90..+100: allied

    public class ReputationEvent : JournalEvent<ReputationEvent.ReputationEventArgs>
    {
        public ReputationEvent() : base("Reputation") { }

        public class ReputationEventArgs : JournalEventArgs
        {
            public double Alliance { get; set; }
            public double Empire { get; set; }
            public double Federation { get; set; }
            public double Independent { get; set; }


            public ReputationStatus AllianceStatus => CalculateReputationStatus(Alliance);
            public ReputationStatus EmpireStatus => CalculateReputationStatus(Empire);
            public ReputationStatus FederationStatus => CalculateReputationStatus(Federation);
            public ReputationStatus IndependentStatus => CalculateReputationStatus(Independent);


            private ReputationStatus CalculateReputationStatus(double rep)
            {
                if (rep < -90) return ReputationStatus.Hostile;
                else if (rep < -35) return ReputationStatus.Unfriendly;
                else if (rep < 4) return ReputationStatus.Neutral;
                else if (rep < 35) return ReputationStatus.Cordial;
                else if (rep < 90) return ReputationStatus.Friendly;
                else return ReputationStatus.Allied;
            }
        }
    }
}
