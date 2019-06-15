using FishTechMobile.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishTechMobile
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
            throw new NotImplementedException();
        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
#if DEBUG
            HotReloader.Current.Run(this);
#endif
            await NavigationService.NavigateAsync($"xf:///{nameof(MenuPage)}/NavigationPage/{nameof(MainPage)}");
        }
    }
}
