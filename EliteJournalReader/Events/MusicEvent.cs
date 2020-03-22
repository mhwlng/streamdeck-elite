using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: when the game music 'mood' changes
    //Parameters:
    //•	MusicTrack: (name)

    //Possible track names are: NoTrack, MainMenu, CQCMenu, SystemMap, GalaxyMap, GalacticPowers
    //CQC, DestinationFromHyperspace, DestinationFromSupercruise, Supercruise, Combat_Unknown
    //Unknown_Encounter, CapitalShip, CombatLargeDogFight, Combat_Dogfight, Combat_SRV
    //Unknown_Settlement, DockingComputer, Starport, Unknown_Exploration, Exploration
    //Note: Other music track names may be used in future
    public class MusicEvent : JournalEvent<MusicEvent.MusicEventArgs>
    {
        public MusicEvent() : base("Music") { }

        public class MusicEventArgs : JournalEventArgs
        {
            public string MusicTrack { get; set; }
        }
    }
}
