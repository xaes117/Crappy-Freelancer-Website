
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
    public class MessageController : ApiController
    {
        private DataManager dataManager;

        // GET: api/Message/5
        public JObject Get(string jwt)
        {
            // return last N messages

            string query = "select                                                                       " +
                           "uid_sender,                                                                  " +
                           "uid_receiver,                                                                " +
                           "(select users.name from users where uid = uid_sender) as sender_name,        " +
                           "(select users.name from users where uid = uid_receiver) as receiver_name,    " +                                       
                           "messages.datetime,                                                           " +
                           "messages.message                                                             " +
                           "from messages                                                                " +
                           "left join web_tokens wt_sent on wt_sent.uid = messages.uid_sender            " +
                           "left join web_tokens wt_received on wt_received.uid = messages.uid_receiver  " +
                           "where wt_sent.jwt = '" + jwt + "'                                            " +
                           "or wt_received.jwt = '" + jwt + "'                                           " +
                           "order by messages.datetime desc;                                             ";

            List<List<string>> messageListFromDB = this.dataManager.Select(query);

            List<Message> messageList = new List<Message>();

            foreach (List<string> m in messageListFromDB) 
            {
                int sender_id = Int32.Parse(m[0]);
                int receiver_id = Int32.Parse(m[1]);
                string sender_name = m[2];
                string receiver_name = m[3];
                string dateTime = m[4];
                string message = m[5];

                messageList.Add(new Message(sender_id, receiver_id, sender_name, receiver_name, message, dateTime));
            }

            return JObject.Parse("{ \"messages\": " + JsonConvert.SerializeObject(messageList) + "}"); 
        }

        // POST: api/Message
        public Boolean Post(string jwt, int receiver, string message)
        {
            string query = "INSERT INTO `soft7003`.`messages` (`uid_sender`, `uid_receiver`, `datetime`, `message`) " +
                           "VALUES(                                                                                 " +
                           "(                                                                                       " +
                           "    select uid from web_tokens wt where wt.jwt = '" + jwt + "'                          " +
                           "), '" + receiver + "', now(), '" + message + "'); ";

            this.dataManager.Insert(query);

            return true;
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
