using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters {
  public class BoolToItalicConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      return (bool)value
       ? FontStyles.Italic
       : FontStyles.Normal;
      //var isChecked = (bool)value;
      //var isNormal = (string)parameter == "true" ? true : false;

      //if (isChecked && isNormal) {
      //  return FontStyles.Normal;
      //}
      //else if (!isChecked && isNormal) {
      //  return FontStyles.Italic;
      //}
      //else if(isChecked && !isNormal){
      //  return FontStyles.Italic;
      //}
      //else {
      //  return FontStyles.Normal;
      //}
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
