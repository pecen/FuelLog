using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.UI.Wpf.Module.Enums {
  public enum ToolTipTexts {
    [Description("Click the button to save the car")]
    SaveButtonToolTip,
    [Description("Click the button to update the existing car")]
    UpdateButtonToolTip,
    [Description("Click the button to import the cars")]
    ImportButtonToolTip
  }
}
