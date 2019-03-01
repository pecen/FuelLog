using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelLog.UI.Wpf.Module.ViewModels {
  public class FillupsViewModel : ViewModelBase {
    public FillupsViewModel() {
      Title = TabHeaders.Fillups.ToString();
    }
  }
}
