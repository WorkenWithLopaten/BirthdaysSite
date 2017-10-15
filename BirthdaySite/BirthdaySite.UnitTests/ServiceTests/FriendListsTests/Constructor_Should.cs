using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Models;
using MVCTemplate.Services.Data;
using System;

namespace BirthdaySite.UnitTests.ServiceTests.FriendListsTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Constructor_ShouldInitialize_Correctly()
        {
            var repoMocked = new Mock<IDbRepository<FriendsList>>();

            var service = new FriendListService(repoMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenArgumentIsNull()
        {
            var repoMocked = new Mock<IDbRepository<FriendsList>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new FriendListService(null));
        }
    }
}
