using FuelLog.UI.Wpf.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace FuelLog.UI.Wpf.Module {
  public class FuelLogModule : IModule {
    private IRegionManager _regionManager;
    private IUnityContainer _container;

    public FuelLogModule(IRegionManager regionManager, IUnityContainer container) {
      _regionManager = regionManager;
      _container = container;
    }

    public void Initialize() {
      _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
    }

    public void OnInitialized(IContainerProvider containerProvider) {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry) {
      containerRegistry.RegisterForNavigation<ViewA>("ViewA");
    }
  }
}