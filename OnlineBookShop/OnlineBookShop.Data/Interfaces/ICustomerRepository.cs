using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Contracts.Models.Data;

namespace OnlineBookShop.Data.Interfaces
{
    public interface ICustomerRepository : IRepository
    {
        Customer AddCustomer(Customer details);
        Customer DeleteCustomer(int id);
        Customer GetCustomer(int id);
        Customer UpdateCustomer(Customer details);
    }
}
