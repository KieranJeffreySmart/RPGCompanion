namespace RPGCompanion.Api.IoC
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Domain.Repository;
    using Infrastructure.DataAccess.Character;
    using Infrastructure.DataAccess.Context;
    using Infrastructure.DataAccess.Item;
    using Infrastructure.DataAccess.Setting;
    using Infrastructure.DataAccess.Story;

    public class DataAccessInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //var pick = Classes.FromAssemblyContaining(typeof(ContextRepository))
            //    .Where(t => t.Name.EndsWith("Repository"));
            
            ////var items = pick.Configure(configurer => configurer.Named(configurer.Implementation.Name))
            ////    .LifestyleSingleton();

            //container.Register(pick.WithService.Base()
            //    .LifestyleSingleton());

            container.Register(Component.For<IStoryRepository>().ImplementedBy<StoryRepository>());
            container.Register(Component.For<IContextRepository>().ImplementedBy<ContextRepository>());
            container.Register(Component.For<IItemRepository>().ImplementedBy<ItemRepository>());
            container.Register(Component.For<ICharacterRepository>().ImplementedBy<CharacterRepository>());
            container.Register(Component.For<IGlobalEnvironmentRepository>().ImplementedBy<GlobalEnvironmentRepository>());
        }
    }
}