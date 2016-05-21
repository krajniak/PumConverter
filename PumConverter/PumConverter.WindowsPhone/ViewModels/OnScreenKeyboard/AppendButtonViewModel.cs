using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels.OnScreenKeyboard
{
    public class AppendButtonViewModel : BaseOnScreenButtonViewModel
    {
        private string _appendString;
        private IStringProvider _stringProvider;

        public AppendButtonViewModel(IStringProvider stringProvider) : base()
        {
            _stringProvider = stringProvider;
        }

        public string AppendString { get { return _appendString; } set { _appendString = value; RaisePropertyChanged(); } }

        protected override void Execute()
        {
            base.Execute();

            _stringProvider.ProvidedString += AppendString;
        }
    }
}
