using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTemplate.Data.Models;
using System;

namespace BirthdaySite.UnitTests.ModelTests
{
    [TestClass]
    public class FriendTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var friend = new Friend("test", false);

            Assert.AreEqual(friend.Name, "test");
            Assert.AreEqual(friend.Gender, false);
        }

        [TestMethod]
        public void Name_ShouldWorkCorrectly()
        {
            var friend = new Friend("test", false);

            friend.Name = "test1";

            Assert.AreEqual(friend.Name, "test1");
            Assert.AreEqual(friend.Gender, false);
        }

        [TestMethod]
        public void GenderSetter_ShouldWorkCorrectly()
        {
            var friend = new Friend("test", false);

            friend.Gender = true;

            Assert.AreEqual(friend.Name, "test");
            Assert.AreEqual(friend.Gender, true);
        }

        [TestMethod]
        public void BirthdaySetter_ShouldWorkCorrectly()
        {
            var friend = new Friend("test", false);

            var birthday = new DateTime(1994, 4, 5);

            friend.Birthday = birthday;

            Assert.AreEqual(friend.Birthday, birthday);
        }
    }
}
