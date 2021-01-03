using Covid19Tracker.ViewModel.Base;
using Covid19TrackerLibrary.Model.Commands.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace Covid19Tracker.ViewModel
{
    public class TheLatestDataByCountryViewModel : BaseViewModel, ICloseCommand
    {
        public RelayCommand<Window> Close { get; set; }

        public void CloseWindow(Window window)
        {
            if (window != null)
                window.Close();
        }

        public TheLatestDataByCountryViewModel()
        {
            Close = new RelayCommand<Window>(CloseWindow);
        }
    }
}
