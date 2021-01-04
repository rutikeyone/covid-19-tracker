using System;

namespace Covid19TrackerLibrary.Model.Covid19API.Interfaces
{
    public interface IAPIWork<T> where T : class
    {
        T CovidData { get; set; }
        public void GetData(string country = null);

        public string GetRecovered();

        public string GetConfirmed();

        public string GetDeaths();
    }
}
