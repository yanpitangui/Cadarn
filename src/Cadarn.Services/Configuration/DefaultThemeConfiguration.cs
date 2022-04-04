using Cadarn.Services.Abstractions.Models.Enums;

namespace Cadarn.Services.Configuration;

public record DefaultThemeConfiguration
{
    public Theme DefaultTheme { get; init; }
}