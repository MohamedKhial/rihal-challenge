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
using rihal.challenge.Domain.Entities.AuthenticationAggregate;
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
            ConfigureLocalizationOptions(services);

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                //config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                //config.OutputFormatters.Add(new XmlSerializerOutputFormatter());

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
            CofigureAuthentication(services);

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
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            //CreateRoles(serviceProvider);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }





        public string message = "";
        private void CofigureAuthentication(IServiceCollection services)
        {
            string issuer = Configuration["Tokens:Issuer"];
            var secret = new SymmetricSecurityKey(Convert.FromBase64String(Configuration["Tokens:ClientSecret"]));


            // SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Tokens:SigningKey"]));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer("Bearer", config =>
            {
                config.SaveToken = true;

                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    IssuerSigningKey = secret
                };
                config.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = ctx =>
                    {
                        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        message += "From OnAuthenticationFailed:\n";
                        message += FlattenException(ctx.Exception);
                        return Task.CompletedTask;
                    },

                    OnChallenge = ctx =>
                    {
                        message += "From OnChallenge:\n";
                        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        ctx.Response.ContentType = "text/plain";
                        return ctx.Response.WriteAsync(message);

                    },

                    OnMessageReceived = ctx =>
                    {
                        message = "From OnMessageReceived:\n";
                        ctx.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues BearerToken);
                        if (BearerToken.Count == 0)
                        {
                            BearerToken = "no Bearer token sent\n";
                        }

                        message += "Authorization Header sent: " + BearerToken + "\n";
                        return Task.CompletedTask;
                    },

                    OnTokenValidated = ctx =>
                    {
                        Debug.WriteLine("token: " + ctx.SecurityToken.ToString());
                        return Task.CompletedTask;
                    }
                };
            });
        }
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
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = $"Please insert the token below into text box\r\n: {Configuration["Swagger:LongLifetimeToken"]}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
          });
                c.EnableAnnotations();
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        private void ConfigureLocalizationOptions(IServiceCollection services)
        {
            const string enUSCulture = "en-US";
            const string arEGCulture = "ar-EG";
            const string arSACulture = "ar-SA";
            const string arQACulture = "ar-QA";

            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo
            {  // change long time pattern to 24 hours 
               // e.g. 13:50:21
                LongTimePattern = "HH:mm:ss",
                FullDateTimePattern = "dd/MM/yyyy HH:mm:ss",

                // short time pattern as 12 hours
                // e.g. 01:50:21 PM
                ShortTimePattern = "hh:mm tt"

            };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                CultureInfo[] supportedCultures = new[]
                {
                    new CultureInfo(enUSCulture),
                    new CultureInfo(arEGCulture){
                    DateTimeFormat = dateTimeFormatInfo,
                    },
                    new CultureInfo(arSACulture){
                    DateTimeFormat = dateTimeFormatInfo,
                    },
                    new CultureInfo(arQACulture){
                    DateTimeFormat = dateTimeFormatInfo,
                    }
                };

                options.DefaultRequestCulture = new RequestCulture(culture: enUSCulture, uiCulture: enUSCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider(),
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });
        }
        private void CreateRoles(IServiceProvider serviceProvider)
        {


            RoleManager<ApplicationRole> roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            Task<IdentityResult> roleResult;
            string email = "admin@dbs.com";
            string Lawyeremail = "Lawyer@dbs.com";
            string Judgeemail = "Judge@dbs.com";

            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
            hasAdminRole.Wait();
            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new ApplicationRole("Administrator"));
                roleResult.Wait();
            }
            Task<bool> hasLawyerRole = roleManager.RoleExistsAsync("Lawyer");

            hasLawyerRole.Wait();

            if (!hasLawyerRole.Result)
            {
                roleResult = roleManager.CreateAsync(new ApplicationRole("Lawyer"));
                roleResult.Wait();
            }
            Task<bool> hasJudgeRole = roleManager.RoleExistsAsync("Judge");

            hasJudgeRole.Wait();

            if (!hasJudgeRole.Result)
            {
                roleResult = roleManager.CreateAsync(new ApplicationRole("Judge"));
                roleResult.Wait();
            }
            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<ApplicationUser> adminUser = userManager.FindByEmailAsync(email);
            adminUser.Wait();

            if (adminUser.Result == null)
            {
                ApplicationUser administrator = new ApplicationUser("admin", "admin@dbs.com", "Administrator", "Admin", "Hello");


                Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "P@ssw0rd");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
                    newUserRole.Wait();
                }
            }
            Task<ApplicationUser> LawyerUser = userManager.FindByEmailAsync(Lawyeremail);
            LawyerUser.Wait();

            if (LawyerUser.Result == null)
            {
                ApplicationUser Lawyer = new ApplicationUser("Lawyer", "Lawyer@dbs.com", "Lawyer", "Lawyer", "Hello");


                Task<IdentityResult> newUser = userManager.CreateAsync(Lawyer, "P@ssw0rd");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(Lawyer, "Lawyer");
                    newUserRole.Wait();
                }
            }
            Task<ApplicationUser> JudgeUser = userManager.FindByEmailAsync(Judgeemail);
            JudgeUser.Wait();

            if (JudgeUser.Result == null)
            {
                ApplicationUser Judge = new ApplicationUser("Judge", "Judge@dbs.com", "Judge", "Judge", "Hello");


                Task<IdentityResult> newUser = userManager.CreateAsync(Judge, "P@ssw0rd");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(Judge, "Judge");
                    newUserRole.Wait();
                }
            }

        }
    }

}
