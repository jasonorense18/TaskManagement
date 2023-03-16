using Microsoft.Extensions.DependencyInjection;
using MediatR;
using TaskManagement.Application.Common.Behaviors;
using System.Reflection;
using FluentValidation;

namespace TaskManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            // Automatically register all MediatR
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            //Automatically register FluentValidation
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            // Auto Register
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;

        }
    }
}
