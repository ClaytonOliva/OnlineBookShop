using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineBookShop;
using OnlineBookShop.Contracts.Models.Presentation;
using OnlineBookShop.Controllers;
using OnlineBookShop.Service.Interfaces;
using StructureMap;

namespace OnlineBookShop.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        private readonly ICustomerService _customerService;

        public CustomersControllerTest()
        {
            Container container = OnlineBookShop.Bootstrapper.ApiConfig.ConfigureBindings();
            _customerService = container.GetInstance<ICustomerService>();
        }

        [TestMethod]
        public void GetDetails()
        {
            // Arrange
            CustomersController controller = new CustomersController(_customerService);

            var details = controller.GetDetails(2);

            // Assert.
            Assert.IsNotNull(details);
            Assert.IsTrue(details.IsSuccess);
            Assert.IsNotNull(details.Data);
            Assert.AreEqual(2, details.Data.Id);
        }

        [TestMethod]
        public void Register()
        {
            // Arrange
            CustomersController controller = new CustomersController(_customerService);

            Customer testCustomer = 
                new Customer(){ Id=1, Address = "Home Address", Email = "email@email.com", Name = "Name", Surname = "Surname"};

            var details = controller.Register(testCustomer);
            Assert.IsNotNull(details);
            Assert.IsTrue(details.IsSuccess);
            Assert.IsNotNull(details.Data);
        }

        [TestMethod]
        public void UpdateDetails()
        {
            // Arrange
            CustomersController controller = new CustomersController(_customerService);

            Customer testCustomer = 
                new Customer() { Id = 1, Address = "Home Address Changed", Email = "email@email.com", Name = "Name Changed", Surname = "Surname" };

            var details = controller.Register(testCustomer);
            Assert.IsNotNull(details);
            Assert.IsTrue(details.IsSuccess);
            Assert.IsNotNull(details.Data);
            Assert.AreEqual(testCustomer.Address, details.Data.Address);
            Assert.AreEqual(testCustomer.Name, details.Data.Name);
        }

        [TestMethod]
        public void Unregister()
        {
            // Arrange
            CustomersController controller = new CustomersController(_customerService);

            var details = controller.Unregister(2);
            Assert.IsTrue(details.IsSuccess);
        }
    }
}
