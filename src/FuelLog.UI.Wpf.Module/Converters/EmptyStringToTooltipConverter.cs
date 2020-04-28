using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters {
  public class EmptyStringToTooltipConverter : IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
      var value = values[0] as string;

      if (string.IsNullOrEmpty(value) || !Path.IsPathRooted(value)) {
        return values[1] as string;
      }

      return values[0];
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
