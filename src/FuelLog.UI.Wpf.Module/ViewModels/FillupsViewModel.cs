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

    public FillupsViewModel(IEventAggregator eventAggregator) {
      Title = TabHeaders.Fillups.ToString();

      _eventAggregator = eventAggregator;

      _eventAggregator.GetEvent<GetFillupsCommand>().Subscribe(FillupsReceived);
    }

    private void FillupsReceived(FillupList obj) => Fillups = obj;
  }
}
