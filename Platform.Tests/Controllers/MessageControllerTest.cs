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
using Accounts.Assets;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                if (query.Contains("select") && query.Contains("from messages"))
                {
                    return new List<List<string>>
                    {
                        new List<string>
                        {
                            "1", "2", "mockMessage", "mockTimestampe"
                        }
                    };
                }

                return null;
            }

            public override void Insert(string query)
            {
                // do nothing
            }
        }

        [TestMethod]
        public void GetMessageTest()
        {
            // Arrange
            MockDataManager dataManager = new MockDataManager();
            MessageController controller = new MessageController(dataManager);
            string mockJwt = "mockJwt";

            // Act
            List<Message> messageList = controller.Get(mockJwt);
            Message firstMessage = messageList[0];

            // Assert
            Assert.AreEqual(firstMessage.getAccount(), 1);
            Assert.AreEqual(firstMessage.getAccount(), 2);
            Assert.IsTrue(firstMessage.getMessage().Equals("mockMessage"));
        }

        [TestMethod]
        public void PostSuccessMessageTest()
        {
            // Arrange
            MockDataManager dataManager = new MockDataManager();
            MessageController controller = new MessageController(dataManager);
            string mockJwt = "mockJwt";

            // Act
            bool isSuccess = controller.Post(mockJwt, 1, 2, "mockMessage");
            
            // Assert
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void PostFailMessageTest()
        {
            // Arrange
            MockDataManager dataManager = new MockDataManager();
            MessageController controller = new MessageController(dataManager);
            string mockJwt = "mockJwt";

            // Act
            bool isSuccess = controller.Post(mockJwt, 1, 1, "mockMessage");

            // Assert
            Assert.IsFalse(isSuccess);
        }
    }
}
