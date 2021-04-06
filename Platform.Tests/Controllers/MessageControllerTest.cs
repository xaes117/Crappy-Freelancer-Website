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

        [TestMethod]
        public void GetMessageTest()
        {
/*            List<Message> messages = new List<Message>();

            // Arrange
            Mock<DataManager> dataManager = new Mock<DataManager>();
            dataManager.Setup(x => x.getMessages(It.IsAny<Account>(),It.IsAny<Account>())).Returns(messages);
            
            MessageController controller = new MessageController(dataManager.Object);

            // Act
            List<Message> messageList = controller.Get("21343-10391-5");

            // Assert
            Assert.AreEqual(messageList, messages);*/
        }

        [TestMethod]
        public void MessageTest()
        {
            // Arrange
            MessageController controller = new MessageController();

            // Act
            Boolean xss = controller.Post("<script>");
            Boolean sql1 = controller.Post("DROP TABLE table_name;");
            Boolean sql2 = controller.Post("SELECT * FROM table_name;");

            // Assert
            Assert.IsFalse(xss);
            Assert.IsFalse(sql1);
            Assert.IsFalse(sql2);
        }
    }
}
