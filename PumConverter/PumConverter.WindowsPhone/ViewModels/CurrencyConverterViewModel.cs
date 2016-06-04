using PumConverter.ViewModels.OnScreenKeyboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PumConverter.ViewModels
{
    public class CurrencyConverterViewModel : BaseViewModel, IStringProvider
    {
        private string _entryValue;
        public string EntryValue
        {
            get { return _entryValue; }
            set {
                _entryValue = value;
                RaisePropertyChanged();
                ProvidedStringChanged?.Invoke(this, EventArgs.Empty);
                Update();
            }
        }

        private void Update()
        {
            try
            {
                var value = decimal.Parse(EntryValue);
                OutputValue = (value * Model.Currencies.CurrencyDataService.Rates[InputCurrency][OutputCurrency].Rate).ToString();
            } catch
            {
                OutputValue = string.Empty;
            }
        }

        private string _outputValue;
        public string OutputValue
        {
            get { return _outputValue; }
            set
            {
                _outputValue = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _currencies;

        public List<string> Currencies
        {
            get { return _currencies; }
            set { _currencies = value; RaisePropertyChanged(); }
        }


        private string _inputCurrency;
        public string InputCurrency
        {
            get { return _inputCurrency; }
            set { _inputCurrency = value; RaisePropertyChanged(); Update(); }
        }

        private string _outputCurrency;

        public string OutputCurrency
        {
            get { return _outputCurrency; }
            set { _outputCurrency = value; RaisePropertyChanged(); Update(); }
        }


        public List<BaseOnScreenButtonViewModel> OnScreenKeyboardButtons { get; private set; }
        

        public CurrencyConverterViewModel()
        {
            var buttonList = new List<BaseOnScreenButtonViewModel>(
                Enumerable
                .Range(0, 10)
                .Select(x => (x+1)%10 )
                .Select(x => new AppendButtonViewModel(this) { Label = x.ToString(), AppendString = x.ToString() })
                );

            buttonList.Add(new BackspaceOnScreenButtonViewModel(this) { Label = "" });
            buttonList.Add(new ClearOnScreenButtonViewModel(this) { Label = "" });

            buttonList.Add(new AppendButtonViewModel(this) { Label = ".", AppendString = "." });
            buttonList.Add(new AppendButtonViewModel(this) { Label = "'", AppendString = "'" });
            buttonList.Add(new AppendButtonViewModel(this) { Label = "''", AppendString = "''" });

            OnScreenKeyboardButtons = buttonList;

            InitCurrencies();
        }

        public async void InitCurrencies()
        {
            await Model.Currencies.CurrencyDataService.LoadRatesAsync();
            Currencies = Model.Currencies.CurrencyDataService.Currencies.ToList();
            InputCurrency = Currencies.First();
            OutputCurrency = Currencies.Skip(1).First();
        }
        
        public string ProvidedString { get { return EntryValue; } set { EntryValue = value; } }
        public event EventHandler ProvidedStringChanged;
    }
}
