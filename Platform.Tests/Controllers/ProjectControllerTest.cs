using DBManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Platform.Tests.Controllers
{

    [TestClass]
    public class ProjectControllerTest
    {
        private class MockDataManager : DataManager
        {
/*            public override List<List<string>> Select(string query)
            {
                if (query.Contains("mockSuccessfulProject"))
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
                return null;
            }*/
        }

        [TestMethod]
        public void PostProjectTest()
        {

        }

        [TestMethod]
        public void ApplyToProjectTest()
        {

        }
    }
}
