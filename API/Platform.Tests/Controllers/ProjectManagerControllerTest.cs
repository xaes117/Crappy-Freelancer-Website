using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Platform.Controllers;
using System;
using System.Collections.Generic;

namespace Platform.Tests.Controllers
{

    [TestClass]
    public class ProjectManagerControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override void Update(string query)
            {
                // insert nothing
            }
        }

        [TestMethod]
        public void PutInProgressTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProjectManagerController managerController = new ProjectManagerController(mockDataManager);

            string mockJwt = "mockJwt";
            int mockProjectId = 1;
            bool isComplete = true;

            //Act
            string jwt = managerController.Post(mockProjectId, mockJwt, isComplete);

            // Assert
            Assert.IsTrue(jwt.Equals(mockJwt));
        }

        [TestMethod]
        public void PutCompleteTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProjectManagerController managerController = new ProjectManagerController(mockDataManager);

            string mockJwt = "mockJwt";
            int mockProjectId = 1;
            bool isComplete = false;

            //Act
            string jwt = managerController.Post(mockProjectId, mockJwt, isComplete);

            // Assert
            Assert.IsTrue(jwt.Equals(mockJwt));
        }
    }
}
