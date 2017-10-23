using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.Models;
using MVCTemplate.Data.Models;
using System.Data.Entity.Infrastructure;

namespace BirthdaySite.UnitTests.Data
{
    [TestClass]
    public class DbRepositoryTests
    {
        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class, IDeletableEntity
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }

        [TestMethod]
        public void Controller_ShouldThrowsArgumentNullException_WhenPassedParametersAreNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                        new DbRepository<User>(null));
        }

        [TestMethod]
        public void Controller_ShouldInitialise_WithoutProblems()
        {
            var mockedDbContext = new Mock<DbContext>();
            var repo = new DbRepository<User>(mockedDbContext.Object);
        }

        [TestMethod]
        public void All_ShouldReturnsNotDeletedObjects_IfValid()
        {
            // Arrange
            var notDeletedUser = new User { IsDeleted = false };
            var DeletedUser = new User { IsDeleted = true };

            var users = new List<User>()
            {
                notDeletedUser,
                DeletedUser
            };

            var usersDbSet = GetQueryableMockDbSet(users);

            var mockedContext = new Mock<DbContext>();
            mockedContext.Setup(c => c.Set<User>()).Returns(usersDbSet);

            var repository = new DbRepository<User>(mockedContext.Object);

            // Act
            var result = repository.All();

            // Assert
            Assert.AreEqual(1, result.ToList().Count);
        }

        [TestMethod]
        public void All_ShouldReturnsAllObjects_IfValid()
        {
            // Arrange
            var notDeletedUser = new User { IsDeleted = false };
            var DeletedUser = new User { IsDeleted = true };

            var users = new List<User>()
            {
                notDeletedUser,
                DeletedUser
            };

            var usersDbSet = GetQueryableMockDbSet(users);

            var mockedContext = new Mock<DbContext>();
            mockedContext.Setup(c => c.Set<User>()).Returns(usersDbSet);

            var repository = new DbRepository<User>(mockedContext.Object);

            // Act
            var result = repository.AllWithDeleted();

            // Assert
            Assert.AreEqual(2, result.ToList().Count);
        }

        [TestMethod]
        public void Add_ShouldWork_Correctly()
        {
            // Arrange
            var notDeletedUser = new User
            {
                UserName = "test",
                Email = "test",
                IsDeleted = false
            };

            var users = new List<User>()
            {

            };

            var usersDbSet = GetQueryableMockDbSet(users);

            var mockedContext = new Mock<DbContext>();
            mockedContext.Setup(c => c.Set<User>()).Returns(usersDbSet);
            //mockedContext.Setup(c => c.Entry(notDeletedUser));

            var repository = new DbRepository<User>(mockedContext.Object);

            //repository.Add(notDeletedUser);
        }
    }
}

