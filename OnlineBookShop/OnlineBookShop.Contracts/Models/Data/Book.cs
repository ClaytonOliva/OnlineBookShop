using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Contracts.Models.Data
{
    /// <summary>
    /// Data container for the Book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Primary identifier of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ISBN of the book.
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Year of the book.
        /// </summary>
        public int Year { get; set; }
    }
}
