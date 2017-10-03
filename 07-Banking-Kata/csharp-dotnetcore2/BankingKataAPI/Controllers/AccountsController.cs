using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Katas
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private AccountsService accountsService;

        public AccountsController(AccountsService accountsService){
            this.accountsService = accountsService;
        }

        // GET api/accounts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/accounts/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return this.accountsService.FindAccount(id);
        }

        // POST api/accounts
        [HttpPost]
        public void Post([FromBody]Money value)
        {
            this.accountsService.OpenNewAccount(value);
        }

        // PUT api/accounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/accounts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
