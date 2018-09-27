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
            Container container = new Container();

            container.Configure(c =>
            {
                c.AddRegistry<ServiceRegistry>();
                c.AddRegistry<DataRegistry>();
                c.For<System.Data.IDbConnection>().Use<System.Data.SqlClient.SqlConnection>().Ctor<string>().Is("YOUR_CONNECTION_STRING");
            });

            return container;
        }
    }
}
