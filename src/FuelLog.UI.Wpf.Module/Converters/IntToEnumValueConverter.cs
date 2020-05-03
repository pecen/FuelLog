using FuelLog.Core.Extensions;
using FuelLog.Library.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FuelLog.UI.Wpf.Module.Converters
{
  public class IntToEnumValueConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      var s = parameter.ToString();
      string enumValue = string.Empty;
      string description = string.Empty;

      if (!string.IsNullOrEmpty(s)) {
        s = s.Substring(s.LastIndexOf('.') + 1);
        switch (s) {
          case "DistanceUnits":
            description = ((DistanceUnits)value).GetDescription();
            enumValue = string.IsNullOrEmpty(description) ? ((DistanceUnits)value).ToString() : description;
            break;
          case "VolumeUnits":
            description = ((VolumeUnits)value).GetDescription();
            enumValue = string.IsNullOrEmpty(description) ? ((VolumeUnits)value).ToString() : description;
            break;
          case "ConsumptionUnits":
            description = ((ConsumptionUnits)value).GetDescription();
            enumValue = string.IsNullOrEmpty(description) ? ((ConsumptionUnits)value).ToString() : description;
            break;
        }
      }

      return enumValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}
