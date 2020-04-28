using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.UI.Wpf.Module.Enums
{
  public enum Titles {
    [Description("Fuel Log")]
    AppTitle,
    Cars,
    Fillups,
    Costs,
    [Description("Add Car")]
    AddCar
  }
}
