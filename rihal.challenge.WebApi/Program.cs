using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace rihal.challenge.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            try
            {
                Log.Information("Getting the application running...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IConfiguration Configuration { get; } =
            new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).
            AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
            AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true).Build();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSerilog();
                    webBuilder.UseStartup<Startup>();
                });
        }
    }

}
