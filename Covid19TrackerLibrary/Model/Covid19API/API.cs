using System;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry;
using RestSharp;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class API
    {
        public APIWorkByCountry APIByCountry { get; set; }
        public APIWorkByGlobal APIByGlobal { get; set; }
        private RestClient Client;
        public API()
        {
            APIByCountry = new APIWorkByCountry();
            APIByGlobal = new APIWorkByGlobal();
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
    }
}
