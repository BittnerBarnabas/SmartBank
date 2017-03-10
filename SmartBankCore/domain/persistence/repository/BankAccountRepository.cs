using System.Data.Entity;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankAccountRepository : AbstractRepositoryImpl<BankAccount, string>
    {
        public BankAccountRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}