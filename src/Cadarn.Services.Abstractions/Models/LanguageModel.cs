namespace Cadarn.Services.Abstractions.Models;

public record struct LanguageModel(string Code, string Name, string NativeName)
{
    public string Name { get; init; } = Name;

    public string NativeName { get; init;  } = NativeName;
    public string Code { get; init; } = Code;
}