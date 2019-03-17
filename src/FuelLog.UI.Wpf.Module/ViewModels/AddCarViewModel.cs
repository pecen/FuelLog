using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class AddCarViewModel : ViewModelBase {
    public ObservableCollection<CarInfo> DistanceUnit { get; set; }
    public ObservableCollection<CarInfo> VolumeUnit { get; set; }
    public ObservableCollection<CarInfo> ConsumptionUnit { get; set; }

    public AddCarViewModel() {
      Title = TabHeaders.AddCar.ToString();
    }
  }
}
