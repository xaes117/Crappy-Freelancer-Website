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
        public string rating;
        public string description;

        public Review(string reviewer, string rating, string description)
        {
            this.reviewer = reviewer;
            this.rating = rating;
            this.description = description;
        }
    }
}