﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses;
using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.Parts;
using Covid19TrackerLibrary.Model.Covid19API.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class APIWorkByGlobal : IAPIWork<Covid19Data>
    {
        public Covid19Data CovidData { get; set; }
        public event Action<Covid19Data> GotEvent;
        public async void GetData(RestClient client)
        {
            await Task.Run(() =>
            {
                RestRequest Request = new RestRequest(Method.GET);
                IRestResponse Response = client.ExecuteAsync(Request).Result;
                CovidData = JsonConvert.DeserializeObject<Covid19Data>(Response.Content);
            });
            GotEvent?.Invoke(CovidData);
        }

        public string GetConfirmed(Covid19Data covidData)
        {
            return covidData.Global.TotalConfirmed + " people";
        }

        public string GetDeaths(Covid19Data covidData)
        {
            return covidData.Global.TotalDeaths + " people";
        }

        public string GetRecovered(Covid19Data covidData)
        {
            return covidData.Global.TotalRecovered + " people";
        }
    }
}
