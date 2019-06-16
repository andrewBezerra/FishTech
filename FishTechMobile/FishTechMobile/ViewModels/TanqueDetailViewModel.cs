using FishTechMobile.Models;
using FishTechMobile.Services;
using Microcharts;
using Prism.Navigation;
using Prism.Services;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishTechMobile.ViewModels
{
    public class TanqueDetailViewModel : ViewModelBase
    {
        private IFishTechAPIService _FishTechService;
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;
        public BarChart phchart { get; set; }
        public LineChart odchart { get; set; }
        public PointChart tempchart { get; set; }
        public LineChart turbidezchart { get; set; }
        public Entry[] entries { get; set; }
        Tanque _tanque;
        private int _pageindex = 1;
        public Tanque Tanque
        {
            get { return _tanque; }
            set
            {
                _tanque = value;
                OnPropertyChanged();
            }
        }
        protected TanqueDetailViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService, IFishTechAPIService FishTechService) : base(navigationService, pageDialogService)
        {

            _FishTechService = FishTechService;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            phchart = new BarChart();
            phchart.Entries = new[]
                {
                    new Entry(6.5f)
                    {
                        Label = "09/06/2019",
                        ValueLabel = "6.5",
                        Color = SKColor.Parse("#FFA000")
                    },
                     new Entry(6.8f)
                    {
                        Label = "10/06/2019",
                        ValueLabel = "6.8",
                        Color = SKColor.Parse("#D32F2F")
                    },
                      new Entry(5.9f)
                    {
                        Label = "11/06/2019",
                        ValueLabel = "5.9",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                       new Entry(4.7f)
                    {
                        Label = "12/06/2019",
                        ValueLabel = "4.7",
                        Color = SKColor.Parse("#CDDC39")
                    },
                        new Entry(5.8f)
                    {
                        Label = "13/06/2019",
                        ValueLabel = "5.8",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                         new Entry(7.4f)
                    {
                        Label = "14/06/2019",
                        ValueLabel = "7.4",
                        Color = SKColor.Parse("#D32F2F")
                    },
                          new Entry(7.4f)
                    {
                        Label = "15/06/2019",
                        ValueLabel = "7.4",
                        Color = SKColor.Parse("#D32F2F")
                    },

                };
            odchart = new LineChart()
            {
                LineMode = LineMode.Spline,
                LineSize = 8,
                PointMode = PointMode.Circle,
                PointSize = 18,

            };
            odchart.Entries = new[]
                {
                    new Entry(36.1f)
                    {
                        Label = "09/06/2019",
                        ValueLabel = "36.1",
                        Color = SKColor.Parse("#FFA000")
                    },
                     new Entry(37.1f)
                    {
                        Label = "10/06/2019",
                        ValueLabel = "37.1",
                        Color = SKColor.Parse("#D32F2F")
                    },
                      new Entry(33.1f)
                    {
                        Label = "11/06/2019",
                        ValueLabel = "33.1",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                       new Entry(31.1f)
                    {
                        Label = "12/06/2019",
                        ValueLabel = "31.1",
                        Color = SKColor.Parse("#CDDC39")
                    },
                        new Entry(36.1f)
                    {
                        Label = "13/06/2019",
                        ValueLabel = "36.1",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                         new Entry(39.1f)
                    {
                        Label = "14/06/2019",
                        ValueLabel = "39.1",
                        Color = SKColor.Parse("#D32F2F")
                    },
                          new Entry(36.1f)
                    {
                        Label = "15/06/2019",
                        ValueLabel = "36.1",
                        Color = SKColor.Parse("#FFA000")
                    },

                };

            tempchart = new PointChart()
            {
                PointMode=PointMode.Square,
                MaxValue=36.5f,
                MinValue=33.5f
                
            };
            tempchart.Entries = new[]
                {
                    new Entry(33.1f)
                    {
                        Label = "09/06/2019",
                        ValueLabel = "33.1",
                        Color = SKColor.Parse("#CDDC39")
                    },
                     new Entry(34.1f)
                    {
                        Label = "10/06/2019",
                        ValueLabel = "34.1",
                        Color = SKColor.Parse("#CDDC39")
                    },
                      new Entry(34.8f)
                    {
                        Label = "11/06/2019",
                        ValueLabel = "34.1",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                       new Entry(34.8f)
                    {
                        Label = "12/06/2019",
                        ValueLabel = "34.8",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                        new Entry(35.6f)
                    {
                        Label = "13/06/2019",
                        ValueLabel = "35.6",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                         new Entry(36.2f)
                    {
                        Label = "14/06/2019",
                        ValueLabel = "36.2",
                        Color = SKColor.Parse("#D32F2F")
                    },
                          new Entry(36.8f)
                    {
                        Label = "15/06/2019",
                        ValueLabel = "36.8",
                        Color = SKColor.Parse("#D32F2F")
                    },

                };
            turbidezchart = new LineChart()
            {
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,

            };
            turbidezchart.Entries = new[]
                {
                    new Entry(33.1f)
                    {
                        Label = "09/06/2019",
                        ValueLabel = "33.1",
                        Color = SKColor.Parse("#CDDC39")
                    },
                     new Entry(34.1f)
                    {
                        Label = "10/06/2019",
                        ValueLabel = "34.1",
                        Color = SKColor.Parse("#CDDC39")
                    },
                      new Entry(34.8f)
                    {
                        Label = "11/06/2019",
                        ValueLabel = "34.1",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                       new Entry(34.8f)
                    {
                        Label = "12/06/2019",
                        ValueLabel = "34.8",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                        new Entry(35.6f)
                    {
                        Label = "13/06/2019",
                        ValueLabel = "35.6",
                        Color = SKColor.Parse("#FFEB3B")
                    },
                         new Entry(36.2f)
                    {
                        Label = "14/06/2019",
                        ValueLabel = "36.2",
                        Color = SKColor.Parse("#D32F2F")
                    },
                          new Entry(36.8f)
                    {
                        Label = "15/06/2019",
                        ValueLabel = "36.8",
                        Color = SKColor.Parse("#D32F2F")
                    },

                };


        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {



        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;
            var tanque = parameters.GetValue<Tanque>("tanque");
            Tanque = tanque;
            Title = tanque.Descricao;
            IsBusy = false;

        }

    }
}
