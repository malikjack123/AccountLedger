using System.Collections.Generic;

namespace AccountLedger.Web.ViewModels
{
    public class AccountViewModel
    {
        public int AccountId { get; set; }
        public string AccountTitle { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public List<ToDoItemViewModel> Items = new();
    }
}
