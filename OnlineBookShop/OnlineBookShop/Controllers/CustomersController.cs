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

        // GET api/values
        //[HttpGet]
        //[Route("api/customers")]
        //public IEnumerable<string> Get()
        //{
        //    try
        //    {
        //        _bookService.GetBooks();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error",ex);
        //    }

        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [Route("api/customers/{id:int}")]
        public Response<Customer> GetDetails(int id)
        {
            try
            {
                var value = new Response<Customer>();
                value.Data = new Customer(){Id = 1, Name = "Clayton", Surname = "Oliva", Email = "clayton.oliva@gmail.com", Address = "Home"};
                value.IsSuccess = true;

                return value;

                //return _customerService.ViewCustomerDetails(id);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return new Response<Customer>();
            }
        }

        [HttpPost]
        [Route("api/customers/{id:int}")]
        public Response<Customer> Unregister(int id)
        {
            try
            {
                return _customerService.UnregisterCustomer(id);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return new Response<Customer>();
            }
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/customers/{id:int}")]
        public Response<Customer> UpdateDetails(int id, Customer customer)
        {
            try
            {
                return _customerService.UpdateCustomerDetails(customer);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return new Response<Customer>();
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("customers/{id:int}")]
        public void DeleteCustomer(int id)
        {
            try
            {
                 _customerService.UnregisterCustomer(id);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
            }
        }
    }
}
