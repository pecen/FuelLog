using FuelLog.Core.Extensions;
using FuelLog.UI.Wpf.Module.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters {
  public class BoolToButtonToolTipTextConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      return (bool)value
        ? ToolTipTexts.UpdateButtonToolTip.GetDescription()
        : ToolTipTexts.SaveButtonToolTip.GetDescription();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
