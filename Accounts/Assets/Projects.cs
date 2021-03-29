using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Assets
{
    public class Projects
    {
        public int projectId;
        public int ownerId;
        
        public string businessName;
        public string profileImageUrl;
        public string businessDeescription;
        public string projectTitle;
        public string projectDescription;

        public Projects(string businessName, string profileImageUrl, string businessDeescription, string projectTitle, string projectDescription)
        {
            this.businessName = businessName;
            this.profileImageUrl = AccountManager.TrimHTTPHeader(profileImageUrl);
            this.businessDeescription = businessDeescription;
            this.projectTitle = projectTitle;
            this.projectDescription = projectDescription;
        }

        public Projects(int projectId, int ownerId, string projectTitle, string projectDescription)
        {
            this.projectId = projectId;
            this.ownerId = ownerId;
            this.projectTitle = projectTitle;
            this.projectDescription = projectDescription;
        }
    }
}
