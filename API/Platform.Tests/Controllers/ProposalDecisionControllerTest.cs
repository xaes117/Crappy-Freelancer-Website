using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Platform.Controllers;
using System;
using System.Collections.Generic;

namespace Platform.Tests.Controllers
{

    [TestClass]
    public class ProposalDecisionControllerTest
    {
        private class MockDataManager : DataManager
        {
            public override List<List<string>> Select(string query)
            {
                if (query.Contains("mockGetJwt"))
                {
                    List<string> mockList = new List<string>
                    {
                        "1", "2", "mockProjectName", "mockProjectDescription", "mockUsername", 
                        "mockUserDescription", "mockProfileImage",
                        "mockCoverLetter", "accepted", "1", "1"
                    };

                    return new List<List<string>>
                    {
                        mockList
                    };
                }

                if (query.Contains("mockPutJwt"))
                {
                    return new List<List<string>>
                    {
                        new List<string>(), new List<string>()
                    };
                }

                return null;
            }

            public override void Update(string query)
            {
                // insert nothing
            }
        }

        [TestMethod]
        public void GetProposalSuccessTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProposalDecisionController decisionController = new ProposalDecisionController(mockDataManager);

            string mockJwt = "mockGetJwt";

            //Act
            JObject mockObject = decisionController.Get(mockJwt);
            string projectName = (string) mockObject["proposalList"][0]["projectName"];

            // Assert
            Assert.IsTrue(projectName.Equals("mockProjectName"));
        }

        [TestMethod]
        public void UpdateProposalSuccessTest()
        {
            // Arrange
            MockDataManager mockDataManager = new MockDataManager();
            ProposalDecisionController decisionController = new ProposalDecisionController(mockDataManager);

            string mockPutJwt = "mockPutJwt";
            int mockId = 1;
            bool acceptProposal = false;

            //Act
            string jsonObject = decisionController.PostDecision(mockPutJwt, mockId, acceptProposal);

            // Assert
            Assert.IsTrue(jsonObject.Contains("'OK'"));
        }

        [TestMethod]
        public void ApplyToProjectTest()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
