using AccountLedger.Core.ProjectAggregate;
using Ardalis.Specification;

namespace AccountLedger.Core.ProjectAggregate.Specifications
{
    public class AccountByIdSpec : Specification<LedgerAccount>, ISingleResultSpecification
    {
        public AccountByIdSpec(int accountId)
        {
            Query
                .Where(account => account.Id == accountId)
                 .Include(project => project.Items);

        }
    }

    public class AccountByNumberSpec : Specification<LedgerAccount>, ISingleResultSpecification
    {
        public AccountByNumberSpec(string accountNumber)
        {
            Query
                .Where(account => account.AccountNumber == accountNumber)
                 .Include(project => project.Items);

        }
    }
}
