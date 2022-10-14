using AccountLedger.Core.ProjectAggregate.Events;
using AccountLedger.SharedKernel;
using AccountLedger.SharedKernel.Interfaces;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountLedger.Core.ProjectAggregate
{
    public class AccountTransaction : BaseEntity, IAggregateRoot
    {
        public string AccountNumber { get; set; }
        public TransactionStatus TransType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransDate { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }

        private LedgerAccount _inverseAccount = new LedgerAccount();
        public LedgerAccount InverseAccount => _inverseAccount;

        private List<AccountTransaction> _items = new List<AccountTransaction>();

        public AccountTransaction(string notes, decimal amount, string accountNumber)
        {
            Notes = notes;//  Guard.Against.NullOrEmpty(notes, nameof(notes));
            AccountNumber = Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
            Amount = Guard.Against.Negative(amount, nameof(amount));
        }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in InverseAccount.Items)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        public void MakeDeposit()
        {
            if (Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Amount), "Amount of deposit must be positive");
            }
            this.TransType = TransactionStatus.Credit;
            _items.Add(this);
        }

        public void MakeWithdrawal()
        {
            if (Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Amount), "Amount of withdrawal must be positive");
            }
            if (Balance - Amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            this.TransType = TransactionStatus.Debit;
            _items.Add(this);
        }
    }
}
