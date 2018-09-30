using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
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

                //  Map data objects to presentation object.
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

        public Response<IEnumerable<Purchase>> GetPurchaseHistory(int customerId)
        {
            var returnValue = new Response<IEnumerable<Purchase>>();

            try
            {
                var purchases = _bookStoreRepo.GetPurchaseHistory(customerId);

                // Map data object to presentation object.
                returnValue.IsSuccess = true;
                returnValue.Data =
                    purchases.Select(p => new Purchase() { Id = p.Id, Customer = p.Customer, Book = p.Book});

                return returnValue;

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
            var returnValue = new Response<Transaction>();

            try
            {
                _bookStoreRepo.PurchaseBook(new Contracts.Models.Data.Transaction(){ BookId = details.BookId, CustomerId = details.CustomerId});
                returnValue.IsSuccess = true;
                returnValue.Data = null; // No need to return data.
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
