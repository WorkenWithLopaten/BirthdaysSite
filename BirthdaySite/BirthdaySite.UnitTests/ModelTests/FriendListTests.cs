using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTemplate.Data.Models;
using System;

namespace BirthdaySite.UnitTests.ModelTests
{
    [TestClass]
    public class FriendListTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var friend = new FriendsList("testFriendList");

            Assert.AreEqual(friend.Name, "testFriendList");
            Assert.IsNotNull(friend.Friends);
        }

        [TestMethod]
        public void Name_ShouldWorkCorrectly()
        {
            var friend = new FriendsList("test");

            friend.Name = "test1";

            Assert.AreEqual(friend.Name, "test1");
        }
    }
}
