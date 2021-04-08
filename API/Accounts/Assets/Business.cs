using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounts.Assets
{
    public class Business : Account
    {
        public Business(string name, string description, string accountType, string profileImageUrl) : base(name, description, accountType, profileImageUrl)
        {

        }
    }
}