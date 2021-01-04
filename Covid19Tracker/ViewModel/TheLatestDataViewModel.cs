using Covid19Tracker.ViewModel.Base;
using Covid19TrackerLibrary.Model.Commands;
using Covid19TrackerLibrary.Model.Commands.Interfaces;
using Covid19TrackerLibrary.Model.Windows;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace Covid19Tracker.ViewModel
{
    public class TheLatestDataViewModel : BaseLatestData, ICloseCommand, IBackCommand
    {
        private DisplayRootRegistry DisplayRootRegistry;
        public ICommand Back { get; set; }
        public bool CanBackExecute(object sender) => true;
        public void BackExecute(object sender)
        {
            DisplayRootRegistry.RegistryWindowType<MainViewModel, MainWindow>();
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            if (sender is Window)
                (sender as Window).Close();
        }

        public RelayCommand<Window> Close { get; set; }
        public void CloseWindow(Window window)
        {
            if (window != null)
                window.Close();
        }

        public TheLatestDataViewModel()
        {
            DisplayRootRegistry = new DisplayRootRegistry();
            Back = new ActionCommand(BackExecute, CanBackExecute);
            Close = new RelayCommand<Window>(CloseWindow);
        }

    }
}
