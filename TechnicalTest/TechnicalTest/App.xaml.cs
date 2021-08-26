using Prism;
using Prism.Ioc;
using TechnicalTest.Settings;
using TechnicalTest.Settings.Mapper;
using TechnicalTest.ViewModels;
using TechnicalTest.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TechnicalTest
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Xamarin.Forms.Device.SetFlags(new string[] { "Shapes_Experimental" });
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            AutoMapperConfig.Register(containerRegistry);
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailTip, DetailTipViewModel>();
            DependencyInjectionContainer.Register(containerRegistry);
        }
    }
}
