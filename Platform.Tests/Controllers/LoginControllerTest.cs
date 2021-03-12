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

        [TestMethod]
        public void RegisterEmailTest()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            string out1 = controller.Post("@example.com", "username", "sampleHash", true, true);
            string out2 = controller.Post("hello.com", "username", "sampleHash", true, true);
            string out3 = controller.Post("hello@exa@mple.com", "username", "sampleHash", true, true);

            // Assert
            Assert.AreEqual(LoginController.InvalidEmailMessage, out1);
            Assert.AreEqual(LoginController.InvalidEmailMessage, out2);
            Assert.AreEqual(LoginController.InvalidEmailMessage, out3);
        }
    }
}
