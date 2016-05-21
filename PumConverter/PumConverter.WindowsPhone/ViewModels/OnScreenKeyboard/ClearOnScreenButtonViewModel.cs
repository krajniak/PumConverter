using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels.OnScreenKeyboard
{
    public class ClearOnScreenButtonViewModel : BaseNonEmptyEntryValueButtonViewModel
    {
        public ClearOnScreenButtonViewModel(IStringProvider stringProvider) : base(stringProvider)
        {
        }

        protected override void Execute()
        {
            _stringProvider.ProvidedString = string.Empty;
        }
    }
}
