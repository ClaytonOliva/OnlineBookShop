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
        Transaction PurchaseBook(Transaction details);
        IEnumerable<Purchase> GetPurchaseHistory(int customerId);
        Transaction GetTransaction(int transactionId);
    }
}
