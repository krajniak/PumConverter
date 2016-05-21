using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PumConverter.ViewModels.OnScreenKeyboard
{
    public abstract class BaseOnScreenButtonViewModel : BaseViewModel
    {
        private string _label;
      
        public BaseOnScreenButtonViewModel()
        {
            ExecuteCommand = new RelayCommand(_ => Execute(), _ => CanExecute() );
        }
        
        protected virtual void Execute()
        {

        }

        protected virtual bool CanExecute()
        {
            return true;
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; RaisePropertyChanged(); }
        }

        public RelayCommand ExecuteCommand { get; set; }
    }
}
