using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumConverter
{
    public interface IStringProvider
    {
        string ProvidedString { get; set; }
        event EventHandler ProvidedStringChanged;
    }
}
