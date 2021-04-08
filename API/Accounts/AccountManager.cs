using Accounts.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounts
{
    public class AccountManager
    {

        private List<Account> accountList;

        public List<Account> searchByProfile(string query)
        {
            return new List<Account>();
        }

        public static string TrimHTTPHeader(string url)
        {
            if (url.Length < 5)
            {
                return url;
            }

            if (url.Substring(0, 5).ToLower().Equals("https"))
            {
                return url.Substring(5 + 3);
            }

            if (url.Substring(0, 4).ToLower().Equals("http"))
            {
                return url.Substring(4 + 3);
            }

            return url;
        }
    }
}