﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters {
  public class BoolToEnabledConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      return (bool)value
        ? true
        : false;
      //var isChecked = (bool)value;
      //var isNormal = (string)parameter == "true" ? true : false;

      //if (isChecked && isNormal) {
      //  return true;
      //}
      //else if (!isChecked && isNormal) {
      //  return false;
      //}
      //else if (isChecked && !isNormal) {
      //  return false;
      //}
      //else {
      //  return true;
      //}
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
