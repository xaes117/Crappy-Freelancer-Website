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
                // get proposals
                List<List<string>> proposals = this.dataManager.Select(this.ViewProposalsQuery(jwt));

                // create proposal list
                List<Proposal> proposalList = new List<Proposal>();

                // iterate through each proposal and add to list
                foreach (List<string> p in proposals)
                {
                    Proposal proposal = new Proposal(Int32.Parse(p[0]), Int32.Parse(p[1]), p[2], p[3], p[4], p[5], p[6], p[7], p[8]);
                    proposalList.Add(proposal);
                }

                // create output structure
                Dictionary<string, List<Proposal>> outList = new Dictionary<string, List<Proposal>>();
                outList.Add(jwt, proposalList);

                // return json object
                return JObject.Parse(JsonConvert.SerializeObject(outList));

            }
            catch (Exception e)
            {
                return JObject.Parse(e.ToString());
            }
        }

        // POST api/<controller>
        public void Post(int proposalId, bool acceptProposal)
        {
            
        }

        // PUT api/<controller>/5
        public string Put(string jwt, int proposalId, bool acceptProposal)
        {
            try
            {
                // try to get the exact record
                List<List<string>> verify = this.dataManager.Select(this.VerifyQuery(jwt, proposalId));

                // check if record is null or empty
                // as it would imply the proposal belongs to someone else
                if (verify is null || verify.Count == 0)
                {
                    throw new NullReferenceException("Cannot update proposal that is not yours");
                }   

                // update the proposal if the record can be verified
                this.dataManager.Update(this.UpdateProposalQuery(proposalId, acceptProposal));

                // return json string
                return "{"                               +
                            "'jwt' : '" + jwt + "',"     +
                            "'message' : 'OK'"           +
                        "}";
            }
            catch (NullReferenceException e)
            {
                return e.ToString();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private string VerifyQuery(string jwt , int proposalId)
        {
            return "select                                                           " +
                   "proposals.proposal_id,                                           " +
                   "t.jwt                                                            " +
                   "from proposals                                                   " +
                   "left join projects on projects.projectid = proposals.project_id  " +
                   "left join web_tokens t on t.uid = projects.owner_id              " +
                   "where t.jwt = '" + jwt + "'                                      " +
                   "and proposal_id = " + proposalId + ";                            "; 
        }

        private string UpdateProposalQuery(int proposalId, bool isAccepted)
        {
            if (isAccepted)
            {
                return "UPDATE `soft7003`.`proposals` SET `status` = 'accepted' WHERE (`proposal_id` = '" + proposalId + "');";
            } else
            {
                return "UPDATE `soft7003`.`proposals` SET `status` = 'rejected' WHERE (`proposal_id` = '" + proposalId + "');";
            }
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