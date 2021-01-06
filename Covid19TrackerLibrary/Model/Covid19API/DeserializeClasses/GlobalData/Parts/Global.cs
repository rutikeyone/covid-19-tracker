namespace Covid19TrackerLibrary.Model.Covid19API.DeserializeClasses.Parts
{
    //Класс необходимый для десериализации данных по всему миру
    public class Global
    {
        public string NewConfirmed { get; set; }
        public string TotalConfirmed { get; set; }
        public string NewDeaths { get; set; }
        public string TotalDeaths { get; set; }
        public string NewRecovered { get; set; }
        public string TotalRecovered { get; set; }
    }
}
