using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteJournalReader
{
    public struct SystemPosition
    {
        public decimal X, Y, Z;

        public bool IsZero()
        {
            return X == 0 && Y == 0 && Z == 0;
        }

        public override bool Equals(object obj) => obj is SystemPosition that && Equals(that);

        public bool Equals(SystemPosition that)
        {
            return X == that.X && Y == that.Y && Z == that.Z;
        }

        public override int GetHashCode()
        {
            //https://stackoverflow.com/a/892640/3131828
            unchecked
            {
                int h = 23;
                h *= 31 + X.GetHashCode();
                h *= 31 + Y.GetHashCode();
                h *= 31 + Z.GetHashCode();

                return h;
            }
        }

        public decimal[] ToArray()
        {
            return new[] { X, Y, Z };
        }

        public List<double> ToList()
        {
            return new List<double>{ (double)X, (double)Y, (double)Z };
        }


        public override string ToString()
        {
            return System.FormattableString.Invariant($"{X}, {Y}, {Z}");
        }

        public static bool operator ==(SystemPosition left, SystemPosition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SystemPosition left, SystemPosition right)
        {
            return !(left == right);
        }
    }

    public class SystemPositionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SystemPosition);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var pos = (SystemPosition)existingValue;
            if (JToken.ReadFrom(reader) is JArray jarr)
            {
                decimal[] array = jarr.ToObject<decimal[]>();
                pos.X = Math.Round(array[0], 3);
                pos.Y = Math.Round(array[1], 3);
                pos.Z = Math.Round(array[2], 3);
            }
            return pos;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var pos = (SystemPosition)value;
            new JArray(pos.X, pos.Y, pos.Z).WriteTo(writer);
        }
    }
}
