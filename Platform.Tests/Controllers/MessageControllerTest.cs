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
        public void Get()
        {
            // Arrange
            MessageController controller = new MessageController();

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
            MessageController controller = new MessageController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
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

        [TestMethod]
        public void Put()
        {
            // Arrange
            MessageController controller = new MessageController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            MessageController controller = new MessageController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
