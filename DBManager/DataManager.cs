using System;
using System.Collections.Generic;
using Accounts.Assets;
using MySql.Data.MySqlClient;

namespace DBManager
{
    public class DataManager
    {
        public Boolean userExists(string username)
        {
            return false;
        }

        public List<Message> getMessages(Account a, Account b)
        {
            return null;
        }

        public List<Message> getMessages(Account a, Account b, int number)
        {
            return null;
        }
    }
}