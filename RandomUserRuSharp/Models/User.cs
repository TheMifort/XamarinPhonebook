using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RandomUserRuSharp.Models
{
    public class User
    {
        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("sha1")]
        public string Sha1 { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("registered")]
        public DateTime? Registered { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("dob")]
        public DateTime? Dob { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }
    }
}