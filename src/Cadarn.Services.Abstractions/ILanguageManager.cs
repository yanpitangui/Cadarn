﻿using Cadarn.Services.Abstractions.Models;

namespace Cadarn.Services.Abstractions;

public interface ILanguageManager
{
    LanguageModel CurrentLanguage { get; }

    LanguageModel DefaultLanguage { get; }

    IEnumerable<LanguageModel> AllLanguages { get; }

    void SetLanguage(string languageCode);

    void SetLanguage(LanguageModel languageModel);
}