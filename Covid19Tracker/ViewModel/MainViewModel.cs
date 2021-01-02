using Covid19TrackerLibrary.Model.Commands;
using Covid19TrackerLibrary.Model.Windows;
using Covid19Tracker.ViewModel.Base;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace Covid19Tracker.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private DisplayRootRegistry DisplayRootRegistry;

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
            DisplayRootRegistry.ShowPresentation(new TheLatestDataByCountryViewModel());
            if(sender is Window)
            {
                (sender as Window).Close();
            }
        }
        #endregion

        #region GetTheLatestDataCommand
        public RelayCommand<Window> GetTheLatestData { get; set; }
        public void GetTheLatestDataExecute(Window window)
        {
            DisplayRootRegistry.ShowPresentation(new TheLatestDataViewModel());
            if (window != null)
                window.Close();
        } 
        #endregion

        #region Constructor
        public MainViewModel()
        {
            GetDataByCountry = new ActionCommand(GetDataByCountryExecute, CanGetDataByCountryExecute);
            GetTheLatestData = new RelayCommand<Window>(GetTheLatestDataExecute);
            Close = new RelayCommand<Window>(CloseWindow);
            DisplayRootRegistry = (Application.Current as App).displayRootRegistry;
        }
        #endregion
    }
}
