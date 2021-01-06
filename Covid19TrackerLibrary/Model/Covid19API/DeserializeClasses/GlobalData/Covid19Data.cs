using Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.Parts;

namespace Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses
{
    //Класс необходимый для десериализации данных по всему миру
    public class Covid19Data
    {
        public Global Global { get; set; }
        public Covid19Data()
        {
            Global = new Global();
        }
    }
}
