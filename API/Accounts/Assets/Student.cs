using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounts.Assets
{
    public class Student : Account
    {
        public Student(string name, string description, string accountType, string profileImageUrl) : base(name, description, accountType, profileImageUrl)
        {

        }
    }
}