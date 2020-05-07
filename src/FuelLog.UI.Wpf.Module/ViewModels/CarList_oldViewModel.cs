﻿using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;

// The following using is if we would use ICommand
//using System.Windows.Input;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class CarList_oldViewModel : ViewModelBase {
    private IEventAggregator _eventAggregator;
    private readonly IRegionManager _regionManager;

    private ObservableCollection<CarInfo> _cars;
    public ObservableCollection<CarInfo> Cars {
      get { return _cars; }
      set { SetProperty(ref _cars, value); }
    }

    private CarInfo _selectedCar;
    public CarInfo SelectedCar {
      get { return _selectedCar; }
      set {
        SetProperty(ref _selectedCar, value);
        _eventAggregator.GetEvent<EditCarCommand>().Publish(_selectedCar);
        _regionManager.RequestNavigate(Regions.ContentRegion.ToString(), "AddCar");
      }
    }

    // This one is used only if there should be like an update button
    // to bind to
    //public DelegateCommand GetCarsCommand { get; set; }

    public DelegateCommand<string> AddCarCommand { get; set; }

    // A different way of doing navigation
    //public ICommand AddCarCommand { get; set; }

    public CarList_oldViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) {
      _eventAggregator = eventAggregator;
      _regionManager = regionManager;

      //GetCarsCommand = new DelegateCommand(Execute);
      AddCarCommand = new DelegateCommand<string>(AddCar);

      // A different way of doing navigation
      //AddCarCommand = new DelegateCommand(() => AddCar("ContentPage"));

      Title = Titles.Cars.ToString();

      _eventAggregator.GetEvent<GetCarsCommand>().Subscribe(CarListReceived);
      _eventAggregator.GetEvent<SaveCarCommand_old>().Subscribe(CarListReceived);  //NewCarReceived);
    }

    //private void NewCarReceived(CarEdit obj) {
    //  _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());
    //  RaisePropertyChanged(nameof(CarItems));
    //}

    private void AddCar(string uri) {
      _regionManager.RequestNavigate(Regions.ContentRegion.ToString(), uri);
    }

    private void CarListReceived(CarList obj) {
      Cars = obj;
      RaisePropertyChanged(nameof(Cars));
    }
  }
}