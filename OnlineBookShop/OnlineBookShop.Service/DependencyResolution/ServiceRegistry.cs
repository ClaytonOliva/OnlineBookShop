using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Service.Interfaces;
using StructureMap;

namespace OnlineBookShop.Service.DependencyResolution
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry() 
        {
            For<IBookStoreService>().Use<Services.BookStoreService>();
            For<ICustomerService>().Use<Services.CustomerService>();
        }
    }
}
