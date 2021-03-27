using DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class ProjectManagerController : ApiController
    {
        private DataManager dataManager;

        // GET: api/ProjectManager
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProjectManager/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProjectManager
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProjectManager/5
        public string Put(int projectId, string jwt, bool status)
        {
            // consider using JWT to authenticate first
            if (status)
            {
                string updateQuery = "UPDATE `soft7003`.`projects` SET `status` = 'complete' WHERE (`projectid` = '" + projectId + "');";
                this.dataManager.Update(updateQuery);
                return jwt;
            } else
            {
                string updateQuery = "UPDATE `soft7003`.`projects` SET `status` = 'progress' WHERE (`projectid` = '" + projectId + "');";
                this.dataManager.Update(updateQuery);
                return jwt;
            }
        }

        public ProjectManagerController()
        {
            this.dataManager = new DataManager();
        }

        public ProjectManagerController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
