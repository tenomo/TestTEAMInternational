using Interview.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Interview
{
    public class InMemoryRepositoryTests
    {
        private readonly InMemoryRepository<Book> _inMemoryBookRepository;
        private IList<Book> booksList;

        public InMemoryRepositoryTests()
        {
            booksList = new List<Book>();
            _inMemoryBookRepository = new InMemoryRepository<Book>(booksList);
        }

        #region InMemoryRepository's ctor tests

        [Fact]
        public void Constructor_NullDataSet_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new InMemoryRepository<Book>(null));

        [Fact]
        public void Constructor_Successful() => new InMemoryRepository<Book>(new List<Book>());

        #endregion

        #region All method

        [Fact]
        public void All_ReturningDataSetIsNull_failed()
        {
            var entities = _inMemoryBookRepository.All();
            Assert.NotNull(entities);
        }

        [Fact]
        public void All_EmpyDataSet()
        {
            booksList = new List<Book>();
            var ntities = _inMemoryBookRepository.All();
            Assert.Empty(ntities);
        }

        [Fact]
        public void All_3Entites()
        {
            booksList = new List<Book>()
            {
                new Book(),
                new Book(),
                new Book()
            };
            var entities = _inMemoryBookRepository.All();
            Assert.Equal(booksList.Count, entities.Count());
        }

        #endregion

        #region delete method

        [Fact]
        public void Delete_EntityIsNotExisting_ThrowsArgumentNullException()
        {
            booksList = new List<Book>();
            Assert.Throws<InvalidOperationException>(() => _inMemoryBookRepository.Delete(1));
        }

        [Fact]
        public void Delete_1Entity()
        {
            booksList = new List<Book>()
            {
                new Book() {Id = 1}
            };
            _inMemoryBookRepository.Delete(1);
            Assert.Empty(booksList);
        }

        #endregion

        [Fact]
        public void Save_EntityIsExisting_ThrowsArgumentNullException()
        {
            var entity = new Book() {Id = 1};
            booksList = new List<Book>()
            {
                entity
            };
            Assert.Throws<InvalidOperationException>(() => _inMemoryBookRepository.Save(entity));
        }

        [Fact]
        public void Save_1Entity()
        {
            var entity = new Book() {Id = 1};
            booksList = new List<Book>();
            Assert.NotEmpty(booksList);
        }

        [Fact]
        public void FindById_EnttyFound()
        {
            var entity = new Book() {Id = 1};
            booksList = new List<Book>()
            {
                entity,
                new Book() {Id = 2}
            };
            var foundEntity = _inMemoryBookRepository.FindById(entity.Id);
            Assert.NotNull(foundEntity);
            Assert.Equal(entity.Id, foundEntity.Id);
        }

        [Fact]
        public void InMemoryRepository_FindById_notFound_successful()
        {
            booksList = new List<Book>()
            {
                new Book() {Id = 2}
            };
            var foundEntity = _inMemoryBookRepository.FindById(1);
            Assert.Null(foundEntity);
        }
    }
}