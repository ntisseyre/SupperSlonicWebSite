﻿using Newtonsoft.Json;
using System;

namespace SupperSlonicWebSite.DomainLogic.Models.Account
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonIgnore]
        public bool IsVerified { get; set; }

        [JsonIgnore]
        public DateTime TimeStamp { get; set; }
    }
}