using System.Data.Entity;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankAccountRepository : AbstractRepositoryImpl<BankAccount, int>
    {
        public BankAccountRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}