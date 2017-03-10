using System.Data.Entity;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankUserRepository : AbstractRepositoryImpl<BankUser, string>
    {
        public BankUserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}