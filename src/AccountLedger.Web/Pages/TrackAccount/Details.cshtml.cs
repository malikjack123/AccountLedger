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
    public class DetailsModel : PageModel
    {
        private readonly IRepository<LedgerAccount> _repository;

        private readonly HttpClient _client;

        public DetailsModel(IRepository<LedgerAccount> repository)
        {
            _repository = repository;
        }
        public async Task OnGetAsync()
        {

            var aaaa = "";
            

        }
    }
}
