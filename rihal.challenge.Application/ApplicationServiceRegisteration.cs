using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using rihal.challenge.Application.Common.Validators;
using System.Reflection;

namespace rihal.challenge.Application
{

    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
            return services;
        }
    }
}

