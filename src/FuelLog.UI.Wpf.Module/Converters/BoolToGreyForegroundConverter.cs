using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FuelLog.UI.Wpf.Module.Converters {
  public class BoolToGreyForegroundConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      return (bool)value
        ? new SolidColorBrush(Colors.Black)
        : new SolidColorBrush(Colors.Gray);
      //var isChecked = (bool)value;
      //var isNormal = (string)parameter == "true" ? true : false;

      //if (isChecked && isNormal) {
      //  return new SolidColorBrush(Colors.Black);
      //}
      //else if (!isChecked && isNormal) {
      //  return new SolidColorBrush(Colors.Gray);
      //}
      //else if (isChecked && !isNormal) {
      //  return new SolidColorBrush(Colors.Gray);
      //}
      //else {
      //  return new SolidColorBrush(Colors.Black);
      //}
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
