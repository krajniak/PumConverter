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
            set { _entryValue = value; RaisePropertyChanged(); BackspaceCommand.RaiseCanExecuteChanged(); }
        }

        public UnitConverterViewModel()
        {
            BackspaceCommand = new RelayCommand(o => EntryValue = EntryValue?.Substring(0, EntryValue.Length - 1), o => (EntryValue?.Length ?? 0) != 0);
            ZeroCommand = new RelayCommand(o => EntryValue += "0");
        }

        public RelayCommand BackspaceCommand { get; private set; } 
        public RelayCommand ZeroCommand { get; private set; }
    }
}
