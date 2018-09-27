using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Data
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString(string connectionStringName)
        {
            var setting = 
                System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];

            if (setting == null)
                throw new Exception(String.Format("Error while retrieving ConnectiongString {0}, this conection String was not found in the .config file", connectionStringName));

            return setting.ConnectionString;
        }
    }
}
