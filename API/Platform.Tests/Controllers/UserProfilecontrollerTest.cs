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
                        "name", "deescription", "student", "imageUrl"
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
                        "name", "deescription", "business", "imageUrl"
                    };

                    return new List<List<string>>
                    {
                        mockBusinessProfile
                    };
                }

                return null;
            }

            public override void Insert(string query)
            {
                
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

        [TestMethod]
        public void PostupdateTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            UserProfileController userProfileController = new UserProfileController(mockDataManager);

            Exception exception = null;

            // Act
            try
            {
                userProfileController.Post("mockJwt", "mockUsername", "mockDescription");
            } catch (Exception e)
            {
                exception = e;
            } finally
            {
                // Assert
                Assert.IsNull(exception);
            }
        }
    }
}
