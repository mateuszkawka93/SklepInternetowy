using System.Configuration;

namespace SklepInternetowy.Infrastructure
{
    public class AppConfig
    {
        private static string _productsPictureFolder = ConfigurationManager.AppSettings["ProductsIconFolder"];

        public static string ProductsPictureFolder
        {
            get
            {
                return _productsPictureFolder;
            }
        }
    }
}