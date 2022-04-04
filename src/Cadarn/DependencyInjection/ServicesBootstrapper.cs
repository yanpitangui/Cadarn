using Cadarn.Services;
using Cadarn.Services.Abstractions;
using Cadarn.Services.Configuration;
using Splat;

namespace Cadarn.DependencyInjection;

public static class ServicesBootstrapper
{
    public static void RegisterServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        RegisterCommonServices(services, resolver);
    }

    private static void RegisterCommonServices(IMutableDependencyResolver services,
        IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton<ILocalizationService>(() => new LocalizationService(
        ));
        services.RegisterLazySingleton<IThemeService>(() => new ThemeService(
            resolver.GetRequiredService<DefaultThemeConfiguration>()
        ));
        
        services.RegisterLazySingleton<ILanguageManager>(() => new LanguageManager(
            resolver.GetRequiredService<LanguagesConfiguration>()
        ));
    }
}