using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Accounts;
using Accounts.Assets;
using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Platform;
using Platform.Controllers;

namespace Platform.Tests.Controllers
{
    [TestClass]
    public class SearchControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                if (query.Contains("mockProjectSearchQuery"))
                {
                    List<string> mockProjectList = new List<string>
                    {
                        "1", "2", "mockProjectName", "mockProjectDescription"
                    };

                    return new List<List<string>>
                    {
                        mockProjectList
                    };
                }

                if (query.Contains("mockAccountSearchQuery"))
                {
                    List<string> mockAccountList = new List<string>
                    {
                        "1", "mockName", "mockDescription", "mockImageUrl"
                    };

                    return new List<List<string>>
                    {
                        mockAccountList
                    };
                }

                return null;
            }
        }

        [TestMethod]
        public void SearchProjectTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            SearchController searchController = new SearchController(mockDataManager);

            //Act
            JObject jsonObject = searchController.Get(SearchController.SearchCategory.Project, "mockProjectSearchQuery");
            string projectTitle = (string) jsonObject["projects"][0]["projectTitle"];
            string projectDescription = (string)jsonObject["projects"][0]["projectDescription"];

            // Assert
            Assert.IsTrue(projectTitle.Contains("mockProjectName"));
            Assert.IsTrue(projectDescription.Contains("mockProjectDescription"));
        }

        [TestMethod]
        public void SearchAccountTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            SearchController searchController = new SearchController(mockDataManager);

            //Act
            JObject jsonObject = searchController.Get(SearchController.SearchCategory.Students, "mockAccountSearchQuery");
            string accountName = (string)jsonObject["students"][0]["name"];
            string accountDescription = (string)jsonObject["students"][0]["description"];

            // Assert
            Assert.IsTrue(accountName.Contains("mockName"));
            Assert.IsTrue(accountDescription.Contains("mockDescription"));
        }
    }
}
