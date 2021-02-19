using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManager.Assets
{
    public abstract class Account
    {
        protected List<Review> reviewList;
        protected List<Message> messageList;
    }
}