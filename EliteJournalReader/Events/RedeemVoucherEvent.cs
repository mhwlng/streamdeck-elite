using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When Written: when claiming payment for combat bounties and bonds
    //Parameters:
    //•	Type
    //•	Amount
    public class RedeemVoucherEvent : JournalEvent<RedeemVoucherEvent.RedeemVoucherEventArgs>
    {
        public RedeemVoucherEvent() : base("RedeemVoucher") { }

        public class RedeemVoucherEventArgs : JournalEventArgs
        {
            public struct FactionAmount
            {
                public string Faction;
                public int Amount;
            }

            public string Type { get; set; }
            public int Amount { get; set; }
            public string Faction { get; set; }
            public double? BrokerPercentage { get; set; }
            public FactionAmount[] Factions { get; set; }
        }
    }
}
