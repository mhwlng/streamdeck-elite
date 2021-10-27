using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class LoadGameEvent : JournalEvent<LoadGameEvent.LoadGameEventArgs>
    {
        //When written: at startup, when loading from main menu into game
        //Parameters:
        //�	Commander: commander name
        //�	Horizons: bool
        //�	Ship: current ship type
        //�	ShipID: ship id number
        //�	StartLanded: true (only present if landed)
        //�	StartDead:true (only present if starting dead: see �Resurrect�)
        //�	GameMode: Open, Solo or Group
        //�	Group: name of group (if in a group)
        //�	Credits: current credit balance
        //�	Loan: current loan
        //�	ShipName: user-defined ship name
        //�	ShipIdent: user-defined ship ID string
        //�	FuelLevel: current fuel 
        //�	FuelCapacity: size of main tank

        public LoadGameEvent() : base("LoadGame") { }

        public class LoadGameEventArgs : JournalEventArgs
        {
            public string Commander { get; set; }
            public string FID { get; set; }
            public bool Horizons { get; set; }
            public bool Odyssey { get; set; }
            public string Ship { get; set; }
            public string ShipID { get; set; }
            public string Ship_Localised { get; set; }
            public bool StartLanded { get; set; } = false;
            public bool StartDead { get; set; } = false;

            [JsonConverter(typeof(ExtendedStringEnumConverter<GameMode>))]
            public GameMode GameMode { get; set; }

            public string Group { get; set; }
            public long Credits { get; set; }
            public int Loan { get; set; }
            public string ShipName { get; set; }
            public string ShipIdent { get; set; }
            public double FuelLevel { get; set; }
            public double FuelCapacity { get; set; }

            public string Language { get; set; }
            public string Gameversion { get; set; }
            public string Build { get; set; }
        }
    }
}
