using RestSharp;
using System;

namespace Covid19TrackerLibrary.Model.Covid19API.Interfaces
{
    public interface IAPIWork<T> where T : class
    {
        T CovidData { get; set; }
        public event Action<T> GotEvent;
        public void GetData(RestClient client);

        public string GetRecovered(T covidData);

        public string GetConfirmed(T covidData);

        public string GetDeaths(T covidData);
    }
}
