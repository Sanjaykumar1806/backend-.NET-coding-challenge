using System;
using System.Reflection;
using FizzBuzz.Output;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FizzBuzz.Engines;
using FizzBuzz.Rules;

namespace FizzBuzz.Binders
{
    public class ComponentBindings : IWindsorInstaller
    {
        public void Install(IWindsorContainer componentContainer, IConfigurationStore store)
        {
            if (componentContainer == null)
            {
                throw new ArgumentNullException(nameof(componentContainer));
            }

            componentContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(componentContainer.Kernel));

            componentContainer.Register(
                Component.For<IFizzBuzzEngine>().ImplementedBy<FizzBuzzEngines>()
                    .LifestyleSingleton(),

                Component.For<IOutput>().ImplementedBy<OutputResult>()
                    .LifestyleSingleton(),

                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .BasedOn<IRules>()
                    .WithServiceAllInterfaces()
                    .Unless(x => x == typeof(DivisibleBy))
                    .LifestyleSingleton(),

                Component.For<IRules>().ImplementedBy<DivisibleBy>()
                    .Named(Constants.DivBy3)
                    .UsingFactoryMethod(x => new DivisibleBy(Constants.DivBy3Output, 3))
                    .LifestyleSingleton(),

                Component.For<IRules>().ImplementedBy<DivisibleBy>()
                    .Named(Constants.DivBy5)
                    .UsingFactoryMethod(x => new DivisibleBy(Constants.DivBy5Output, 5))
                    .LifestyleSingleton()
            );
        }
    }
}
