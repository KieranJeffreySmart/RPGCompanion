namespace RPGCompanion.Api.IoC
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Domain.Repository;
    using Infrastructure.DataAccess;

    public class DataAccessInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStoryRepository>().ImplementedBy<StoryRepository>());
            container.Register(Component.For<IContextRepository>().ImplementedBy<ContextRepository>());
        }
    }
}