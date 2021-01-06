using Covid19Tracker.ViewModel.Base;
using Covid19TrackerLibrary.Model.Covid19API;

namespace Covid19Tracker.ViewModel
{
    public class TheTotalDataByCountryViewModel : BaseCountryViewModel
    {
        //Задаем значение для тестового UI и получаем данные
        public void SetCountry(string country)
        {
            API.GetAllDataByCountry(country);
            Country = country;
        }

    }
}
