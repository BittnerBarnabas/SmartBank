using System.Data.Entity;
using System.Linq;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankUserRepository : AbstractRepositoryImpl<BankUser, string>
    {
        public BankUserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        ///     Finds a user by it's id and loads it's BankAccounts.
        /// </summary>
        /// <param name="id">user's username</param>
        /// <returns>The BankUser object if it's present, null otherwise</returns>
        public override BankUser FindById(string id)
        {
            return DbContext.Set<BankUser>().Include(e => e.BankAccounts).FirstOrDefault(e => e.Username.Equals(id));
        }
    }
}