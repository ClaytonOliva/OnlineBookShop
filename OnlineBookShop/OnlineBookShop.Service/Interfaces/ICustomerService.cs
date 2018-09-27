using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Contracts.Models;
using OnlineBookShop.Contracts.Models.Presentation;

namespace OnlineBookShop.Service.Interfaces
{
    public interface ICustomerService
    {
        Response<Customer> RegisterCustomer(Customer details);
        Response<Customer> UnregisterCustomer(int id);
        Response<Customer> ViewCustomerDetails(int id);
        Response<Customer> UpdateCustomerDetails(Customer details);
    }
}
