using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Nmro.Web
{
    public static class NmroWebHost
    {
        [Obsolete("Enable for backward compatible only, will be removed soon")]
        public static int BuildWebHost<TStartUp>(string[] args, Action<WebHostBuilderContext, IConfigurationBuilder> configDelegate) where TStartUp : class
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = GetConfiguration(env);
            Log.Logger = CreateSerilogLogger(configuration);

            try
            {
                Log.Information("Configuring WebHost");

                IWebHost host = CreateWebHostBuilder<TStartUp>(args, configDelegate).Build();

                Log.Information("Starting WebHost");
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "WebHost terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static int Build<TStartUp>(string[] args, Action<IHost> migration = null) where TStartUp : class
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = GetConfiguration(env);
            Log.Logger = CreateSerilogLogger(configuration);

            try
            {
                Log.Information("Configuring Host");

                IHost host = CreateHostBuilder<TStartUp>(args).Build();

                if( migration != null){
                    migration(host);
                }

                Log.Information("Starting Host");
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

        private static IHostBuilder CreateHostBuilder<TStartUp>(string[] args) where TStartUp : class
            => Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartUp>();
                });

        [Obsolete("Enable for backward compatible only, will be removed soon")]
        private static IWebHostBuilder CreateWebHostBuilder<TStartUp>(string[] args, Action<WebHostBuilderContext, IConfigurationBuilder> configDelegate) where TStartUp : class
             => WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration(configDelegate)
                .UseStartup<TStartUp>();


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
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
