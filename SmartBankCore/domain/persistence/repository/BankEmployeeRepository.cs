using System.Data.Entity;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankEmployeeRepository : AbstractRepositoryImpl<BankEmployee, string>
    {
        public BankEmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}