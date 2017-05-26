namespace RPGCompanion.Api.Host
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using IoC;
    using Middleware;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = Create();
            var resolver = Bootstrapper.ApiBootstrap(config, appBuilder);
            appBuilder.UseWebApi(config);
            config.DependencyResolver = resolver;
        }

        public static HttpConfiguration Create()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ConfigureFormatters(config);
            config.EnsureInitialized();
            return config;
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());
        }
    }
}