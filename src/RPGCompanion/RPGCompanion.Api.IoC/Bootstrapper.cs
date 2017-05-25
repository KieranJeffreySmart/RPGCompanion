namespace RPGCompanion.Api.IoC
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public static class Bootstrapper
    {
        public static IWindsorContainer Bootstrap()
        {
            return new WindsorContainer().Install(FromAssembly.This());
        }
    }
}
