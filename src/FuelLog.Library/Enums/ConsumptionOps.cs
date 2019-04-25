using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library.Enums {
  public enum ConsumptionOps {
    [Description("L/100Km")]
    LiterPer100Km,

    [Description("L/10Km")]
    LiterPer10Km,

    [Description("L/Km")]
    LiterPerKm,

    [Description("Km/L")]
    KmPerLiter,
  }
}
