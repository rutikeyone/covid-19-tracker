namespace Covid19Tracker.ViewModel.Base
{
    public class BaseCountryViewModel : BaseLatestData
    {
        //Поле и свойство для привязки и манипулирования значениями в MainViewModel и TheLatestDataByCountryViewModel
        #region Country text UI 

        private string _country = null;
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        #endregion
    }
}
