using BirthdaySite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common.Repositories;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace BirthdaySite.UnitTests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class GetAllTests
    {
        [TestMethod]
        public void GetAll_ShouldCallAll_Once()
        {
            var repoMocked = new Mock<IUserRepository<ApplicationUser>>();

            var users = new List<ApplicationUser>();

            repoMocked.Setup(m => m.All()).Returns(users.AsQueryable());

            var service = new UserService(repoMocked.Object);

            service.GetAll();

            repoMocked.Verify(m => m.All(), Times.Once);
        }
    }
}
