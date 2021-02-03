using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;
using Platform.Controllers;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTest
    {
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
