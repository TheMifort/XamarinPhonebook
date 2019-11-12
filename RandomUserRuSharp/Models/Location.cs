using Newtonsoft.Json;

namespace RandomUserRuSharp.Models
{
    public class Location
    {
        [JsonProperty("building")]
        public long Building { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }
    }
}