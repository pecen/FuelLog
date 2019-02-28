using FuelLog.UI.Wpf.Shell.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace FuelLog.UI.Wpf.Shell.ViewModels {
  public class MainWindowViewModel : BindableBase {
    private readonly IRegionManager _regionManager;

    //private string Title => "Fuel Log";

    private string _title = "Fuel Log";
    public string Title {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    private string _tabRegion; // => "TabRegion";
    public string TabRegion {
      get { return _tabRegion; }
      set { SetProperty(ref _tabRegion, value); }
    }

    private string _carListRegion;
    public string CarListRegion {
      get { return _carListRegion; }
      set { SetProperty(ref _carListRegion, value); }
    }

    private string _contentRegion;
    public string ContentRegion {
      get { return _contentRegion; }
      set { SetProperty(ref _contentRegion, value); }
    }

    public DelegateCommand<string> NavigateCommand { get; set; }

    public MainWindowViewModel(IRegionManager regionManager) {
      _regionManager = regionManager;

      NavigateCommand = new DelegateCommand<string>(Navigate);

      TabRegion = WindowRegions.TabRegion.ToString();
      ContentRegion = WindowRegions.ContentRegion.ToString();
      CarListRegion = WindowRegions.CarListRegion.ToString();
    }

    private void Navigate(string uri) {
      _regionManager.RequestNavigate(TabRegion, uri);
    }
  }
}
