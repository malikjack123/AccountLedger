using AccountLedger.Core.ProjectAggregate;
using AccountLedger.Core.ProjectAggregate.Specifications;
using AccountLedger.Infrastructure.Data;
using AccountLedger.SharedKernel.Interfaces;
using AccountLedger.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountLedger.Web.Api
{
    /// <summary>
    /// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
    /// https://github.com/ardalis/ApiEndpoints
    /// </summary>
    public class AccountController : BaseApiController
    {
        private readonly IRepository<LedgerAccount> _repository;

        public AccountController(IRepository<LedgerAccount> repository)
        {
            _repository = repository;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reqDTOs = (await _repository.ListAsync())
                .Select(request => new LedgerAccountDTO
                {
                    Id = request.Id,
                    Owner = request.Owner,
                    AccountNumber = request.AccountNumber,
                    Balance = request.AvailableBalance 
                })
                .ToList();

            return Ok(reqDTOs);
        }

        // GET: api/Account
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var projectSpec = new AccountByIdSpec(id);
            var request = await _repository.GetBySpecAsync(projectSpec);

            var result = new LedgerAccountDTO
            {
                Id = request.Id,
                Owner = request.Owner,
                AccountNumber = request.AccountNumber,
                Balance = request.AvailableBalance,
                Items = request.Items.Select(x => new AccountTransactionDTO()
                {
                    AccountNumber = request.AccountNumber,
                    Amount = x.Amount,
                    TransType = x.TransType.ToString(),
                    Notes = x.Notes,
                    TransDate = x.TransDate
                }).ToList()
            };

            return Ok(result);
        }

        // POST: api/CreateAccount
        [HttpPost("/CreateAccount")]
        public async Task<IActionResult> Post([FromBody] LedgerAccountDTO request)
        {
            var newAccount = new LedgerAccount(request.AccountNumber, request.Owner, request.Balance);
            //var newAccount = new LedgerAccount
            //{
            //    AccountNumber = request.AccountNumber,
            //    Owner = request.Owner,
            //    Balance = request.Balance
            //}; 

            var createdAccount = await _repository.AddAsync(newAccount);
            var result = new LedgerAccountDTO
            {
                Id = createdAccount.Id,
                Owner = createdAccount.Owner,
                AccountNumber = createdAccount.AccountNumber,
                Balance = createdAccount.Balance
            };
            return Ok(result);
        }

        // POST: api/MakeDeposit
        [HttpPost("/MakeTransaction")]
        public async Task<IActionResult> MakeTransaction([FromBody] AccountTransaction request)
        {
            var accountSpec = new AccountByNumberSpec(request.AccountNumber);
            var account = await _repository.GetBySpecAsync(accountSpec);
            if (account == null) return NotFound("No such Account exists");

            var itemTransactions = new AccountTransaction(request.Notes, request.Amount, account.AccountNumber);
            if (request.TransType == TransactionStatus.Credit)
            {
                account.MakeDeposit(itemTransactions);
            }
            else
            {
                account.MakeWithdrawal(itemTransactions);
            }

            await _repository.UpdateAsync(account);
            await _repository.SaveChangesAsync();
            return Ok("Success");
        }

    }
}
