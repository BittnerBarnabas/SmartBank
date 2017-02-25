using System.Collections.Generic;

namespace SmartBankCore.domain.persistence.repository
{
    interface IRepository<TEntity, in TId> where TEntity : class
    {
        TEntity FindById(TId id);
        IEnumerable<TEntity> FindAll();
        void DeleteById(TId id);
        void DeleteAll();
        long Count();
        bool Exists(TId id);
        TS Save<TS>(TS entity) where TS : TEntity;
        IEnumerable<TS> Save<TS>(IEnumerable<TS> entities) where TS : TEntity;

    }
}
