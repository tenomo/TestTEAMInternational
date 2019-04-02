using Interview.Repositories;
using System;
using System.Collections.Generic;
using Xunit;


namespace Interview
{
    public class Tests
    {
        private readonly IRepository<Book> _inMemoryBookRepository = default(IRepository<Book>);

        [Fact]
        public void InMemoryRepository_manualyCreation_nullData_failed()
        {
            Assert.Throws<NullReferenceException>(() => new InMemoryRepository<Book>(null));
        }

        [Fact]
        public void InMemoryRepository_manualyCreation_successful()
        {
        }

        [Fact]
        public IEnumerable<Book> InMemoryRepository_All_empyDataSet_successful()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public IEnumerable<Book> InMemoryRepository_All_fiveElements_successful()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void InMemoryRepository_Delete_isNotExisting_failed()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void InMemoryRepository_Delete_successful()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void InMemoryRepository_Save_isExisting_failed()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void InMemoryRepository_Save_successful()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void InMemoryRepository_FindById_successful()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void InMemoryRepository_FindById_notFound_successful()
        {
            throw new NotImplementedException();
        }
    }
}