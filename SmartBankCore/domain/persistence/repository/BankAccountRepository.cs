using System;
using System.Data.Entity;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankAccountRepository : AbstractRepositoryImpl<BankAccount, String>
    {
        public BankAccountRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}