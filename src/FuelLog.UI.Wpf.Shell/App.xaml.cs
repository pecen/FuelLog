using FuelLog.UI.Wpf.Module;
using FuelLog.UI.Wpf.Module.UserControls;
using FuelLog.UI.Wpf.Module.ViewModels;
using FuelLog.UI.Wpf.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System.Windows;

namespace FuelLog.UI.Wpf.Shell {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App {
    protected override Window CreateShell() {
      return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry) {
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) {
      base.ConfigureModuleCatalog(moduleCatalog);

      moduleCatalog.AddModule<FuelLogModule>();
    }

    protected override void ConfigureViewModelLocator() {
      base.ConfigureViewModelLocator();

      ViewModelLocationProvider.Register<CarItem, CarItemViewModel>();
    }
  }
}
