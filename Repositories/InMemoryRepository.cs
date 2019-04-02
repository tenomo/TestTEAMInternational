using System;
using System.Collections.Generic;
using System.Linq;

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
            return _dataSet;
        }

        public void Delete(IComparable id)
        {
            var entity = _dataSet.FirstOrDefault(ent => ent.Id == id);
            if (entity == null)
                throw new InvalidOperationException($"The entity by id {id} was not found in the storage."); // should change to specific exception
            _dataSet.Remove(entity);
        }

        public void Save(TEntity item)
        {
            if (_dataSet.Any(entity => entity.Id == item.Id))
                throw new InvalidOperationException($"The entity by id {item.Id} is existing in the storage."); // should change to specific exception
            _dataSet.Add(item);
        }

        public TEntity FindById(IComparable id)
        {
            var entity = _dataSet.FirstOrDefault(ent => ent.Id == id);
            return entity;
        }
    }
}
