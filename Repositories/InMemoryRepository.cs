using System;
using System.Collections.Generic;

namespace Interview.Repositories
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IStoreable
    {
        private readonly IList<TEntity> _dataSet;

        public InMemoryRepository(IList<TEntity> dataSet)
        {
            _dataSet = dataSet ?? throw new ArgumentNullException(nameof(dataSet), "The data set cannot be null.");
        }

        public IEnumerable<TEntity> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity item)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(IComparable id)
        {
            throw new NotImplementedException();
        }
    }
}
