using FuelLog.Library;
using FuelLog.UI.Wpf.Module.Commands;
using FuelLog.UI.Wpf.Module.Enums;
using FuelLog.UI.Wpf.Module.UserControls;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class CarListViewModel : ViewModelBase {
    private IEventAggregator _eventAggregator;

    public ObservableCollection<CarInfo> CarItems { get; set; }

    // This one is used only if there should be like an update button
    // to bind to
    //public DelegateCommand GetCarsCommand { get; set; }

    public CarListViewModel(IEventAggregator eventAggregator) {
      _eventAggregator = eventAggregator;

      //GetCarsCommand = new DelegateCommand(Execute);

      Title = TabHeaders.Cars.ToString();

      _eventAggregator.GetEvent<GetCarsCommand>().Subscribe(CarListReceived);
      Execute();
    }

    private void CarListReceived(CarList obj) => CarItems = obj;

    private void Execute() {
      _eventAggregator.GetEvent<GetCarsCommand>().Publish(CarList.GetCars());
    }
  }
}
