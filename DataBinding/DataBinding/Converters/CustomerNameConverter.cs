using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBinding.Converters
{
    public class CustomerNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StringBuilder _sb = new StringBuilder();
            foreach (object item in values)
            {
                _sb.Append(item.ToString()).Append(" ");
            }

            return _sb.ToString().Trim();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString().Split(' ');
        }
    }
}
