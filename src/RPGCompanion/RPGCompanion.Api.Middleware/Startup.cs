namespace RPGCompanion.Api.Middleware
{
    using System.Web.Http;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;
    using Owin;
    using Swashbuckle.Application;

    public static class Configure
    {
        public static void Enable(HttpConfiguration config)
        {
            config.EnableSwagger(c => c.SingleApiVersion("v1", "RPG Companion API")).EnableSwaggerUi();
        }

        public static void Use(IAppBuilder appBuilder)
        {
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            appBuilder.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44319/identity",
                ClientId = "mvc",
                RedirectUri = "https://localhost:44319/",
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies"
            });
        }
    }
}
