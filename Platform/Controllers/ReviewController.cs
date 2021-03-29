using Accounts.Assets;
using DBManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class ReviewController : ApiController
    {

        private DataManager dataManager;

        // GET api/<controller>/5
        public JObject Get(string jwt)
        {
            // create return object
            Dictionary<string, Object> retObject = new Dictionary<string, Object>();
            
            // add jwt
            retObject.Add("jwt", jwt);
            
            // add reviews
            retObject.Add("reviews", this.getReviews(jwt));
            
            // return as Json 
            return JObject.Parse(JsonConvert.SerializeObject(retObject));
        }

        // POST api/<controller>
        public string Post(int review_giver, int review_receiver, int rating, string reviewDescription)
        {
            try
            {
                // call function to insert new review
                this.insertReview(review_giver, review_receiver, rating, reviewDescription);
                return "review successfully created";
            } catch (Exception e)
            {
                return "review not successful";
            }
        }

        private List<Review> getReviews(string jwt)
        {
            string selectQuery = 
            "select                                                          " +
            "reviewer.name as 'review_giver',                                " +
            "r.rating,                                                       " +
            "r.description                                                   " +
            "from reviews r                                                  " +
            "left join web_tokens wt on wt.uid = r.uid_receiver              " +
            "left join users reviewer on r.uid_reviewer = reviewer.uid       " +
            "where wt.jwt = '" + jwt + "';                                   ";

            List<List<string>> reviewListFromDB = this.dataManager.Select(selectQuery);
            List<Review> reviewList = new List<Review>();

            foreach (List<string> r in reviewListFromDB)
            {
                string reviewer = r[0];
                string rating = r[1];
                string description = r[2];

                reviewList.Add(new Review(reviewer, rating, description));
            }

            return reviewList;

        }

        private void insertReview(int review_giver, int review_reveiver, int rating, string reviewDescription)
        {
            string insertQuery = "INSERT INTO `soft7003`.`reviews` (`uid_reviewer`, `uid_receiver`, `rating`, `description`) " +
                "VALUES (" +
                "'" + review_giver + "', " +
                "'" + review_reveiver + "', " +
                "'" + rating + "', " +
                "'" + reviewDescription + "');";

            this.dataManager.Insert(insertQuery);
        }

        public ReviewController()
        {
            this.dataManager = new DataManager();
        }

        public ReviewController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}