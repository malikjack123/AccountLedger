using AccountLedger.Core.ProjectAggregate;
using AccountLedger.Core.ProjectAggregate.Specifications;
using AccountLedger.SharedKernel.Interfaces;
using AccountLedger.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccountLedger.Web.Pages.TrackAccount
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<LedgerAccount> _repository;

        private readonly HttpClient _client;

        public IndexModel(IRepository<LedgerAccount> repository)
        {
            _repository = repository;
        }
       

        public async Task OnGetAsync()
        {

            var aaaa = "";
            //var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            //var project = await _repository.GetBySpecAsync(projectSpec);

            //if (project == null)
            //{
            //    Message = "No project found.";
            //    return;
            //}

            //Project = new ProjectDTO
            //{
            //    Id = project.Id,
            //    Name = project.Name,
            //    Items = project.Items
            //    .Select(item => ToDoItemDTO.FromToDoItem(item))
            //    .ToList()
            //};
        }
    }
}
