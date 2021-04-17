using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Assets
{
    public class Proposal
    {
        public int proposalId;
        public int projectId;
        public int studentId;
        public string projectName;
        public string projectDescription;
        public string username;
        public string userDescription;
        public string userProfileImg;
        public string coverLetter;
        public string status;

        public Proposal(int proposalId, int projectId, string projectName, string projectDescription, string username, string userDescription, string userProfileImg, string coverLetter, string status, int studentId)
        {
            this.proposalId = proposalId;
            this.projectId = projectId;
            this.projectName = projectName;
            this.projectDescription = projectDescription;
            this.username = username;
            this.userDescription = userDescription;
            this.userProfileImg = userProfileImg;
            this.coverLetter = coverLetter;
            this.status = status;
            this.studentId = studentId;
        }
    }
}
