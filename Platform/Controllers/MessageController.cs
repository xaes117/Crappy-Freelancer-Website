
using Accounts.Assets;
using DBManager;
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
        private DataManager dataManager;

        // GET: api/Message/5
        public List<Message> Get(string jwt)
        {
            // return last N messages
            return null; 
        }

        // POST: api/Message
        public Boolean Post(string jwt, int sender, int receiver, string message)
        {
            return false;
        }

        public MessageController()
        {
            this.dataManager= new DataManager();
        }

        public MessageController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
