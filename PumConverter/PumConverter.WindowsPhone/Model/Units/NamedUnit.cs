using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.Model.Units
{
    public class NamedUnit
    {
        public UnitSystem System { get; private set; }
        public UnitCategory Category { get; private set; }
        public double ToSiMultiplier { get; private set; }
        public string FullName { get; private set; }
        public string Abbreviation { get; private set; }

        public NamedUnit(UnitSystem system, UnitCategory category, double toSiMultiplier, string fullName, string abbreviation)
        {
            System = system;
            Category = category;
            ToSiMultiplier = toSiMultiplier;
            FullName = fullName;
            Abbreviation = abbreviation;
        }

        public double FromSi(double siValue)
        {
            return siValue / ToSiMultiplier;
        }

        public double ToSi(double inUnitValue)
        {
            return inUnitValue * ToSiMultiplier;
        }

        public string ToString(double value)
        {
            return value.ToString("N2") + Abbreviation;
        }
    }
}
