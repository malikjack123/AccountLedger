using AccountLedger.Core;
using AccountLedger.Core.ProjectAggregate;
using AccountLedger.Core.ProjectAggregate.Specifications;
using AccountLedger.SharedKernel.Interfaces;
using AccountLedger.Web.ApiModels;
using AccountLedger.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AccountLedger.Web.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly IRepository<Account> _projectRepository;

        public AccountsController(IRepository<Account> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET accounts/{accountId?}
        [HttpGet("{accountId:int}")]
        public async Task<IActionResult> GetAccount(int accountId = 1)
        {
            var spec = new AccountByIdWithItem(accountId);
            // var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new AccountViewModel
            {
                //AccountId = project.Id,
                //AccountTitle = project.AccountName,
                //Items = project.Items
                //            .Select(item => ToDoItemViewModel.FromToDoItem(item))
                //            .ToList()
                AccountId = 5,
                AccountTitle = "Account Payable",

            };
            return Ok(dto);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<AccountViewModel>> CreateAccount([FromBody] AccountViewModel account)
        {
            try
            {
                if (account == null)
                    return BadRequest();

               // var createdAccounte = await _projectRepository.AddAsync(account);

                return Ok(1);
            }
            catch (Exception)
            {
                return StatusCode(500,
                    "Error creating new Account record");
            }
        }

        private object GetEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
