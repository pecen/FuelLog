using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Enums;
using FuelLog.UI.Wpf.Module.UserControls;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class CarListViewModel : ViewModelBase {
    public ObservableCollection<CarItem> CarItems { get; set; }
    //public ObservableCollection<CarInfo> CarItems2 { get; set; }

    public CarListViewModel() {
      Title = TabHeaders.Cars.ToString();

      CarItems = new ObservableCollection<CarItem>();

      Initialize();
    }

    private void Initialize() {
      //CarItems2 = CarList.GetCars();

      var cars = CarList.GetCars().ToList();
      //foreach (var car in cars)
      //{
      //    CarItems.Add(car);
      //}

      foreach (var car in cars) {
        var carItemVm = new CarItemViewModel {
          AverageConsumption = $"{car.AverageConsumption}l/km",
          ChosenUnits = car.ChosenUnits,
          FullName = car.FullName,
          Plate = car.LicensePlate,
          TotalDistance = $"{car.TotalDistance} km",
          TotalFillups = $"{car.TotalFillups} fill-ups"
        };
        var carItem = new CarItem {
          DataContext = carItemVm
        };
        CarItems.Add(carItem);
      }
    }
  }
}
