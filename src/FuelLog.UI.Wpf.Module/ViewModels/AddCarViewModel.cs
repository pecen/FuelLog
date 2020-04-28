using FuelLog.Core.Extensions;
using FuelLog.Library.Enums;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class AddCarViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;

    private readonly string _header = "Fill in the information below and press ";

    #region Properties

    public DelegateCommand SaveCarCommand { get; set; }

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

    private string _fileName;
    public string FileName {
      get { return _fileName; }
      set {
        SetProperty(ref _fileName, value);
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

    public AddCarViewModel(IEventAggregator eventAggregator) {
      _eventAggregator = eventAggregator;

      Title = Titles.AddCar.GetDescription();
      CarExists = false;

      DistanceList = new ObservableCollection<string>();
      VolumeList = new ObservableCollection<string>();
      ConsumptionList = new ObservableCollection<string>();

      DistanceList.GetEnumValues<DistanceUnits>();
      VolumeList.GetEnumValues<VolumeUnits>();
      ConsumptionList.GetEnumValues<ConsumptionUnits>();

      SaveCarCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => Make)
        .ObservesProperty(() => Model);
    }

    private bool CanExecute() {
      return !string.IsNullOrEmpty(Make)
        && !string.IsNullOrEmpty(Model);
    }

    private void Execute() {
      throw new NotImplementedException();
    }
  }
}

