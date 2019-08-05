using Prism;
using Prism.Ioc;
using FuelLog.UI.Mobile.ViewModels;
using FuelLog.UI.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FuelLog.UI.Mobile {
  public partial class App {
    /* 
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor. 
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */
    public App() : this(null) { }

    public App(IPlatformInitializer initializer) : base(initializer) { }

    protected override async void OnInitialized() {
      InitializeComponent();

      await NavigationService.NavigateAsync("NavigationPage/MainPage");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry) {
      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
      containerRegistry.RegisterForNavigation<FillupsPage, FillupsPageViewModel>();
      containerRegistry.RegisterForNavigation<CostsPage, CostsPageViewModel>();
      containerRegistry.RegisterForNavigation<CalcPage, CalcPageViewModel>();
      containerRegistry.RegisterForNavigation<StatsPage, StatsPageViewModel>();
      containerRegistry.RegisterForNavigation<VehiclesPage, VehiclesPageViewModel>();
      containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
    }
  }
}
