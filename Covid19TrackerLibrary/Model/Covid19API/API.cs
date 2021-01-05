using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Covid19Tracker.Services;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry;
using Covid19TrackerModels;
using RestSharp;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class API
    {
        private APIWorkByCountry APIByCountry;
        private APIWorkByGlobal APIByGlobal;
        private RestClient Client;
        public Action<string, string, string> GetCasesEvent;

        string GlobalConfirmed { get; set; }
        private string GlobalRecovered { get; set; }
        private string GlobalDeaths { get; set; }

        public API()
        {
            APIByCountry = new APIWorkByCountry();
            APIByGlobal = new APIWorkByGlobal();
            APIByGlobal.GotEvent += GlobalSetUIData;
            APIByCountry.GotEvent += CountrySetUIData;

        }

        public void GetAllDataByCountry(string country)
        {
            Client = new RestClient($"https://api.covid19api.com/total/country/{country}");
            APIByCountry.GetData(Client);
        }

        public void GetGlobalData()
        {
                Client = new RestClient("https://api.covid19api.com/summary");
                APIByGlobal.GetData(Client);
        }


        //Исправлю данный код, но позже
        public void GlobalSetUIData(Covid19Data covidData)
        {
            GlobalConfirmed = APIByGlobal.GetConfirmed(covidData);
            GlobalRecovered = APIByGlobal.GetRecovered(covidData);
            GlobalDeaths = APIByGlobal.GetDeaths(covidData);
            GetCasesEvent?.Invoke(GlobalConfirmed, GlobalRecovered, GlobalDeaths);
        }

        public void CountrySetUIData(Covid19DataByCountry covidData)
        {
            GlobalConfirmed = APIByCountry.GetConfirmed(covidData);
            GlobalRecovered = APIByCountry.GetRecovered(covidData);
            GlobalDeaths = APIByCountry.GetDeaths(covidData);
            GetCasesEvent?.Invoke(GlobalConfirmed, GlobalRecovered, GlobalDeaths);
        }
    }
}
