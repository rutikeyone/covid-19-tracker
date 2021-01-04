using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Covid19Tracker.ViewModel.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private string _country = null;
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}
