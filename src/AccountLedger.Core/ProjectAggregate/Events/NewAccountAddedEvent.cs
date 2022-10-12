using AccountLedger.SharedKernel;

namespace AccountLedger.Core.ProjectAggregate.Events
{
    public class NewAccountAddedEvent : BaseDomainEvent
    {
        public ToDoItem NewItem { get; set; }
        public Account Account { get; set; }

        public NewAccountAddedEvent(Account project,
            ToDoItem newItem)
        {
            Account = project;
            NewItem = newItem;
        }
    }
}