using Covid19TrackerLibrary.Model.Covid19API;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Covid19Tracker.ViewModel.Base
{
    public class BaseLatestData : BaseViewModel
    {
        protected API API; //Объект необходим для работы с ViewModel с API

        //Binding текстовых UI к свойствам для манипулирования значениями количества человек
        #region Text UI Value

        protected string _confirmedValue = "Getting data";
        public string ConfirmedValue
        {
            get => _confirmedValue;
            set => SetProperty(ref _confirmedValue, value);
        }

        protected string _recoveredValue = "Getting data";
        public string RecoveredValue
        {
            get => _recoveredValue;
            set => SetProperty(ref _recoveredValue, value);
        }

        protected string _deathsValue = "Getting data";
        public string DeathsValue
        {
            get => _deathsValue;
            set => SetProperty(ref _deathsValue, value);
        }

        protected string _statusValue = "Select type data";
        public string StatusValue
        {
            get => _statusValue;
            set => SetProperty(ref _statusValue, value);
        }

        #endregion

        //Простой конструктор который подписывается на событие 
        #region Constructor

        public BaseLatestData()
        {
            API = new API();
            API.APIByCountry.GotEvent += NotifyByCountry;
            API.APIByGlobal.GotEvent += GlobalNotify;
            API.APIByCountry.GotErrorEvent += NotifyError;
        }

        #endregion

        //Метод для подписки события для изменение текстовых UI, я бы мог использовать указатели но лучше использую события
        #region Set Text UI new value

        public void SetCases(string globalConfirmed, string globalRecovered, string globalDeaths)
        {
            ConfirmedValue = globalConfirmed;
            RecoveredValue = globalConfirmed;
            DeathsValue = globalDeaths;
        }

        #endregion

        public override void GlobalNotify(Covid19Data covidData)
        {
            RecoveredValue = API.APIByGlobal.GetRecovered(covidData);
            ConfirmedValue = API.APIByGlobal.GetConfirmed(covidData);
            DeathsValue = API.APIByGlobal.GetDeaths(covidData);
        }

        public override void NotifyByCountry(Covid19DataByCountry covidData)
        {
            RecoveredValue = API.APIByCountry.GetRecovered(covidData);
            ConfirmedValue = API.APIByCountry.GetConfirmed(covidData);
            DeathsValue = API.APIByCountry.GetDeaths(covidData);
        }

        public override void NotifyError(string errorMessage)
        {
            RecoveredValue = errorMessage;
            ConfirmedValue = errorMessage;
            DeathsValue = errorMessage;
        }
    }
}
