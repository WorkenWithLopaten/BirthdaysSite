using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Common.SaveContext;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace BirthdaySite.UnitTests.ServiceTests.GroupServiceTests
{
    [TestClass]
    public class GetAllTests
    {
        [TestMethod]
        public void GetAll_Should_CallRepoAll_Once()
        {
            var repoMocked = new Mock<IDbRepository<Group>>();
            var contextMocked = new Mock<ISaveContext>();

            var groups = new List<Group>();

            repoMocked.Setup(m => m.All()).Returns(groups.AsQueryable());

            var service = new GroupService(repoMocked.Object, contextMocked.Object);

            service.GetAll();

            repoMocked.Verify(m => m.All(), Times.Once);
        }
    }
}
