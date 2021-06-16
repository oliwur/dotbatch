using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace dotBatch
{
    internal sealed class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddSimpleConsole(options =>
                    {
                        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss.fff ";
                        options.SingleLine = true;
                        options.ColorBehavior = LoggerColorBehavior.Enabled;
                        options.IncludeScopes = false;
                    });
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices((hostContext, services) => { services.AddHostedService<ConsoleHostedService>(); })
                .UseConsoleLifetime()
                .ConfigureServices(cfg => { })
                .Build();

            AppLogging.LoggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            LibLogging.LoggerFactory = host.Services.GetRequiredService<ILoggerFactory>();

            await host.RunAsync();
        }
    }
}