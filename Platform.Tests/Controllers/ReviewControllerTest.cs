using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Platform.Controllers;
using System;
using System.Collections.Generic;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class ReviewControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                // return an arbitary review
                if (query.Contains("from reviews"))
                {
                    return new List<List<string>>
                    {
                        new List<string> {
                            "mockReviewer", "5", "mockDescription"
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
        public void GetReviewTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ReviewController pageController = new ReviewController(mockDataManager);

            string mockJwt = "mockJwt";

            // Act 
            JObject jsonObject = pageController.Get(mockJwt);
            string jwt = (string)jsonObject["jwt"];

            // Assert
            Assert.IsTrue(jwt.Equals(mockJwt));
        }

        [TestMethod]
        public void PostReviewSuccessTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ReviewController pageController = new ReviewController(mockDataManager);

            int reviewGiver = 1;
            int reviewReceiver = 2;
            int rating = 5;
            string reviewDescription = "mockDescription";


            // Act 
            string message = pageController.Post(reviewGiver, reviewReceiver, rating, reviewDescription);

            // Assert
            Assert.IsTrue(message.Contains("successfully created"));
        }

        [TestMethod]
        public void PostReviewFailTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ReviewController pageController = new ReviewController(mockDataManager);

            int reviewGiver = -11;
            int reviewReceiver = 2;
            int rating = 5;
            string reviewDescription = "mockDescription";


            // Act 
            string message = pageController.Post(reviewGiver, reviewReceiver, rating, reviewDescription);

            // Assert
            Assert.IsTrue(message.Contains("Cannot have negative ids"));
        }
    }
}
