using Newtonsoft.Json;

namespace RandomUserRuSharp.Models
{
    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }
    }
}