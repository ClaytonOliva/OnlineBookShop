using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Contracts.Models.Presentation
{
    /// <summary>
    /// Presentation container for a purchase.
    /// </summary>
    public class Purchase
    {
        /// <summary>
        /// Primary identifier of the Transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The customer Id of the customer.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// The Book Id of the customer.
        /// </summary>
        public string Book { get; set; }

        

    }
}
