using Newtonsoft.Json;

namespace RandomUserRuSharp.Models
{
    public class RootObject
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }
}