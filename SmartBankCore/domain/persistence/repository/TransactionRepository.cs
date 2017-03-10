using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace SmartBankCore.domain.persistence.repository
{
    public class TransactionRepository : AbstractRepositoryImpl<Transaction, string>
    {
        public TransactionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Transaction> FindTransactionsForAccountNumber(int accountNumber)
        {
            return DbContext.Set<Transaction>()
                .SqlQuery("SELECT * FROM TRANSACTIONS WHERE RECIP_ACC_NUM=@accNum OR SRC_ACC_NUM=@accNum",
                    new SqlParameter("@accNum", accountNumber)).ToList();
        }
    }
}