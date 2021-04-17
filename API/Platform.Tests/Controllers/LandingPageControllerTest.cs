using System.Collections.Generic;
using System.Web.Mvc;
using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Platform;
using Platform.Controllers;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class LandingPageControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                if (query.Contains("mockBusinessJwt") && query.Contains("from users"))
                {
                    return new List<List<string>>
                    {
                        new List<string> {
                            "businessName", "businessDescription", "business", "imageUrl", "1"
                        }
                    };
                }

                if (query.Contains("mockStudentJwt") && query.Contains("from users"))
                {
                    return new List<List<string>>
                    {
                        new List<string> {
                            "studentName", "studentDescription", "student", "imageUrl", "1"
                        }
                    };
                }

                if (query.Contains("from projects"))
                {
                    return new List<List<string>>
                    {
                        new List<string> {
                            "projectOwner", "imageUrl", "businessDescription", "projectName", "projectDescription", "pending", "1", "2"
                        }
                    };
                }

                return null;
            }
        }

        [TestMethod]
        public void GetLandingPageAsBusinessTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            LandingPageController pageController = new LandingPageController(mockDataManager);

            string jwt = "mockBusinessJwt";

            // Act
            JObject jsonObject = pageController.Get(jwt);
            string returnedJwt = (string)jsonObject["jwt"];

            // Assert
            Assert.IsTrue(returnedJwt.Equals(jwt));

        }

        [TestMethod]
        public void GetLandingPageAsStudentTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            LandingPageController pageController = new LandingPageController(mockDataManager);

            string jwt = "mockStudentJwt";

            // Act
            JObject jsonObject = pageController.Get(jwt);
            string returnedJwt = (string)jsonObject["jwt"];

            // Assert
            Assert.IsTrue(returnedJwt.Equals(jwt));

        }
    }
}
