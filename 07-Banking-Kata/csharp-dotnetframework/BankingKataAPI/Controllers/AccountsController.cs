using Katas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katas
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private AccountsService accountsService;

        public AccountsController(AccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        // GET api/accounts
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            Account[] accounts = await this.accountsService.retrieveAll();
            var response = accounts.Select(a => new
            {
                id = a.id,
                balanceAmount = a.DbBalance
            });
            return Json(response);
        }

        // GET api/accounts/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(Guid id)
        {
            var account = await this.accountsService.FindAccount(id);
            var response = new
            {
                id = account.id,
                balanceAmount = account.DbBalance
            };
            return Json(response);
        }

        // POST api/accounts
        [HttpPost]
        public void Post([FromBody]decimal balance)
        {
            this.accountsService.OpenNewAccount(balance);
        }

        // PUT api/accounts/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody]decimal amount)
        {
            await this.accountsService.Deposit(id, amount);
        }

        // DELETE api/accounts/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.accountsService.DeleteAccount(id);
        }
    }
}