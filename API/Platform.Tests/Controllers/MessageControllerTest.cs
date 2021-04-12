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
using Newtonsoft.Json.Linq;

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
                            "1", "2", "mockSender", "mockReceiveer",
                            "mockTimestampe", "mockMessage"
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
            JObject messageList = controller.Get(mockJwt);
            string jsonString = messageList.ToString(Newtonsoft.Json.Formatting.None);

            // Assert
            Assert.IsTrue(jsonString.Contains("mockSender"));
            Assert.IsTrue(jsonString.Contains("mockReceiveer"));
            Assert.IsTrue(jsonString.Contains("mockTimestampe"));
            Assert.IsTrue(jsonString.Contains("mockMessage"));
        }

        [TestMethod]
        public void PostSuccessMessageTest()
        {
            // Arrange
            MockDataManager dataManager = new MockDataManager();
            MessageController controller = new MessageController(dataManager);
            string mockJwt = "mockJwt";

            // Act
            bool isSuccess = controller.Post(mockJwt, 1, "mockMessage");
            
            // Assert
            Assert.IsTrue(isSuccess);
        }
    }
}
