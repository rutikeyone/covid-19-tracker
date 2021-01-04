using System;
using Covid19Tracker.Models;
using Covid19Tracker.Services;
using Covid19TrackerLibrary.Model.Covid19API.Interfaces;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class APIWorkByGlobal : IAPIWork<GlobalData>
    {
        public GlobalData CovidData { get; set; }
        public APIWorkByGlobal()
        {
            CovidData = new GlobalData();
        }

        public async void GetData(string country = null)
        {
            CovidData = await Covid19TrackerAPI.GetGlobalDataAsync();
        }

        public string GetConfirmed()
        {
            return CovidData.Cases.ToString();
        }

        public string GetDeaths()
        {
            return CovidData.Deaths.ToString();
        }

        public string GetRecovered()
        {
            return CovidData.Recovered.ToString();
        }
    }
}
