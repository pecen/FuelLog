using FuelLog.Core.Extensions;
using FuelLog.Library;
using FuelLog.Library.Enums;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using FuelLog.UI.Wpf.Module.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class AddCarViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;
    private readonly IPathProvider _pathProvider;

    private readonly string _header = "Fill in the information below and press ";

    #region Properties

    public string FilenameToolTip { get; } = "Type in a valid filename (*.Xml), or click the button to the right to select file.";

    public DelegateCommand GetFilenameCommand { get; set; }
    public DelegateCommand SaveCarCommand { get; set; }

    private Stream XmlStream { get; set; }

    public string FullPath {
      get => !string.IsNullOrEmpty(FilePath)
        || !string.IsNullOrEmpty(Filename)
        ? $@"{FilePath}\{Filename}"
        : string.Empty;
    }

    public string PageHeader {
      get { return _header + BtnName; }
    }

    private string BtnName {
      get {
        return CarExists
          ? ButtonNames.Update.ToString()
          : ButtonNames.Save.ToString();
      }
    }

    private string _filePath;
    public string FilePath {
      get { return _filePath; }
      set {
        SetProperty(ref _filePath, value);
      }
    }

    private string _filename;
    public string Filename {
      get { return _filename; }
      set {
        SetProperty(ref _filename, value);
        RaisePropertyChanged(nameof(FullPath));
      }
    }

    private bool _carExists;
    public bool CarExists {
      get { return _carExists; }
      set { SetProperty(ref _carExists, value); }
    }

    private bool _importCarsIsChecked;
    public bool ImportCarsIsChecked {
      get { return _importCarsIsChecked; }
      set {
        SetProperty(ref _importCarsIsChecked, value);
        //if (value == true) ReplaceIsChecked = false;
        RaisePropertyChanged(nameof(ImportCarsIsNotChecked));
      }
    }

    public bool ImportCarsIsNotChecked {
      get { return !_importCarsIsChecked; }
    }

    private string _make;
    public string Make {
      get { return _make; }
      set { SetProperty(ref _make, value); }
    }

    private string _model;
    public string Model {
      get { return _model; }
      set {
        SetProperty(ref _model, value);
      }
    }

    private string _plate;
    public string Plate {
      get { return _plate; }
      set {
        SetProperty(ref _plate, value);
      }
    }

    private ObservableCollection<string> _distanceList;
    public ObservableCollection<string> DistanceList {
      get { return _distanceList; }
      private set { SetProperty(ref _distanceList, value); }
    }

    private int _selectedDistance;
    public int SelectedDistance {
      get { return _selectedDistance; }
      set { SetProperty(ref _selectedDistance, value); }
    }

    private ObservableCollection<string> _volumeList;
    public ObservableCollection<string> VolumeList {
      get { return _volumeList; }
      private set { SetProperty(ref _volumeList, value); }
    }

    private int _selectedVolume;
    public int SelectedVolume {
      get { return _selectedVolume; }
      set { SetProperty(ref _selectedVolume, value); }
    }

    private ObservableCollection<string> _consumptionList;
    public ObservableCollection<string> ConsumptionList {
      get { return _consumptionList; }
      private set { SetProperty(ref _consumptionList, value); }
    }

    private int _selectedConsumption;
    public int SelectedConsumption {
      get { return _selectedConsumption; }
      set { SetProperty(ref _selectedConsumption, value); }
    }

    private string _notes;
    public string Notes {
      get { return _notes; }
      set { SetProperty(ref _notes, value); }
    }

    #endregion

    public AddCarViewModel(IEventAggregator eventAggregator, IPathProvider pathProvider) {
      _eventAggregator = eventAggregator;
      _pathProvider = pathProvider;

      Title = Titles.AddCar.GetDescription();
      CarExists = false;

      DistanceList = new ObservableCollection<string>();
      VolumeList = new ObservableCollection<string>();
      ConsumptionList = new ObservableCollection<string>();

      DistanceList.GetEnumValues<DistanceUnits>();
      VolumeList.GetEnumValues<VolumeUnits>();
      ConsumptionList.GetEnumValues<ConsumptionUnits>();

      GetFilenameCommand = new DelegateCommand(GetFilename);
      SaveCarCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => Make)
        .ObservesProperty(() => Model)
        .ObservesProperty(() => Filename)
        .ObservesProperty(() => ImportCarsIsChecked);

      _eventAggregator.GetEvent<GetFilenameCommand>().Subscribe(FilenameReceived);
    }

    private void FilenameReceived(string obj) {
      FilePath = Path.GetDirectoryName(obj);
      Filename = Path.GetFileName(obj);
    }

    private void GetFilename() {
      XmlStream = _pathProvider.FilePathService() ?? XmlStream;
    }

    private bool CanExecute() {
      if (ImportCarsIsChecked
        && File.Exists(FullPath)) {
        return true;
      }

      return ImportCarsIsNotChecked 
        && !string.IsNullOrEmpty(Make)
        && !string.IsNullOrEmpty(Model);
    }

    private void Execute() {
      var car = CarEdit.NewCar();

      car.Make = Make;
      car.Model = Model;
      car.LicensePlate = Plate;
      car.Note = Notes;
      car.DistanceUnit = (DistanceUnits)SelectedDistance;
      car.VolumeUnit = (VolumeUnits)SelectedVolume;
      car.ConsumptionUnit = (ConsumptionUnits)SelectedConsumption;
      car.LastModified = car.DateAdded = DateTime.Now;

      car = car.Save();

      //_eventAggregator
      //  .GetEvent<SaveCarCommand>()
      //  .Publish(car);

      _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());
    }
  }
}

