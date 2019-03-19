using Csla;
using FuelLog.Dal;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public static readonly PropertyInfo<string> DistanceUnitProperty = RegisterProperty<string>(c => c.DistanceUnit);
    public string DistanceUnit {
      get { return GetProperty(DistanceUnitProperty); }
      set { SetProperty(DistanceUnitProperty, value); }
    }

    public static readonly PropertyInfo<string> VolumeUnitProperty = RegisterProperty<string>(c => c.VolumeUnit);
    public string VolumeUnit {
      get { return GetProperty(VolumeUnitProperty); }
      set { SetProperty(VolumeUnitProperty, value); }
    }

    public static readonly PropertyInfo<string> ConsumptionUnitProperty = RegisterProperty<string>(c => c.ConsumptionUnit);
    public string ConsumptionUnit {
      get { return GetProperty(ConsumptionUnitProperty); }
      set { SetProperty(ConsumptionUnitProperty, value); }
    }

    public string ChosenUnits {
      get { return DistanceUnit + ", " + VolumeUnit + ", " + ConsumptionUnit; }
    }

    public static readonly PropertyInfo<string> TotalFillupsProperty = RegisterProperty<string>(c => c.TotalFillups);
    public string TotalFillups {
      get { return GetProperty(TotalFillupsProperty); }
      set { SetProperty(TotalFillupsProperty, value); }
    }

    public static readonly PropertyInfo<string> TotalDistanceProperty = RegisterProperty<string>(c => c.TotalDistance);
    public string TotalDistance {
      get { return GetProperty(TotalDistanceProperty); }
      set { SetProperty(TotalDistanceProperty, value); }
    }

    public static readonly PropertyInfo<string> AverageConsumptionProperty = RegisterProperty<string>(c => c.AverageConsumption);
    public string AverageConsumption {
      get { return GetProperty(AverageConsumptionProperty); }
      set { SetProperty(AverageConsumptionProperty, value); }
    }

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

    #region Factory Methods

    public static CarEdit NewCar() {
      return DataPortal.Create<CarEdit>();
    }

    public static CarEdit GetCar(int id) {
      return DataPortal.Fetch<CarEdit>(id);
    }

    #endregion

    #region Data Access

    protected override void DataPortal_Create() {
      base.DataPortal_Create();
    }

    protected override void DataPortal_Insert() {
      using (var ctx = DalFactory.GetManager()) {
        var dal = ctx.GetProvider<ICarDal>();
        using (BypassPropertyChecks) {
          var item = new CarDto {
            Make = Make,
            Model = Model,
            LicensePlate = LicensePlate,
            Note = Note,
            ConsumptionUnit = ConsumptionUnit,
            DistanceUnit = DistanceUnit,
            VolumeUnit = VolumeUnit            
          };
          dal.Insert(item);
          Id = item.Id;
        }
      }
    }

    #endregion
  }
}
