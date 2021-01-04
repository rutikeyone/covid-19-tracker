using System;

namespace Covid19Tracker.ViewModel.Base
{
    public class BaseLatestData : BaseViewModel
    {
        protected string _confirmedValue = null;
        public string ConfirmedValue
        {
            get => _confirmedValue;
            set => SetProperty(ref _confirmedValue, value);
        }

        protected string _recoveredValue = null;
        public string RecoveredValue
        {
            get => _recoveredValue;
            set => SetProperty(ref _recoveredValue, value);
        }

        protected string _deathsValue = null;
        public string DeathsValue
        {
            get => _deathsValue;
            set => SetProperty(ref _deathsValue, value);
        }
    }
}
