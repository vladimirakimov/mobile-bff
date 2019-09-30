using AutoMapper;
using ITG.Brix.Mobile.Bff.Application.Mappers;
using ITG.Brix.Mobile.Bff.Application.Mappers.Impl;
using ITG.Brix.Mobile.Bff.Application.Services;
using ITG.Brix.Mobile.Bff.Application.Services.Builds;
using ITG.Brix.Mobile.Bff.Application.Services.Builds.Impl;
using ITG.Brix.Mobile.Bff.Application.Services.Converters;
using ITG.Brix.Mobile.Bff.Application.Services.Converters.Impl;
using ITG.Brix.Mobile.Bff.Application.Services.Impl;
using ITG.Brix.Mobile.Bff.Application.Services.Jsons;
using ITG.Brix.Mobile.Bff.Application.Services.Jsons.Impl;
using ITG.Brix.Mobile.Bff.Infrastructure.RestApis;
using ITG.Brix.Mobile.Bff.Infrastructure.RestApis.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace ITG.Brix.Mobile.Bff.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }

        public static IServiceCollection RestApis(this IServiceCollection services)
        {
            services.AddHttpClient<IUsersRestApi, UsersRestApi>();
            services.AddHttpClient<ITeamsRestApi, TeamsRestApi>();
            services.AddHttpClient<IEccSetupRestApi, EccSetupRestApi>();
            services.AddHttpClient<IWorkOrdersRestApi, WorkOrdersRestApi>();

            return services;
        }

        public static IServiceCollection Mappers(this IServiceCollection services)
        {
            services.AddScoped<IFilterMapper, FilterMapper>();

            return services;
        }

        public static IServiceCollection Services(this IServiceCollection services)
        {
            services.AddScoped<IJsonService<object>, JsonService>();
            services.AddScoped<IFilterBuildService, FilterBuildService>();
            services.AddScoped<ILocationBuildService, LocationBuildService>();
            services.AddScoped<IModelDtoConverter, ModelDtoConverter>();

            services.AddScoped<IMobileService, MobileService>();

            return services;
        }
    }
}
