using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace avTest.Localization
{
    public class LocalizedStrings : ReactiveObject
    {

        private readonly LocalizationService _localizationService;

        public LocalizedStrings(LocalizationService localizationService)
        {
            _localizationService = localizationService;
            _localizationService.LanguageChanged += (sender, args) => this.RaisePropertyChanged(string.Empty);
        }

        public string TestText => Language.TestText;

        public string LanguageText => Language.langText;


        public string WelcomeText => Language.textWelcome;

    }
}
