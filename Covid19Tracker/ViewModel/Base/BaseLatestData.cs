using Covid19TrackerLibrary.Model.Covid19API;
using System;

namespace Covid19Tracker.ViewModel.Base
{
    public class BaseLatestData : BaseViewModel
    {
        protected API API;
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

        public BaseLatestData()
        {
            API = new API();
            API.GetCasesEvent += SetCases;
        }

        //Метод для подписки события для изменение текстовых UI, я бы мог использовать указатели но лучше использую события
        public void SetCases(string globalConfirmed, string globalRecovered, string globalDeaths)
        {
            ConfirmedValue = globalConfirmed;
            RecoveredValue = globalConfirmed;
            DeathsValue = globalDeaths;
        }
    }
}
