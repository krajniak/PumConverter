using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels
{
    public class AppendButtonViewModel : BaseOnScreenButtonViewModel
    {
        private string _appendString;

        public AppendButtonViewModel(UnitConverterViewModel parentViewModel) : base(parentViewModel)
        {

        }

        public string AppendString { get { return _appendString; } set { _appendString = value; RaisePropertyChanged(); } }

        protected override void Execute()
        {
            base.Execute();

            _parentViewModel.EntryValue += AppendString;
        }
    }
}
