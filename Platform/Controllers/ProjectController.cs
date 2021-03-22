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