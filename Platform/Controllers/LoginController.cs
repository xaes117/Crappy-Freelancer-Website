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
        public string Post(string email, string username, string passHash, bool isRegistration, bool isStudent)
        {
            DataManager dataManager = new DataManager();

            if (isRegistration)
            {
                try
                {
                    string maxUidQuery = "SELECT MAX(uid) FROM soft7003.users;";

                    int uid = Int32.Parse(dataManager.Select(maxUidQuery)[0][0]) + 1;

                    string addUserQuery = "INSERT INTO `soft7003`.`users` (`email`, `uid`, `name`, `acc_type`) " +
                        "VALUES(" +
                        "'" + email + "', " +
                        "'" + uid + "', " +
                        "'" + username + "', " +
                        "'" + (isStudent ? "student" : "business") + "');";

                    string storePassHashQuery = "INSERT INTO `soft7003`.`passwords` (`uid`, `password_hash`) " +
                        "VALUES(" +
                        "'" + uid + "', " +
                        "'" + passHash + "');";

                    dataManager.Insert(addUserQuery);
                    dataManager.Insert(storePassHashQuery);

                    return JwtManager.getWebToken(email);
                } catch (Exception e)
                {
                    return e.ToString();
                }
            } else
            {
                try
                {
                    string query = "select p.password_hash from passwords p, users u where p.uid = u.uid and u.email = '" + email + "';";

                    string passwordHash = dataManager.Select(query)[0][0];

                    if (passHash.Equals(passwordHash))
                    {
                        return JwtManager.getWebToken(email);
                    }

                    return "invalid password or email address";

                } catch (Exception e)
                {
                    return e.ToString();
                }
            }
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
