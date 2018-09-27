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
        /// The customer ID of the 
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime PurchaseDate { get; set; }
    }
}
