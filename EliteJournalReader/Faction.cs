using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteJournalReader
{
    public class Faction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public string Government_Localised { get; set; }
        public double Influence { get; set; }
        public string Allegiance { get; set; }
        public string MyReputation { get; set; }
        public bool SquadronFaction { get; set; } = false;
        public bool HappiestSystem { get; set; } = false;
        public bool HomeSystem { get; set; } = false;

        public FactionStateChange[] PendingStates { get; set; }
        public FactionStateChange[] RecoveringStates { get; set; }
        public FactionStateChange[] ActiveStates { get; set; }

        public override bool Equals(object obj) => Equals(obj as Faction);

        public bool Equals(Faction that) => that != null
            && that.Name?.Equals(Name) == true
            && that.FactionState?.Equals(FactionState) == true
            && that.Government?.Equals(Government) == true
            && that.Influence == Influence
            && that.Allegiance?.Equals(Allegiance) == true
            && that.MyReputation?.Equals(MyReputation) == true
            && that.SquadronFaction == SquadronFaction
            && that.HappiestSystem == HappiestSystem
            && that.HomeSystem == HomeSystem
            && that.PendingStates?.Equals(PendingStates) == true
            && that.RecoveringStates?.Equals(RecoveringStates) == true
            && that.ActiveStates?.Equals(ActiveStates) == true;

        public override int GetHashCode()
        {
            //https://stackoverflow.com/a/892640/3131828
            unchecked
            {
                int h = 23;
                h *= 31 + (Name?.GetHashCode() ?? 0);
                h *= 31 + (FactionState?.GetHashCode() ?? 0);
                h *= 31 + (Government?.GetHashCode() ?? 0);
                h *= 31 + Influence.GetHashCode();
                h *= 31 + (Allegiance?.GetHashCode() ?? 0);
                h *= 31 + (MyReputation?.GetHashCode() ?? 0);
                h *= 31 + SquadronFaction.GetHashCode();
                h *= 31 + HappiestSystem.GetHashCode();
                h *= 31 + HomeSystem.GetHashCode();
                h *= 31 + (PendingStates?.GetHashCode() ?? 0);
                h *= 31 + (RecoveringStates?.GetHashCode() ?? 0);
                h *= 31 + (ActiveStates?.GetHashCode() ?? 0);

                return h;
            }
        }

        public Faction Clone() => (Faction)MemberwiseClone();
    }

    public struct FactionStateChange
    {
        public string State { get; set; }
        public int Trend { get; set; }
    }
}
