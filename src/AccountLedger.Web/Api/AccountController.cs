using AccountLedger.Core.ProjectAggregate;
using AccountLedger.Core.ProjectAggregate.Specifications;
using AccountLedger.SharedKernel.Interfaces;
using AccountLedger.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepository<Account> _repository;

        public AccountController(IRepository<Account> repository)
        {
            _repository = repository;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projectDTOs = (await _repository.ListAsync())
                .Select(project => new AccountDTO
                {
                    Id = project.Id,
                    Name = project.AccountName
                })
                .ToList();

            return Ok(projectDTOs);
        }

        // GET: api/Account
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var projectSpec = new AccountByIdWithItem(id);
            //var project = await _repository.GetBySpecAsync(projectSpec);

            //var result = new ProjectDTO
            //{
            //    Id = project.Id,
            //    Name = project.Name,
            //    Items = new List<ToDoItemDTO>
            //    (
            //        project.Items.Select(i => ToDoItemDTO.FromToDoItem(i)).ToList()
            //    )
            //};

            return Ok(5);
        }

        // POST: api/Account
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectDTO request)
        {
            // var newProject = new Account(request.Name);

            //var createdProject = await _repository.AddAsync(newProject);

            //var result = new ProjectDTO
            //{
            //    Id = createdProject.Id,
            //    Name = createdProject.Name
            //};
            //return Ok(result);

            return Ok();
        }

       
    }
}
