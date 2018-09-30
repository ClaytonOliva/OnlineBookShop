using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Contracts.Models;
using OnlineBookShop.Contracts.Models.Presentation;

namespace OnlineBookShop.Service.Interfaces
{
    public interface IBookStoreService
    {
        Response<IEnumerable<Book>> GetBooks();
        Response<Transaction> PurchaseBook(Transaction transaction);
        Response<IEnumerable<Purchase>> GetPurchaseHistory(int customerId);
    }
}
