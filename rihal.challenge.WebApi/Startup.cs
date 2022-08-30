using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using rihal.challenge.Application;
using rihal.challenge.Application.Common.Configurations;
using rihal.challenge.Application.Common.Utilities;
using rihal.challenge.Application.Contracts.Services;
using rihal.challenge.Infrastructure;
using rihal.challenge.Persistence;
using rihal.challenge.WebApi.Middleware;
using rihal.challenge.WebApi.Services;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace rihal.challenge.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurationsManager config = new ConfigurationsManager();
            Configuration.Bind(config);
            services.AddSingleton(config);

            ConfigureSwagger(services);

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter(config));

            })
               .AddNewtonsoftJson(options =>
               {
                   // Use the default property (Pascal) casing
                   options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
               });

            services.AddPersistenceServices(Configuration);
            services.AddApplicationServices();
            services.AddInfrastructureServices();

            services.AddSingleton(typeof(ILogger), typeof(Logger<Startup>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICurrentLanguageService, CurrentLanguageService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

          
            IdentityModelEventSource.ShowPII = true;
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)

                    );
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            IOptions<RequestLocalizationOptions> options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            UseSwagger(app, env);

            app.UseCustomExceptionHandler();

            // turn on PII logging
            IdentityModelEventSource.ShowPII = true;

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }





        public string message = "";
        public static string FlattenException(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }
            return stringBuilder.ToString();
        }

        private void UseSwagger(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string virtualDirectory = env.IsDevelopment() ? string.Empty : $"{Configuration["VirtualDirectory"]}/";
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{ virtualDirectory }swagger/v1/swagger.json", "rihal.challenge.WebApi v1");
                c.InjectStylesheet("../swagger-ui/custom.css");
                c.DocExpansion(DocExpansion.None);
                c.EnableFilter();
                c.DefaultModelRendering(ModelRendering.Model);
                c.DisplayRequestDuration();
                c.ShowExtensions();
            });
            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "rihal.challenge",
                    Version = "v1",
                    Description = "Apis for rihal.challenge"
                });
          
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

    }

}
