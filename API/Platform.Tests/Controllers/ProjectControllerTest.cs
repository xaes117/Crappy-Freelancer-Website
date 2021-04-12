using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform.Controllers;
using System;
using System.Collections.Generic;

namespace Platform.Tests.Controllers
{

    [TestClass]
    public class ProjectControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                if (query.Contains("mockPostJwt") || query.Contains("mockPutJwt"))
                {
                    List<string> mockList = new List<string>
                    {
                        "1", "business"
                    };

                    return new List<List<string>>
                    {
                        mockList
                    };
                }

                if (query.Contains("mockFailPostJwt"))
                {
                    List<string> mockList = new List<string>
                    {
                        "-1", "business"
                    };

                    return new List<List<string>>
                    {
                        mockList
                    };
                }

                if (query.Contains("SELECT MAX(cast(projectid as unsigned))"))
                {
                    return new List<List<string>>
                    {
                        new List<string>
                        {
                            "1"
                        }
                    };
                }

                if (query.ToLower().Contains("select") && query.ToLower().Contains("from projects"))
                {
                    return new List<List<string>>
                    {
                        new List<string>
                        {
                            "1", "mockProjectName", "mockProjectDescription", "1",
                            "mockBusinessName", "mockBusinessDescription", "4.0"
                        }
                    };
                }

                return null;
            }

            public override void Insert(string query)
            {
                // insert nothing
            }
        }

        [TestMethod]
        public void GetProjectTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProjectController projectController = new ProjectController(mockDataManager);

            Dictionary<string, string> jsonString = projectController.Get(1);

            Assert.IsTrue(jsonString["projectName"].Contains("mockProjectName"));
            Assert.IsTrue(jsonString["businessName"].Contains("mockBusinessName"));

            bool errorDetected = false;

            try
            {
                Dictionary<string, string> exceptionString = projectController.Get(2);
            }
            catch (Exception)
            {
                errorDetected = true;
            }
            finally
            {
                Assert.IsTrue(errorDetected);
            }
        }

        [TestMethod]
        public void PostProjectSuccessTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProjectController projectController = new ProjectController(mockDataManager);

            string mockJwt = "mockPostJwt";
            string mockProjectTitle = "mockProjectTitle";
            string mockProjectDescription = "mockProjectDescription";

            //Act
            string mockObject = projectController.Post(mockJwt, mockProjectTitle, mockProjectDescription);

            // Assert
            Assert.IsTrue(mockObject.Contains(mockJwt));
            Assert.IsTrue(mockObject.Contains("Successfully created project"));
        }

        [TestMethod]
        public void PostProjectFailTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProjectController projectController = new ProjectController(mockDataManager);

            string mockJwt = "mockFailPostJwt";
            string mockProjectTitle = "mockProjectTitle";
            string mockProjectDescription = "mockProjectDescription";

            //Act
            string mockObject = projectController.Post(mockJwt, mockProjectTitle, mockProjectDescription);

            // Assert
            Assert.IsTrue(mockObject.Contains("could not find project owner"));
        }

        [TestMethod]
        public void ApplyToProjectTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProjectController projectController = new ProjectController(mockDataManager);

            int mockId = 10;
            string mockJwt = "mockPutJwt";
            string mockCoverLetter = "mockCoverLetter";

            // Act
            string mockObject = projectController.PostProposal(mockId, mockJwt, mockCoverLetter);

            // Assert
            Assert.IsTrue(mockObject.Contains("'message' : 'success'"));
            Assert.IsTrue(mockObject.Contains(mockJwt));
        }
    }
}
