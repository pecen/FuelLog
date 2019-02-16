using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace FuelLog.UI.Wpf.Shell.ViewModels {
  public class MainWindowViewModel : BindableBase {
    private readonly IRegionManager _regionManager;

    private string Title => "Fuel Log";
    private string TabRegion => "TabRegion";

    public DelegateCommand<string> NavigateCommand { get; set; }

    public MainWindowViewModel(IRegionManager regionManager) {
      _regionManager = regionManager;

      NavigateCommand = new DelegateCommand<string>(Navigate);
    }

    private void Navigate(string uri) {
      _regionManager.RequestNavigate(TabRegion, uri);
    }
  }
}
