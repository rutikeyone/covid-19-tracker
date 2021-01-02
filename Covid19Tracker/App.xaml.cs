using Covid19Tracker.View;
using Covid19TrackerLibrary.Model.Windows;
using Covid19TrackerLibrary.ViewModel;
using System.Windows;

namespace Covid19Tracker
{
    public partial class App : Application
    {
        private DisplayRootRegistry DisplayRootRegistry;
        private MainViewModel MainWindowViewModel;

        public App()
        {
            DisplayRootRegistry = new DisplayRootRegistry();
            DisplayRootRegistry.RegistryWindowType<MainViewModel, MainWindow>();
            DisplayRootRegistry.RegistryWindowType<DataViewModel, DataWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowViewModel = new MainViewModel();
            await DisplayRootRegistry.ShowModalPresendation(MainWindowViewModel);
            Shutdown();

        }
    }
}
