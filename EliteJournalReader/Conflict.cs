using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteJournalReader
{
    public class Conflict
    {
        public string WarType { get; set; }
        public string Status { get; set; }
        public ConflictFaction Faction1 { get; set; }
        public ConflictFaction Faction2 { get; set; }

        public override bool Equals(object obj) => Equals(obj as Conflict);

        public bool Equals(Conflict that) => that != null
            && that.WarType?.Equals(WarType) == true
            && that.Status?.Equals(Status) == true
            && that.Faction1?.Equals(Faction1) == true
            && that.Faction2?.Equals(Faction2) == true;

        public override int GetHashCode()
        {
            //https://stackoverflow.com/a/892640/3131828
            unchecked
            {
                int h = 23;
                h *= 31 + (WarType?.GetHashCode() ?? 0);
                h *= 31 + (Status?.GetHashCode() ?? 0);
                h *= 31 + (Faction1?.GetHashCode() ?? 0);
                h *= 31 + (Faction2?.GetHashCode() ?? 0);

                return h;
            }
        }

        public Conflict Clone()
        {
            var clone = (Conflict)MemberwiseClone();
            clone.Faction1 = Faction1?.Clone();
            clone.Faction2 = Faction2?.Clone();
            return clone;
        }
    }

    public class ConflictFaction
    {
        public string Name { get; set; }
        public string Stake { get; set; }
        public int WonDays { get; set; }

        public override bool Equals(object obj) => Equals(obj as ConflictFaction);

        public bool Equals(ConflictFaction that) => that != null
            && that.Name?.Equals(Name) == true
            && that.Stake?.Equals(Stake) == true
            && that.WonDays == WonDays;

        public override int GetHashCode()
        {
            //https://stackoverflow.com/a/892640/3131828
            unchecked
            {
                int h = 23;
                h *= 31 + (Name?.GetHashCode() ?? 0);
                h *= 31 + (Stake?.GetHashCode() ?? 0);
                h *= 31 + WonDays.GetHashCode();

                return h;
            }
        }

        public ConflictFaction Clone() => (ConflictFaction)MemberwiseClone();
    }
}
