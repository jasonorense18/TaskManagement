using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using TaskManagement.Api.Common.Errors;
using TaskManagement.Api.Common.Mapping;

namespace TaskManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentatiion(
            this IServiceCollection services)
        {
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Override the DefaultProblemDetailsFactory from MVC to Custom ProblemDetailsFactory.
            services.AddSingleton<ProblemDetailsFactory, TaskManagementProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }
    }
}