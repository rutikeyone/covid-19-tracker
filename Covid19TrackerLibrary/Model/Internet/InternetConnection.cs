using System.Net;

namespace Covid19TrackerLibrary.Model.Internet
{
    public class InternetConnection
    {
        public bool CheckInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://google.com"))
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
