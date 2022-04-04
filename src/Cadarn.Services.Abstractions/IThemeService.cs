using Cadarn.Services.Abstractions.Models.Enums;

namespace Cadarn.Services.Abstractions;

public interface IThemeService
{
    Theme GetCurrentTheme();
}