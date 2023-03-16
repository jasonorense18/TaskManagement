using Mapster;
using MapsterMapper;
using System.Reflection;

namespace TaskManagement.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(
            this IServiceCollection services)
        {
            //Scan the assembly and find all the items IRegister interfaces and register the different configuration.
            var config = TypeAdapterConfig.GlobalSettings;

            // We are getting in the executing assembly
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
