using OnlineBookShop.Contracts.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Data.Interfaces
{
    public interface IBookStoreRepository : IRepository
    {
        IEnumerable<Book> GetBooks();
        Purchase PurchaseBook();
        IEnumerable<Purchase> GetPurchaseHistory();
    }
}
