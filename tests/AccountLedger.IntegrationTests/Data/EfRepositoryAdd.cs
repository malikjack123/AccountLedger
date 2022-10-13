using AccountLedger.Core.ProjectAggregate;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AccountLedger.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsProjectAndSetsId()
        {
            var repository = GetRepository();
            var newAccount = new LedgerAccount("ACT:123456789", "Usama", 500);
            var createdAccount = await repository.AddAsync(newAccount);
            Assert.Equal(newAccount.AccountNumber, createdAccount.AccountNumber);
            Assert.True(createdAccount?.Id > 0);

        }
    }
}
