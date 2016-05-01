using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PumConverter
{
    public class MetersToFeetValueConverter : IValueConverter
    {
        const double FootToMeters = 0.3048;
        const double InchToMeters = 0.0254;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var meteres = double.Parse(value as string);
                var feet = Math.Floor(meteres / FootToMeters);
                var inches = Math.Round((meteres - feet * FootToMeters) / InchToMeters);
                if (inches == 12.0) { feet += 1; inches = 0; }
                if (feet == 0)
                    return $"{meteres}m equals {inches}''";
                else if (inches == 0)
                    return $"{meteres}m equals {feet}'";
                else
                    return $"{meteres}m equals {feet}'{inches}''";
            }
            catch
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
