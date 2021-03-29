using Accounts;
using Accounts.Assets;
using DBManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class SearchController : ApiController
    {
        public enum SearchCategory
        {
            Business,
            Students,
            Project
        }

        private DataManager dataManager;

        // GET: api/Search/5
        public JObject Get(SearchCategory searchCategory, string searchQuery)
        {
            if (searchCategory == SearchCategory.Business)
            {
                List<Projects> projectList = this.getProjects(searchQuery);
                return JObject.Parse("{ \"projects\": " + JsonConvert.SerializeObject(projectList) + "}");
            } else if (searchCategory == SearchCategory.Students)
            {
                List<Account> accountList = this.getAccounts(searchQuery, false);
                return JObject.Parse("{ \"students\": " + JsonConvert.SerializeObject(accountList) + "}");
            }
            else if (searchCategory == SearchCategory.Project)
            {
                List<Account> accountList = this.getAccounts(searchQuery, true);
                return JObject.Parse("{ \"businesses\": " + JsonConvert.SerializeObject(accountList) + "}");
            }
            else
            {
                return JObject.Parse("{ \"error\" : \"search term not valid\" }");
            }
        }

        // POST: api/Search
        public void Post([FromBody] string value)
        {
        }

        private List<Projects> getProjects(string searchTerm)
        {
            string getProjectQuery =
            "select p.projectid,                              " +
            "p.owner_id,                                      " +
            "p.project_name,                                  " +
            "p.description                                    " +
            "from projects p                                  " +
            "where (p.status not like 'complete'              " +
            "or p.status is null)                             " +
            "and p.project_name like '%" + searchTerm + "%'; ;";

            List<List<string>> businessListFromDB = this.dataManager.Select(getProjectQuery);
            List<Projects> projectList = new List<Projects>();

            foreach (List<string> a in businessListFromDB)
            {
                string projectId = a[0];
                string ownerId = a[1];
                string projectName = a[2];
                string projectDescription = a[3];

                projectList.Add(new Projects(Int32.Parse(projectId), Int32.Parse(ownerId), projectName, projectDescription));
            }

            return projectList;

        }

        private List<Account> getAccounts(string searchTerm, bool isBusiness)
        {
            string searchQuery =
            "select u.uid,                                                         " +
            "u.name,                                                               " +
            "u.description,                                                        " +
            "u.profile_image_url                                                   " +
            "from users u                                                          " +
            "where u.acc_type like '" + (isBusiness ? "business" : "student") + "' " +
            "and u.description like '%" + searchTerm + "%';                        ";

            List<List<string>> accountListFromDB = this.dataManager.Select(searchQuery);
            List<Account> accountList = new List<Account>();

            foreach (List<string> a in accountListFromDB)
            {
                int uid = Int32.Parse(a[0]);
                string name = a[1];
                string description = a[2];
                string profileImageUrl = a[3];

                accountList.Add(new Account(uid, name, description, profileImageUrl));
            }
            return accountList;
        }

        public SearchController()
        {
            this.dataManager = new DataManager();
        }

        public SearchController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
