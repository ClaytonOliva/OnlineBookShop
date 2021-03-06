﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Contracts.Models.Presentation
{
    /// <summary>
    /// Presentation container for a Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Primary identifier of the Transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the customer doing the purchase. 
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The ID of the book being purchased.
        /// </summary>
        public int BookId { get; set; }
    }
}
