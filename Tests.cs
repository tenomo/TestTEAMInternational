using Interview.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Interview
{
    public class InMemoryRepositoryTests
    {
        #region InMemoryRepository's ctor tests

        [Fact]
        public void Constructor_NullDataSet_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new InMemoryRepository<Book>(null));

        [Fact]
        public void Constructor_Successful() => new InMemoryRepository<Book>(new List<Book>());

        #endregion

        #region All method

        [Fact]
        public void All_ReturningCollectionIsNotNull()
        {
            var booksList = new List<Book>();
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            var entities = inMemoryBookRepository.All();
            Assert.NotNull(entities);
        }

        [Fact]
        public void All_EmpyDataSet()
        {
            var booksList = new List<Book>();
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            var ntities = inMemoryBookRepository.All();
            Assert.Empty(ntities);
        }

        [Fact]
        public void All_3Entites()
        {
            var booksList = new List<Book>()
            {
                new Book(),
                new Book(),
                new Book()
            };
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            var entities = inMemoryBookRepository.All();
            Assert.Equal(booksList.Count, entities.Count());
        }

        #endregion

        #region delete method

        [Fact]
        public void Delete_EntityIsNotExisting_ThrowsArgumentNullException()
        {
            var booksList = new List<Book>();
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            Assert.Throws<InvalidOperationException>(() => inMemoryBookRepository.Delete(1));
        }

        [Fact]
        public void Delete_1Entity()
        {
            var entity = new Book() { Id = 1 };
            var booksList = new List<Book>()
            {
                entity
            };
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            inMemoryBookRepository.Delete(entity.Id);
            Assert.Empty(booksList);
        }

        #endregion

        #region Save method

        [Fact]
        public void Save_EntityIsExisting_ThrowsArgumentNullException()
        {
            var entity = new Book() { Id = 1 };
            var booksList = new List<Book>()
            {
                entity
            };
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            Assert.Throws<InvalidOperationException>(() => inMemoryBookRepository.Save(entity));
        }

        [Fact]
        public void Save_1Entity()
        {
            var entity = new Book() { Id = 1 };
            var booksList = new List<Book>();
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            inMemoryBookRepository.Save(entity);
            Assert.NotEmpty(booksList);
        }

        #endregion

        #region FindById method

        [Fact]
        public void FindById_EnttyFound()
        {
            var entity = new Book() { Id = 1 };
            var booksList = new List<Book>()
            {
                entity,
                new Book() {Id = 2}
            };
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            var foundEntity = inMemoryBookRepository.FindById(entity.Id);
            Assert.NotNull(foundEntity);
            Assert.Equal(entity.Id, foundEntity.Id);
        }

        [Fact]
        public void InMemoryRepository_FindById_notFound_successful()
        {
            var booksList = new List<Book>()
            {
                new Book() {Id = 2}
            };
            var inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
            var foundEntity = inMemoryBookRepository.FindById(1);
            Assert.Null(foundEntity);
        }

        #endregion
    }
}