using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System;

namespace BirthdaySite.UnitTests.ServiceTests.GroupServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Constructor_Should_InitializeCorrectly()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            var service = new GroupService(repoMocked.Object, contextMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Constructor_Should_Throw_WhenRepoIsNull()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new GroupService(null, contextMocked.Object));           
        }

        [TestMethod]
        public void Constructor_Should_ThrowWhen_SaveContextIsNull()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new GroupService(repoMocked.Object, null));
        }
    }
}
