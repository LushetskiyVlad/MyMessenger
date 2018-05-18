using MessengerClient.MessengerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MessengerClient.Converters
{
    class LastItemConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var items = value as IEnumerable<object>;
            if (items != null)
            {
                return items.Select(a => ((ViewMessage)a).Content.Text).LastOrDefault();
            }
            else return Binding.DoNothing;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
