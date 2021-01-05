using System;
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

        public void GetData(RestClient client)
        {
            RestRequest Request = new RestRequest(Method.GET);
            IRestResponse Response = client.ExecuteAsync(Request).Result;
            CovidData = JsonConvert.DeserializeObject<Covid19Data>(Response.Content);
        }

        public string GetConfirmed()
        {
            return CovidData.Global.TotalConfirmed + " people";
        }

        public string GetDeaths()
        {
            return CovidData.Global.TotalDeaths + " people";
        }

        public string GetRecovered()
        {
            return CovidData.Global.TotalRecovered + " people";
        }
    }
}
