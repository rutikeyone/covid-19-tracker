using Covid19Tracker.ViewModel.Base;
using Covid19TrackerLibrary.Model.Commands;
using Covid19TrackerLibrary.Model.Commands.Interfaces;
using Covid19TrackerLibrary.Model.Covid19API;
using Covid19TrackerLibrary.Model.Windows;
using CovidSharp;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace Covid19Tracker.ViewModel
{
    public class TheLatestDataByCountryViewModel : BaseLatestData, ICloseCommand, IBackCommand
    {
        private DisplayRootRegistry DisplayRootRegistry;
        private API Api;
        private CoronavirusData CovidData;

        #region Close command
        public RelayCommand<Window> Close { get; set; }

        public void CloseWindow(Window window)
        {
            if (window != null)
                window.Close();
        }
        #endregion

        #region Back command
        public ICommand Back { get; set; }
        public bool CanBackExecute(object sender) => true;
        public void BackExecute(object sender)
        {
            DisplayRootRegistry.RegistryWindowType<MainViewModel, MainWindow>();
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            if (sender is Window)
                (sender as Window).Close();
        }
        #endregion

        public TheLatestDataByCountryViewModel()
        {
            Api = new API();
            DisplayRootRegistry = new DisplayRootRegistry();
            Close = new RelayCommand<Window>(CloseWindow);
            Back = new ActionCommand(BackExecute, CanBackExecute);
        }

        public void SetCountry(string country)
        {
            Country = country;
            //Api.GetTheLatestDataFromCountryNamePopulation(CovidData, country, ref confirmedValue, ref recoveredValue, ref deathsValue);
        }

    }
}
