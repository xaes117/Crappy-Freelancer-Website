﻿using Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class LoginController : ApiController
    {

        private DataManager dataManager;

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public string Post([FromBody]string value)
        {
            return value;
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
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
