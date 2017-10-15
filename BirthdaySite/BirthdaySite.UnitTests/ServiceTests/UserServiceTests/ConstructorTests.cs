using BirthdaySite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common.Repositories;
using MVCTemplate.Services.Data;
using System;

namespace BirthdaySite.UnitTests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Counstructor_ShouldInitializeCorrectly()
        {
            var repoMocked = new Mock<IUserRepository<ApplicationUser>>();

            var service = new UserService(repoMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Counstructor_ShouldThrow_IfThereIsNoRepo()
        {
            var repoMocked = new Mock<IUserRepository<ApplicationUser>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(null));
        }
    }
}
