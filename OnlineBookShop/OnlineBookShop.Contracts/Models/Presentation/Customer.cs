using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnlineBookShop.Contracts.Models.Presentation
{
    public class Customer
    {
        /// <summary>
        /// Primary identifier of the customer.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Surname of customer.        
        /// </summary>
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Email address of customer.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Living Address of customer.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}
