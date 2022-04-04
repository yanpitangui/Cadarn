using System.IO;
using Cadarn.Configuration;
using Cadarn.Services.Configuration;
using Microsoft.Extensions.Configuration;
using Splat;

namespace Cadarn.DependencyInjection;

public static class ConfigurationBootstrapper
{
    
    public static void RegisterConfiguration(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        var configuration = BuildConfiguration();
        
        RegisterLoggingConfiguration(services, configuration);
        RegisterDefaultThemeConfiguration(services, configuration);
        RegisterLanguagesConfiguration(services, configuration);

    }
    
    
    private static void RegisterDefaultThemeConfiguration(IMutableDependencyResolver services,
        IConfiguration configuration)
    {
        var config = new DefaultThemeConfiguration();
        configuration.GetSection("Themes").Bind(config);
        services.RegisterConstant(config);
    }

    private static void RegisterLanguagesConfiguration(IMutableDependencyResolver services,
        IConfiguration configuration)
    {
        var config = new LanguagesConfiguration();
        configuration.GetSection("Languages").Bind(config);
        services.RegisterConstant(config);
    }
    

    
    private static IConfiguration BuildConfiguration() =>
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    private static void RegisterLoggingConfiguration(IMutableDependencyResolver services,
        IConfiguration configuration)
    {
        var config = new LoggingConfiguration();
        configuration.GetSection("Logging").Bind(config);
        services.RegisterConstant(config);
    }
}