using Covid19TrackerLibrary.Model.Covid19API;

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

        #endregion

        //Простой конструктор который подписывается на событие 
        #region Constructor

        public BaseLatestData()
        {
            API = new API();
            API.GetCasesEvent += SetCases;
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
    }
}
