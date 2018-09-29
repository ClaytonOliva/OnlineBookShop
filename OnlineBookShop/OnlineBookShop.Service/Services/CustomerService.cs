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
            var returnValue = new Response<Customer>();

            try
            {
                // Get customer data object.
                var customer = 
                    _customerRepo.AddCustomer(new Contracts.Models.Data.Customer(){ Name = details.Name, Surname = details.Surname, Email = details.Email, Address = details.Address});

                // Update ID
                details.Id = customer.Id;

                returnValue.IsSuccess = true;
                returnValue.Data = details;

                return returnValue;
            }
            catch (Exception e)
            {
                returnValue.IsSuccess = false;
                returnValue.ExceptionMessage = e.Message;
                return returnValue;
            }
        }

        public Response<Customer> UnregisterCustomer(int id)
        {
            var returnValue = new Response<Customer>();

            try
            {
                var isDeleted = _customerRepo.DeleteCustomer(id);
                returnValue.IsSuccess = isDeleted;

                return returnValue;
            }
            catch (Exception e)
            {
                returnValue.IsSuccess = false;
                returnValue.ExceptionMessage = e.Message;
                return returnValue;
            }
        }

        public Response<Customer> UpdateCustomerDetails(Customer details)
        {
            var returnValue = new Response<Customer>();

            try
            {
                var customer = _customerRepo.UpdateCustomer(new Contracts.Models.Data.Customer() { Id = details.Id, Name = details.Name, Surname = details.Surname, Email = details.Email, Address = details.Address });

                returnValue.IsSuccess = true;
                returnValue.Data = new Customer() { Id = customer.Id, Name = customer.Name, Surname = customer.Surname, Email = customer.Email, Address = customer.Address };

                return returnValue;
            }
            catch (Exception e)
            {
                returnValue.IsSuccess = false;
                returnValue.ExceptionMessage = e.Message;
                return returnValue;
            }
        }

        public Response<Customer> ViewCustomerDetails(int id)
        {

            var returnValue = new Response<Customer>();

            try
            {
                // Get from customer Data object.
                var customer =
                    _customerRepo.GetCustomer(id);

                // Map to customer presentation object.
                returnValue.IsSuccess = true;
                returnValue.Data = new Customer(){Id= customer.Id, Name = customer.Name, Surname = customer.Surname, Email = customer.Email, Address = customer.Address };

                return returnValue;
            }
            catch (Exception e)
            {
                returnValue.IsSuccess = false;
                returnValue.ExceptionMessage = e.Message;
                return returnValue;
            }
        }
    }
}
