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
    public class BookStoreController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IBookStoreService _bookService;
        private static ILog Log { get; set; }
        private ILog log = LogManager.GetLogger(typeof(BookStoreController));

        public BookStoreController(ICustomerService customerService, IBookStoreService bookService)
        {
            _customerService = customerService;
            _bookService = bookService;
        }


       [HttpGet]
       [Route("api/bookstore")]
        public Response<IEnumerable<Book>> GetAllBooks()
        {
            var value = new Response<IEnumerable<Book>>() { IsSuccess = false };

            try
            {
                value = _bookService.GetBooks();

                if(!value.IsSuccess)
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
