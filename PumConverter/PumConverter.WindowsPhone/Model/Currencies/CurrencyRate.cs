using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter.Model.Currencies
{
    public class CurrencyRate
    {
        public string First { get; set; }
        public string Second { get; set; }
        public Decimal Rate { get; set; }
    }
}
