using FishTechMobile.Models;
using FishTechMobile.Services;
using FishTechMobile.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTechMobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Tanque> Tanques { get; }

        private DelegateCommand<Tanque> _ShowMovieCommand;
        public DelegateCommand<Tanque> ShowMovieCommand =>
            _ShowMovieCommand ?? (_ShowMovieCommand = new DelegateCommand<Tanque>(async (itemSelect) =>
            await ExecuteShowMovieCommand(itemSelect), (itemSelect) => !IsBusy));

        private DelegateCommand<Tanque> _loadMoreCommand;
        public DelegateCommand<Tanque> LoadMoreCommand =>
            _loadMoreCommand ?? (_loadMoreCommand = new DelegateCommand<Tanque>(async (itemSelect) =>
            await ExecuteLoadMoreCommand(itemSelect), (itemSelect) => !IsBusy));

        private DelegateCommand _pullToRefreshCommand;
        public DelegateCommand PullToRefreshCommand =>
            _pullToRefreshCommand ?? (_pullToRefreshCommand = new DelegateCommand(async () =>
             await ExecutePullToRefreshCommand(), () => !IsBusy));

        IFishTechAPIService _FishTechService;

        private int _pageindex = 1;

        protected MainViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService, IFishTechAPIService FishTechService) : base(navigationService, pageDialogService)
        {
            Title = "Meus Tanques";

            Tanques = new ObservableCollection<Tanque>();
            _FishTechService = FishTechService;

       

        }


        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            
                await LoadAsync();

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

        private async Task ExecuteShowMovieCommand(Tanque tanque)
        {

            try
            {
                IsBusy = true;


                tanque = await _FishTechService.FindByIdAsync(tanque.ID);
                var navigationParams = new NavigationParameters
                {
                    {"tanque", tanque}
                };
                await NavigationService.NavigateAsync(nameof(TanqueDetailPage), navigationParams);


            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movie:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }


        }
        private async Task ExecuteLoadMoreCommand(Tanque item)
        {
            if (Tanques.Last() == item)
            {
                _pageindex++;
                await LoadAsync(_pageindex);
            }
        }
        private async Task ExecutePullToRefreshCommand()
        {
            Tanques.Clear();
            _pageindex = 1;
            await LoadAsync();
        }

        private async Task LoadAsync(int page = 1)
        {
            try
            {
                IsBusy = true;

                var tanques = await _FishTechService.GetTanquesAsync(page);


                foreach (var tanque in tanques.Results)
                {
                    Tanques.Add(tanque);
                }

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movies:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }
        }

    }

}
