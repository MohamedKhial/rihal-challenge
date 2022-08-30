using Microsoft.Extensions.DependencyInjection;
using rihal.challenge.Application.Common.Utilities;
using rihal.challenge.Application.Contracts.Infrastructure;
using rihal.challenge.Infrastructure.ExcelFiles;
using rihal.challenge.Infrastructure.Files;
using rihal.challenge.Infrastructure.TextFiles;

namespace rihal.challenge.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileHandler, FileHandler>();
            services.AddScoped<IExcelExporter, ExcelExporter>();
            services.AddScoped<ITextFileReader, TextFileReader>();
        
        }
    }
}
