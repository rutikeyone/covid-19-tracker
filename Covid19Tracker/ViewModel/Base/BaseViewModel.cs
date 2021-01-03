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

        private string country = null;
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        private string confirmedValue = null;
        public string ConfirmedValue
        {
            get => confirmedValue;
            set => SetProperty(ref confirmedValue, value);
        }

        private string recoveredValue = null;
        public string RecoveredValue
        {
            get => recoveredValue;
            set => SetProperty(ref recoveredValue, value);
        }

        private string deathsValue = null;
        public string DeathsValue
        {
            get => deathsValue;
            set => SetProperty(ref deathsValue, value);
        }
    }
}
