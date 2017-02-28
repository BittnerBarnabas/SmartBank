using System;
using System.Data.Entity;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankUserRepository : AbstractRepositoryImpl<BankUser, String>
    {
        public BankUserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}