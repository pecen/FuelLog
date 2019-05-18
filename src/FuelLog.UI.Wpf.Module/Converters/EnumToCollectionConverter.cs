﻿using FuelLog.Core.Utilities;
using FuelLog.Library.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace FuelLog.UI.Wpf.Module.Converters {
  //[ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescription>))]
  //public class EnumToCollectionConverter : MarkupExtension, IValueConverter {
  //  public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
  //    return EnumHelper.GetAllValuesAndDescriptions(value.GetType());
  //  }
  //  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
  //    return null;
  //  }
  //  public override object ProvideValue(IServiceProvider serviceProvider) {
  //    return this;
  //  }
  //}

  public class EnumToCollectionConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      if (value is ConsumptionUnitType description) {
        return EnumUtils.GetEnumDescription(description);
      }

      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
  }
}