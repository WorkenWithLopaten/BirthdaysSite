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
    public class GetAllFriendsTests
    {
        [TestMethod]
        public void GetAllFriends_ShouldCall_AllOnce()
        {
            var repoMocked = new Mock<IDbRepository<FriendsList>>();

            var friendLists = new List<FriendsList>();

            repoMocked.Setup(m => m.All()).Returns(friendLists.AsQueryable());

            var service = new FriendListService(repoMocked.Object);

            service.GetAllFriends("friendList");

            repoMocked.Verify(m => m.All(), Times.Once);
        }

        [TestMethod]
        public void GetAllFriends_ShouldReturnEmptyList_WhenNoFriendListFound()
        {
            var repoMocked = new Mock<IDbRepository<FriendsList>>();

            var friendLists = new List<FriendsList>();

            repoMocked.Setup(m => m.All()).Returns(friendLists.AsQueryable());

            var service = new FriendListService(repoMocked.Object);

            var friends = service.GetAllFriends("friendList");

            Assert.AreEqual(friends.Count, 0);
        }

        [TestMethod]
        public void GetAllFriends_ShouldReturnEmptyList_ShouldReturnRightAmountOfFriends()
        {
            var repoMocked = new Mock<IDbRepository<FriendsList>>();

            var friendLists = new List<FriendsList>()
            {
                new FriendsList()
                {
                    Name = "friendList",
                    Friends = new List<Friend>()
                    {
                        new Friend()
                        {
                            Name = "testUser"
                        }
                    }
                }
            };

            repoMocked.Setup(m => m.All()).Returns(friendLists.AsQueryable());

            var service = new FriendListService(repoMocked.Object);

            var friends = service.GetAllFriends("friendList");

            Assert.AreEqual(friends.Count, 1);
        }
    }
}
