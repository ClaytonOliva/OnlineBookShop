using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Contracts.Models;
using OnlineBookShop.Contracts.Models.Presentation;
using OnlineBookShop.Data.Interfaces;
using OnlineBookShop.Service.Interfaces;

namespace OnlineBookShop.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public Response<Customer> RegisterCustomer(Customer details)
        {
            try
            {
                _customerRepo.AddCustomer(new Contracts.Models.Data.Customer());
                return new Response<Customer>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Response<Customer> UnregisterCustomer(int id)
        {
            try
            {
                _customerRepo.DeleteCustomer(id);
                return new Response<Customer>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Response<Customer> UpdateCustomerDetails(Customer details)
        {
            try
            {
                _customerRepo.UpdateCustomer(new Contracts.Models.Data.Customer());
                return new Response<Customer>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Response<Customer> ViewCustomerDetails(int id)
        {
            try
            {
                _customerRepo.GetCustomer(id);
                return new Response<Customer>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
