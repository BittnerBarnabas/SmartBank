using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SmartBankCore.domain.persistence.repository
{
    public class TransactionRepository : AbstractRepositoryImpl<Transaction, string>,
        ITransactionRepository<Transaction, string>
    {
        public TransactionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Transaction> FindTransactionsForAccountNumber(int accountNumber)
        {
            return
                FindAll()
                    .Select(e => e)
                    .Where(
                        e =>
                            e.RecipientAccountNumber.Equals(accountNumber) ||
                            e.SourceAccountNumber.Equals(accountNumber))
                    .ToList();
        }
    }
}