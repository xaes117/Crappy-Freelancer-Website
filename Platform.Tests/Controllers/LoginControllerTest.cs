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
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                // Arrange
                string mockHash = "gh942gh20983uf02";

                // Create mock hash data structure
                List<List<string>> mockReturnStructure = new List<List<string>>();
                List<string> mockHashList = new List<string>();
                mockHashList.Add(mockHash);
                mockReturnStructure.Add(mockHashList);

                return mockReturnStructure;
            }
        }

        [TestMethod]
        public void LoginTest()
        {
            MockDataManager mockDataManager = new MockDataManager();

            // Other mock variables
            string mockEmail = "hello@example.com";
            string mockQuery = "select p.password_hash from passwords p, users u where p.uid = u.uid and u.email = '" + mockEmail + "';";

            // Set up mock return
            LoginController controller = new LoginController(mockDataManager);

            // Act
            string negativeTest = controller.Post(mockEmail, "username", "incorrect password hash", false, true);

            // Assert
            Assert.AreEqual("invalid password or email address", negativeTest);
        }


        /*
        [TestMethod]
        public void RegisterPasswordTest()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string out1 = controller.Post("{'type': 'register', 'user@email.com': 'username', password: 'password'}");
            string out2 = controller.Post("{'type': 'register', 'user@email.com': 'username', password: 'password123'}");
            string out3 = controller.Post("{'type': 'register', 'user@email.com': 'username', password: 'password@'}");
            string out4 = controller.Post("{'type': 'register', 'user@email.com': 'username', password: 'passwo'}");

            // Assert
            Assert.AreNotEqual("OK", out1);
            Assert.AreNotEqual("OK", out2);
            Assert.AreNotEqual("OK", out3);
            Assert.AreNotEqual("OK", out4);
        }

        [TestMethod]
        public void RegisterEmailTest()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string out1 = controller.Post("{'type': 'register', 'user': 'invalidEmailFormat', password: 'password'}");
            string out2 = controller.Post("{'type': 'register', 'user': 'invalid@emailFormat', password: 'password123'}");
            string out3 = controller.Post("{'type': 'register', 'user': 'valid@email.format', password: 'passwo'}");

            // Assert
            Assert.AreNotEqual("OK", out1);
            Assert.AreNotEqual("OK", out2);
            Assert.AreEqual("OK", out3);
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
            string user1 = controller.Post("{'type': 'register', 'user@email.com': 'user1', password: 'password123@'}");
            string user2 = controller.Post("{'type': 'register', 'user@email.com': 'user2', password: 'password123@'}");

            // Assert
            Assert.AreEqual("OK", user1);
            Assert.AreNotEqual("OK", user2);
        }
        */
    }
}
