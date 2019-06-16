using FishTechMobile.Models;
using FishTechMobile.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FishTechMobile.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {

        private INavigationService _navigationService;
        private int _pageindex = 1;
        public ObservableCollection<FishMenuItem> MenuItems { get; set; }
        private FishMenuItem selectedMenuItem;
        public FishMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }
        public DelegateCommand NavigateCommand { get; private set; }
        protected MenuViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Title = "Meus Tanques";


            _navigationService = navigationService;

            MenuItems = new ObservableCollection<FishMenuItem>();

            MenuItems.Add(new FishMenuItem()
            {
                Icon = "",
                PageName = nameof(MainPage),
                Title = "Tanques"
            });

            MenuItems.Add(new FishMenuItem()
            {
                Icon = "",
                PageName = nameof(MainPage),
                Title = "PRO"
            });



            NavigateCommand = new DelegateCommand(Navigate);



        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {

          

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var navigationMode = parameters.GetNavigationMode();
            //if (navigationMode == NavigationMode.Back)
            //{
            //    Console.Write("Voltei!");
            //    return;
            //}
            //else
            //{
            //    Console.Write("Navegando para");
            //}

        }

        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
        }


    }
}
