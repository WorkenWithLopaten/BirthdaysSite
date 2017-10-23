using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System;
using System.Security.Principal;

namespace BirthdaySite.UnitTests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Counstructor_ShouldInitializeCorrectly()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Counstructor_ShouldThrow_IfThereIsNoRepo()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(null,
                contextMocked.Object, identityMocked.Object));
        }

        [TestMethod]
        public void Counstructor_ShouldThrow_IfThereIsContext()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(repoMocked.Object,
                null, identityMocked.Object));
        }

        [TestMethod]
        public void Counstructor_ShouldThrow_IfThereIsNoIdentity()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(repoMocked.Object,
                contextMocked.Object, null));
        }
    }
}
