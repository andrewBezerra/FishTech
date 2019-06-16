using FishTechMobile.Services;
using FishTechMobile.ViewModels;
using FishTechMobile.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishTechMobile
{
    public partial class App : PrismApplication
    {
        public App()
             : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
           : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MenuPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<TanqueDetailPage, TanqueDetailViewModel>();
            //containerRegistry.RegisterForNavigation<NoConnectionPage, NoConnectionViewModel>();
            //containerRegistry.RegisterForNavigation<MenuPage, MenuViewModel>();
            containerRegistry.RegisterSingleton<IHttpRequest, HttpRequest>();
            containerRegistry.RegisterSingleton<IFishTechAPIService, FishTechApiService>();
        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
#if DEBUG
            HotReloader.Current.Run(this, new HotReloader.Configuration
            {
                ExtensionAutoDiscoveryPort = 15000 // VALUE FROM EXTENSION's ALERT
            });
#endif

          
            await InitializeNavigation();


        }

        private Task InitializeNavigation()
         => NavigationService.NavigateAsync($"xf:///{nameof(MenuPage)}/NavigationPage/{nameof(MainPage)}");
    }
}
