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
            try
            {
                _bookStoreRepo.GetBooks();
                return new Response<IEnumerable<Book>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Response<IEnumerable<Transaction>> GetPurchaseHistory()
        {
            try
            {
                _bookStoreRepo.GetPurchaseHistory();
                return new Response<IEnumerable<Transaction>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Response<Transaction> PurchaseBook()
        {
            try
            {
                _bookStoreRepo.PurchaseBook();
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
