using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Contracts.Models.Data
{
    /// <summary>
    /// Data container for the Customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Primary identifier of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of customer.        
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Email address of customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Living Address of customer.
        /// </summary>
        public string Address { get; set; }
    }
}
