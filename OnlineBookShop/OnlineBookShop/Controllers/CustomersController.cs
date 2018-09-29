using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using OnlineBookShop.Contracts.Models;
using OnlineBookShop.Contracts.Models.Presentation;
using OnlineBookShop.Service.Interfaces;

namespace OnlineBookShop.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IBookStoreService _bookService;
        private static ILog Log { get; set; }
        private ILog log = LogManager.GetLogger(typeof(CustomersController));

        public CustomersController(ICustomerService customerService, IBookStoreService bookService)
        {
            _customerService = customerService;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("api/customers/{id:int}")]
        public Response<Customer> GetDetails(int id)
        {
            var value = new Response<Customer>() { IsSuccess = false };

            try
            {
                value = _customerService.ViewCustomerDetails(id);

                if (!value.IsSuccess)
                    log.Error(value.ExceptionMessage);

                return value;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                value.ExceptionMessage = ex.Message;
            }

            return value;
        }

        [HttpPost]
        [Route("api/customers")]
        public Response<Customer> Register(Customer details)
        {
            var value = new Response<Customer>() { IsSuccess = false };

            try
            {
                value = _customerService.RegisterCustomer(details);

                if (!value.IsSuccess)
                    log.Error(value.ExceptionMessage);

                return value;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                value.ExceptionMessage = ex.Message;
            }

            return value;
        }

        [HttpPut]
        [Route("api/customers")]
        public Response<Customer> UpdateDetails(Customer customer)
        {
            var value = new Response<Customer>() { IsSuccess = false };

            try
            {
                value = _customerService.UpdateCustomerDetails(customer);

                if (!value.IsSuccess)
                    log.Error(value.ExceptionMessage);

                return value;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                value.ExceptionMessage = ex.Message;
            }

            return value;
        }

        [HttpDelete]
        [Route("customers/{id:int}")]
        public Response<Customer> Unregister(int id)
        {
            var value = new Response<Customer>() { IsSuccess = false };

            try
            {
                value = _customerService.UnregisterCustomer(id);

                if (!value.IsSuccess)
                    log.Error(value.ExceptionMessage);

                return value;
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                value.ExceptionMessage = ex.Message;
            }

            return value;
        }
    }
}
