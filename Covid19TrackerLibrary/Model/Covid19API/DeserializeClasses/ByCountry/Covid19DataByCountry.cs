using System;

namespace Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry
{
    public class Covid19DataByCountry
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
        public string Active { get; set; }
        public string Date { get; set; }
    }
}
