using FuelLog.Core.Extensions;
using FuelLog.Core.Utilities;
using FuelLog.Library;
using FuelLog.Library.Enums;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
//using FuelLog.UI.Wpf.Module.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class AddCarViewModel_old : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;
    private readonly IRegionManager _regionManager;

    #region Properties

    public DelegateCommand SaveCommand { get; set; }
    public DelegateCommand<string> CancelCommand { get; set; }

    private int Id { get; set; }

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

    private ObservableCollection<string> _distanceUnitList;
    public ObservableCollection<string> DistanceUnitList {
      get { return _distanceUnitList; }
      private set { SetProperty(ref _distanceUnitList, value); }
    }

    private int _selectedDistanceUnit;
    public int SelectedDistanceUnit {
      get { return _selectedDistanceUnit; }
      set { SetProperty(ref _selectedDistanceUnit, value); }
    }

    private ObservableCollection<string> _volumeUnitList;
    public ObservableCollection<string> VolumeUnitList {
      get { return _volumeUnitList; }
      private set { SetProperty(ref _volumeUnitList, value); }
    }

    private int _selectedVolumeUnits;
    public int SelectedVolumeUnit {
      get { return _selectedVolumeUnits; }
      set { SetProperty(ref _selectedVolumeUnits, value); }
    }

    private ObservableCollection<string> _consumptionUnitList;
    public ObservableCollection<string> ConsumptionUnitList {
      get { return _consumptionUnitList; }
      private set { SetProperty(ref _consumptionUnitList, value); }
    }

    private int _selectedConsumptionUnit;
    public int SelectedConsumptionUnit {
      get { return _selectedConsumptionUnit; }
      set { SetProperty(ref _selectedConsumptionUnit, value); }
    }

    //public ObservableCollection<DistanceInfo> DistanceUnits { get; set; }
    //public ObservableCollection<VolumeInfo> VolumeUnits { get; set; }
    //public ObservableCollection<ConsumptionUnits> ConsumptionUnits { get; set; }

    //public ObservableCollection<UnitInfo> DistanceUnits { get; set; }
    //public ObservableCollection<UnitInfo> VolumeUnits { get; set; }
    //public ObservableCollection<UnitInfo> ConsumptionUnits { get; set; }

    //public ObservableCollection<ConsumptionUnitType> ConsumptionUnits { get; set; }

    //private DistanceInfo _selectedDistance;
    //public DistanceInfo SelectedDistance {
    //  get { return _selectedDistance; }
    //  set {
    //    SetProperty(ref _selectedDistance, value);
    //  }
    //}

    //private VolumeInfo _selectedVolume;
    //public VolumeInfo SelectedVolume {
    //  get { return _selectedVolume; }
    //  set {
    //    SetProperty(ref _selectedVolume, value);
    //  }
    //}

    //private UnitInfo _selectedDistance;
    //public UnitInfo SelectedDistance {
    //  get { return _selectedDistance; }
    //  set {
    //    SetProperty(ref _selectedDistance, value);
    //  }
    //}

    //private UnitInfo _selectedVolume;
    //public UnitInfo SelectedVolume {
    //  get { return _selectedVolume; }
    //  set {
    //    SetProperty(ref _selectedVolume, value);
    //  }
    //}

    //private UnitInfo _selectedConsumption;
    //public UnitInfo SelectedConsumption {
    //  get { return _selectedConsumption; }
    //  set { SetProperty(ref _selectedConsumption, value); }
    //}

    //private ConsumptionUnitType _selectedConsumption;
    //public ConsumptionUnitType SelectedConsumption {
    //  get { return _selectedConsumption; }
    //  set { SetProperty(ref _selectedConsumption, value); }
    //}

    //private ConsumptionInfo _selectedConsumption;
    //public ConsumptionInfo SelectedConsumption {
    //  get { return _selectedConsumption; }
    //  set {
    //    SetProperty(ref _selectedConsumption, value);
    //  }
    //}

    //private ConsumptionUnits _selectedConsumption;
    //public ConsumptionUnits SelectedConsumption {
    //  get { return _selectedConsumption; }
    //  set {
    //    SetProperty(ref _selectedConsumption, value);
    //  }
    //}

    #endregion

    public AddCarViewModel_old(IEventAggregator eventAggregator, IRegionManager regionManager) {
      Title = Titles.AddCar.ToString();

      _eventAggregator = eventAggregator;
      _regionManager = regionManager;

      //DistanceUnits = DistanceList.GetDistanceList();
      //VolumeUnits = VolumeList.GetVolumeList();
      //var cu = Enum.GetValues(typeof(FuelLog.Library.Enums.ConsumptionUnits)); // ConsumptionUnits; // ConsumptionList.GetConsumptionList();
      //ConsumptionUnits.AddRange(cu);

      //DistanceUnits = UnitList.GetUnitList<DistanceList>();
      //VolumeUnits = UnitList.GetUnitList<VolumeList>();
      //ConsumptionUnits = UnitList.GetUnitList<ConsumptionList>();

      DistanceUnitList = new ObservableCollection<string>();
      VolumeUnitList = new ObservableCollection<string>();
      ConsumptionUnitList = new ObservableCollection<string>();

      DistanceUnitList.GetEnumValues<DistanceUnits>();
      VolumeUnitList.GetEnumValues<VolumeUnits>();
      ConsumptionUnitList.GetEnumValues<ConsumptionUnits>();

      //DistanceUnits = UnitList.GetUnitList(UnitCategory.Distance);
      //VolumeUnits = UnitList.GetUnitList(UnitCategory.Volume);
      //ConsumptionUnits = UnitList.GetUnitList(UnitCategory.Consumption);

      //ConsumptionUnits = new ObservableCollection<ConsumptionUnitType>(Enum.GetValues(typeof(ConsumptionUnitType)).Cast<ConsumptionUnitType>());

      //SelectedDistance = DistanceUnitList.FirstOrDefault(); //DistanceUnits.Where(d => d.Id == Id).FirstOrDefault(); 
      //SelectedVolume = VolumeUnitList.FirstOrDefault();
      //SelectedConsumption = ConsumptionUnitType.LiterPerKm;
      //SelectedConsumption = ConsumptionUnits.FirstOrDefault();
      //SelectedConsumption = ConsumptionUnitList.Where(c => c.Id == 0).FirstOrDefault();

      SaveCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => Make)
        .ObservesProperty(() => Model);

      CancelCommand = new DelegateCommand<string>(Cancel);

      _eventAggregator.GetEvent<EditCarCommand>().Subscribe(EditCar);
    }

    private void EditCar(CarInfo car) {
      Id = car.Id;
      Make = car.Make;
      Model = car.Model;
      Plate = car.LicensePlate;
      Note = car.Note;
      //SelectedDistanceUnit = DistanceUnitList.FirstOrDefault(d => d.Id == car.DistanceUnit.Id);
      //SelectedVolumeUnit = VolumeUnitList.FirstOrDefault(v => v.Id == car.VolumeUnit.Id);
      //SelectedConsumptionUnit = ConsumptionUnitList.FirstOrDefault(c => c.Id == car.ConsumptionUnit.Id);
      //SelectedConsumption = ConsumptionUnits.FirstOrDefault(c => .Id == (int)car.ConsumptionUnit);
      //SelectedConsumption = car.ConsumptionUnit;
    }

    private void Cancel(string uri) {
      _regionManager.RequestNavigate("ContentRegion", uri);
      //ClearFields();
    }

    private bool CanExecute() {
      return !string.IsNullOrWhiteSpace(Make)
        && !string.IsNullOrWhiteSpace(Model);
    }

    private void Execute() {
      var car = CarEdit.NewCar();
      car.Id = Id;
      car.Make = Make;
      car.Model = Model;
      car.LicensePlate = Plate;
      car.Note = Note;
      car.LastModified = car.DateAdded = DateTime.Now;
      car.TotalFillups = 0;
      //car.DistanceUnit = SelectedDistanceUnit.Id;
      //car.VolumeUnit = SelectedVolume.Id;
      //car.ConsumptionUnit = SelectedConsumption.Id;
      car = car.Save();

      _eventAggregator
        .GetEvent<SaveCarCommand>()
        .Publish(CarList.GetCars());
      //.Publish(car);

      _regionManager.RequestNavigate(Regions.ContentRegion.ToString(), "CarList");
      ClearFields();
    }

    public override void OnNavigatedTo(NavigationContext navigationContext) {
      base.OnNavigatedTo(navigationContext);

      //ClearFields();
    }

    public override void OnNavigatedFrom(NavigationContext navigationContext) {
      base.OnNavigatedFrom(navigationContext);
      //   var views = _regionManager.Regions[Regions.ContentRegion.ToString()].Views.ToList();
      //   Views.AddCar view2 = views.SingleOrDefault(v => v.GetType().Name ==
      //"AddCar") as Views.AddCar;
      //   _regionManager.Regions[Regions.ContentRegion.ToString()].Remove(view2);
    }

    private void ClearFields() {
      Make = string.Empty;
      Model = string.Empty;
      Plate = string.Empty;
      Note = string.Empty;
      //SelectedDistance = DistanceUnitList.FirstOrDefault();
      //SelectedVolume = VolumeUnitList.FirstOrDefault();
      //SelectedConsumption = ConsumptionUnits.FirstOrDefault();
    }
  }
}
