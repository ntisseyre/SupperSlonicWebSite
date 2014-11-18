﻿using SupperSlonicDomain.Models.Account;
using SupperSlonicWebSite.Models.Account;
using System.Security.Claims;

namespace SupperSlonicWebSite.Providers.ClaimsMappingStrategies
{
    public class RegisteredExternal : ClaimsMapper
    {
        public RegisteredExternal(User user, ExternalLoginModel extLogin)
        {
            this.Id = user.Id.ToString();
            this.Email = user.Email;
            this.FullName = user.FullName ?? string.Empty;
            this.AvatarUrl = UserProvider.GetAvatarUrl(user);
            this.Sid = extLogin.ProviderKey;
            this.Version = this.GetVersion(user.TimeStamp);
            this.IsVerified = user.IsVerified.ToString();
            this.Issuer = ClaimsIdentity.DefaultIssuer;
            this.OriginalIssuer = extLogin.Provider.ToString();
        }
    }
}