using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rihal.challenge.Application.Common.Configurations;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Persistence.DbContexts;
using rihal.challenge.Persistence.Repositories;
namespace rihal.challenge.Persistence
{
    public static class PersistenceServiceRegisteration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            ConfigurationsManager configManager = serviceProvider.GetService<ConfigurationsManager>();

            const string rihalchallengeDatabaseConnectionKeyName = "rihalchallenge";

            services.AddDbContext<rihalchallengeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(rihalchallengeDatabaseConnectionKeyName)));

            services.AddScoped(typeof(IAsyncRepo<,>), typeof(BaseRepo<,>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IClassRepo), typeof(ClassRepo));
            services.AddScoped(typeof(IStudentRepo), typeof(StudentRepo));
            services.AddScoped(typeof(ICountryRepo), typeof(CountryRepo));

         


          
            return services;
        }
    }
}
