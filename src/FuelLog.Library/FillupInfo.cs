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
    #region IsChecked

    private bool _isChecked;
    public bool IsChecked {
      get => _isChecked;
      set {
        if (value == _isChecked) return;
        _isChecked = value;
        OnPropertyChanged(nameof(IsChecked));
      }
    }

    #endregion

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

    public static readonly PropertyInfo<string> FillupDateProperty = RegisterProperty<string>(c => c.FillupDate);
    public string FillupDate {
      get { return GetProperty(FillupDateProperty); }
      set { LoadProperty(FillupDateProperty, value); }
    }

    public static readonly PropertyInfo<string> OdometerProperty = RegisterProperty<string>(c => c.Odometer);
    public string Odometer {
      get { return GetProperty(OdometerProperty); }
      set { LoadProperty(OdometerProperty, value); }
    }

    public static readonly PropertyInfo<string> FuelProperty = RegisterProperty<string>(c => c.Amount);
    public string Amount {
      get { return GetProperty(FuelProperty); }
      set { LoadProperty(FuelProperty, value); }
    }

    public static readonly PropertyInfo<string> VolumePriceProperty = RegisterProperty<string>(c => c.VolumePrice);
    public string VolumePrice {
      get { return GetProperty(VolumePriceProperty); }
      set { LoadProperty(VolumePriceProperty, value); }
    }

    public static readonly PropertyInfo<string> TotalCostProperty = RegisterProperty<string>(c => c.TotalCost);
    public string TotalCost {
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

    public string DaysSinceLast { get; set; }
    public string DistanceSinceLast { get; set; }
    public string AverageConsumption { get; set; }

    #endregion

    #region Data Access

    private void Child_Fetch(FillupDto item) {
      Id = item.Id;
      CarId = item.CarId;
      FillupDate = item.FillUpDate.ToShortDateString();
      Amount = $"{item.Amount} L";
      Odometer = $"{item.Odometer} Km";
      TotalCost = $"SEK {Math.Round(item.Amount * item.VolumePrice, 2)}";

      //DaysSinceLast = item.DaysSinceLast == 0
      //  ? string.Empty
      //  : $"(+ {item.DaysSinceLast} days)";

      //DistanceSinceLast = item.DaysSinceLast == 0
      //  ? string.Empty
      //  : $"+ {item.DistanceSinceLast} Km";

      //AverageConsumption = item.AverageConsumption == 0
      //  ? string.Empty
      //  : $"{Math.Round(item.AverageConsumption, 2)} L/100 Km";

      VolumePrice = $"SEK {Math.Round(item.VolumePrice, 2)}/L";
      PartialFillup = item.PartialFillUp;
      Note = item.Note;
    }

    #endregion
  }
}
