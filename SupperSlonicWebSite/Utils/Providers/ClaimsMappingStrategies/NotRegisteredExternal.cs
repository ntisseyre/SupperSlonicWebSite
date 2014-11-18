﻿using SupperSlonicWebSite.Models.Account;

namespace SupperSlonicWebSite.Providers.ClaimsMappingStrategies
{
    public class NotRegisteredExternal : ClaimsMapper
    {
        public NotRegisteredExternal(ExternalLoginModel extLogin)
        {
            this.Id = string.Empty;
            this.Email = extLogin.Email ?? string.Empty;
            this.FullName = extLogin.FullName ?? string.Empty;
            this.AvatarUrl = extLogin.AvatarUrl ?? string.Empty;
            this.Sid = extLogin.ProviderKey;
            this.Version = string.Empty;
            this.IsVerified = false.ToString();
            this.Issuer = extLogin.Provider.ToString();
            this.OriginalIssuer = this.Issuer;
        }
    }
}