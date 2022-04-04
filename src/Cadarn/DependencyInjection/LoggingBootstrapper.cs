using System;
using System.IO;
using Cadarn.Configuration;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Sinks.SystemConsole.Themes;
using Splat;

namespace Cadarn.DependencyInjection;

public static class LoggingBootstrapper
{
    public static void RegisterLogging(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton(() =>
        {
            var config = resolver.GetRequiredService<LoggingConfiguration>();
            var logFilePath = GetLogFileName(config).Replace("{Date}", DateTime.Now.ToString("yyyy-MM-dd"));
            var logger = new LoggerConfiguration()
                .MinimumLevel.Override("Default", config.DefaultLogLevel)
                .MinimumLevel.Override("Microsoft", config.MicrosoftLogLevel)
                .WriteTo.Async(a =>
                {
                    a.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code);
                    a.File(logFilePath, fileSizeLimitBytes: config.LimitBytes);
                })
                .CreateLogger();
            var factory = new SerilogLoggerFactory(logger);

            return factory.CreateLogger("Default");
        });
    }
    
    private static string GetLogFileName(LoggingConfiguration config)
    {
        var logDirectory = Directory.GetCurrentDirectory();
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        return Path.Combine(logDirectory, config.LogFileName);
    }
}