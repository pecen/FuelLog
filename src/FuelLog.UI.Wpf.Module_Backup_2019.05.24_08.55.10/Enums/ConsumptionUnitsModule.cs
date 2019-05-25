using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library.Enums {
  public enum ConsumptionUnitsModule {
    [Description("l/100km")]
    LiterPer100Km,

    [Description("l/10km")]
    LiterPer10Km,

    [Description("l/km")]
    LiterPerKm,

    [Description("mpg (us)")]
    MilesPerGallonUS,

    [Description("mpg (uk)")]
    MilesPerGallonUK,

    [Description("km/l")]
    KmPerLiter,

    [Description("l/mi")]
    LiterPerMiles,

    [Description("mi/l")]
    MilesPerLiter,

    [Description("gal(us)/km")]
    USGallonsPerKm,

    [Description("gal(us)/100km")]
    USGallonsPer100Km,

    [Description("gal(us)/mi")]
    USGallonsPerMiles,

    [Description("gal(us)/100mi")]
    USGallonsPer100Miles,

    [Description("km/gal(us)")]
    KmPerUSGallons,

    [Description("gal(uk)/km")]
    UKGallonsPerKm,

    [Description("gal(uk)/100km")]
    UKGallonsPer100Km,

    [Description("gal(uk)/mi")]
    UKGallonsPerMiles,

    [Description("gal(uk)/100mi")]
    UKGallonsPer100Miles,

    [Description("km/gal(uk)")]
    KmPerUKGallons,

    [Description("kWh/km")]
    KiloWattPerKm,

    [Description("kWh/100km")]
    KiloWattPer100Km,

    [Description("kWh/mi")]
    KiloWattPerMiles,

    [Description("kWh/100mi")]
    KiloWattPer100Miles,

    [Description("km/kWh")]
    KmPerKiloWatt,

    [Description("mi/kWh")]
    MilesPerKiloWatt,

    [Description("kg/km")]
    KgPerKm,

    [Description("kg/100km")]
    KgPer100Km,

    [Description("kg/mi")]
    KgPerMiles,

    [Description("kg/100mi")]
    KgPer100Miles,

    [Description("km/kg")]
    KmPerKg,

    [Description("mi/kg")]
    MilesPerKg,

    [Description("gge/km")]
    GGEPerKm,

    [Description("gge/100km")]
    GGEPer100Km,

    [Description("gge/mi")]
    GGEPerMiles,

    [Description("gge/100mi")]
    GGEPer100Miles,

    [Description("km/gge")]
    KmPerGGE,

    [Description("mi/gge")]
    MilesPerGGE,

    [Description("l/h")]
    LitresPerHour,

    [Description("h/l")]
    HoursPerLitre,

    [Description("gal(us)/h")]
    USGallonsPerHour,

    [Description("h/gal(us)")]
    HoursPerUSGallons,

    [Description("gal(uk)/h")]
    UKGallonsPerHour,

    [Description("h/gal(uk)")]
    HoursPerUKGallons,

    [Description("kWh/h")]
    KiloWattPerHour,

    [Description("h/kWh")]
    HoursPerKiloWatt,

    [Description("kg/h")]
    KgPerHour,

    [Description("h/kg")]
    HoursPerKg,

    [Description("gge/h")]
    GGEPerHour,

    [Description("h/gge")]
    HoursPerGGE,
  }
}
