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
        public string Post(string user, string passHash, bool isRegistration, bool isStudent)
        {
            DataManager dataManager = new DataManager();

            if (isRegistration)
            {
                string maxUidQuery = "SELECT MAX(uid) FROM soft7003.users;";

                int uid = Int32.Parse(dataManager.Select(maxUidQuery)[0][0]) + 1;

                string addUserQuery = "INSERT INTO `soft7003`.`users` (`uid`, `name`, `acc_type`) " +
                    "VALUES(" +
                    "'" + uid + "', " +
                    "'" + user + "', " +
                    "'" + (isStudent ? "student" : "business") + "');";
                string storePassHashQuery = "INSERT INTO `soft7003`.`passwords` (`uid`, `password_hash`) " +
                    "VALUES(" +
                    "'" + uid + "', " +
                    "'" + passHash + "');";

                dataManager.Insert(addUserQuery);
                dataManager.Insert(storePassHashQuery);

            }
            return user + passHash;
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
