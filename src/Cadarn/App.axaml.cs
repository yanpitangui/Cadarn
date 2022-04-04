using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Cadarn.DependencyInjection;
using Cadarn.Services.Abstractions;
using Cadarn.Services.Abstractions.Models.Enums;
using Cadarn.Styles.Themes;
using Cadarn.ViewModels.Interfaces;
using Cadarn.Views;
using Splat;

namespace Cadarn;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        LoadSettings();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DataContext = GetRequiredService<IMainWindowViewModel>();
            desktop.MainWindow = new MainWindow
            {
                DataContext = DataContext
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private void LoadSettings()
    {
        LoadTheme();
        LoadLanguage();
    }

    private void LoadTheme()
    {
        var themeService = GetRequiredService<IThemeService>();
        var selectedTheme = themeService.GetCurrentTheme();

        Styles.Add(selectedTheme switch
        {
            Theme.Dark => new DarkTheme(),
            Theme.Light => new LightTheme(),
            _ => throw new ArgumentOutOfRangeException(nameof(selectedTheme), selectedTheme, null)
        });
    }

    private static void LoadLanguage()
    {
        var localizationService = GetRequiredService<ILocalizationService>();
        if (localizationService.GetSavedLanguage() is { } savedLanguage)
        {
            var languageManager = GetRequiredService<ILanguageManager>();

            languageManager.SetLanguage(savedLanguage.Code);
        }
    }
        
    private static T GetRequiredService<T>() => Locator.Current.GetRequiredService<T>();
}