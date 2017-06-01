namespace RPGCompanion.Api.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Application.Context.Handlers;
    using Application.Domain.Mediator;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Infrastructure.Mediator;
    using Component = Castle.MicroKernel.Registration.Component;

    public class MediatrInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IManagedMediator>().ImplementedBy<CastleManagedMediator>());
            RegisterInterfaces(typeof(CreateContextHandler).Assembly, container, new List<Type>
            {
                typeof(IPrivateMessageHandler<,>),
                typeof(IPrivateMessageHandler<>)
            });

            container.Register(Component.For<SingleHandlerFactory>().Instance(container.Resolve));
            container.Register(Component.For<MultipleHandlerFactory>().Instance(t => container.ResolveAll(t).OfType<object>()));
        }

        protected void RegisterInterfaces(Assembly assembly, IWindsorContainer container, ICollection<Type> targetInterfaces)
        {
            var classes = assembly.ExportedTypes
                .Select(t => t.GetTypeInfo())
                .Where(IsConcreteClass);

            var interfaces = classes.SelectMany(c => c
                    .ImplementedInterfaces.Where(i => IsTargetInterface(targetInterfaces, i.GetTypeInfo()))
                    .Select(i => new KeyValuePair<Type, Type>(i.GetTypeInfo(), c.AsType())))
                .ToList();

            foreach (var classInterface in interfaces)
            {
                container.Register(Component.For(classInterface.Key).ImplementedBy(classInterface.Value).LifestyleSingleton());
            }
        }

        private static bool IsTargetInterface(ICollection<Type> targetInterfaces, TypeInfo interfaceTypeInfo)
        {
            return interfaceTypeInfo.IsGenericType && targetInterfaces.Any(ti => interfaceTypeInfo.GetGenericTypeDefinition() == ti);
        }

        private bool IsConcreteClass(TypeInfo typeInfo)
        {
            return typeInfo.IsClass && !typeInfo.IsAbstract;
        }
    }
}