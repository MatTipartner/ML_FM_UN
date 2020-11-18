using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MS_ML_FU_CREDENCIALES.Models.Environment;
using Owin;

[assembly: OwinStartup(typeof(MS_ML_FU_CREDENCIALES.Startup))]

namespace MS_ML_FU_CREDENCIALES
{
    public class Startup
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigurarOAuth(app);
            app.UseWebApi(config);
        }

        public void ConfigurarOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions opcionesautorizacion = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(values.ExpiracionTokenAcceso),
                Provider = new Credenciales.TokenProvider(),
                RefreshTokenProvider = new Credenciales.SimpleRefreshTokenProvider()
            };
            app.UseOAuthAuthorizationServer(opcionesautorizacion);
            //
            OAuthBearerAuthenticationOptions opcionesoauth = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(opcionesoauth);
        }

    }
}
