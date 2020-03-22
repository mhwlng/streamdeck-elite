using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader
{
    [JsonConverter(typeof(EngineeringModifiersCoverter))]
    public struct EngineeringModifiers
    {
        [JsonConverter(typeof(ExtendedStringEnumConverter<ModuleAttribute>))]
        public ModuleAttribute Label { get; set; }

        public double Value { get; set; }
        public string ValueStr { get; set; }
        public string ValueStr_Localised { get; set; }
        public double OriginalValue { get; set; }
        public string OriginalValueStr { get; set; }
        public string OriginalValueStr_Localised { get; set; }
        public bool LessIsGood { get; set; }
    }

    internal class EngineeringModifiersCoverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(EngineeringModifiers);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var mod = new EngineeringModifiers();
            var obj = JObject.Load(reader);

            mod.Label = (ModuleAttribute)Enum.Parse(typeof(ModuleAttribute), obj.Value<string>(nameof(mod.Label)));
            mod.LessIsGood = obj.Value<bool>(nameof(mod.LessIsGood));

            var valueToken = obj[nameof(mod.Value)];
            if (valueToken?.Type == JTokenType.Float)
            {
                mod.Value = valueToken.Value<double>();
            }
            else if (valueToken?.Type == JTokenType.String)
            {
                mod.ValueStr = valueToken.Value<string>();
            }
            else if (valueToken == null)
            {
                mod.ValueStr = obj[nameof(mod.ValueStr)]?.Value<string>();
                mod.ValueStr_Localised = obj[nameof(mod.ValueStr_Localised)]?.Value<string>();
            }

            var origToken = obj[nameof(mod.OriginalValue)];
            if (origToken?.Type == JTokenType.Float)
            {
                mod.OriginalValue = origToken.Value<double>();
            }
            else if (origToken?.Type == JTokenType.String)
            {
                mod.OriginalValueStr = origToken.Value<string>();
            }
            else if (origToken == null)
            {
                mod.OriginalValueStr = obj[nameof(mod.OriginalValueStr)]?.Value<string>();
                mod.OriginalValueStr_Localised = obj[nameof(mod.OriginalValueStr_Localised)]?.Value<string>();
            }

            return mod;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }
    }
}
