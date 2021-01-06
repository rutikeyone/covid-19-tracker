using Covid19Tracker.ViewModel.Base.Notify;
using Covid19TrackerLibrary.Model.Commands;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry;
using Covid19TrackerLibrary.Model.Windows;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Covid19Tracker.ViewModel.Base
{
    //Данный класс служит базовым для всех ViewModel
    public class BaseViewModel : NotifyAPI<Covid19Data, Covid19DataByCountry>, INotifyPropertyChanged
    {
        //Поле для взаимодействия с логикой открытия и закрытия окон
        protected DisplayRootRegistry DisplayRootRegistry { get; private set; }
        //Реализация INotifyPropertyChanged
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged; //Реализуем INotifyPropertyChanged

        //Метод для обновления значения свойства и текстового UI
        protected bool SetProperty<T>(ref T field, T value, string property = null)
        {
            if(EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(property);
            return true;
        }
        //Метод для вызова события
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        //Общая для всех трех ViewModel команда для закрытия окна
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

        //Команда необходимая для возвращения на главное окно
        #region Back command
        public ICommand Back { get; set; }
        public bool CanBackExecute(object sender) => true;
        public void BackExecute(object sender)
        {
            DisplayRootRegistry.ShowPresentation(new MainViewModel());
            if (sender is Window)
                (sender as Window).Close();
        }
        #endregion

        //Конструктор в котором мы устанавливаем базовое значение
        #region Constructor

        public BaseViewModel()
        {
            DisplayRootRegistry = (Application.Current as App).displayRootRegistry;
            Close = new RelayCommand<Window>(CloseWindow);
            Back = new ActionCommand(BackExecute, CanBackExecute);
        }

        #endregion

    }
}
