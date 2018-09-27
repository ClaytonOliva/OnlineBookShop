using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Contracts.Models.Data;
using OnlineBookShop.Data.Interfaces;

namespace OnlineBookShop.Data.Repos
{
    public class BookStoreRepository : BaseRepository, IBookStoreRepository
    {
        

        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetPurchaseHistory()
        {
            throw new NotImplementedException();
        }

        public Purchase PurchaseBook()
        {
            throw new NotImplementedException();
        }
    }
}
