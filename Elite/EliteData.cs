using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EliteJournalReader;
using EliteJournalReader.Events;


namespace Elite
{
    public class EliteData
    {

        public static bool UnderAttack = false;
        public static DateTime LastUnderAttackEvent = DateTime.Now;
        public static string FsdTargetName { get; set; }
        public static int RemainingJumpsInRoute { get; set; }
        public static string StarSystem { get; set; }
        public static int LimpetCount { get; set; } 

        public class Status
        {
            public bool Docked { get; set; }
            public bool Landed { get; set; }
            public bool LandingGearDown { get; set; }
            public bool ShieldsUp { get; set; }
            public bool Supercruise { get; set; }
            public bool FlightAssistOff { get; set; }
            public bool HardpointsDeployed { get; set; }
            public bool InWing { get; set; }
            public bool LightsOn { get; set; }
            public bool CargoScoopDeployed { get; set; }
            public bool SilentRunning { get; set; }
            public bool ScoopingFuel { get; set; }
            public bool SrvHandbrake { get; set; }
            public bool SrvTurret { get; set; }
            public bool SrvUnderShip { get; set; }
            public bool SrvDriveAssist { get; set; }
            public bool FsdMassLocked { get; set; }
            public bool FsdCharging { get; set; }
            public bool FsdCooldown { get; set; }
            public bool LowFuel { get; set; }
            public bool Overheating { get; set; }
            public bool HasLatLong { get; set; }
            public bool IsInDanger { get; set; }
            public bool BeingInterdicted { get; set; }
            public bool InMainShip { get; set; }
            public bool InFighter { get; set; }
            public bool InSRV { get; set; }
            public bool HudInAnalysisMode { get; set; }
            public bool NightVision { get; set; }
            public bool AltitudeFromAverageRadius { get; set; }
            public bool FsdJump { get; set; }
            public bool SrvHighBeam { get; set; }

            public StatusFuel Fuel { get; set; } = new StatusFuel();

            public double FuelCapacity { get; set; }

            public double Cargo { get; set; }
            public string LegalState { get; set; }
            public double JumpRange { get; set; }

            public int Firegroup { get; set; }
            public string GuiFocus { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public double Altitude { get; set; }
            public double Heading { get; set; }
            public string BodyName { get; set; }
            public double PlanetRadius { get; set; }


            public int[] Pips { get; set; } = new int[3];
        }

        public static Status StatusData = new Status();

        public static void HandleCargoEvents(object sender, CargoEvent.CargoEventArgs evt)
        {
            if (evt?.Inventory != null && evt?.Vessel == "Ship")
            {
                EliteData.LimpetCount =
                  evt.Inventory.Where(x => x.Name.ToLower().Contains("drones")).Sum(x => x.Count);
            }
        }

        public static void HandleStatusEvents(object sender, StatusFileEvent evt)
        {
            StatusData.ShieldsUp = (evt.Flags & StatusFlags.ShieldsUp) != 0;
            StatusData.FlightAssistOff = (evt.Flags & StatusFlags.FlightAssistOff) != 0;
            StatusData.InWing = (evt.Flags & StatusFlags.InWing) != 0;
            StatusData.LightsOn = (evt.Flags & StatusFlags.LightsOn) != 0;
            StatusData.NightVision = (evt.Flags & StatusFlags.NightVision) != 0;
            StatusData.AltitudeFromAverageRadius = (evt.Flags & StatusFlags.AltitudeFromAverageRadius) != 0;
            StatusData.LowFuel = (evt.Flags & StatusFlags.LowFuel) != 0;
            StatusData.Overheating = (evt.Flags & StatusFlags.Overheating) != 0;
            StatusData.HasLatLong = (evt.Flags & StatusFlags.HasLatLong) != 0;
            StatusData.InMainShip = (evt.Flags & StatusFlags.InMainShip) != 0;
            StatusData.InFighter = (evt.Flags & StatusFlags.InFighter) != 0;
            StatusData.InSRV = (evt.Flags & StatusFlags.InSRV) != 0;
            StatusData.SrvDriveAssist = (evt.Flags & StatusFlags.SrvDriveAssist) != 0 && StatusData.InSRV;
            StatusData.SrvUnderShip = (evt.Flags & StatusFlags.SrvUnderShip) != 0 && StatusData.InSRV;
            StatusData.SrvTurret = (evt.Flags & StatusFlags.SrvTurret) != 0 && StatusData.InSRV;
            StatusData.SrvHandbrake = (evt.Flags & StatusFlags.SrvHandbrake) != 0 && StatusData.InSRV;
            StatusData.SrvHighBeam = (evt.Flags & StatusFlags.SrvHighBeam) != 0 && StatusData.InSRV;

            StatusData.Docked = (evt.Flags & StatusFlags.Docked) != 0;
            StatusData.Landed = (evt.Flags & StatusFlags.Landed) != 0;
            StatusData.LandingGearDown = (evt.Flags & StatusFlags.LandingGearDown) != 0;
            StatusData.CargoScoopDeployed = (evt.Flags & StatusFlags.CargoScoopDeployed) != 0;
            StatusData.SilentRunning = (evt.Flags & StatusFlags.SilentRunning) != 0;
            StatusData.ScoopingFuel = (evt.Flags & StatusFlags.ScoopingFuel) != 0;
            StatusData.IsInDanger = (evt.Flags & StatusFlags.IsInDanger) != 0;
            StatusData.BeingInterdicted = (evt.Flags & StatusFlags.BeingInterdicted) != 0;
            StatusData.HudInAnalysisMode = (evt.Flags & StatusFlags.HudInAnalysisMode) != 0;

            StatusData.FsdMassLocked = (evt.Flags & StatusFlags.FsdMassLocked) != 0;
            StatusData.FsdCharging = (evt.Flags & StatusFlags.FsdCharging) != 0;
            StatusData.FsdCooldown = (evt.Flags & StatusFlags.FsdCooldown) != 0;

            StatusData.Supercruise = (evt.Flags & StatusFlags.Supercruise) != 0;
            StatusData.FsdJump = (evt.Flags & StatusFlags.FsdJump) != 0;
            StatusData.HardpointsDeployed = (evt.Flags & StatusFlags.HardpointsDeployed) != 0 && !StatusData.Supercruise && !StatusData.FsdJump;

            StatusData.Fuel = evt.Fuel ?? new StatusFuel();

            StatusData.Cargo = evt.Cargo;

            StatusData.LegalState = evt.LegalState;

            StatusData.Firegroup = evt.Firegroup;
            StatusData.GuiFocus = evt.GuiFocus.ToString();
            StatusData.Latitude = evt.Latitude;
            StatusData.Longitude = evt.Longitude;
            StatusData.Altitude = evt.Altitude;
            StatusData.Heading = evt.Heading;
            StatusData.BodyName = evt.BodyName;
            StatusData.PlanetRadius = evt.PlanetRadius;

            StatusData.Pips[0] = evt.Pips.System;
            StatusData.Pips[1] = evt.Pips.Engine;
            StatusData.Pips[2] = evt.Pips.Weapons;


        }


        public static void HandleEliteEvents(object sender, JournalEventArgs e)
        {
            var evt = ((JournalEventArgs) e).OriginalEvent.Value<string>("event");

            if (string.IsNullOrWhiteSpace(evt))
            {
                return;
            }

            switch (evt)
            {
                case "Location":
                    //When written: at startup, or when being resurrected at a station

                    var locationInfo = (LocationEvent.LocationEventArgs) e;

                    EliteData.StarSystem = locationInfo.StarSystem;
                    break;

                case "ApproachBody":
                    //    When written: when in Supercruise, and distance from planet drops to within the 'Orbital Cruise' zone
                    var approachBodyInfo = (ApproachBodyEvent.ApproachBodyEventArgs)e;

                    EliteData.StarSystem = approachBodyInfo.StarSystem;
                    break;

                case "LeaveBody":
                    //When written: when flying away from a planet, and distance increases above the 'Orbital Cruise' altitude
                    var leaveBodyInfo = (LeaveBodyEvent.LeaveBodyEventArgs)e;

                    EliteData.StarSystem = leaveBodyInfo.StarSystem;
                    break;

                case "Docked":
                    //    When written: when landing at landing pad in a space station, outpost, or surface settlement
                    var dockedInfo = (DockedEvent.DockedEventArgs)e;

                    EliteData.StarSystem = dockedInfo.StarSystem;
                    break;

                case "FSDJump":
                    //When written: when jumping from one star system to another
                    var fsdJumpInfo = (FSDJumpEvent.FSDJumpEventArgs)e;

                    EliteData.StarSystem = fsdJumpInfo.StarSystem;
                    break;

                case "SupercruiseExit":
                    //When written: leaving supercruise for normal space
                    var supercruiseExitInfo = (SupercruiseExitEvent.SupercruiseExitEventArgs)e;

                    EliteData.StarSystem = supercruiseExitInfo.StarSystem;
                    break;

                case "FSDTarget":
                    //When written: when selecting a star system to jump to
                    var fSdTargetInfo = (FSDTargetEvent.FSDTargetEventArgs)e;

                    EliteData.FsdTargetName = fSdTargetInfo.Name;

                    EliteData.RemainingJumpsInRoute = fSdTargetInfo.RemainingJumpsInRoute;

                    break;

                case "UnderAttack":
                    //    When written: when under fire(same time as the Under Attack voice message)

                    var underAttackInfo = (UnderAttackEvent.UnderAttackEventArgs)e;

                    if (underAttackInfo.Target == "You")
                    {
                        EliteData.UnderAttack = true;
                        EliteData.LastUnderAttackEvent = DateTime.Now;
                    }

                    break;

                case "Cargo":

                    var cargoInfo = (CargoEvent.CargoEventArgs)e;
                    /*
                    if (cargoInfo.Vessel == "Ship")
                    {
                        if (cargoInfo.Inventory == null)
                        {
                            cargoInfo = Program.JournalWatcher.ReadCargoJson();
                        }

                        if (cargoInfo.Inventory != null)
                        {
                            EliteData.LimpetCount =
                              cargoInfo.Inventory.Where(x => x.Name.ToLower().Contains("drones")).Sum(x => x.Count);
                        }
                    }
                    */
                    break;

                case "Died":

                    var diedInfo = (DiedEvent.DiedEventArgs)e;

                    EliteData.LimpetCount = 0;

                    break;

            }

        }
    }

}