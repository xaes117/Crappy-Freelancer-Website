using DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class ProjectController : ApiController
    {
        private DataManager dataManager;

        // GET api/<controller>
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post(string jwt, string projectTitle, string projectDescription)
        {
            string getUidQuery =
            "select                                      " +
            "users.uid,                                  " +
            "users.acc_type                              " +
            "from users                                  " +
            "left join web_tokens t on t.uid = users.uid " +
            "where t.jwt = '" + jwt + "';";

            try
            {
                List<List<string>> data = this.dataManager.Select(getUidQuery);
                string uid = data[0][0];
                string accountType = data[0][1];

                if (accountType.ToLower().Equals("student"))
                {
                    return "students not allowed to post projects";
                }

                // Set project ID
                string maxUidQuery = "SELECT MAX(cast(projectid as unsigned)) FROM soft7003.projects;";
                int projectId = Int32.Parse(this.dataManager.Select(maxUidQuery)[0][0]) + 1;


                try
                {
                    // create insert string
                    string insertQuery = "INSERT INTO `soft7003`.`projects` (`projectid`, `owner_id`, `project_name`, `description`) " +
                    "VALUES (" +
                    "'" + projectId + "'," +
                    " '" + uid + "', " +
                    "'" + projectTitle + "', " +
                    "'" + projectDescription + "');";

                    // attempt insert
                    this.dataManager.Insert(insertQuery);

                    return "{ " +
                        "'jwt' : '" + jwt + "'," +
                        "'message' : 'Successfully created project'," +
                        "'projectId' : '" + projectId + "'" +
                        "}";

                } catch (Exception e)
                {
                    return "failed to insert project into database";
                }

            } catch (Exception e)
            {
                return "could not find project owner";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, string value)
        {
            return value;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public ProjectController()
        {
            this.dataManager = new DataManager();
        }

        public ProjectController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}