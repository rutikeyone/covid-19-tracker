using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.Parts;
using System;

namespace Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses
{
    public class Covid19Data
    {
        public Global Global { get; set; }
        public Covid19Data()
        {
            Global = new Global();
        }
    }
}
