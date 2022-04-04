using Cadarn.ViewModels.Implementations;
using Cadarn.ViewModels.Implementations.Menu;
using Cadarn.ViewModels.Interfaces;
using Splat;

namespace Cadarn.DependencyInjection;

public static class ViewModelBootstrapper
{
    public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        RegisterCommonViewModels(services, resolver);
    }
    
    private static void RegisterCommonViewModels(IMutableDependencyResolver services,
        IReadonlyDependencyResolver resolver)
    {
        services.RegisterLazySingleton<IMenuViewModel>(() => new MenuViewModel(
        ));
        
        services.RegisterLazySingleton<IMainWindowViewModel>(() => new MainWindowViewModel(

            resolver.GetRequiredService<IMenuViewModel>()
        ));
    }
}