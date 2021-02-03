using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public Boolean Post([FromBody]string value)
        {
            return false;
        }
    }
}
