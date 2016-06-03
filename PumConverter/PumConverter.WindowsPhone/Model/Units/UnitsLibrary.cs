using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.Model.Units
{
    public static class UnitsLibrary
    {
        private static Dictionary<UnitSystem, Dictionary<UnitCategory, List<NamedUnit>>> _units =
            new Dictionary<UnitSystem, Dictionary<UnitCategory, List<NamedUnit>>>();

        static UnitsLibrary()
        {
            // Initialize all unit systems
            _units[UnitSystem.Imperial] = new Dictionary<UnitCategory, List<NamedUnit>>();
            _units[UnitSystem.Metric] = new Dictionary<UnitCategory, List<NamedUnit>>();

            // Initialze unit lists
            foreach (var unitSystem in Enum.GetValues(typeof(UnitSystem)).Cast<UnitSystem>())
                foreach (var unitType in Enum.GetValues(typeof(UnitCategory)).Cast<UnitCategory>())
                    _units[unitSystem][unitType] = new List<NamedUnit>();

            // Weight
            _units[UnitSystem.Imperial][UnitCategory.Weight].Add(new NamedUnit(UnitSystem.Imperial, UnitCategory.Weight, 0.02835 ,"ounce", "oz"));
            _units[UnitSystem.Imperial][UnitCategory.Weight].Add(new NamedUnit(UnitSystem.Imperial, UnitCategory.Weight, 0.4536 ,"pound", "lb"));
            _units[UnitSystem.Imperial][UnitCategory.Weight].Add(new NamedUnit(UnitSystem.Imperial, UnitCategory.Weight, 907.2, "us ton", "t"));

            _units[UnitSystem.Metric][UnitCategory.Weight].Add(new NamedUnit(UnitSystem.Metric, UnitCategory.Weight, 0.001, "gram", "g"));
            _units[UnitSystem.Metric][UnitCategory.Weight].Add(new NamedUnit(UnitSystem.Metric, UnitCategory.Weight, 1, "kilogram", "kg"));
            _units[UnitSystem.Metric][UnitCategory.Weight].Add(new NamedUnit(UnitSystem.Metric, UnitCategory.Weight, 1000, "ton", "t"));

        }

        public static IEnumerable<NamedUnit> NamedUnits(UnitSystem system, UnitCategory category)
        {
            return _units[system][category];
        }
    }
}
