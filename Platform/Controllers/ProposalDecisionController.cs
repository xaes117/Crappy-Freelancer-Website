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
    public class ProposalDecisionController : ApiController
    {
        private DataManager dataManager;

        // GET api/<controller>/5
        public JObject Get(string jwt)
        {
            try
            {
                List<List<string>> proposals = this.dataManager.Select(this.ViewProposalsQuery(jwt));

                List<Proposal> proposalList = new List<Proposal>();

                foreach (List<string> p in proposals)
                {
                    Proposal proposal = new Proposal(Int32.Parse(p[0]), Int32.Parse(p[1]), p[2], p[3], p[4], p[5], p[6], p[7], p[8]);
                    proposalList.Add(proposal);
                }

                Dictionary<string, List<Proposal>> outList = new Dictionary<string, List<Proposal>>();
                outList.Add(jwt, proposalList);

                return JObject.Parse(JsonConvert.SerializeObject(outList));

            }
            catch (Exception e)
            {
                return JObject.Parse(e.ToString());
            }
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private string ViewProposalsQuery(string jwt)
        {
            return "select                                                          " +
                   "projects.projectid,                                             " +
                   "proposals.proposal_id,                                          " +
                   "projects.project_name,                                          " +
                   "projects.description,                                           " +
                   "users.name,                                                     " +
                   "users.description,                                              " +
                   "users.profile_image_url,                                        " +
                   "proposals.cover_letter,                                         " +
                   "proposals.status                                                " +
                   "from proposals                                                  " +
                   "left join projects on projects.projectid = proposals.project_id " +
                   "left join web_tokens t on t.uid = projects.owner_id             " +
                   "left join users on users.uid = proposals.student_id             " +
                   "where t.jwt = '" + jwt + "';                                    " ;
        }

        public ProposalDecisionController()
        {
            this.dataManager = new DataManager();
        }

        public ProposalDecisionController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}