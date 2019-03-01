using Csla;
using FuelLog.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.Library {
  [Serializable]
  public class FillupInfo : ReadOnlyBase<FillupInfo> {
    #region Properties

    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    public int Id {
      get { return GetProperty(IdProperty); }
      set { LoadProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<int> CarIdProperty = RegisterProperty<int>(c => c.CarId);
    public int CarId {
      get { return GetProperty(CarIdProperty); }
      set { LoadProperty(CarIdProperty, value); }
    }

    public static readonly PropertyInfo<DateTime> FillUpDateProperty = RegisterProperty<DateTime>(c => c.FillUpDate);
    public DateTime FillUpDate {
      get { return GetProperty(FillUpDateProperty); }
      set { LoadProperty(FillUpDateProperty, value); }
    }

    public static readonly PropertyInfo<int> OdometerProperty = RegisterProperty<int>(c => c.Odometer);
    public int Odometer {
      get { return GetProperty(OdometerProperty); }
      set { LoadProperty(OdometerProperty, value); }
    }

    public static readonly PropertyInfo<double> FuelProperty = RegisterProperty<double>(c => c.Amount);
    public double Amount {
      get { return GetProperty(FuelProperty); }
      set { LoadProperty(FuelProperty, value); }
    }

    public static readonly PropertyInfo<double> VolumePriceProperty = RegisterProperty<double>(c => c.VolumePrice);
    public double VolumePrice {
      get { return GetProperty(VolumePriceProperty); }
      set { LoadProperty(VolumePriceProperty, value); }
    }

    public static readonly PropertyInfo<double> TotalCostProperty = RegisterProperty<double>(c => c.TotalCost);
    public double TotalCost {
      get { return GetProperty(TotalCostProperty); }
      set { LoadProperty(TotalCostProperty, value); }
    }

    public static readonly PropertyInfo<bool> PartialFillupProperty = RegisterProperty<bool>(c => c.PartialFillup);
    public bool PartialFillup {
      get { return GetProperty(PartialFillupProperty); }
      set { LoadProperty(PartialFillupProperty, value); }
    }

    public static readonly PropertyInfo<string> NoteProperty = RegisterProperty<string>(c => c.Note);
    public string Note {
      get { return GetProperty(NoteProperty); }
      set { LoadProperty(NoteProperty, value); }
    }

    #endregion

    #region Data Access

    private void Child_Fetch(FillupDto item) {
      Id = item.Id;
      CarId = item.CarId;
      FillUpDate = item.FillUpDate;
      Odometer = item.Odometer;
      Amount = item.Amount;
      VolumePrice = item.VolumePrice;
      TotalCost = Amount * VolumePrice;
      PartialFillup = item.PartialFillUp;
      Note = item.Note;
    }

    #endregion
  }
}
