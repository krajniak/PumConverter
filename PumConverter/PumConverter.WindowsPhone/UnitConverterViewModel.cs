using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter
{
    public class UnitConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _entryValue;
        public string EntryValue
        {
            get { return _entryValue; }
            set { _entryValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntryValue))); }
        }
    }
}
