using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels.OnScreenKeyboard
{
    public abstract class BaseNonEmptyEntryValueButtonViewModel : BaseOnScreenButtonViewModel
    {
        protected IStringProvider _stringProvider;

        public BaseNonEmptyEntryValueButtonViewModel(IStringProvider stringProvider) : base()
        {
            _stringProvider = stringProvider;
            _stringProvider.ProvidedStringChanged += ProvidedStringChanged;
        }

        private void ProvidedStringChanged(object sender, EventArgs e)
        { 
                EntryValueUpdated();
        }

        protected virtual void EntryValueUpdated()
        {
            ExecuteCommand.RaiseCanExecuteChanged();
        }

        protected override bool CanExecute()
        {
            return !string.IsNullOrEmpty(_stringProvider?.ProvidedString);
        }
    }
}
