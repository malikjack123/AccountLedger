using AccountLedger.SharedKernel;

namespace AccountLedger.Core.ProjectAggregate.Events
{
    public class NewLedgerAccountAddedEvent : BaseDomainEvent
    {
        public LedgerAccount Account { get; set; }

        public NewLedgerAccountAddedEvent(LedgerAccount newItem)
        {
            Account = newItem;
        }
    }
}