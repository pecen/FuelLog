using FuelLog.Library;
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

    public DelegateCommand SaveCommand { get; set; }

    public AddCarViewModel(IEventAggregator eventAggregator) {
      Title = TabHeaders.AddCar.ToString();

      _eventAggregator = eventAggregator;

      SaveCommand = new DelegateCommand(Execute, CanExecute)
        .ObservesProperty(() => Make)
        .ObservesProperty(() => Model);
    }

    private bool CanExecute() {
      return !string.IsNullOrWhiteSpace(Make)
        && !string.IsNullOrWhiteSpace(Model);
    }

    private void Execute() {
      throw new NotImplementedException();
    }
  }
}
