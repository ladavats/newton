using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace newton.webapi
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //If the cridentials is ok, generate the token for passing through the headers for other access.
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "peter" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Peter"));
                context.Validated(identity);
            }
            else if (context.UserName == "peter" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Peter"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid grant", "provided username and password is incorrect.");
                return;
            }

        }
    }
}