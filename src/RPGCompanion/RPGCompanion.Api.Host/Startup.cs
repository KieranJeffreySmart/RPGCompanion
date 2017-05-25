namespace RPGCompanion.Api.Host
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using IoC;
    using Owin;
    using Swashbuckle.Application;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var container = Bootstrapper.Bootstrap();
            Create(appBuilder, new WindsorDependencyResolver(container));
        }

        public static void Create(IAppBuilder app, IDependencyResolver resolver)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            ConfigureFormatters(config);

            config.DependencyResolver = resolver;
            app.UseWebApi(config);
            config.EnsureInitialized();

            config.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")).EnableSwaggerUi();
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());
        }
    }
}