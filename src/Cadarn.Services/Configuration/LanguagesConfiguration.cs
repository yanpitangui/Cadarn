namespace Cadarn.Services.Configuration;

public record LanguagesConfiguration
{
    public List<string> AvailableLocales { get; init; } = new();

}