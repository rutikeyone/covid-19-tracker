using Covid19TrackerLibrary.Model.Commands;
using Covid19TrackerLibrary.Model.Windows;
using Covid19Tracker.ViewModel.Base;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using System;
using Covid19TrackerLibrary.Model.Internet;

namespace Covid19Tracker.ViewModel
{
    //MainViewModel описывает логику работы главного окна(MainWindow)
    public class MainViewModel : BaseCountryViewModel
    {
        //Данные свойство и событие необходимо для передачи значения страны с новое окно TheLatestDataByCountry
        private TheTotalDataByCountryViewModel TheByCountry { get; set; }
        private event Action<string> OpenByCountryEvent;
        private bool IsHaveInternetConnection { get; set; }
        private InternetConnection Internet { get; set; }

        //Команда для получения данных о конкретной стране
        #region GetDataByCountyCommand
        public ICommand GetDataByCountry { get; set; }
        public bool CanGetDataByCountryExecute(object sender) => !string.IsNullOrEmpty(Country) && IsHaveInternetConnection;
        public void GetDataByCountryExecute(object sender)
        {
                DisplayRootRegistry.ShowPresentation(TheByCountry);
                OpenByCountryEvent?.Invoke(Country);
                if (sender is Window)
                    (sender as Window).Close();
            
        }
        #endregion

        //Команда для получения всех данных
        #region GetTheTotalDataCommand
        public ICommand GetTheTotalData { get; set; }
        public bool CanGetTheTotalData(object sender) => IsHaveInternetConnection;
        public void GetTheTotalDataExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new TheTotalDataViewModel());
            if (sender is Window)
                (sender as Window).Close();
        } 
        #endregion

        //Конструктор
        #region Constructor

        public MainViewModel()
        {
            Internet = new InternetConnection();
            TheByCountry = new TheTotalDataByCountryViewModel();
            OpenByCountryEvent += TheByCountry.SetCountry;
            GetDataByCountry = new ActionCommand(GetDataByCountryExecute, CanGetDataByCountryExecute);
            GetTheTotalData = new ActionCommand(GetTheTotalDataExecute, CanGetTheTotalData);
            IsHaveInternetConnection = Internet.CheckInternetConnection();

            if (!IsHaveInternetConnection)
            {
                StatusValue = "Check your internet connection";
            }
        }

        #endregion
    }
}
