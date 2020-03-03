using Csla;
using FuelLog.Core.Utilities;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using FuelLog.Library.Enums;
using FuelLog.Library.Services;
using FuelLog.UI.Wpf.Module.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class CarInfo : ReadOnlyBase<CarInfo> {
    #region Properties

    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    public int Id {
      get { return GetProperty(IdProperty); }
      set { LoadProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<string> MakeProperty = RegisterProperty<string>(c => c.Make);
    public string Make {
      get { return GetProperty(MakeProperty); }
      set { LoadProperty(MakeProperty, value); }
    }

    public static readonly PropertyInfo<string> ModelProperty = RegisterProperty<string>(c => c.Model);
    public string Model {
      get { return GetProperty(ModelProperty); }
      set { LoadProperty(ModelProperty, value); }
    }

    public string FullName {
      get { return $"{Make} {Model}"; }
    }

    public static readonly PropertyInfo<string> LicensePlateProperty = RegisterProperty<string>(c => c.LicensePlate);
    public string LicensePlate {
      get { return GetProperty(LicensePlateProperty); }
      //get => !string.IsNullOrEmpty(Note) ? $"{GetProperty(LicensePlateProperty)} | {GetProperty(NoteProperty)}" : GetProperty(LicensePlateProperty);

      set { LoadProperty(LicensePlateProperty, value); }
    }

    public static readonly PropertyInfo<string> NoteProperty = RegisterProperty<string>(c => c.Note);

    public string Note {
      get { return GetProperty(NoteProperty); }
      set { LoadProperty(NoteProperty, value); }
    }

    //public static readonly PropertyInfo<DistanceInfo> DistanceUnitProperty = RegisterProperty<DistanceInfo>(c => c.DistanceUnit);
    //public DistanceInfo DistanceUnit {
    //  get { return GetProperty(DistanceUnitProperty); }
    //  set { LoadProperty(DistanceUnitProperty, value); }
    //}

    public static readonly PropertyInfo<DistanceUnits> DistanceUnitProperty = RegisterProperty<DistanceUnits>(c => c.DistanceUnit);
    public DistanceUnits DistanceUnit {
      get { return GetProperty(DistanceUnitProperty); }
      set { LoadProperty(DistanceUnitProperty, value); }
    }

    //public static readonly PropertyInfo<VolumeInfo> VolumeProperty = RegisterProperty<VolumeInfo>(c => c.VolumeUnit);
    //public VolumeInfo VolumeUnit {
    //  get { return GetProperty(VolumeProperty); }
    //  set { LoadProperty(VolumeProperty, value); }
    //}

    public static readonly PropertyInfo<VolumeUnits> VolumeProperty = RegisterProperty<VolumeUnits>(c => c.VolumeUnit);
    public VolumeUnits VolumeUnit {
      get { return GetProperty(VolumeProperty); }
      set { LoadProperty(VolumeProperty, value); }
    }

    //public static readonly PropertyInfo<ConsumptionUnitType> ConsumptionUnitProperty = RegisterProperty<ConsumptionUnitType>(c => c.ConsumptionUnit);
    //public ConsumptionUnitType ConsumptionUnit {
    //  get { return GetProperty(ConsumptionUnitProperty); }
    //  set { LoadProperty(ConsumptionUnitProperty, value); }
    //}

    public static readonly PropertyInfo<ConsumptionUnits> ConsumptionUnitProperty = RegisterProperty<ConsumptionUnits>(c => c.ConsumptionUnit);
    public ConsumptionUnits ConsumptionUnit {
      get { return GetProperty(ConsumptionUnitProperty); }
      set { LoadProperty(ConsumptionUnitProperty, value); }
    }

    // To be implemented
    //
    //public string ChosenUnits {
    //  get { return DistanceUnit.ShortName + ", " + VolumeUnit.ShortName + ", " + ConsumptionUnit.Name; }
    //  //get { return DistanceUnit.ShortName + ", " + VolumeUnit.ShortName + ", " + ConsumptionUnit.GetEnumDescription(); }
    //}

    public static readonly PropertyInfo<string> TotalFillupsProperty = RegisterProperty<string>(c => c.TotalFillups);
    public string TotalFillups {
      get { return GetProperty(TotalFillupsProperty); }
      set { LoadProperty(TotalFillupsProperty, value); }
    }

    public static readonly PropertyInfo<string> TotalDistanceProperty = RegisterProperty<string>(c => c.TotalDistance);
    public string TotalDistance {
      get { return GetProperty(TotalDistanceProperty); }
      set { LoadProperty(TotalDistanceProperty, value); }
    }

    public static readonly PropertyInfo<string> AverageConsumptionProperty = RegisterProperty<string>(c => c.AverageConsumption);
    public string AverageConsumption {
      get { return GetProperty(AverageConsumptionProperty); }
      set { LoadProperty(AverageConsumptionProperty, value); }
    }

    public static readonly PropertyInfo<DateTimeOffset> DateAddedProperty = RegisterProperty<DateTimeOffset>(c => c.DateAdded);
    public DateTimeOffset DateAdded {
      get { return GetProperty(DateAddedProperty); }
      set { LoadProperty(DateAddedProperty, value); }
    }

    public static readonly PropertyInfo<DateTimeOffset> LastModifiedProperty = RegisterProperty<DateTimeOffset>(c => c.LastModified);
    public DateTimeOffset LastModified {
      get { return GetProperty(LastModifiedProperty); }
      set { LoadProperty(LastModifiedProperty, value); }
    }

    public static readonly PropertyInfo<FillupList> FillupsProperty = RegisterProperty<FillupList>(c => c.Fillups);
    public FillupList Fillups {
      get { return GetProperty(FillupsProperty); }
      set { LoadProperty(FillupsProperty, value); }
    }

    //public static readonly PropertyInfo<CarSettingsInfo> CarSettingsProperty = RegisterProperty<CarSettingsInfo>(c => c.CarSettings);
    //public CarSettingsInfo CarSettings
    //{
    //    get { return GetProperty(CarSettingsProperty); }
    //    set { LoadProperty(CarSettingsProperty, value); }
    //}

    //public static readonly PropertyInfo<CarStatisticsInfo> CarStatisticsProperty = RegisterProperty<CarStatisticsInfo>(c => c.CarStatistics);
    //public CarStatisticsInfo CarStatistics
    //{
    //    get { return GetProperty(CarStatisticsProperty); }
    //    set { LoadProperty(CarStatisticsProperty, value); }
    //}

    #endregion

    #region Factory Methods

    public static CarInfo NewCar() {
      return DataPortal.Create<CarInfo>();
    }

    public static CarInfo GetCar(int carId) {
      return DataPortal.Fetch<CarInfo>(carId);
    }

    public static explicit operator CarInfo(CarEdit car) {
      //var distanceUnit = UnitList.GetUnitList(UnitCategory.Distance)
      //  .FirstOrDefault(d => d.Id == car.DistanceUnit);

      //var volumeUnit = UnitList.GetUnitList(UnitCategory.Volume)
      //  .FirstOrDefault(v => v.Id == car.VolumeUnit);

      //var consumptionUnit = UnitList.GetUnitList(UnitCategory.Consumption)
      //  .FirstOrDefault(c => c.Id == car.ConsumptionUnit);

      var carInfo = NewCar();
      carInfo.Id = car.Id;
      carInfo.Make = car.Make;
      carInfo.Model = car.Model;
      carInfo.LicensePlate = car.LicensePlate;
      carInfo.Note = car.Note;
      carInfo.DistanceUnit = car.DistanceUnit;
      carInfo.VolumeUnit = car.VolumeUnit;
      carInfo.ConsumptionUnit = car.ConsumptionUnit;
      carInfo.DateAdded = car.DateAdded;
      carInfo.LastModified = car.LastModified;
      //carInfo.TotalDistance = $"{car.TotalDistance} {distanceUnit}";
      //carInfo.TotalFillups = $"{car.TotalFillups} Fillups"

      return carInfo;
    }

    #endregion

    #region Data Access

    [Create]
    [RunLocal]
    private void Create() {
      // Do initiating stuff here
    }

    [Fetch]
    private void Fetch(int id) {
      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<ICarDal>();
        var data = dal.Fetch(id);
      }
    }

    delegate double ConsumptionOp(FillupList list);

    [FetchChild]
    private void Child_Fetch(CarDto item) {
      Id = item.Id;
      Make = item.Make;
      Model = item.Model;
      LicensePlate = item.LicensePlate;
      Note = item.Note;

      //DistanceUnit = UnitList.GetUnitList(UnitCategory.Distance)
      //  .FirstOrDefault(d => d.Id == item.DistanceUnitId);
      //VolumeUnit = UnitList.GetUnitList(UnitCategory.Volume)
      //  .FirstOrDefault(v => v.Id == item.VolumeUnitId);
      //ConsumptionUnit = UnitList.GetUnitList(UnitCategory.Consumption)
      //  .FirstOrDefault(c => c.Id == item.ConsumptionUnitId);

      //Fillups = DataPortal.FetchChild<FillupList>(item.Id);
      //var count = Fillups.Count();

      //// Ex. 0 Fillups, 23 Fillups, or 1 Fillup, 
      //// TotalFillups = $"{count} Fillup{(count == 0 || count > 1 ? "s" : string.Empty)}";
      //TotalFillups = $"{count} Fillup{(count == 1 ? string.Empty : "s")}";

      //if (count > 1) {
      //  var f = Fillups.OrderBy(a => a.FillupDate);

      //  var first = f.First(); // Fillups.OrderBy(a => a.FillupDate).First();
      //  var last = f.Last(); // Fillups.OrderBy(a => a.FillupDate).Last();
      //  var firstOdo = int.Parse(Regex.Match(first.Odometer, @"\d+").Value);
      //  var lastOdo = int.Parse(Regex.Match(last.Odometer, @"\d+").Value);
      //  var totalDistance = lastOdo - firstOdo;
      //  //var totalDistance = int.Parse(Regex.Match(last.Odometer, @"\d+").Value) 
      //  //  - int.Parse(Regex.Match(first.Odometer, @"\d+").Value);

      //  TotalDistance = $"{totalDistance} {DistanceUnit.ShortName}";

      //  //var firstAmount = decimal.Parse(Regex.Match(first.Amount, @"\d+.+\d").Value);
      //  //var sumAmount = Fillups.Sum(con => decimal.Parse(Regex.Match(con.Amount, @"\d+.+\d").Value));
      //  //var avg = Math.Round((lastOdo - firstOdo) / (sumAmount - firstAmount), 2);

      //  //ConsumptionOp consumptionOp = ConsumptionCalcService.KmPerLiter;
      //  //ConsumptionOp op = delegate (FillupList fff) {
      //  //  return ConsumptionCalcService.KmPerLiter(fff);
      //  //};

      //  Func<FillupList, double> ff = ConsumptionCalcService.KmPerLiter;
      //  var avg = ff(Fillups);
      //  AverageConsumption = $"{avg} {ConsumptionUnit.Name}";
      //  //AverageConsumption = $"{avg} {ConsumptionUnit.GetEnumDescription()}";

      //  decimal[] values = { 1.2m, 2.4m, 3.6m };
      //  //var fff = ConsumptionCalcService.Calculate(values, ConsumptionCalcService.KmPerLiter);
      //}

      ////AverageConsumption = $"{item.AverageConsumption.ToString()} {ConsumptionUnit.Name}";

      ////var unit = DistanceList.GetDistanceList().Where(d => d.Id == item.DistanceUnitId).FirstOrDefault().Name;
      ////var d = DataPortal.FetchChild<DistanceInfo>();
      ////CarSettings = DataPortal.FetchChild<CarSettingsInfo>(Id);
      ////CarStatistics = DataPortal.FetchChild<CarStatisticsInfo>(Id);
    }

    #endregion
  }
}
