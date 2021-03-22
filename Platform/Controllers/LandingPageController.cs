using Accounts.Assets;
using DBManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Platform.Controllers
{
    public class LandingPageController : ApiController
    {

        private DataManager dataManager;

        // GET api/<controller>/5
        public JObject Get(string jwt)
        {

            string getProfileQuery = "                         " +
                "select users.* from users                     " +
                "left join web_tokens wt on wt.uid = users.uid " +
                "where wt.jwt = '" + jwt + "';                 ";

            try
            {

                List<string> profile = this.dataManager.Select(getProfileQuery)[0];
                string name = profile[1];
                string userDescription = profile[2];
                string accountType = profile[3];
                string profileImageUrl = profile[5];
                
                if (accountType.ToLower().Equals("business"))
                {
                    string getStudentsQuery = 
                    "select                                                     " +
                    "    users.name,                                            " +
                    "    users.profile_image_url,                               " +
                    "    users.description,                                     " +
                    "	avg(reviews.rating) as average_rating                   " +
                    "from users                                                 " +
                    "    left join reviews on reviews.uid_receiver = users.uid  " +
                    "where users.acc_type = 'student'                           " +
                    "group by users.uid;                                        ";

                    return null;

                } else
                {
                    string getProjects = 
                    "select                                           " +
                    "    users.name as 'project owner',               " +
                    "	users.profile_image_url,                      " +
                    "    users.description as 'business description', " +
                    "	projects.project_name,                        " +
                    "    projects.description as 'project description'" +
                    "from projects                                    " +
                    "left join users on users.uid = projects.owner_id;";

                    List<List<string>> projectListFromDB = dataManager.Select(getProjects);
                    List<Projects> projectList = new List<Projects>();

                    foreach (List<string> projectInfo in projectListFromDB)
                    {
                        string projectOwner = projectInfo[0];
                        string profileImage = projectInfo[1];
                        string businessDescription = projectInfo[2];
                        string projectName = projectInfo[3];
                        string projectDescription = projectInfo[4];

                        projectList.Add(new Projects(projectOwner, profileImage, businessDescription, projectName, projectDescription));
                    }

                    Dictionary<string, List<Projects>> outList = new Dictionary<string, List<Projects>>();
                    outList.Add(jwt, projectList);
                    string jsonString = JsonConvert.SerializeObject(outList);

                    return JObject.Parse(jsonString);

                }
            }
            catch (Exception e)
            {
                return JObject.Parse(e.ToString());
            }
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public LandingPageController()
        {
            this.dataManager = new DataManager();
        }

        public LandingPageController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
