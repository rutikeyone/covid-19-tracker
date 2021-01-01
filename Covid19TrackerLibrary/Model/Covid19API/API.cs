using System;
using CovidSharp;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class API
    {
        public void GetTheLatestData(CoronavirusData data, ref string latestConfimed, ref string latestRecovered, ref string latestDeaths)
        {
            latestConfimed = data.LatestConfirmed();
            latestRecovered = data.LatestRecovered();
            latestDeaths = data.LatestDeaths();
        }

        public void GetTheLatestDataFromCountryNamePopulation(CoronavirusData data, string country, ref string latestConfimed, ref string latestRecovered, ref string latestDeaths)
        {
            latestConfimed = data.FromCountryNameConfirmed(country);
            latestRecovered = data.FromCountryNameRecovered(country);
            latestDeaths = data.FromCountryNameDeaths(country);
        }
    }
}
