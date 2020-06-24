using TesteSoftplan.Infra.CrossCutting.Identity;
using TesteSoftplan.Services.ApiTwo.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Identity;
using NetDevPack.Identity.User;
using TesteSoftplan.Domain.Models;

namespace TesteSoftplan.Services.ApiTwo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // WebAPI Config
            services.AddControllers();

            // ASP.NET Identity Settings & JWT
            services.AddApiIdentityConfiguration(Configuration);

            // Interactive AspNetUser (logged in)
            services.AddAspNetUserConfiguration();

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();

            services.Configure<JurosSet>(Configuration.GetSection("JurosSet"));
            services.Configure<Api>(Configuration.GetSection("Api"));
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
