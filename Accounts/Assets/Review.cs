using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accounts.Assets
{
    public class Review
    {
        // made public as private may affect object to json conversion
        public string reviewer;
        public string receiver;
        public string rating;
        public string description;

        public Review(string reviewer, string receiver, string rating, string description)
        {
            this.reviewer = reviewer;
            this.receiver = receiver;
            this.rating = rating;
            this.description = description;
        }
    }
}