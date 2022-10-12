using System.Collections.Generic;

namespace AccountLedger.Web.ApiModels
{
    // ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
    public class AccountDTO : CreateProjectDTO
    {
        public int Id { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public List<ToDoItemDTO> Items = new();
    }

}
