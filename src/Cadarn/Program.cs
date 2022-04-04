using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Cadarn.DependencyInjection;
using Microsoft.Extensions.Logging;
using Splat;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Cadarn;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        SubscribeToDomainUnhandledEvents();
        RegisterDependencies();
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args, ShutdownMode.OnMainWindowClose);
    }

    private static void RegisterDependencies() => 
        Bootstrapper.Register(Locator.CurrentMutable, Locator.Current);

    private static void SubscribeToDomainUnhandledEvents() =>
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            var logger = Locator.Current.GetRequiredService<ILogger>();
            var ex = (Exception) args.ExceptionObject;

            logger.LogCritical(ex, $"Unhandled application error");
        };

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
}