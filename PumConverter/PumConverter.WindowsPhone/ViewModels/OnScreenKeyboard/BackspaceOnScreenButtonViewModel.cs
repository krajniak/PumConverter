using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels.OnScreenKeyboard
{
    public class BackspaceOnScreenButtonViewModel : BaseNonEmptyEntryValueButtonViewModel
    {
        public BackspaceOnScreenButtonViewModel(IStringProvider stringProvider) : base(stringProvider)
        {
        }

        protected override void Execute()
        {
            _stringProvider.ProvidedString = _stringProvider.ProvidedString.Substring(0, _stringProvider.ProvidedString.Length - 1); 
        }
    }
}
