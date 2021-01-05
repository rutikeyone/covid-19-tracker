using Covid19Tracker.Services;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry;
using Covid19TrackerLibrary.Model.Covid19API.Interfaces;
using Covid19TrackerModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class APIWorkByCountry : IAPIWork<Covid19DataByCountry>
    {
        List<Covid19DataByCountry> ListCovidData = new List<Covid19DataByCountry>();

        public Covid19DataByCountry CovidData { get; set; }
        public event Action<Covid19DataByCountry> GotEvent;
        public string GetConfirmed(Covid19DataByCountry covidData)
        {
            return covidData.Country.Confirmed;
        }

        public async void GetData(RestClient client)
        {
            /*RestRequest Request = new RestRequest(Method.GET);
            IRestResponse Response = client.ExecuteAsync(Request).Result;
            ListCovidData = JsonConvert.DeserializeObject<List<Covid19DataByCountry>>(Response.Content);
            for(int i = 0; i < ListCovidData.Count; i++)
            {
                MessageBox.Show(ListCovidData[i].Country.Date);
            }
            await Task.Run(() =>
            {
                RestRequest Request = new RestRequest(Method.GET);
                IRestResponse Response = client.ExecuteAsync(Request).Result;
                CovidData = JsonConvert.DeserializeObject<Covid19DataByCountry>(Response.Content);
            });
            GotEvent?.Invoke(CovidData);*/
        }

        public string GetDeaths(Covid19DataByCountry covidData)
        {
            return covidData.Country.Deaths;
        }

        public string GetRecovered(Covid19DataByCountry covidData)
        {
            return covidData.Country.Recovered;
        }
    }
}
