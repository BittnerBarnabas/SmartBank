using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SmartBankCore.domain.persistence.repository
{
    public class AbstractRepositoryImpl<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public AbstractRepositoryImpl(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity FindById(TIdentity id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void DeleteById(TIdentity id)
        {
            _dbContext.Set<TEntity>().Remove(FindById(id));
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        public bool Exists(TIdentity id)
        {
            return FindById(id) != null;
        }

        public TS Save<TS>(TS entity) where TS : TEntity
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public IEnumerable<TS> Save<TS>(IEnumerable<TS> entities) where TS : TEntity
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}