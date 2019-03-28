using Csla;
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
      get { return Make + " " + Model; }
    }

    public static readonly PropertyInfo<string> LicensePlateProperty = RegisterProperty<string>(c => c.LicensePlate);
    public string LicensePlate {
      get { return GetProperty(LicensePlateProperty); }
      set { LoadProperty(LicensePlateProperty, value); }
    }

    public static readonly PropertyInfo<string> NoteProperty = RegisterProperty<string>(c => c.Note);

    public static explicit operator CarInfo(CarEdit v) {
      return new CarInfo {
        Make = v.Make,
        Model = v.Model,
        LicensePlate = v.LicensePlate,
        Note = v.Note
      };
    }

    public string Note {
      get { return GetProperty(NoteProperty); }
      set { LoadProperty(NoteProperty, value); }
    }

    public static readonly PropertyInfo<int> DistanceUnitProperty = RegisterProperty<int>(c => c.DistanceUnitId);
    public int DistanceUnitId {
      get { return GetProperty(DistanceUnitProperty); }
      set { LoadProperty(DistanceUnitProperty, value); }
    }

    public static readonly PropertyInfo<int> VolumeUnitProperty = RegisterProperty<int>(c => c.VolumeUnitId);
    public int VolumeUnitId {
      get { return GetProperty(VolumeUnitProperty); }
      set { LoadProperty(VolumeUnitProperty, value); }
    }

    public static readonly PropertyInfo<int> ConsumptionUnitProperty = RegisterProperty<int>(c => c.ConsumptionUnitId);
    public int ConsumptionUnitId {
      get { return GetProperty(ConsumptionUnitProperty); }
      set { LoadProperty(ConsumptionUnitProperty, value); }
    }

    public string ChosenUnits {
      get { return DistanceUnitId + ", " + VolumeUnitId + ", " + ConsumptionUnitId; }
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
      DistanceUnitId = item.DistanceUnitId;
      VolumeUnitId = item.VolumeUnitId;
      ConsumptionUnitId = item.ConsumptionUnitId;
      TotalFillups = item.TotalFillups.ToString() + " Fillups";
      TotalDistance = item.TotalDistance.ToString() + " km";
      AverageConsumption = item.AverageConsumption.ToString() + $" {ConsumptionUnitId}";

      //CarSettings = DataPortal.FetchChild<CarSettingsInfo>(Id);
      //CarStatistics = DataPortal.FetchChild<CarStatisticsInfo>(Id);
    }

    #endregion
  }
}
