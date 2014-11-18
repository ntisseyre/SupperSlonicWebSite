using Newtonsoft.Json;
using SupperSlonicDomain.Models.Account;

namespace SupperSlonicWebSite.Models.Account
{
    public class ExternalLoginProviderModel
    {
        [JsonProperty("name", Required = Required.Always)]
        public ExternalLoginProvider Provider { get; set; }

        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty("state", Required = Required.Always)]
        public string State { get; set; }
    }
}