using System.ComponentModel;

namespace FuelLog.UI.Wpf.Module.Enums {
  public enum VolumeUnits {
    [Description("Litres (l)")]
    Litres,
    [Description("Gallons US (gal)")]
    GallonsUS,
    [Description("Gallons UK (gal)")]
    GallonsUK,
    [Description("Electric (kWh)")]
    Electric,
    [Description("CNG (kg)")]
    CNGkg,
    [Description("CNG (gge)")]
    CNGgge,
  }
}
