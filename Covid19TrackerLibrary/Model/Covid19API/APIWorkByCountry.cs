using Covid19Tracker.Services;
using Covid19TrackerLibrary.Model.Covid19API.Interfaces;
using Covid19TrackerModels;
using System;
using System.Windows;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class APIWorkByCountry : IAPIWork<CountryData>
    {
        public CountryData CovidData { get; set; }
        public APIWorkByCountry()
        {
            CovidData = new CountryData();
        }
        public async void GetData(string country = null)
        {
            CovidData = await Covid19TrackerAPI.GetDataByCountryAsync(country);
        }

        public string GetRecovered()
        {
            return CovidData.Recovered.ToString();
        }

        public string GetConfirmed()
        {
            return CovidData.Cases.ToString();
        }

        public string GetDeaths()
        {
            return CovidData.Deaths.ToString();
        }
    }
}
