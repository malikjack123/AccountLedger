using AccountLedger.Core.ProjectAggregate.Events;
using AccountLedger.SharedKernel;
using AccountLedger.SharedKernel.Interfaces;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace AccountLedger.Core.ProjectAggregate
{
    public class Account : BaseEntity, IAggregateRoot
    {
        public string AccountName { get; set; }

        private List<ToDoItem> _items = new List<ToDoItem>();
        public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
        public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

        //public Account(string name)
        //{
        //    AccountName = Guard.Against.NullOrEmpty(name, nameof(name));
        //}

        public void AddItem(ToDoItem newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewAccountAddedEvent(this, newItem);
            Events.Add(newItemAddedEvent);
        }

        public void UpdateName(string newName)
        {
            AccountName = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
    }
}
