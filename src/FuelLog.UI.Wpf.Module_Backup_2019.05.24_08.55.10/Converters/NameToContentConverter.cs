using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters
{
    class NameToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Type userControl = Type.GetType(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "." + value, null, null);
                return Activator.CreateInstance(userControl);
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
