using Cadarn.Services.Abstractions.Models;

namespace Cadarn.Services.Abstractions;

public interface ILocalizationService
{
    LanguageModel GetSavedLanguage();
}