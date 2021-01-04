using System;

namespace Covid19Tracker.ViewModel.Base
{
    public class BaseLatestData : BaseViewModel
    {
        protected string confirmedValue = null;
        public string ConfirmedValue
        {
            get => confirmedValue;
            set => SetProperty(ref confirmedValue, value);
        }

        protected string recoveredValue = null;
        public string RecoveredValue
        {
            get => recoveredValue;
            set => SetProperty(ref recoveredValue, value);
        }

        protected string deathsValue = null;
        public string DeathsValue
        {
            get => deathsValue;
            set => SetProperty(ref deathsValue, value);
        }
    }
}
