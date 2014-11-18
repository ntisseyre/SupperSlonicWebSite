using Newtonsoft.Json;

namespace SupperSlonicWebSite.Models.Account
{
    public class AccessToken
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}