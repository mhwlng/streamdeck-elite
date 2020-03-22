using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: at startup
    //This line contains the information displayed in the statistics panel on the right side of the cockpit

    //Parameters:
    //•	Bank_Account
    //o   Current_Wealth Spent_On_Ships
    //o Spent_On_Outfitting Spent_On_Repairs
    //o   Spent_On_Fuel
    //o   Spent_On_Ammo_Consumables
    //o   Insurance_Claims
    //o   Spent_On_Insurance
    //•	Combat
    //o   Bounties_Claimed
    //o   Bounty_Hunting_Profit
    //o   Combat_Bonds
    //o   Combat_Bond_Profits
    //o   Assassinations
    //o   Assassination_Profits
    //o   Highest_Single_Reward
    //o   Skimmers_Killed 
    //•	Crime
    //o   Fines
    //o   Total_Fines
    //o   Bounties_Received
    //o   Total_Bounties
    //o   Highest_Bounty
    //•	Smuggling
    //o   Black_Markets_Traded_With
    //o   Black_Markets_Profits
    //o   Resources_Smuggled
    //o   Average_Profit
    //o   Highest_Single_Transaction 
    //•	Trading
    //o   Markets_Traded_With
    //o   Market_Profits
    //o   Resources_Traded
    //o   Average_Profit
    //o   Highest_Single_Transaction 
    //•	Mining
    //o   Mining_Profits
    //o   Quantity_Mined
    //o   Materials_Collected 
    //•	Exploration
    //o   Systems_Visited
    //o   Fuel_Scooped
    //o   Fuel_Purchased
    //o   Exploration_Profits
    //o   Planets_Scanned_To_Level_2
    //o   Planets_Scanned_To_Level_3
    //o   Highest_Payout
    //o   Total_Hyperspace_Distance
    //o   Total_Hyperspace_Jumps
    //o   Greatest_Distance_From_Start
    //o   Time_Played 
    //•	Passengers
    //o   Passengers_Missions_Bulk
    //o   Passengers_Missions_VIP
    //o   Passengers_Missions_Delivered
    //o   Passengers_Missions_Ejected 
    //•	Search_And_Rescue
    //o   SearchRescue_Traded
    //o   SearchRescue_Profit
    //o   SearchRescue_Count 
    //•	Crafting
    //o   Spent_On_Crafting
    //o   Count_Of_Used_Engineers
    //o   Recipes_Generated
    //o   Recipes_Generated_Rank_1
    //o   Recipes_Generated_Rank_2
    //o   Recipes_Generated_Rank_3
    //o   Recipes_Generated_Rank_4
    //o   Recipes_Generated_Rank_5
    //o   Recipes_Applied
    //o   Recipes_Applied_Rank_1
    //o   Recipes_Applied_Rank_2
    //o   Recipes_Applied_Rank_3
    //o   Recipes_Applied_Rank_4
    //o   Recipes_Applied_Rank_5
    //o   Recipes_Applied_On_Previously_Modified_Modules 
    //•	Crew
    //o   NpcCrew_TotalWages
    //o   NpcCrew_Hired
    //o   NpcCrew_Fired
    //o   NpcCrew_Died
    //•	Multicrew
    //o   Multicrew_Time_Total
    //o   Multicrew_Gunner_Time_Total
    //o   Multicrew_Fighter_Time_Total
    //o   Multicrew_Credits_Total
    //o   Multicrew_Fines_Total

    //Note times are in seconds
    public class StatisticsEvent : JournalEvent<StatisticsEvent.StatisticsEventArgs>
    {
        public StatisticsEvent() : base("Statistics") { }

        public class StatisticsEventArgs : JournalEventArgs
        {
            public BankAccount Bank_Account { get; set; }
            public Combat Combat { get; set; }
            public Crime Crime { get; set; }
            public Smuggling Smuggling { get; set; }
            public Trading Trading { get; set; }
            public Mining Mining { get; set; }
            public Exploration Exploration { get; set; }
            public Passengers Passengers { get; set; }
            public SearchAndRescue Search_And_Rescue { get; set; }
            public Crafting Crafting { get; set; }
            public Crew Crew { get; set; }
            public Multicrew Multicrew { get; set; }
            public ThargoidEncounters TG_Encounters { get; set; }
            public CQC CQC { get; set; }
            public MaterialsTrader Material_Trader_Stats { get; set; }
        }

        public struct BankAccount
        {
            public long Current_Wealth_Spent_On_Ships { get; set; }
            public long Spent_On_Outfitting { get; set; }
            public long Spent_On_Repairs { get; set; }
            public long Spent_On_Fuel { get; set; }
            public long Spent_On_Ammo_Consumables { get; set; }
            public long Insurance_Claims { get; set; }
            public long Spent_On_Insurance { get; set; }
        }

        public struct Combat
        {
            public long Bounties_Claimed { get; set; }
            public long Bounty_Hunting_Profit { get; set; }
            public long Combat_Bonds { get; set; }
            public long Combat_Bonds_Profits { get; set; }
            public long Assassinations { get; set; }
            public long Assassinations_Profits { get; set; }
            public long Highest_Single_Reward { get; set; }
            public long Skimmers_Killed { get; set; }
        }

        public struct Crime
        {
            public long Fines { get; set; }
            public long Total_Fines { get; set; }
            public long Bounties_Received { get; set; }
            public long Total_Bounties { get; set; }
            public long Highest_Bounty { get; set; }
        }

        public struct Smuggling
        {
            public long Black_Markets_Traded_With { get; set; }
            public long Black_Markets_Profit { get; set; }
            public long Resources_Smuggled { get; set; }
            public double Average_Profit { get; set; }
            public long Highest_Single_Transaction { get; set; }
        }

        public struct Trading
        {
            public long Markets_Traded_With { get; set; }
            public long Markets_Profits { get; set; }
            public long Resources_Traded { get; set; }
            public double Average_Profit { get; set; }
            public long Highest_Single_Transaction { get; set; }
        }

        public struct Mining
        {
            public long Mining_Profits { get; set; }
            public long Quantity_Mined { get; set; }
            public long Materials_Collected { get; set; }
        }

        public struct Exploration
        {
            public long Systems_Visited { get; set; }
            public double Fuel_Scooped { get; set; }
            public double Fuel_Purchased { get; set; }
            public long Planets_Scanned_To_Level_2 { get; set; }
            public long Planets_Scanned_To_Level_3 { get; set; }
            public long Highest_Payout { get; set; }
            public long Total_Hyperspace_Distance { get; set; }
            public long Total_Hyperspace_Jumps { get; set; }
            public double Greatest_Distance_From_Start { get; set; }
            public long Time_Played { get; set; }
        }

        public struct Passengers
        {
            public long Passengers_Missions_Bulk { get; set; }
            public long Passengers_Missions_VIP { get; set; }
            public long Passengers_Missions_Delivered { get; set; }
            public long Passengers_Missions_Ejected { get; set; }
        }

        public struct SearchAndRescue
        {
            public long SearchRescue_Traded { get; set; }
            public long SearchRescue_Profit { get; set; }
            public long SearchResuce_Count { get; set; }
        }

        public struct ThargoidEncounters
        {
            public long TG_Encounter_Wakes { get; set; }
        }

        public struct Crafting
        {
            public long Spent_On_Crafting { get; set; }
            public long Count_Of_Used_Engineers { get; set; }
            public long Recipes_Generated { get; set; }
            public long Recipes_Generated_Rank_1 { get; set; }
            public long Recipes_Generated_Rank_2 { get; set; }
            public long Recipes_Generated_Rank_3 { get; set; }
            public long Recipes_Generated_Rank_4 { get; set; }
            public long Recipes_Generated_Rank_5 { get; set; }
            public long Recipes_Applied { get; set; }
            public long Recipes_Applied_Rank_1 { get; set; }
            public long Recipes_Applied_Rank_2 { get; set; }
            public long Recipes_Applied_Rank_3 { get; set; }
            public long Recipes_Applied_Rank_4 { get; set; }
            public long Recipes_Applied_Rank_5 { get; set; }
            public long Recipes_Applied_On_Previously_Modified_Modules { get; set; }
        }

        public struct Crew
        {
            public long NpcCrew_TotalWages { get; set; }
            public long NpcCrew_Hired { get; set; }
            public long NpcCrew_Fired { get; set; }
            public long NpcCrew_Died { get; set; }
        }

        public struct Multicrew
        {
            public long Multicrew_Time_Total { get; set; }
            public long Multicrew_Gunner_Time_Total { get; set; }
            public long Multicrew_Fighter_Time_Total { get; set; }
            public long Multicrew_Credits_Total { get; set; }
            public long Multicrew_Fines_Total { get; set; }
        }

        public struct CQC
        {
            public long CQC_Credits_Earned { get; set; }
            public long CQC_Time_Played { get; set; }
            public double CQC_KD { get; set; }
            public long CQC_Kills { get; set; }
            public double CQC_WL { get; set; }
        }

        public struct MaterialsTrader
        {
            public long Trades_Completed { get; set; }
            public long Materials_Traded { get; set; }
        }
    }
}
