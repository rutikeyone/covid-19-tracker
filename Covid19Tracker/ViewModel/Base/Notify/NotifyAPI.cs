using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Tracker.ViewModel.Base.Notify
{
    public class NotifyAPI<T,H>
    {
        public virtual void GlobalNotify(T covidData) { }
        public virtual void NotifyByCountry(H covidData) { }

        public virtual void NotifyError(string errorMessage) { }
    }
}
