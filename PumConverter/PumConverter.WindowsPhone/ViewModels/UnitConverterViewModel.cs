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
    public class UnitConverterViewModel : BaseViewModel, IStringProvider
    {
        private string _entryValue;
        public string EntryValue
        {
            get { return _entryValue; }
            set {
                _entryValue = value;
                RaisePropertyChanged();
                ProvidedStringChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool _isMetricToImperial;

        public bool IsMetricToImperial
        {
            get { return _isMetricToImperial; }
            set { _isMetricToImperial = value; RaisePropertyChanged(); }
        }

        public List<BaseOnScreenButtonViewModel> OnScreenKeyboardButtons { get; private set; }

        private UnitConverterEntryViewModel _converterEntry;

        public UnitConverterEntryViewModel ConverterEntry
        {
            get { return _converterEntry; }
            set { _converterEntry = value; RaisePropertyChanged(); }
        }

        public UnitConverterViewModel()
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

            ConverterEntry = new UnitConverterEntryViewModel(this, Model.Units.UnitSystem.Metric, Model.Units.UnitCategory.Weight);
        }


        public string ProvidedString { get { return EntryValue; } set { EntryValue = value; } }
        public event EventHandler ProvidedStringChanged;
    }
}
