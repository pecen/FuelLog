using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FuelLog.Library.Services {
  public class ConsumptionCalcService {
    // TODO: Add the different consumption calculations here
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
  }
}
