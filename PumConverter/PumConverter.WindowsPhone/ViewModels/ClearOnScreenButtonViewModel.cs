using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels
{
    public class ClearOnScreenButtonViewModel : BaseNonEmptyEntryValueButtonViewModel
    {
        public ClearOnScreenButtonViewModel(UnitConverterViewModel parentViewModel) : base(parentViewModel)
        {
        }

        protected override void Execute()
        {
            _parentViewModel.EntryValue = string.Empty;
        }
    }
}
