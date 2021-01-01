﻿using Covid19TrackerLibrary.Model.Commands;
using Covid19TrackerLibrary.ViewModel.Base;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace Covid19TrackerLibrary.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Text Ui

        #region CountryText
        private string country = null;
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        #endregion

        #endregion

        #region Close command
        public RelayCommand<Window> Close { get; set; }

        public void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion

        #region GetDataByCountyCommand
        public ICommand GetDataByCountry { get; set; }
        public bool CanGetDataByCountryExecute(object sender) => !string.IsNullOrEmpty(country);
        public void GetDataByCountryExecute(object sender)
        {
          
        }
        #endregion

        #region GetTheLatestDataCommand
        public ICommand GetTheLatestData { get; set; }
        public bool CanGetTheLatestDataExecute(object sender) => !string.IsNullOrEmpty(country);
        public void GetTheLatestDataExecute(object sender)
        {

        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            GetDataByCountry = new ActionCommand(GetDataByCountryExecute, CanGetDataByCountryExecute);
            GetTheLatestData = new ActionCommand(GetTheLatestDataExecute, CanGetTheLatestDataExecute);
            Close = new RelayCommand<Window>(CloseWindow);
        }
        #endregion
    }
}
