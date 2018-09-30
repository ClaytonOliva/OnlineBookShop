using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineBookShop;
using OnlineBookShop.Contracts.Models;
using OnlineBookShop.Contracts.Models.Presentation;
using OnlineBookShop.Controllers;
using OnlineBookShop.Service.Interfaces;
using StructureMap;

namespace OnlineBookShop.Tests.Controllers
{
    [TestClass]
    public class BookStoreControllerTest
    {
        private readonly IBookStoreService _bookStoreService;

        public BookStoreControllerTest()
        {
            Container container = OnlineBookShop.Bootstrapper.ApiConfig.ConfigureBindings();
            _bookStoreService = container.GetInstance<IBookStoreService>();
        }

        [TestMethod]
        public void GetAllBooks()
        {
            // Arrange
            BookStoreController controller = new BookStoreController(_bookStoreService);

            var testTransaction = new Transaction(){BookId = 1,CustomerId = 2} ;

            var details = controller.GetAllBooks();

        }

        [TestMethod]
        public void GetPurchaseHistory()
        {
           
        }

        [TestMethod]
        public void PurchaseBook()
        {
            // Arrange
            BookStoreController controller = new BookStoreController(_bookStoreService);

            var testTransaction = new Transaction() { BookId = 1, CustomerId = 2 };

            var details = controller.PurchaseBook(testTransaction);

            // Assert.
            Assert.IsNotNull(details);
            Assert.IsTrue(details.IsSuccess);
            Assert.IsNotNull(details.Data);
            Assert.AreNotEqual(0, details.Data.Id);
        }
    }
}
