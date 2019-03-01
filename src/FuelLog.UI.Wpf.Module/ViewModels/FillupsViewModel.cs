using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class FillupsViewModel : ViewModelBase {
    private IEventAggregator _eventAggregator;

    public ObservableCollection<FillupInfo> Fillups { get; set; }
    public ObservableCollection<CarInfo> Cars { get; set; }

    private CarInfo _selectedCar;

    public CarInfo SelectedCar {
      get { return _selectedCar; }
      set {
        SetProperty(ref _selectedCar, value);
        _eventAggregator.GetEvent<GetFillupsCommand>().Publish(FillupList.GetFillups(_selectedCar.Id));
        RaisePropertyChanged(nameof(Fillups));
      }
    }


    public FillupsViewModel(IEventAggregator eventAggregator) {
      Title = TabHeaders.Fillups.ToString();

      _eventAggregator = eventAggregator;

      _eventAggregator.GetEvent<GetCarsCommand>().Subscribe(CarsReceived);
      _eventAggregator.GetEvent<GetFillupsCommand>().Subscribe(FillupsReceived);

      Initialize();
      SelectedCar = Cars.FirstOrDefault();
    }

    public void CarsReceived(CarList obj) => Cars = obj;

    private void FillupsReceived(FillupList obj) => Fillups = obj;

    private void Initialize() {
      _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());
      //_eventAggregator.GetEvent<GetFillupsCommand>().Publish(FillupList.GetFillups(SelectedItem));
    }
  }
}
