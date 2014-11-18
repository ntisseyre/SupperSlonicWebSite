using Newtonsoft.Json;
using System;

namespace SupperSlonicDomain.Models.Account
{
    public class UserDb : User
    {
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

        [JsonIgnore]
        public Guid? VerifyEmailCode { get; set; }
    }
}