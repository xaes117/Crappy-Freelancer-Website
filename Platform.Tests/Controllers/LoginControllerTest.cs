using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;
using Platform.Controllers;
using Moq;
using Platform.Models;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string positiveTest = controller.Post("{'type': 'login', 'user': 'username', 'password': 'password'}");    

            // Assert
            Assert.AreEqual("OK", positiveTest);
        }

        [TestMethod]
        public void LoginNegative()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string negativeTest = controller.Post("{'type': 'login', 'user': 'username'}");

            // Assert
            Assert.AreNotEqual("OK", negativeTest);
        }

        [TestMethod]
        public void RegisterPasswordTest()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string out1 = controller.Post("{'type': 'register', 'user': 'username', password: 'password'}");
            string out2 = controller.Post("{'type': 'register', 'user': 'username', password: 'password123'}");
            string out3 = controller.Post("{'type': 'register', 'user': 'username', password: 'password@'}");
            string out4 = controller.Post("{'type': 'register', 'user': 'username', password: 'passwo'}");

            // Assert
            Assert.AreNotEqual("OK", out1);
            Assert.AreNotEqual("OK", out2);
            Assert.AreNotEqual("OK", out3);
            Assert.AreNotEqual("OK", out4);
        }

        [TestMethod]
        public void RegisterUserTest()
        {
            // Arrange
            Mock<DataManager> dataManager = new Mock<DataManager>();
            dataManager.Setup(x => x.userExists("user1")).Returns(true);
            dataManager.Setup(x => x.userExists("user2")).Returns(false);

            LoginController controller = new LoginController(dataManager.Object);

            // Act
            string user1 = controller.Post("{'type': 'register', 'user1': 'username', password: 'password123@'}");
            string user2 = controller.Post("{'type': 'register', 'user2': 'username', password: 'password123@'}");

            // Assert
            Assert.AreEqual("OK", user1);
            Assert.AreNotEqual("OK", user2);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
