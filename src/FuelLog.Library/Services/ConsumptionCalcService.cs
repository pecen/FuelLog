using FuelLog.Library.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FuelLog.Library.Services {
  public class ConsumptionCalcService {
    private readonly IDictionary<string, ConsumptionOps> _ops;

    public ConsumptionCalcService() {
      _ops = new Dictionary<string, ConsumptionOps> {
        ["KmPerL"] = ConsumptionOps.KmPerLiter
      };
    }

    #region Properties

    public IDictionary<string, ConsumptionOps> Ops {
      get {
        return _ops;

        //return new Dictionary<string, ConsumptionOps> {
        //  ["KmPerL"] = ConsumptionOps.KmPerLiter
        //};
      }
    }

    //public IDictionary<string, string> APICalls {
    //  get {
    //    return new Dictionary<string, string> {
    //      [EnumUtilities.GetEnumDescription(ApiRequests.GetAllRooms)] = "api/connector/v1/spaces/getAll",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.SearchCustomers)] = "api/connector/v1/customers/search",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.AddOrder)] = "api/connector/v1/orders/add",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.GetServices)] = "api/connector/v1/services/getAll",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.GetReservations)] = "api/connector/v1/reservations/getAll",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.GetAccountingCategories)] = "api/connector/v1/accountingCategories/getAll",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.AddOutletBill)] = "api/connector/v1/outletbills/add",
    //      [EnumUtilities.GetEnumDescription(ApiRequests.GetAllOutlets)] = "api/connector/v1/outlets/getAll"
    //    };
    //  }
    //}

    #endregion

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
