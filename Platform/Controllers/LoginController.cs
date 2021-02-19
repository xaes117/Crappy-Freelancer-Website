using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DBManager;

namespace Platform.Controllers
{
    public class LoginController : ApiController
    {

        private DataManager dataManager;

        // POST: api/Login
        public string Post([FromBody]string value)
        {
            return value;
        }

        public LoginController()
        {
            this.dataManager = new DataManager();
        }

        public LoginController(DataManager manager)
        {
            this.dataManager = manager;
        }
    }
}
