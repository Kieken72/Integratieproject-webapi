using System;
using System.Configuration;
using System.Web.Http;
using Leisurebooker.Business;
using Leisurebooker.Business.Services;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApi;
using WebApi.Providers;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuthTokenGeneration(app);
            ConfigureOAuthTokenConsumption(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<AuthService>(AuthService.Create);
            app.CreatePerOwinContext<RoleService>(RoleService.Create);


            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(),
            };

            // Token Generation
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {

            app.CreatePerOwinContext<AuthService>(AuthService.Create);
            app.CreatePerOwinContext<RoleService>(RoleService.Create);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("https://leisurebooker.azurewebsites.net/")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }
        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = "https://leisurebooker.azurewebsites.net/";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }

    }
}