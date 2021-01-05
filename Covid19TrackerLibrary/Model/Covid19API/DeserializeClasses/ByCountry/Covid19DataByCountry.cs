using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.ByCountry
{
    public class Covid19DataByCountry
    {
        public CountryData Country { get; set; }

        public Covid19DataByCountry()
        {
            Country = new CountryData();
        }
    }
}
