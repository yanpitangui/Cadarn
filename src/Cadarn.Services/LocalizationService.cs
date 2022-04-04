using Cadarn.Services.Abstractions;
using Cadarn.Services.Abstractions.Models;

namespace Cadarn.Services;

public class LocalizationService : ILocalizationService
{
    public LanguageModel GetSavedLanguage()
    {
        return new LanguageModel(Code: "en-us", Name: "English", NativeName: "English");
    }
    
}