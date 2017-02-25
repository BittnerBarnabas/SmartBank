using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartBankCore.domain.persistence.repository
{
    public class BankUserRepository : IRepository<BankUser, String>
    {
        private readonly DbContext _dbContext;
        public BankUserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BankUser FindById(string id)
        {
            return _dbContext.Set<BankUser>().Find(id);
        }

        public IEnumerable<BankUser> FindAll()
        {
            return _dbContext.Set<BankUser>().ToList();
        }

        public void DeleteById(string id)
        {
            _dbContext.Set<BankUser>().Remove(FindById(id));
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            return _dbContext.Set<BankUser>().Count();
        }

        public bool Exists(string id)
        {
            return FindById(id) != null;
        }

        public TS Save<TS>(TS entity) where TS : BankUser
        {
            _dbContext.Set<BankUser>().Add(entity);
            return entity;
        }

        public IEnumerable<TS> Save<TS>(IEnumerable<TS> entities) where TS : BankUser
        {
            throw new NotImplementedException();
        }
    }
}