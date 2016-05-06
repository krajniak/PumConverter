using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PumConverter.ViewModels
{
    public class UnitConverterViewModel : BaseViewModel
    {
        private string _entryValue;
        public string EntryValue
        {
            get { return _entryValue; }
            set { _entryValue = value; RaisePropertyChanged(); }
        }

        public List<BaseOnScreenButtonViewModel> OnScreenKeyboardButtons { get; private set; }

        public UnitConverterViewModel()
        {
            var buttonList = new List<BaseOnScreenButtonViewModel>(
                Enumerable
                .Range(0, 10)
                .Select(x => (x+1)%10 )
                .Select(x => new AppendButtonViewModel(this) { Label = x.ToString(), AppendString = x.ToString() })
                );

            OnScreenKeyboardButtons = buttonList;
        }

    }
}
