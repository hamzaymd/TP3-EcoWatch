using Newtonsoft.Json;

namespace TP3_EcoWatch.Models
{
    public class AirQuality
    {
        [JsonProperty("ville")]
        public string Ville { get; set; } = "";

        [JsonProperty("date")]
        public string Date { get; set; } = "";

        [JsonProperty("indice_qualite_air")]
        public int IndiceQualiteAir { get; set; }

        [JsonProperty("polluants")]
        public Dictionary<string, int> Polluants { get; set; } = new Dictionary<string, int>();
    }

    public class PolluantsModel
    {
        public int DioxydeAzote { get; set; }
        public int DioxydeSoufre { get; set; }
        public int ParticulesFines { get; set; }
    }
}
