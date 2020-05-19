using FuelLog.Core.Extensions;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class AddFillupViewModel : ViewModelBase {
    private readonly IEventAggregator _eventaggregator;

    public AddFillupViewModel(IEventAggregator eventAggregator) {
      _eventaggregator = eventAggregator;

      Title = Titles.AddFillup.GetDescription();
    }
  }
}
