using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BirthdaySite.UnitTests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class UpdateTests
    {
        [TestMethod]
        public void Update_Should_CallUpdate_Once()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            var user = new User()
            {
                Email = "test"
            };

            var users = new List<User>()
            {
                 user
            };


            repoMocked.Setup(m => m.All())
                .Returns(users.AsQueryable());

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            service.Update("test");

            repoMocked.Verify(m => m.Update(user), Times.Once);
        }

        [TestMethod]
        public void Update_ShouldCall_Commit_Once()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            var user = new User()
            {
                Email = "test"
            };

            var users = new List<User>()
            {
                 user
            };


            repoMocked.Setup(m => m.All())
                .Returns(users.AsQueryable());

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            service.Update("test");

            contextMocked.Verify(m => m.Commit(), Times.Once);
        }

        [TestMethod]
        public void Update_Should_ThrowWhenUserIsNotFound()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            var users = new List<User>()
            {

            };


            repoMocked.Setup(m => m.All())
                .Returns(users.AsQueryable());

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            Assert.ThrowsException<ArgumentNullException>(()
                => service.Update("test"));
        }

        [TestMethod]
        public void Update_Should_UpdateNewUser()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            var user = new User()
            {
                Email = "testUser",
                UserName = "testUser"
            };

            var users = new List<User>()
            {
                 user
            };


            repoMocked.Setup(m => m.All())
                .Returns(users.AsQueryable());

            identityMocked.Setup(m => m.Identity.Name).Returns("testUser");

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            service.Update("updateTest");

            Assert.AreEqual(user.UserName, "updateTest");
            Assert.AreEqual(user.Email, "updateTest");
        }

        [TestMethod]
        public void Update_ShouldCall_All()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();

            var user = new User()
            {
                Email = "test"
            };

            var users = new List<User>()
            {
                 user
            };


            repoMocked.Setup(m => m.All())
                .Returns(users.AsQueryable());

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            service.Update("test");

            repoMocked.Verify(m => m.All(), Times.Once);
        }
    }
}
