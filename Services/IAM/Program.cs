using System;
using System.IO;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Serilog;
using Nmro.IAM.Extensions;
using Nmro.IAM.Repository;
using Nmro.IAM.Services;

namespace Nmro.IAM
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = GetConfiguration(env);

            Log.Logger = CreateSerilogLogger(configuration);

            try
            {
                Log.Information("Configuring web host");
                var host = CreateWebHostBuilder(args).Build();

                Log.Information("Applying migrations");
                host.MigrateDbContext<IAMDbcontext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<IdentityUserContextSeed>>();
                    var passwordValidator = services.GetService<IPasswordValidator>();

                    new IdentityUserContextSeed(passwordValidator)
                        .SeedAsync(context, logger)
                        .Wait();
                });

                Log.Information("Starting web host");
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static IConfiguration GetConfiguration(string env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            return builder.Build();
        }

        private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
