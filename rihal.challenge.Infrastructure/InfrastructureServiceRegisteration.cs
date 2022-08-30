using Microsoft.Extensions.DependencyInjection;
using rihal.challenge.Application.Contracts.Infrastructure;
using rihal.challenge.Infrastructure.ExcelFiles;

namespace rihal.challenge.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IExcelExporter, ExcelExporter>();
        }
    }
}
