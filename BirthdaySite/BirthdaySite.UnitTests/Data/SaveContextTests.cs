using BirthdaySite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common.SaveContext;
using System;
using System.Data.Entity;

namespace BirthdaySite.UnitTests.Data
{
    [TestClass]
    public class SaveContextTests
    {
        [TestMethod]
        public void Controller_ShouldThrowsArgumentNullException_WhenPassedParametersAreNull()
        {
            var mockedDbContext = new Mock<IApplicationDbContext>();

            //Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() 
                => new SaveContext(null));
        }

        [TestMethod]
        public void Controller_ShouldNotThrowArgumentNullException_WhenPassedParametersAreNull()
        {
            var mockedDbContext = new Mock<IApplicationDbContext>();

            //Act and Assert
            var context =  new SaveContext(mockedDbContext.Object);

            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void Commit_ShouldCallSaveChangesToDatabaseContext()
        {
            // Arrange
            var mockedDbContext = new Mock<IApplicationDbContext>();
            mockedDbContext.Setup(x => x.SaveChanges());

            var saveContext = new SaveContext(mockedDbContext.Object);

            // Act
            saveContext.Commit();

            // Assert
            mockedDbContext.Verify(dbc => dbc.SaveChanges(), Times.Once);
        }
    }
}
