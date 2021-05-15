using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the player’s rank increases
    //Parameters: one of the following
    //•	Combat: new rank
    //•	Trade: new rank
    //•	Explore: new rank
    //•	CQC: new rank
    public class PromotionEvent : JournalEvent<PromotionEvent.PromotionEventArgs>
    {
        public PromotionEvent() : base("Promotion") { }

        public class PromotionEventArgs : JournalEventArgs
        {
            public CombatRank? Combat { get; set; }
            public TradeRank? Trade { get; set; }
            public ExplorationRank? Explore { get; set; }
            public CQCRank? CQC { get; set; }
            public FederationRank? Federation { get; set; }
            public EmpireRank? Empire { get; set; }

            public SoldierRank? Soldier { get; set; }
            public ExobiologistRank? Exobiologist { get; set; }

        }
    }
}
