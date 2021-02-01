using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Platform;
using Platform.Controllers;
using Platform.Models;
using Platform.Models.Assets;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class SearchControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            SearchController controller = new SearchController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void Search()
        {
            // Arrange
            List<Account> emptList = new List<Account>();

            Mock<AccountManager> accountManager = new Mock<AccountManager>();
            accountManager.Setup(x => x.searchByProfile("python")).Returns(emptList);

            SearchController controller = new SearchController();

            // Act
            List<Account> result = controller.Get("python");

            // Assert
            Assert.AreEqual(result, emptList);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            SearchController controller = new SearchController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            SearchController controller = new SearchController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            SearchController controller = new SearchController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
