using System;
using System.Collections.Generic;
using System.Windows;
using Covid19Tracker.Services;
using Covid19TrackerModels;

namespace Covid19TrackerLibrary.Model.Covid19API
{
    public class API
    {
        private APIWorkByCountry APIByCountry;
        private APIWorkByGlobal APIByGlobal;
        public API()
        {
            APIByCountry = new APIWorkByCountry();
            APIByGlobal = new APIWorkByGlobal();
        }

        public void GetAllDataByCountry(string country, ref string confirmedAll, ref string recoveredAll, ref string deathsAll)
        {
            APIByCountry.GetData(country);
            confirmedAll = APIByCountry.GetConfirmed();
            recoveredAll = APIByCountry.GetRecovered();
            deathsAll = APIByCountry.GetDeaths();

        }

        public void GetGlobalData(ref string globalConfirmed, ref string globalRecovered, ref string globalDeaths)
        {
            APIByGlobal.GetData();
            globalConfirmed = APIByGlobal.GetConfirmed();
            globalRecovered = APIByGlobal.GetRecovered();
            globalDeaths = APIByGlobal.GetDeaths();
        }
    }
}
