using System;
using System.Collections.Generic;

namespace Interview
{
    // Please create an in memory implementation of IRepository<T> 

    public interface IRepository<TEntity> where TEntity : IStoreable
    {
        IEnumerable<TEntity> All();
        void Delete(IComparable id);
        void Save(TEntity item);
        TEntity FindById(IComparable id);
    }
}
