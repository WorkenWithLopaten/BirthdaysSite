using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BirthdaySite.UnitTests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class GetAllTests
    {
        [TestMethod]
        public void GetAll_ShouldCallAll_Once()
        {
            var repoMocked = new Mock<IDbRepository<User>>();
            var contextMocked = new Mock<ISaveContext>();
            var identityMocked = new Mock<IPrincipal>();
          
            var users = new List<User>();

            repoMocked.Setup(m => m.All()).Returns(users.AsQueryable());

            var service = new UserService(repoMocked.Object,
                contextMocked.Object, identityMocked.Object);

            service.GetAll();

            repoMocked.Verify(m => m.All(), Times.Once);
        }
    }
}
