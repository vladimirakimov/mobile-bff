using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ITG.Brix.Mobile.Bff.DependencyResolver
{
    public static class Resolver
    {
        public static AutofacServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            services
                .AutoMapper()
                .RestApis()
                .Mappers()
                .Services();

            var containerBuilder = BuildContainer(services);

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        private static ContainerBuilder BuildContainer(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            return containerBuilder;
        }
    }
}
