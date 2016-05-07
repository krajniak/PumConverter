using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels
{
    public class BackspaceOnScreenButtonViewModel : BaseNonEmptyEntryValueButtonViewModel
    {
        public BackspaceOnScreenButtonViewModel(UnitConverterViewModel parentViewModel) : base(parentViewModel)
        {
        }

        protected override void Execute()
        {
            _parentViewModel.EntryValue = _parentViewModel.EntryValue.Substring(0, _parentViewModel.EntryValue.Length - 1); 
        }
    }
}
