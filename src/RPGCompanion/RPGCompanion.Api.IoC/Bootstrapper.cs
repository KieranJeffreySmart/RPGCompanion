namespace RPGCompanion.Api.IoC
{
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Middleware;
    using Owin;

    public static class Bootstrapper
    {
        public static IDependencyResolver ApiBootstrap(HttpConfiguration config, IAppBuilder appBuilder)
        {
            BootstrapMiddleware(config, appBuilder);
            return new WindsorDependencyResolver(new WindsorContainer().Install(FromAssembly.This()));
        }
        public static IDependencyResolver ApiBootstrap(HttpConfiguration config)
        {
            BootstrapMiddleware(config, null);
            return new WindsorDependencyResolver(new WindsorContainer().Install(FromAssembly.This()));
        }

        private static void BootstrapMiddleware(HttpConfiguration config, IAppBuilder appBuilder)
        {
            Configure.Enable(config);
            if (appBuilder != null)
            {
                Configure.Use(appBuilder);
            }
        }

        public static IWindsorContainer Bootstrap()
        {
            return new WindsorContainer().Install(FromAssembly.This());
        }
    }
}
