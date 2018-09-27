using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using OnlineBookShop.Contracts.Models.Data;
using OnlineBookShop.Data.Interfaces;

namespace OnlineBookShop.Data.Repos
{
    public class BookStoreRepository : BaseRepository, IBookStoreRepository
    {
        /// <summary>
        /// Gets all books from store.
        /// </summary>
        /// <returns>List of books.</returns>
        public IEnumerable<Book> GetBooks()
        {
            var sqlCustomerSelect =
                "SELECT Id, Name, Surname, Email, Address FROM Customers WHERE Id = @CustomerId;";

            using (var db = Connection)
            {
                return db.Query<Book>(sqlCustomerSelect).ToList();
            }
        }

        /// <summary>
        /// Gets the transaction by ID.
        /// </summary>
        /// <param name="transactionId">Transaction unique ID.</param>
        /// <returns>Transaction data object.</returns>
        public Transaction GetTransaction(int transactionId)
        {
            var sqlCustomerSelect =
                "SELECT * FROM Transactions WHERE Id = @transactionId;";

            using (var db = Connection)
            {
                return db.Query<Transaction>(sqlCustomerSelect,new {transactionId}).SingleOrDefault();
            }
        }

        /// <summary>
        /// Gets all purchase history by customer ID.
        /// </summary>
        /// <param name="customerId">ID of the customer to retrieve data of.</param>
        /// <returns>List of transactions.</returns>
        public IEnumerable<Transaction> GetPurchaseHistory(int customerId)
        {
            var sqlCustomerSelect =
                "SELECT * FROM Transactions WHERE CustomerId = @CustomerId;";

            using (var db = Connection)
            {
                return db.Query<Transaction>(sqlCustomerSelect, new {customerId}).ToList();
            }
        }

        /// <summary>
        /// Purchases book.
        /// </summary>
        /// <param name="details">Transaction details to save.</param>
        /// <returns>Transaction data object.</returns>
        public Transaction PurchaseBook(Transaction details)
        {
            //
            string sqlTransactionInsert =
                "INSERT INTO Transactions (BookId, CustomerId, Date) Values (@BookId,@CustomerId,NOW());" +
                "SELECT LAST_INSERT_ID();";

            // Add the parameters to use in the insert query
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@BookId", details.Book.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@CustomerId", details.Customer.Id, DbType.Int32, ParameterDirection.Input);

            //using (var connection = new SqlConnection(ConnectionStringHelper.GetConnectionString("")))
            using (var connection = Connection)
            {
                var newInsertedId =
                    connection.Query<int>(sqlTransactionInsert, parameter).Single();

                return this.GetTransaction(newInsertedId);
            }
        }
    }
}
