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
        public void Search()
        {
            // Arrange
            List<Account> emptList = new List<Account>();

            Mock<AccountManager> accountManager = new Mock<AccountManager>();
            accountManager.Setup(x => x.searchByProfile(It.IsAny<string>())).Returns(emptList);

            SearchController controller = new SearchController();

            // Act
            List<Account> result = controller.Get("python");

            // Assert
            Assert.AreEqual(result, emptList);
        }
    }
}
