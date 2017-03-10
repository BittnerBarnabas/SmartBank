using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SmartBankCore.domain.persistence.repository
{
    public class AbstractRepositoryImpl<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        public AbstractRepositoryImpl(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity FindById(TIdentity id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public virtual void DeleteById(TIdentity id)
        {
            DbContext.Set<TEntity>().Remove(FindById(id));
        }

        public virtual void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public virtual long Count()
        {
            return DbContext.Set<TEntity>().Count();
        }

        public virtual bool Exists(TIdentity id)
        {
            return FindById(id) != null;
        }

        public virtual TS Save<TS>(TS entity) where TS : TEntity
        {
            DbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual IEnumerable<TS> Save<TS>(IEnumerable<TS> entities) where TS : TEntity
        {
            throw new NotImplementedException();
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}