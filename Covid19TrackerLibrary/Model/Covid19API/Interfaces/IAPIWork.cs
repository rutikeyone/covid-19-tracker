using RestSharp;
using System;

namespace Covid19TrackerLibrary.Model.Covid19API.Interfaces
{
    //Интерфейс для классов, работающих с API 
    public interface IAPIWork<T> where T : class
    {
        T CovidData { get; set; }

        //Событие для оповещения ViewModel
        public event Action<T> GotEvent;

        //Методы для получения данных
        public void GetData(RestClient client);

        public string GetRecovered(T covidData);

        public string GetConfirmed(T covidData);

        public string GetDeaths(T covidData);
    }
}
