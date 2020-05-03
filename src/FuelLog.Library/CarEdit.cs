using Csla;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using FuelLog.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuelLog.Library
{
  [Serializable]
  public class CarEdit : BusinessBase<CarEdit>
    {
    #region Properties

    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    public int Id {
      get { return GetProperty(IdProperty); }
      set { SetProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<string> MakeProperty = RegisterProperty<string>(c => c.Make);
    public string Make {
      get { return GetProperty(MakeProperty); }
      set { SetProperty(MakeProperty, value); }
    }

    public static readonly PropertyInfo<string> ModelProperty = RegisterProperty<string>(c => c.Model);
    public string Model {
      get { return GetProperty(ModelProperty); }
      set { SetProperty(ModelProperty, value); }
    }

    public string FullName {
      get { return Make + " " + Model; }
    }

    public static readonly PropertyInfo<string> LicensePlateProperty = RegisterProperty<string>(c => c.LicensePlate);
    public string LicensePlate {
      get { return GetProperty(LicensePlateProperty); }
      set { SetProperty(LicensePlateProperty, value); }
    }

    public static readonly PropertyInfo<string> NoteProperty = RegisterProperty<string>(c => c.Note);
    public string Note {
      get { return GetProperty(NoteProperty); }
      set { SetProperty(NoteProperty, value); }
    }

    //public static readonly PropertyInfo<int> DistanceUnitProperty = RegisterProperty<int>(c => c.DistanceUnit);
    //public int DistanceUnit {
    //  get { return GetProperty(DistanceUnitProperty); }
    //  set { SetProperty(DistanceUnitProperty, value); }
    //}

    public static readonly PropertyInfo<DistanceUnits> DistanceUnitProperty = RegisterProperty<DistanceUnits>(c => c.DistanceUnit);
    public DistanceUnits DistanceUnit {
      get { return GetProperty(DistanceUnitProperty); }
      set { SetProperty(DistanceUnitProperty, value); }
    }

    //public static readonly PropertyInfo<int> VolumeUnitProperty = RegisterProperty<int>(c => c.VolumeUnit);
    //public int VolumeUnit {
    //  get { return GetProperty(VolumeUnitProperty); }
    //  set { SetProperty(VolumeUnitProperty, value); }
    //}

    public static readonly PropertyInfo<VolumeUnits> VolumeUnitProperty = RegisterProperty<VolumeUnits>(c => c.VolumeUnit);
    public VolumeUnits VolumeUnit {
      get { return GetProperty(VolumeUnitProperty); }
      set { SetProperty(VolumeUnitProperty, value); }
    }

    public static readonly PropertyInfo<ConsumptionUnits> ConsumptionUnitProperty = RegisterProperty<ConsumptionUnits>(c => c.ConsumptionUnit);
    public ConsumptionUnits ConsumptionUnit {
      get { return GetProperty(ConsumptionUnitProperty); }
      set { SetProperty(ConsumptionUnitProperty, value); }
    }

    //public static readonly PropertyInfo<ConsumptionUnitType> ConsumptionUnitProperty = RegisterProperty<ConsumptionUnitType>(c => c.ConsumptionUnit);
    //public ConsumptionUnitType ConsumptionUnit {
    //  get { return GetProperty(ConsumptionUnitProperty); }
    //  set { SetProperty(ConsumptionUnitProperty, value); }
    //}

    //public string ChosenUnits {
    //  get { return DistanceUnitId + ", " + VolumeUnitId + ", " + ConsumptionUnitId; }
    //}

    public static readonly PropertyInfo<int> TotalFillupsProperty = RegisterProperty<int>(c => c.TotalFillups);
    public int TotalFillups {
      get { return GetProperty(TotalFillupsProperty); }
      set { SetProperty(TotalFillupsProperty, value); }
    }

    //public static readonly PropertyInfo<int> TotalDistanceProperty = RegisterProperty<int>(c => c.TotalDistance);
    //public int TotalDistance {
    //  get { return GetProperty(TotalDistanceProperty); }
    //  set { SetProperty(TotalDistanceProperty, value); }
    //}

    //public static readonly PropertyInfo<string> AverageConsumptionProperty = RegisterProperty<string>(c => c.AverageConsumption);
    //public string AverageConsumption {
    //  get { return GetProperty(AverageConsumptionProperty); }
    //  set { SetProperty(AverageConsumptionProperty, value); }
    //}

    public static readonly PropertyInfo<DateTimeOffset> DateAddedProperty = RegisterProperty<DateTimeOffset>(c => c.DateAdded);
    public DateTimeOffset DateAdded {
      get { return GetProperty(DateAddedProperty); }
      set { SetProperty(DateAddedProperty, value); }
    }

    public static readonly PropertyInfo<DateTimeOffset> LastModifiedProperty = RegisterProperty<DateTimeOffset>(c => c.LastModified);
    public DateTimeOffset LastModified {
      get { return GetProperty(LastModifiedProperty); }
      set { SetProperty(LastModifiedProperty, value); }
    }

    #endregion

    public static implicit operator CarEdit(CarInfo car) {
      var obj = NewCar();
      obj.Id = car.Id;
      obj.Make = car.Make;
      obj.Model = car.Model;
      obj.LicensePlate = car.LicensePlate;
      obj.Note = car.Note;
      obj.DistanceUnit = car.DistanceUnit;
      obj.VolumeUnit = car.VolumeUnit;
      obj.ConsumptionUnit = car.ConsumptionUnit;
      obj.DateAdded = car.DateAdded;
      obj.LastModified = car.LastModified;
      //obj.TotalDistance = int.Parse(Regex.Match(car.TotalDistance, @"\d+").Value);
      obj.TotalFillups = int.Parse(Regex.Match(car.TotalFillups, @"\d+").Value);

      return obj;
    }

    #region Factory Methods

    public static CarEdit NewCar() {
      return DataPortal.Create<CarEdit>();
    }

    public static CarEdit GetCar(int id) {
      return DataPortal.Fetch<CarEdit>(id);
    }

    public static void DeleteCar(int id) {
      DataPortal.Delete<CarEdit>(id);
    }

    #endregion

    #region Data Access

    [RunLocal]
    [Create]
    private void Create() { }

    [Insert]
    private void Insert() {
      using (var ctx = DalFactory.GetManager()) {
        var dal = ctx.GetProvider<ICarDal>();
        using (BypassPropertyChecks) {
          var item = new CarDto {
            Make = Make,
            Model = Model,
            LicensePlate = LicensePlate,
            Note = Note,
            DistanceUnit = (int)DistanceUnit,
            VolumeUnit = (int)VolumeUnit,
            ConsumptionUnit = (int)ConsumptionUnit,
            CreationDate = DateAdded,
            LastModified = LastModified,
            //TotalDistance = TotalDistance,
            //TotalFillups = 0
          };
          dal.Insert(item);
          Id = item.Id;
        }
      }
    }

    [Update]
    private void Update() {
      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<ICarDal>();
        using (BypassPropertyChecks) {
          var data = new CarDto {
            Id = Id,
            Make = Make,
            Model = Model,
            LicensePlate = LicensePlate,
            Note = Note,
            DistanceUnit = (int)DistanceUnit,
            VolumeUnit = (int)VolumeUnit,
            ConsumptionUnit = (int)ConsumptionUnit,
            LastModified = DateTime.Now
          };
          dal.Update(data);
        }
      }
    }

    [DeleteSelf]
    private void DeleteSelf() {
      using (BypassPropertyChecks) {
        Delete(Id);
      }
    }

    [Delete]
    private void Delete(int id) {
      using (var dalManager = DalFactory.GetManager()) {
        var dal = dalManager.GetProvider<ICarDal>();
        dal.Delete(id);
      }
    }

    #endregion
  }
}
