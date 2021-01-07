using Covid19Tracker.View;
using Covid19TrackerLibrary.Model.Windows;
using Covid19Tracker.ViewModel;
using System.Windows;
using Covid19TrackerLibrary.Model.Internet;

namespace Covid19Tracker
{
    public partial class App : Application
    {
        //Объекты необходимые для начальной регистрации
        protected internal DisplayRootRegistry displayRootRegistry;
        private MainViewModel MainWindowViewModel;
        //Проверка интернет соединения
        private InternetConnection Internet { get; set; }
        public static bool IsHaveInternetConnection {get;private set;}

        public App()
        {
            //Регистрируем окна
            displayRootRegistry = new DisplayRootRegistry();
            displayRootRegistry.RegistryWindowType<MainViewModel, MainWindow>();
            displayRootRegistry.RegistryWindowType<TheTotalDataViewModel, TheTotalData>();
            displayRootRegistry.RegistryWindowType<TheTotalDataByCountryViewModel, TheTotalDataByCountry>();
        }

        //Переопределяем метод OnStartup
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowViewModel = new MainViewModel();
            Internet = new InternetConnection();
            IsHaveInternetConnection = Internet.CheckInternetConnection();

            if (!IsHaveInternetConnection)
                MainWindowViewModel.StatusValue = "Check your internet connection";

            await displayRootRegistry.ShowModalPresendation(MainWindowViewModel);

        }
    }
}
