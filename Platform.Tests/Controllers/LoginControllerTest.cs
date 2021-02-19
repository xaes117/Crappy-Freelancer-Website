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
using DBManager;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {

        [TestMethod]
        public void LoginTest()
        {
            // Arrange
            Mock<DataManager> dataManager = new Mock<DataManager>();
            dataManager.Setup(x => x.userExists("user1")).Returns(true);
            dataManager.Setup(x => x.userExists("user2")).Returns(false);

            LoginController controller = new LoginController(dataManager.Object);

            // Act
            string positiveTest = controller.Post("{'type': 'login', 'user': 'user1', 'password': 'password123@'}");
            string negativeTest = controller.Post("{'type': 'login', 'user': 'user2', 'password': 'password123@'}");

            // Assert
            Assert.AreEqual("OK", positiveTest);
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
            string user1 = controller.Post("{'type': 'register', 'user': 'user1', password: 'password123@'}");
            string user2 = controller.Post("{'type': 'register', 'user': 'user2', password: 'password123@'}");

            // Assert
            Assert.AreEqual("OK", user1);
            Assert.AreNotEqual("OK", user2);
        }
    }
}
