using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.ViewModels
{
    public class UnitConverterEntryViewModel : BaseViewModel
    {
        private IStringProvider _stringProvider;

        public UnitConverterEntryViewModel(IStringProvider stringProvider)
        {
            _stringProvider = stringProvider;
            _stringProvider.ProvidedStringChanged += ProvidedStringChanged;
        }

        private void ProvidedStringChanged(object sender, EventArgs e)
        {
            Update();
        }

        const double FootToMeters = 0.3048;
        const double InchToMeters = 0.0254;

        private void Update()
        {
            try
            {
                var meteres = double.Parse(_stringProvider?.ProvidedString as string);

                From = $"{meteres.ToString("#,#.##")} m";

                var feet = Math.Floor(meteres / FootToMeters);
                var inches = Math.Round((meteres - feet * FootToMeters) / InchToMeters);
                if (inches == 12.0) { feet += 1; inches = 0; }
                if (feet == 0)
                    To = $"{inches}''";
                else if (inches == 0)
                    To = $"{feet}'";
                else
                    To = $"{feet}'{inches}''";
            }
            catch
            {
                From = string.Empty;
                To = string.Empty;
            }
        }
   
        private string _from;

        public string From
        {
            get { return _from; }
            set { _from = value; RaisePropertyChanged(); }
        }

        private string _to;

        public string To
        {
            get { return _to; }
            set { _to = value; RaisePropertyChanged(); }
        }

    }
}
