namespace RPGCompanion.Api.Host
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using IoC;
    using Middleware;
    using Owin;
    using Swashbuckle.Application;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var container = Bootstrapper.Bootstrap();
            var resolver = new WindsorDependencyResolver(container);
            var config = Create();
            appBuilder.UseWebApi(config);
            config.DependencyResolver = resolver;
        }

        public static HttpConfiguration Create()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ConfigureFormatters(config);
            config.EnsureInitialized();
            Configure.Enable(config);

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