using Avalonia.Interactivity;
using avTest.Enums;
using avTest.Localization;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace avTest.Localization
{
    public class LocalizationService : ReactiveObject
    {

        private string _currentLanguage = "en";
        public string CurrentLanguage
        {
            get => _currentLanguage;
            set => this.RaiseAndSetIfChanged(ref _currentLanguage, value);
        }

        public event EventHandler? LanguageChanged;

        public void updateLanguage(string languageCode)
        {
            CurrentLanguage = languageCode;


            CultureInfo.CurrentCulture = new CultureInfo(languageCode);
            CultureInfo.CurrentUICulture = new CultureInfo(languageCode);   


            LanguageChanged?.Invoke(this, EventArgs.Empty);

        }
    }
}
