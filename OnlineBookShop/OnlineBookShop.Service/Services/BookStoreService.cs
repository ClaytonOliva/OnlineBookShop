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
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookStoreRepository _bookStoreRepo;

        public BookStoreService(IBookStoreRepository bookStoreRepo)
        {
            _bookStoreRepo = bookStoreRepo;
        }

        public Response<IEnumerable<Book>> GetBooks()
        {
            var returnValue = new Response<IEnumerable<Book>>();

            try
            {
                var books = _bookStoreRepo.GetBooks();

                returnValue.IsSuccess = true;
                returnValue.Data = 
                    books.Select(b => new Book() {Id = b.Id, ISBN = b.ISBN, Title = b.Title, Author = b.Author, Year = b.Year});

                return returnValue;
            }
            catch (Exception e)
            {
                returnValue.IsSuccess = false;
                returnValue.ExceptionMessage = e.Message;
                return returnValue;
            }
        }

        public Response<IEnumerable<Transaction>> GetPurchaseHistory(int customerId)
        {
            var returnValue = new Response<IEnumerable<Transaction>>();

            try
            {
                _bookStoreRepo.GetPurchaseHistory(customerId);
                return new Response<IEnumerable<Transaction>>();
            }
            catch (Exception e)
            {
                returnValue.IsSuccess = false;
                returnValue.ExceptionMessage = e.Message;
                return returnValue;
            }
        }

        public Response<Transaction> PurchaseBook(Transaction details)
        {
            try
            {
                _bookStoreRepo.PurchaseBook(new Contracts.Models.Data.Transaction());
                return new Response<Transaction>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
