using Cadarn.Services.Abstractions;
using Cadarn.Services.Abstractions.Models.Enums;
using Cadarn.Services.Configuration;

namespace Cadarn.Services;

public class ThemeService : IThemeService
{
    private readonly DefaultThemeConfiguration _defaultThemeConfiguration;

    public ThemeService(DefaultThemeConfiguration defaultThemeConfiguration)
    {
        _defaultThemeConfiguration = defaultThemeConfiguration;
    }

    public Theme GetCurrentTheme()
    {
        return _defaultThemeConfiguration.DefaultTheme;
    }
}