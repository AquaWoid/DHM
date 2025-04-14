using Avalonia.Interactivity;
using avTest.Enums;
using avTest.Localization;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Input;



namespace avTest.ViewModels;

public class MainViewModel : ViewModelBase
{


    private readonly LocalizationService _LocalizationService;
    public LocalizedStrings Localization { get; }

    


    public ObservableCollection<string> languages { get; } = new() {"English", "German", "Japanese", "French"};


    #region Ui Element Bindings


    private string _selectedItem = "English";
    public string selectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);

    }

    private string _inputText = "Input text here";
    public string inputText
    {
        get => _inputText;
        set => this.RaiseAndSetIfChanged(ref _inputText, value);

        
        
    }


    private string _Greeting = "Welcome";
    public string Greeting {

        get => _Greeting;
        set => this.RaiseAndSetIfChanged(ref _Greeting, value);


    }

    #endregion

    public ICommand testCommand{ get; }


    public MainViewModel()
    {
        _LocalizationService =  new LocalizationService();

        Localization = new LocalizedStrings(_LocalizationService);



        this.WhenAnyValue(x => x.selectedItem).Subscribe(n => updateLanguage());

        testCommand = ReactiveCommand.Create(() =>
        {         
            updateLanguage();

        });
    }

    void updateLanguage()
    {
        switch (selectedItem)
        {
            case "English":
                _LocalizationService.updateLanguage("en");
                break;
            case "German":
                _LocalizationService.updateLanguage("de");
                break;
            case "Japanese":
                _LocalizationService.updateLanguage("ja");
                break;
            case "French":
                _LocalizationService.updateLanguage("fr");
                break;

        }


        inputText = Language.inputFieldText;
        Greeting = Language.textWelcome;
    }

    private void initLanguageUpdateCMD ()
    {


    }


}
