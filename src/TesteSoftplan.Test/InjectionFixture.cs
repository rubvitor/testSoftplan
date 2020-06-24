using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using TesteSoftplan.Infra.CrossCutting.IoC;

namespace TesteSoftplan.Test
{
    public class InjectionFixture
    {
        public InjectionFixture()
        {
            var services = new ServiceCollection();
            var contentRootPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var builder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json", true, true);

            builder.AddEnvironmentVariables();
            var Configuration = builder.Build();
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);

            ServiceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
