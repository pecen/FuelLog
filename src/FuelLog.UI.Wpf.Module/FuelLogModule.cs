//using FuelLog.UI.Wpf.Module.UserControls;
using FuelLog.UI.Wpf.Module.Enums;
using FuelLog.UI.Wpf.Module.Services;
using FuelLog.UI.Wpf.Module.UserControls;
using FuelLog.UI.Wpf.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace FuelLog.UI.Wpf.Module {
  public class FuelLogModule : IModule {
    //private IRegionManager _regionManager;

    public FuelLogModule(IRegionManager regionManager, IUnityContainer container) {
      //_regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider) {
      var regionManager = containerProvider.Resolve<IRegionManager>();

      //_regionManager.RegisterViewWithRegion(Regions.ContentRegion.ToString(), typeof(CarList));
      //_regionManager.RegisterViewWithRegion(Regions.ContentRegion.ToString(), typeof(Fillups));
      //_regionManager.RegisterViewWithRegion(Regions.ContentRegion.ToString(), typeof(AddCar));

      regionManager.RegisterViewWithRegion(Regions.TabRegion.ToString(), typeof(AddCar));
      regionManager.RegisterViewWithRegion(Regions.TabRegion.ToString(), typeof(CarList));
      //regionManager.RegisterViewWithRegion(Regions.TabRegion.ToString(), typeof(CarList));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry) {
      //containerRegistry.RegisterForNavigation<CarList>(nameof(CarList));
      //containerRegistry.RegisterForNavigation<Fillups>(nameof(Fillups));
      //containerRegistry.RegisterForNavigation<AddCar>(nameof(AddCar));

      containerRegistry.RegisterSingleton<IPathProvider, PathProvider>();
    }
  }
}