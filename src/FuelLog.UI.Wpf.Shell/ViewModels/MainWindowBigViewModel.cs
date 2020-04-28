using FuelLog.Core.Extensions;
using FuelLog.UI.Wpf.Module.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelLog.UI.Wpf.Shell.ViewModels {
  public class MainWindowBigViewModel : BindableBase {
    private readonly IRegionManager _regionManager;

    private string _title;
    public string Title {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    public string TabRegion { get; } = Regions.TabRegion.ToString();

    public DelegateCommand<string> NavigateCommand { get; set; }

    public MainWindowBigViewModel(IRegionManager regionManager) {
      _regionManager = regionManager;

      Title = Titles.AppTitle.GetDescription();

      NavigateCommand = new DelegateCommand<string>(Navigate);
      //ContentNavigateCommand = new DelegateCommand<string>(ContentNavigate);

      //TabRegion = WindowRegions.TabRegion.ToString();
      //CarListRegion = WindowRegions.CarListRegion.ToString();
    }

    //private void ContentNavigate(string uri) {
    //  _regionManager.RequestNavigate(ContentRegion, uri);
    //}

    private void Navigate(string uri) {
      _regionManager.RequestNavigate(TabRegion, uri);
    }
  }
}
