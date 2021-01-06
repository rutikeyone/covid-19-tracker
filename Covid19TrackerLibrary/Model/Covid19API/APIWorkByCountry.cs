using Covid19Tracker.Services;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry;
using Covid19TrackerLibrary.Model.Covid19API.Interfaces;
using Covid19TrackerModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class APIWorkByCountry : IAPIWork<Covid19DataByCountry>
    {
        private List<Covid19DataByCountry> ListCovidData = new List<Covid19DataByCountry>();
        public Covid19DataByCountry CovidData { get; set; }
        public event Action<Covid19DataByCountry> GotEvent;
        public string GetConfirmed(Covid19DataByCountry covidData)
        {
            return covidData.Confirmed + " people";
        }

        public async void GetData(RestClient client)
        {
            await Task.Run(() =>
            {
                RestRequest Request = new RestRequest(Method.GET);
                IRestResponse Response = client.ExecuteAsync(Request).Result;
                ListCovidData = JsonConvert.DeserializeObject<List<Covid19DataByCountry>>(Response.Content);
                CovidData = ListCovidData.Last();
            });
            GotEvent?.Invoke(CovidData);
        }

        public string GetDeaths(Covid19DataByCountry covidData)
        {
            return covidData.Deaths + " people";
        }

        public string GetRecovered(Covid19DataByCountry covidData)
        {
            return covidData.Recovered + " people";
        }
    }
}
