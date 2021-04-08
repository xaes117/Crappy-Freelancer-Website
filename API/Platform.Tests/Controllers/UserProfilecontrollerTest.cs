using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Platform.Controllers;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class UserProfileTest
    {

        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                if (query.Contains("mockStudentJwt"))
                {
                    List<string> mockStudentProfile = new List<string>
                    {
                        "1", "name", "deescription", "student", "example@email.com", "imageUrl"
                    };

                    return new List<List<string>>
                    {
                        mockStudentProfile
                    };
                }

                if (query.Contains("mockBusinessJwt"))
                {
                    List<string> mockBusinessProfile = new List<string>
                    {
                        "1", "name", "deescription", "business", "example@email.com", "imageUrl"
                    };

                    return new List<List<string>>
                    {
                        mockBusinessProfile
                    };
                }

                return null;
            }
        }

        [TestMethod]
        public void GetStudentProfileTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            UserProfileController userProfileController = new UserProfileController(mockDataManager);

            // Act
            JObject userProfile = userProfileController.Get("mockStudentJwt");

            // Assert
            Assert.AreEqual("student", userProfile["mockStudentJwt"]["accountType"]);
        }

        [TestMethod]
        public void GetBusinessProfileTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            UserProfileController userProfileController = new UserProfileController(mockDataManager);

            // Act
            JObject userProfile = userProfileController.Get("mockBusinessJwt");

            // Assert
            Assert.AreEqual("business", userProfile["mockBusinessJwt"]["accountType"]);
        }
    }
}
