using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    //When written: When owner opens carrier management
    //•	CarrierID: marketid
    //•	Callsign: string
    //•	Name: string
    //•	DockingAccess: all/none/friends/squadron/squadronfriends
    //•	AllowNotorious: bool
    //•	FuelLevel: int
    //•	JumpRangeCurr: float
    //•	JumpRangeMax: float
    //•	PendingDecommission: bool
    //•	SpaceUsage { TotalCapacity, Crew, Cargo, CargoSpaceReserved, ShipPacks, ModulePacks, FreeSpace
    //}
    //•	Finance { CarrierBalance, ReserveBalance, AvailableBalance, ReservePercent, TaxRate }
    //•	Crew[{ CrewRole, Activated, Enabled, CrewName },...]
    //•	ShipPacks[{ PackTheme, packTier },...]
    //•	ModulePacks[{PackTheme, packTier },...]
    public class CarrierStatsEvent : JournalEvent<CarrierStatsEvent.CarrierStatsEventArgs>
    {
        public CarrierStatsEvent() : base("CarrierStats") { }

        public class CarrierStatsEventArgs : JournalEventArgs
        {
            public long CarrierID { get; set; }
            public string Callsing { get; set; }
            public string Name { get; set; }
            public string DockingAccess { get; set; }
            public bool AllowNotorious { get; set; }
            public int FuelLevel { get; set; }
            public double JumpRangeCurr { get; set; }
            public double JumpRangeMax { get; set; }
            public bool PendingDecommission { get; set; }
            public CarrierSpaceUsage SpaceUsage { get; set; }
            public CarrierFinance Finance { get; set; }
            public CarrierCrew[] Crew { get; set; }
            public CarrierShipPack[] ShipPacks { get; set; }
            public CarrierModulePack[] ModulePacks { get; set; }
        }

        public struct CarrierSpaceUsage
        {
            public long TotalCapacity { get; set; }
            public long Crew { get; set; }
            public long Cargo { get; set; }
            public long CargoSpaceReserved { get; set; }
            public long ShipPacks { get; set; }
            public long ModulePacks { get; set; }
            public long FreeSpace { get; set; }
        }

        public struct CarrierFinance
        {
            public long CarrierBalance { get; set; }
            public long ReserveBalance { get; set; }
            public long AvailableBalance { get; set; }
            public double ReservePercent { get; set; }
            public double TaxRate { get; set; }
        }

        public struct CarrierCrew
        {
            public string CrewRole { get; set; }
            public bool Activated { get; set; }
            public bool Enabled { get; set; }
            public string Name { get; set; }
        }

        public struct CarrierShipPack
        {
            public string PackTheme { get; set; }
            public int PackTier { get; set; }
        }

        public struct CarrierModulePack
        {
            public string PackTheme { get; set; }
            public int PackTier { get; set; }
        }
    }
}
