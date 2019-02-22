using FuelLog.UI.Wpf.Module.Enums;
using FuelLog.UI.Wpf.Module.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class CarItemViewModel : ViewModelBase {
    #region Properties

    private string _fullName = "BMW 320d Touring";
    public string FullName {
      get { return _fullName; }
      set { SetProperty(ref _fullName, value); }
    }

    private string _chosenUnits = "km, l, l/100km";
    public string ChosenUnits {
      get { return _chosenUnits; }
      set { SetProperty(ref _chosenUnits, value); }
    }

    private string _totalDistance = "5561 km";
    public string TotalDistance {
      get { return _totalDistance; }
      set { SetProperty(ref _totalDistance, value); }
    }

    private string _totalFillups = "64 Fillups";
    public string TotalFillups {
      get { return _totalFillups; }
      set { SetProperty(ref _totalFillups, value); }
    }

    private string _averageConsumption = "6,75l/100km";
    public string AverageConsumption {
      get { return _averageConsumption; }
      set { SetProperty(ref _averageConsumption, value); }
    }

    private string plate = "OUS 307";
    public string Plate {
      get { return plate; }
      set { SetProperty(ref plate, value); }
    }

    #endregion

    public CarItemViewModel() {
    }
  }
}
