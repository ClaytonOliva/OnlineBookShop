using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Data
{
    public static class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            var setting = 
                System.Configuration.ConfigurationManager.ConnectionStrings["MySqlDb"];

            if (setting == null)
                throw new Exception("Error while retrieving ConnectiongString. The conection String was not found in the .config file");

            return setting.ConnectionString;
        }
    }
}
