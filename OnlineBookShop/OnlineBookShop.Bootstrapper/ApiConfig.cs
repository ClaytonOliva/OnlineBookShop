using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Data.DependencyResolution;
using OnlineBookShop.Service.DependencyResolution;

namespace OnlineBookShop.Bootstrapper
{
    public static class ApiConfig
    {
        public static Container ConfigureBindings()
        {
            var container = new Container();

            container.Configure(c =>
            {
                c.For<System.Data.IDbConnection>().Use<MySql.Data.MySqlClient.MySqlConnection>().Ctor<string>().Is("server=localhost;user=sa;database=onlineshop;port=3306;password=Passw0rd");
                c.AddRegistry<ServiceRegistry>();
                c.AddRegistry<DataRegistry>();
            });

            return container;
        }
    }
}
