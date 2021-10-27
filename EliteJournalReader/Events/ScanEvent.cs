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
    //When Written: detailed discovery scan of a star, planet or moon
    //Parameters(star)
    //�	ScanType
    //�	StarSystem: name
    //�	SystemAddress
    //�	Bodyname: name of body
    //�	DistanceFromArrivalLS
    //�	StarType: Stellar classification (for a star)
    //�	Subclass: Star�s heat classification 0..9
    //�	StellarMass: mass as multiple of Sol�s mass
    //�	Radius
    //�	AbsoluteMagnitude
    //�	RotationPeriod (seconds)
    //�	SurfaceTemperature
    //�	Luminosity
    //�	Age_MY: age in millions of years
    //�	* Rings: [ array ] - if present
    //�	WasDiscovered: bool
    //�	WasMapped: bool
    //
    //Parameters(Planet/Moon) 
    //�	Bodyname: name of body
    //�	Parents: Array of BodyType:BodyID pairs
    //�	DistanceFromArrivalLS
    //�	* TidalLock: 1 if tidally locked
    //�	* TerraformState: Terraformable, Terraforming, Terraformed, or null
    //�	PlanetClass
    //�	* Atmosphere
    //�	* AtmosphereType
    //�	* AtmosphereComposition: [ array of info ]
    //�	* Volcanism
    //�	SurfaceGravity
    //�	* SurfaceTemperature
    //�	* SurfacePressure
    //�	* Landable: true (if landable)
    //�	* Materials: JSON object with material names and percentage occurrence
    //�	* Composition: structure containing info on solid composition
    //    o Ice
    //    o Rock
    //    o Metal
    //�	* Rings [ array of info ] - if rings present
    //�	* ReserveLevel: (Pristine/Major/Common/Low/Depleted) � if rings present
    //If rotating:
    //�	RotationPeriod(seconds)
    //�	Axial tilt
    //
    // Orbital Parameters for any Star/Planet/Moon (except main star of single-star system)
    //�	SemiMajorAxis
    //�	Eccentricity
    //�	OrbitalInclination
    //�	Periapsis
    //�	OrbitalPeriod (seconds)
    //
    // Rings properties *
    //�	Name
    //�	RingClass
    //�	MassMT - ie in megatons
    //�	InnerRad
    //�	OuterRad
    //
    //Note that a basic scan (ie without having a Detailed Surface Scanner installed) will now save a reduced amount of information.
    //A basic scan on a planet will include body name, planet class, orbital data, rotation period, mass, 
    //radius, surface gravity; but will exclude tidal lock, terraform state, atmosphere, volcanism, surface pressure and temperature, 
    //available materials, and details of rings. The info for a star will be largely the same whether a basic scanner or detailed scanner is used.
    //
    //The "Parents" property provides the body's hierarchical position within the system: in the example below, 
    //"Procyon B 3 a" is a moon of a planet (body 11), which is orbiting a star (body 2), which is has a parent body that's a Barycentre
    //
    //Entries in the list above marked with an asterisk are only included for a detailed scan
    //
    // STAR TYPES:
    // 
    // (Main sequence:) O B A F G K M L T Y 
    // (Proto stars:) TTS AeBe  
    // (Wolf-Raylet:) W WN WNC WC WO
    // (Carbon stars:) CS C CN CJ CH CHd
    // MS S 
    // (white dwarfs:) D DA DAB DAO DAZ DAV DB DBZ DBV DO DOV DQ DC DCV DX
    // N (=Neutron)
    // H (=Black Hole)
    // X (=exotic)
    // SupermassiveBlackHole
    // A_BlueWhiteSuperGiant
    // F_WhiteSuperGiant
    // M_RedSuperGiant
    // M_RedGiant
    // K_OrangeGiant
    // RoguePlanet
    // Nebula
    // StellarRemnantNebula
    // 
    // PLANET CLASSES:
    // 
    // Metal rich body
    // High metal content body
    // Rocky body
    // Icy body
    // Rocky ice body
    // Earthlike body
    // Water world
    // Ammonia world
    // Water giant
    // Water giant with life
    // Gas giant with water based life
    // Gas giant with ammonia based life
    // Sudarsky class I gas giant (also class II, III, IV, V)
    // Helium rich gas giant
    // Helium gas giant
    // 
    // ATMOSPHERE CLASSES:
    // 
    // No atmosphere
    // Suitable for water-based life
    // Ammonia and oxygen
    // Ammonia
    // Water
    // Carbon dioxide
    // Sulphur dioxide
    // Nitrogen
    // Water-rich
    // Methane-rich
    // Ammonia-rich
    // Carbon dioxide-rich
    // Methane
    // Helium
    // Silicate vapour
    // Metallic vapour
    // Neon-rich
    // Argon-rich
    // Neon
    // Argon
    // Oxygen
    // 
    // VOLCANISM CLASSES:
    // (all with possible 'minor' or 'major' qualifier)
    // 
    // None
    // Water Magma
    // Sulphur Dioxide Magma
    // Ammonia Magma
    // Methane Magma
    // Nitrogen Magma
    // Silicate Magma
    // Metallic Magma
    // Water Geysers
    // Carbon Dioxide Geysers
    // Ammonia Geysers
    // Methane Geysers
    // Nitrogen Geysers
    // Helium Geysers
    // Silicate Vapour Geysers
    //
    // STAR LUMINOSITY CLASSES:
    // 0,
    // I,
    // Ia0,
    // Ia,
    // Ib,
    // Iab,
    // II,
    // IIa,
    // IIab,
    // IIb,
    // III,
    // IIIa,
    // IIIab,
    // IIIb,
    // IV,
    // IVa,
    // IVab,
    // IVb,
    // V,
    // Va,
    // Vab,
    // Vb,
    // Vz,
    // VI,
    // VII
    //
    public class ScanEvent : JournalEvent<ScanEvent.ScanEventArgs>
    {
        public ScanEvent() : base("Scan") { }

        public class ScanEventArgs : JournalEventArgs
        {
            [JsonConverter(typeof(ExtendedStringEnumConverter<ScanType>))]
            public ScanType ScanType { get; set; }

            public string StarSystem { get; set; }

            public long SystemAddress { get; set; }

            public string BodyName { get; set; }

            public long BodyID { get; set; }

            public double DistanceFromArrivalLs { get; set; }

            [JsonConverter(typeof(BodyParentConverter))]
            public BodyParent[] Parents { get; set; }

            public double? SemiMajorAxis { get; set; }

            public double? Eccentricity { get; set; }

            public double? Periapsis { get; set; }

            public double? OrbitalInclination { get; set; }

            public double? Age_MY { get; set; }

            public double? MassEM { get; set; }

            public PlanetRing[] Rings { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<ReserveLevel>))]
            public ReserveLevel ReserveLevel { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<StarType>))]
            public StarType StarType { get; set; }

            public int Subclass { get; set; }

            public double? StellarMass { get; set; }

            public double? Radius { get; set; }

            public double? AbsoluteMagnitude { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<StarLuminosity>))]
            public StarLuminosity Luminosity { get; set; }

            public double? OrbitalPeriod { get; set; }

            public double? RotationPeriod { get; set; }

            public double? AxialTilt { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<TerraformState>))]
            public TerraformState TerraformState { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<PlanetClass>))]
            public PlanetClass PlanetClass { get; set; }

            public string Atmosphere { get; set; }

            [JsonConverter(typeof(ExtendedStringEnumConverter<AtmosphereClass>))]
            public AtmosphereClass AtmosphereType { get; set; }

            public ScanItemComponent[] AtmosphereComposition { get; set; }

            public string Volcanism { get; set; }

            public double? SurfaceGravity { get; set; }

            public double? SurfaceTemperature { get; set; }

            public double? SurfacePressure { get; set; }

            public bool? Landable { get; set; }

            public bool? TidalLock { get; set; }

            public ScanItemComponent[] Materials { get; set; }

            public bool? WasDiscovered { get; set; }
            public bool? WasMapped { get; set; }
        }
    }

    public struct ScanItemComponent
    {
        public string Name;
        public double Percent;
    }

    public struct PlanetRing
    {
        public string Name;
        public string RingClass;
        public double MassMT;
        public double InnerRad;
        public double OuterRad;
    }

    public struct BodyParent
    {
        public string Type;
        public long BodyID;
    }



    public class BodyParentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IEnumerable<BodyParent>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var bps = new List<BodyParent>();
            if (JToken.ReadFrom(reader) is JArray array)
            {
                foreach (JToken token in array.Children())
                {
                    if (token is JObject obj)
                    {
                        var prop = obj.Properties().FirstOrDefault();
                        if (prop != null)
                        {
                            var bp = new BodyParent
                            {
                                Type = prop.Name,
                                BodyID = prop.Value.Value<long>()
                            };
                            bps.Add(bp);
                        }
                    }
                }
            }
            return bps.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
