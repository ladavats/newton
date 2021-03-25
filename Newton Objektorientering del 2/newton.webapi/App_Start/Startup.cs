﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using newton.webapi.providers;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(newton.webapi.App_Start.Startup))]

namespace newton.webapi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var newtonProvider = new OAuthWebApiAuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
               AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = newtonProvider
            }; 

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);


        }
    }
}
