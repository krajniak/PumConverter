using PumConverter.Model.Units;
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
        private string _from;
        private string _to;
        private readonly UnitSystem _entrySystem;
        private readonly UnitCategory _category;
        private IList<NamedUnit> _entryNamedUnits;
        private IList<NamedUnit> _outputNamedUnits;
        private int _currentIndex;


        public UnitConverterEntryViewModel(IStringProvider stringProvider, UnitSystem entrySystem, UnitCategory category)
        {
            _stringProvider = stringProvider;
            _stringProvider.ProvidedStringChanged += ProvidedStringChanged;
            _entrySystem = entrySystem;
            _category = category;
            _entryNamedUnits = UnitsLibrary.NamedUnits(entrySystem, category).ToList();
            _outputNamedUnits = UnitsLibrary.NamedUnits(entrySystem == UnitSystem.Imperial ? UnitSystem.Metric : UnitSystem.Imperial, category)
                .ToList();

            _currentIndex = 0;

            NextNamedUnitCommand = new RelayCommand(_ => NextNamedUnit());
        }

        private void ProvidedStringChanged(object sender, EventArgs e)
        {
            Update();
        }
        
        private void Update()
        {
            try
            {
                var entryValue = double.Parse(_stringProvider?.ProvidedString as string);

                From = $"{entryValue.ToString("#,#.##")} {_entryNamedUnits[_currentIndex].Abbreviation}";

                var si = _entryNamedUnits[_currentIndex].ToSi(entryValue);
                var outputValue = _outputNamedUnits[_currentIndex].FromSi(si);

                To = $"{outputValue.ToString("#,#.##")} {_outputNamedUnits[_currentIndex].Abbreviation}";
            }
            catch
            {
                From = string.Empty;
                To = string.Empty;
            }
        }
 
        public string From
        {
            get { return _from; }
            set { _from = value; RaisePropertyChanged(); }
        }


        public string To
        {
            get { return _to; }
            set { _to = value; RaisePropertyChanged(); }
        }

        public RelayCommand NextNamedUnitCommand { get; private set; }

        public void NextNamedUnit()
        {
            _currentIndex = (_currentIndex + 1) % _entryNamedUnits.Count;
            Update();
        }
    }
}
