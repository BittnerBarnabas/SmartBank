using System.Collections.Generic;

namespace SmartBankCore.domain.persistence.repository
{
    public interface ITransactionRepository<TEntity, in TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        ICollection<Transaction> FindTransactionsForAccountNumber(int accountNumber);
    }
}