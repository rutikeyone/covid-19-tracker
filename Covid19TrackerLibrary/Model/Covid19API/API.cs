using System;
using System.Collections.Generic;
using System.Windows;
using Covid19Tracker.Services;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses;
using Covid19TrackerModels;
using RestSharp;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class API
    {
        private APIWorkByCountry APIByCountry;
        private APIWorkByGlobal APIByGlobal;
        private RestClient Client;
        public API()
        {
            APIByCountry = new APIWorkByCountry();
            APIByGlobal = new APIWorkByGlobal();
        }

        public void GetAllDataByCountry(string country, ref string confirmedAll, ref string recoveredAll, ref string deathsAll)
        {
           

        }

        public void GetGlobalData(ref string globalConfirmed, ref string globalRecovered, ref string globalDeaths)
        {
            Client = new RestClient("https://api.covid19api.com/summary");
            APIByGlobal.GetData(Client);
            globalConfirmed = APIByGlobal.GetConfirmed();
            globalRecovered = APIByGlobal.GetRecovered();
            globalDeaths = APIByGlobal.GetDeaths();
        }
    }
}
