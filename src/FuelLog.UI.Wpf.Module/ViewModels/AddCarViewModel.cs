using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class AddCarViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;
    private readonly IRegionManager _regionManager;

    public ObservableCollection<CarInfo> DistanceUnit { get; set; }
    public ObservableCollection<CarInfo> VolumeUnit { get; set; }
    public ObservableCollection<CarInfo> ConsumptionUnit { get; set; }

    private string _make;
    public string Make {
      get { return _make; }
      set { SetProperty(ref _make, value); }
    }

    private string _model;
    public string Model {
      get { return _model; }
      set { SetProperty(ref _model, value); }
    }

    private string _plate;
    public string Plate {
      get { return _plate; }
      set { SetProperty(ref _plate, value); }
    }

    private string _note;
    public string Note {
      get { return _note; }
      set { SetProperty(ref _note, value); }
    }

    public DelegateCommand SaveCommand { get; set; }
    public DelegateCommand<string> CancelCommand { get; set; }

    public AddCarViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) {
      Title = TabHeaders.AddCar.ToString();

      _eventAggregator = eventAggregator;
      _regionManager = regionManager;

      SaveCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => Make)
        .ObservesProperty(() => Model);

      CancelCommand = new DelegateCommand<string>(Cancel);
    }

    private void Cancel(string uri) {
      throw new NotImplementedException();
    }

    private bool CanExecute() {
      return !string.IsNullOrWhiteSpace(Make)
        && !string.IsNullOrWhiteSpace(Model);
    }

    private void Execute() {
      var car = CarEdit.NewCar();
      car.Make = Make;
      car.Model = Model;
      car.LicensePlate = Plate;
      car.Note = Note;
      car = car.Save();

      _eventAggregator
        .GetEvent<SaveCarCommand>()
        .Publish(CarList.GetCars());
      //.Publish(car);

      _regionManager.RequestNavigate("ContentRegion", "CarList");
    }
  }
}
