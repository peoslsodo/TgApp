using Newtonsoft.Json;

namespace TgApp.Model
{
    public class DnsInfo
    {
        [JsonProperty("dns")]
        public Dns Dns { get; set; }
    }

    public class Dns
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("geo")]
        public string Geo { get; set; }
    }
    public class GeoInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }


        [JsonProperty("country")]
        public string Country { get; set; }


        [JsonProperty("regionName")]
        public string RegionName { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }


        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }


        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
