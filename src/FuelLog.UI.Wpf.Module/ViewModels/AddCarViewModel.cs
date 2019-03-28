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

    public ObservableCollection<DistanceInfo> DistanceUnits { get; set; }
    public ObservableCollection<VolumeInfo> VolumeUnits { get; set; }
    public ObservableCollection<ConsumptionInfo> ConsumptionUnits { get; set; }

    private DistanceInfo _selectedDistance;
    public DistanceInfo SelectedDistance {
      get { return _selectedDistance; }
      set {
        SetProperty(ref _selectedDistance, value);
      }
    }

    private VolumeInfo _selectedVolume;
    public VolumeInfo SelectedVolume {
      get { return _selectedVolume; }
      set {
        SetProperty(ref _selectedVolume, value);
      }
    }

    private ConsumptionInfo _selectedConsumption;
    public ConsumptionInfo SelectedConsumption {
      get { return _selectedConsumption; }
      set {
        SetProperty(ref _selectedConsumption, value);
      }
    }

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

      _eventAggregator.GetEvent<EditCarCommand>().Subscribe(EditCar);

      DistanceUnits = DistanceList.GetDistanceList();
      VolumeUnits = VolumeList.GetVolumeList();
      ConsumptionUnits = ConsumptionList.GetConsumptionList();

      SelectedDistance = DistanceUnits.FirstOrDefault();
      SelectedVolume = VolumeUnits.FirstOrDefault();
      SelectedConsumption = ConsumptionUnits.FirstOrDefault();
    }

    private void EditCar(CarInfo car) {
      Make = car.Make;
      Model = car.Model;
      Plate = car.LicensePlate;
      Note = car.Note;
    }

    private void Cancel(string uri) {
      _regionManager.RequestNavigate("ContentRegion", uri);
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
      car.DateAdded = DateTime.Now;
      car.LastModified = DateTime.Now;
      car.TotalFillups = "0";
      car = car.Save();

      _eventAggregator
        .GetEvent<SaveCarCommand>()
        .Publish(CarList.GetCars());
      //.Publish(car);

      _regionManager.RequestNavigate("ContentRegion", "CarList");
      ClearFields();
    }

    private void ClearFields() {
      Make = string.Empty;
      Model = string.Empty;
      Plate = string.Empty;
      Note = string.Empty;
    }
  }
}
