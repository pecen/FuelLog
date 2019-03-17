//using FuelLog.UI.Wpf.Module.UserControls;
using FuelLog.UI.Wpf.Module.UserControls;
using FuelLog.UI.Wpf.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace FuelLog.UI.Wpf.Module {
  public class FuelLogModule : IModule {
    private IRegionManager _regionManager;

    public FuelLogModule(IRegionManager regionManager, IUnityContainer container) {
      _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider) {
      _regionManager.RegisterViewWithRegion("ContentRegion", typeof(CarList));
      _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Fillups));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry) {
      containerRegistry.RegisterForNavigation<CarList>(nameof(CarList));
      containerRegistry.RegisterForNavigation<Fillups>(nameof(Fillups));
      //containerRegistry.RegisterForNavigation<AddCar>(nameof(AddCar));
    }
  }
}