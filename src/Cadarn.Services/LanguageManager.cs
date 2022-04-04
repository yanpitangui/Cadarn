using System.Globalization;
using Cadarn.Services.Abstractions;
using Cadarn.Services.Abstractions.Models;
using Cadarn.Services.Configuration;

namespace Cadarn.Services;

public class LanguageManager : ILanguageManager
{
    private readonly LanguagesConfiguration _configuration;
    private readonly Lazy<Dictionary<string, LanguageModel>> _availableLanguages;
    
    public LanguageModel CurrentLanguage => CreateLanguageModel(Thread.CurrentThread.CurrentUICulture);
    public LanguageModel DefaultLanguage { get; }
    public IEnumerable<LanguageModel> AllLanguages => _availableLanguages.Value.Values;
    
    public LanguageManager(LanguagesConfiguration configuration)
    {
        _configuration = configuration;
        _availableLanguages = new Lazy<Dictionary<string, LanguageModel>>(GetAvailableLanguages);

        DefaultLanguage = CreateLanguageModel(CultureInfo.GetCultureInfo("en"));
    }
    private Dictionary<string, LanguageModel> GetAvailableLanguages() =>
        _configuration
            .AvailableLocales
            .Select(locale => CreateLanguageModel(new CultureInfo(locale)))
            .ToDictionary(lm => lm.Code, lm => lm);

    private LanguageModel CreateLanguageModel(CultureInfo? cultureInfo) =>
        cultureInfo is null
            ? DefaultLanguage
            : new LanguageModel(cultureInfo.TwoLetterISOLanguageName, cultureInfo.EnglishName, cultureInfo.NativeName.ToTitleCase()
                );
    
    public void SetLanguage(string languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
        {
            throw new ArgumentException($"{nameof(languageCode)} can't be empty.");
        }

        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);
    }

    public void SetLanguage(LanguageModel languageModel) => SetLanguage(languageModel.Code);
}

public static class StringExtensions
{
    public static string ToTitleCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        if (value.Length < 2)
        {
            return value.ToUpper();
        }

        return char.ToUpper(value[0]) + value.Substring(1);
    }
}