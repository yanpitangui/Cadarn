using Splat;
using static Cadarn.DependencyInjection.LoggingBootstrapper;
using static Cadarn.DependencyInjection.ConfigurationBootstrapper;
using static Cadarn.DependencyInjection.ServicesBootstrapper;
using static Cadarn.DependencyInjection.ViewModelBootstrapper;

namespace Cadarn.DependencyInjection;

public static class Bootstrapper
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        RegisterConfiguration(services, resolver);
        RegisterLogging(services, resolver);
        RegisterServices(services, resolver);
        RegisterViewModels(services, resolver);
    }
}