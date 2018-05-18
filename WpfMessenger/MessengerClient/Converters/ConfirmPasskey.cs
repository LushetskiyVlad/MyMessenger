using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MessengerClient.Converters
{
    public class ConfirmPasskey : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parm, System.Globalization.CultureInfo culture)
        {
            return values.ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parm, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}