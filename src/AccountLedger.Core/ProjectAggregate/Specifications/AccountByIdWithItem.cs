using AccountLedger.Core.ProjectAggregate;
using Ardalis.Specification;

namespace AccountLedger.Core.ProjectAggregate.Specifications
{
    public class AccountByIdWithItem : Specification<Account>, ISingleResultSpecification
    {
        public AccountByIdWithItem(int accountId)
        {
            Query
                .Where(account => account.Id == accountId)
                .Include(project => project.Items);

        }
    }
}
