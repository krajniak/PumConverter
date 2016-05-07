using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels
{
    public abstract class BaseNonEmptyEntryValueButtonViewModel : BaseOnScreenButtonViewModel
    {
        public BaseNonEmptyEntryValueButtonViewModel(UnitConverterViewModel parentViewModel) : base(parentViewModel)
        {
            _parentViewModel.PropertyChanged += ParentViewModelPropertyChanged;
        }

        private void ParentViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UnitConverterViewModel.EntryValue) || e.PropertyName == null)
            {
                EntryValueUpdated();
            }
        }

        protected virtual void EntryValueUpdated()
        {
            ExecuteCommand.RaiseCanExecuteChanged();
        }

        protected override bool CanExecute()
        {
            return !string.IsNullOrEmpty(_parentViewModel?.EntryValue);
        }
    }
}
