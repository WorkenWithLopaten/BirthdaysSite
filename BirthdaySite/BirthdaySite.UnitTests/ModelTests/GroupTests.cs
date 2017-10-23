using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTemplate.Data.Models;

namespace BirthdaySite.UnitTests.ModelTests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            var friend = new Group("testFriendList");

            Assert.AreEqual(friend.Name, "testFriendList");
            Assert.IsNotNull(friend.Messages);
        }

        [TestMethod]
        public void Name_ShouldWorkCorrectly()
        {
            var friend = new Group("test");

            friend.Name = "test1";

            Assert.AreEqual(friend.Name, "test1");
        }
    }
}
