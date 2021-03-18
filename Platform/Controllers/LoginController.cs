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
        public readonly static string InvalidEmailMessage = "enter a valid email address";

        private DataManager dataManager;

        // POST: api/Login
        public string Post(string email, string username, string passHash, bool isRegistration, bool isStudent)
        {
            DataManager dataManager = new DataManager();

            // if the user is registering follow this path
            if (isRegistration)
            {
                if (!this.validateEmail(email))
                {
                    return LoginController.InvalidEmailMessage;
                }

                try
                {
                    // MySQL query to get the most recent user id
                    string maxUidQuery = "SELECT MAX(cast(uid as unsigned)) FROM soft7003.users;";

                    // create new unique user id by incrementing latest user id
                    int uid = Int32.Parse(dataManager.Select(maxUidQuery)[0][0]) + 1;

                    // create string to insert new user into users table
                    string addUserQuery = "INSERT INTO `soft7003`.`users` (`email`, `uid`, `name`, `acc_type`) " +
                        "VALUES(" +
                        "'" + email + "', " +
                        "'" + uid + "', " +
                        "'" + username + "', " +
                        "'" + (isStudent ? "student" : "business") + "');";

                    // create string to store the password hash
                    string storePassHashQuery = "INSERT INTO `soft7003`.`passwords` (`uid`, `password_hash`) " +
                        "VALUES(" +
                        "'" + uid + "', " +
                        "'" + passHash + "');";

                    // insert data into database
                    dataManager.Insert(addUserQuery);
                    dataManager.Insert(storePassHashQuery);

                    // return web token 
                    return JwtManager.getWebToken(email);
                } catch (Exception e)
                {
                    return e.ToString();
                }
            } else
            {
                try
                {
                    // query to retrieve password hash from database
                    string query = "select p.password_hash from passwords p, users u where p.uid = u.uid and u.email = '" + email + "';";

                    // execute query and get password hash from database
                    string passwordHash = dataManager.Select(query)[0][0];

                    // if the password hashes match then return a web token
                    if (passHash.Equals(passwordHash))
                    {
                        return JwtManager.getWebToken(email);
                    }

                    // return invalid response otherwise
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

        private bool validateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
