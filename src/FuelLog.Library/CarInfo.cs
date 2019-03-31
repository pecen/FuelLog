﻿using Csla;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
      set { LoadProperty(LicensePlateProperty, value); }
    }

    public static readonly PropertyInfo<string> NoteProperty = RegisterProperty<string>(c => c.Note);

    public string Note {
      get { return GetProperty(NoteProperty); }
      set { LoadProperty(NoteProperty, value); }
    }

    public static readonly PropertyInfo<DistanceInfo> DistanceUnitProperty = RegisterProperty<DistanceInfo>(c => c.DistanceUnit);
    public DistanceInfo DistanceUnit {
      get { return GetProperty(DistanceUnitProperty); }
      set { LoadProperty(DistanceUnitProperty, value); }
    }

    public static readonly PropertyInfo<VolumeInfo> VolumeProperty = RegisterProperty<VolumeInfo>(c => c.VolumeUnit);
    public VolumeInfo VolumeUnit {
      get { return GetProperty(VolumeProperty); }
      set { LoadProperty(VolumeProperty, value); }
    }

    public static readonly PropertyInfo<ConsumptionInfo> ConsumptionUnitProperty = RegisterProperty<ConsumptionInfo>(c => c.ConsumptionUnit);
    public ConsumptionInfo ConsumptionUnit {
      get { return GetProperty(ConsumptionUnitProperty); }
      set { LoadProperty(ConsumptionUnitProperty, value); }
    }

    public string ChosenUnits {
      get { return DistanceUnit.ShortName + ", " + VolumeUnit.ShortName + ", " + ConsumptionUnit.Name; }
    }

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

    public static explicit operator CarInfo(CarEdit car) {
      return new CarInfo {
        Id = car.Id,
        Make = car.Make,
        Model = car.Model,
        LicensePlate = car.LicensePlate,
        Note = car.Note,
        DistanceUnit = DistanceList.GetDistanceList()
        .Where(d => d.Id == car.DistanceUnitId)
        .FirstOrDefault(),
        VolumeUnit = VolumeList.GetVolumeList()
          .Where(v => v.Id == car.VolumeUnitId)
          .FirstOrDefault(),
        ConsumptionUnit = ConsumptionList.GetConsumptionList()
          .Where(c => c.Id == car.ConsumptionUnitId)
          .FirstOrDefault(),
        DateAdded = car.DateAdded,
        LastModified = car.LastModified,
        TotalDistance = car.TotalDistance,
        TotalFillups = car.TotalFillups
      };
    }

    #region Factory Methods

    public static CarInfo GetCar(int carId) {
      return DataPortal.Fetch<CarInfo>(carId);
    }

    #endregion

    #region Data Access

    private void DataPortal_Fetch(int id) {
      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<ICarDal>();
        var data = dal.Fetch(id);
      }
    }

    private void Child_Fetch(CarDto item) {
      Id = item.Id;
      Make = item.Make;
      Model = item.Model;
      LicensePlate = item.LicensePlate;
      Note = item.Note;
      DistanceUnit = DistanceList.GetDistanceList()
        .Where(d => d.Id == item.DistanceUnitId)
        .FirstOrDefault();
      VolumeUnit = VolumeList.GetVolumeList()
        .Where(v => v.Id == item.VolumeUnitId)
        .FirstOrDefault();
      ConsumptionUnit = ConsumptionList.GetConsumptionList()
        .Where(c => c.Id == item.ConsumptionUnitId)
        .FirstOrDefault();
      TotalFillups = $"{item.TotalFillups.ToString()} Fillups";
      TotalDistance = $"{item.TotalDistance.ToString()} km";
      AverageConsumption = $"{item.AverageConsumption.ToString()} {ConsumptionUnit.Name}";

      //var unit = DistanceList.GetDistanceList().Where(d => d.Id == item.DistanceUnitId).FirstOrDefault().Name;
      //var d = DataPortal.FetchChild<DistanceInfo>();
      //CarSettings = DataPortal.FetchChild<CarSettingsInfo>(Id);
      //CarStatistics = DataPortal.FetchChild<CarStatisticsInfo>(Id);
    }

    #endregion
  }
}
