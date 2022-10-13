using System;
using System.Collections.Generic;

namespace AccountLedger.Web.ApiModels
{
    // ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
    public class LedgerAccountDTO
    {
        public int Id { get; set; }
        public string Owner { get; set; } = "Test Owner";
        public string AccountNumber { get; set; } = "Test Account";
        public decimal Balance { get; set; } = 0.0m;

        public List<AccountTransactionDTO> Items = new();
    }

    public class AccountTransactionDTO
    {
        public string AccountNumber { get; set; }
        public string TransType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransDate { get; set; }  
        public string Notes { get; set; }
    }

}
