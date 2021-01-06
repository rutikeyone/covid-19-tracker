using Covid19Tracker.ViewModel.Base;
using Covid19TrackerLibrary.Model.Covid19API;

namespace Covid19Tracker.ViewModel
{
    public class TheTotalDataViewModel : BaseLatestData
    {
        //Конструктор

        #region Constructor

        public TheTotalDataViewModel()
        {
            //Получаем глобальные значения и устанавливаем их в окно
            API.GetGlobalData();
        }

        #endregion
    }
}
