using Accounts;
using Accounts.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Platform.Controllers
{
    public class SearchController : ApiController
    {

        private AccountManager accountManager;

        // GET: api/Search/5
        public List<Account> Get(string searchQuery)
        {
            return this.accountManager.searchByProfile(searchQuery);
        }

        // POST: api/Search
        public void Post([FromBody] string value)
        {
        }

        public SearchController()
        {
            this.accountManager = new AccountManager();
        }

        public SearchController(AccountManager accountManager)
        {
            this.accountManager = accountManager;
        }
    }
}
