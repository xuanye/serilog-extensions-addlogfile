using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using System;

namespace HelloSerilog
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var currentEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{currentEnv}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        /*
                    Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .WriteTo.Logger(l => l
                        .Filter.ByIncludingOnly(Matching.FromSource("HelloSerilog"))
                        .WriteTo.Async(cfg => cfg.RollingFile(
                                pathFormat: "Logs/audit-{Date}.log",
                                restrictedToMinimumLevel: LogEventLevel.Information,
                                outputTemplate: "{Timestamp:yyyy-MM-dd.HH:mm:ss.fff}  ,{Message}{NewLine}"
                        ))
                    )
                    .WriteTo.Logger(l => l
                            .Filter.ByExcluding(Matching.FromSource("HelloSerilog"))
                            .WriteTo.LiterateConsole(Serilog.Events.LogEventLevel.Warning)
                            .WriteTo.Async(cfg => cfg.RollingFile(
                                pathFormat: "Logs/log-{Date}.log",
                                restrictedToMinimumLevel: LogEventLevel.Information,
                                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}"
                            ))
                    )
                    .Enrich.WithMachineName()
                    .Enrich.FromLogContext()
                    .CreateLogger();
        */
            try
            {
                Log.Information("Starting Logging");

                var obj = new TestObj();
                obj.LogSoming();

                var obj2 = new Libs.InnerTestObj();
                obj2.LogSoming();

                Console.WriteLine("Hello Serilog");
                Console.ReadKey();
                Log.Warning("Test Warning");
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Web Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}