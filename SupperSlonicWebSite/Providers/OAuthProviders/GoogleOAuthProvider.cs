﻿using Microsoft.Owin.Security.Google;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SupperSlonicWebSite.Providers.OAuthProviders
{
    public class GoogleOAuthProvider : GoogleOAuth2AuthenticationProvider
    {
        public override Task Authenticated(GoogleOAuth2AuthenticatedContext context)
        {
            string avatarUrl = context.User
                .SelectToken("image.url")
                .ToString()
                .Replace("sz=50", "sz=240");

            context.Identity.AddClaim(
                new Claim(OwinHelper.ClaimTypeAvatarUrl, avatarUrl));

            return base.Authenticated(context);
        }
    }
}