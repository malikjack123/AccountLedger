using AccountLedger.Core.ProjectAggregate.Events;
using AccountLedger.SharedKernel;
using AccountLedger.SharedKernel.Interfaces;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountLedger.Core.ProjectAggregate
{
    public class LedgerAccount : BaseEntity, IAggregateRoot
    {
        public string Owner { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<AccountTransaction> Items => _items.AsReadOnly();

        private List<AccountTransaction> _items = new List<AccountTransaction>();

        public decimal AvailableBalance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in Items)
                {
                    if (item.TransType == TransactionStatus.Credit)
                    {
                        balance += item.Amount;
                    }
                    else
                    {
                        balance -= item.Amount;
                    }
                }
                return balance;
            }
        }
        public LedgerAccount()
        {
        }

        public LedgerAccount(string accountNumber, string owner, decimal balance)
        {
            Owner = Guard.Against.NullOrEmpty(owner, nameof(owner));
            Balance = Guard.Against.Negative(balance, nameof(balance));
            AccountNumber = Guard.Against.NullOrEmpty(accountNumber, nameof(accountNumber));
        }

        public void MakeDeposit(AccountTransaction acct)
        {
            if (acct.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(acct.Amount), "Amount of deposit must be positive");
            }
            acct.TransType = TransactionStatus.Credit;
            _items.Add(acct);
        }

        public void MakeWithdrawal(AccountTransaction acct)
        {
            if (acct.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(acct.Amount), "Amount of withdrawal must be positive");
            }
            if (AvailableBalance - acct.Amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            acct.TransType = TransactionStatus.Debit;
            _items.Add(acct);
        }
    }
}
