using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Contracts.Models.Data
{
    /// <summary>
    /// Data container for a Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Primary identifier of the Transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The customer Id of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The Book Id of the customer.
        /// </summary>
        public int BookId { get; set; }
    }
}
