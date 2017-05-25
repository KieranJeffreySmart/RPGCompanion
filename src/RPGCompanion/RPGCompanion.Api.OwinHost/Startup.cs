namespace RPGCompanion.Api.OwinHost
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using Castle.Windsor;
    using IoC;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var container = Bootstrapper.Bootstrap(new WindsorContainer());
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
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());
        }
    }
}