using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Data.Interfaces;

namespace OnlineBookShop.Data.DependencyResolution
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IBookStoreRepository>().Use<Repos.BookStoreRepository>();
            For<ICustomerRepository>().Use<Repos.CustomerRepository>();
        }
    }
}
