using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace BirthdaySite.UnitTests.ServiceTests.FriendListsTests
{
    [TestClass]
    public class GetAllTests
    {
        [TestMethod]
        public void GetAll_Should_CallRepoAll_Once()
        {
            var repoMocked = new Mock<IDbRepository<FriendsList>>();

            var friendLists = new List<FriendsList>();

            repoMocked.Setup(m => m.All()).Returns(friendLists.AsQueryable());

            var service = new FriendListService(repoMocked.Object);

            service.GetAll();

            repoMocked.Verify(m => m.All(), Times.Once);
        }
    }
}
