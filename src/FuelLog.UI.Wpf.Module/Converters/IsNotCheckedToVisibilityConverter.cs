using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters {
  public class IsNotCheckedToVisibilityConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      return (bool)value ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
