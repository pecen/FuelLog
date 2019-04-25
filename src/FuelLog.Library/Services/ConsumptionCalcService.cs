using FuelLog.Core.Utilities;
using FuelLog.Library.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace FuelLog.Library.Services {
  public class ConsumptionCalcService {
    public ConsumptionCalcService() {
      //_kmPerLiter = ConsumptionOps.KmPerLiter.GetEnumDescription();

      Ops = new Dictionary<string, ConsumptionOps> {
        [ConsumptionOps.KmPerLiter.GetEnumDescription()] = ConsumptionOps.KmPerLiter,
        [ConsumptionOps.LiterPer100Km.GetEnumDescription()] = ConsumptionOps.LiterPer100Km, 
        [ConsumptionOps.LiterPer10Km.GetEnumDescription()] = ConsumptionOps.LiterPer10Km,
        [ConsumptionOps.LiterPerKm.GetEnumDescription()] = ConsumptionOps.LiterPerKm
      };
    }

    #region Properties

    public IDictionary<string, ConsumptionOps> Ops { get; }

    #endregion

    // TODO: Add the different consumption calculations here

    [Description("km/liter")]
    public static double KmPerLiter(FillupList fillups) {
      var f = fillups.OrderBy(a => a.FillupDate);

      var first = f.First();
      var last = f.Last(); 
      var firstOdo = int.Parse(Regex.Match(first.Odometer, @"\d+").Value);
      var lastOdo = int.Parse(Regex.Match(last.Odometer, @"\d+").Value);

      var firstAmount = decimal.Parse(Regex.Match(first.Amount, @"\d+.+\d").Value);
      var sumAmount = fillups.Sum(con => decimal.Parse(Regex.Match(con.Amount, @"\d+.+\d").Value));
      return (double)Math.Round((lastOdo - firstOdo) / (sumAmount - firstAmount), 2);
    }

    public static void Calculate<T> (T[] values, Func<T, T> units) {

    }
    public void LiterPer100Km(CarInfo car) {

    }

    public void MilesPerUSGallon(CarInfo car) { }

    public void MilesPerImpGallon(CarInfo car) { }

    public void KmPerLiter(CarInfo car) { }

    public T CalculateConsumption<T>(CarInfo car) where T : class {
      return default(T);
    }
  }
}
